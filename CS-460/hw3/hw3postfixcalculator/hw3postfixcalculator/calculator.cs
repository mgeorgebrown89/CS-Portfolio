using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3postfixcalculator
{
    /*This is a post-fix calculator run through command line.
     * It asks user for input and returns the result. 
     *     
     */

    class Calculator
    {
        //globals
        private LinkedStack stack = new LinkedStack();


        //entry point. 
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            bool playAgain = true;
            Console.WriteLine("\nPostfix calculator. Recognizes these operators: + - * /");
            while (playAgain)
            {
                playAgain = calc.Calculate();
            }
            Console.WriteLine("So long, farewell, auf Wiedersehen, good night!");
        }

        //takes input and begins calculation
        private bool Calculate()
        {
            Console.WriteLine("Enter \"q\" to quit.\n");
            string input = "2 2 + ";
            Console.WriteLine("> "); //prompt for user
            input = Console.ReadLine();

            if (input.StartsWith("q") || input.StartsWith("Q"))
            {
                return false;
            }

            string output = "4";
            try
            {
                output = EvaluatePostFixInput(input);
                Console.WriteLine("Evaluating PostFix Input");
            }
            catch (ArgumentException e)
            {
                output = e.Message;
            }
            Console.WriteLine("\n>>> " + input + " = " + output);
            return true;
        }

        /*
         * 
         */
         public string EvaluatePostFixInput(string input)
        {
            if (input == null || input == "")
            {
                throw new ArgumentException("Null.");
            }
            //clear stack before calculation
            stack.Clear();

            string token; //operator
            double a; //first value
            double b; //temporary value 
            double c; // second value
            double answer = 0.0; // accumulator

            string[] inputs = input.Split(' ');// creates an array of each part of the input from user

            for (int i = 0; i <=inputs.Length - 1; i++)
            {
                if (double.TryParse(inputs[i], out b))
                {
                    stack.Push(b);
                }
                else
                {
                    if (stack.Empty)
                    {
                        throw new ArgumentException("Input error.");
                    }
                    else if (inputs[i].Length > 1)
                    {
                        throw new ArgumentException("Input error. ");
                    }
                    else
                    {
                        Node node1 = (Node)stack.Pop();

                        Node node2 = (Node)stack.Pop();
                        //operand 1
                        a = (double)node1.Data;
                        //operand 2
                        c = (double)node2.Data;
                        //operator
                        token = inputs[i];
                        answer = Operate(token, a, c);
                        stack.Push(answer);
                    }
                }
            }
            return Convert.ToString(answer);
        }
        public double Operate(string token, double t, double o)
        {
            //i should probably do this a switch statement, but...
            double output = 0;
            if (token == "+")
            {
                output = t + o;
            }
            else if (token == "-")
            {
                output = (o - t);
            }
            else if (token == "*")
            {
                output = t * o;
            }
            else if (token == "/")
            {
                try
                {
                    output = (o / t);
                    if (output == Double.NegativeInfinity || output == Double.PositiveInfinity)
                    {
                        throw new ArgumentException("Can't divide by 0!");
                    }
                }
                catch (ArithmeticException e)
                {
                    throw new ArgumentException(e.ToString());
                }
            }
            else
            {
                throw new ArgumentException("Operator not recognized.");
            }
            return output;
        }
    }
}
