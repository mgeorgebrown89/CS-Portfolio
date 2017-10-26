using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3postfixcalculator
{
    class LinkedStack : IStackADT
    {
        //globals
        private Node top;
        //public bool Empty;

        //constructor
        public LinkedStack()
        {
            top = null;
        }

        public object Pop()
        {
            if (Empty)
            {
                return null;
            }
            object topNode = top;
            top = top.Next;
            return topNode;
        }

        public object Peek => Empty ? null : top.Data;//null if empty

        public void Clear()
        {
            top = null;
        }

       public bool Empty => top == null;

        public object Push(object newN)
        {
            if (newN == null)
            {
                return null;
            }
            Node newNode = new Node(newN, top);
            top = newNode;
            return newN;
        }
    }
}
