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
        //private LinkedStack stack = new LinkedStack();


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
            if (input == null || input.Contains(" "))
            {
                throw new ArgumentException("Null or only whitespace entered.");
            }
            //clear stack before calculation
            //stack.Clear();

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
                    //stack.Push(b);
                }
                else
                {
                    if ()
                }
            }
        }
    }
}
