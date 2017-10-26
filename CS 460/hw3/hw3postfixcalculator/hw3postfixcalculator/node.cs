using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3postfixcalculator
{
    //used for generics
    class Node
    {
        //globals
        object data;
        Node next;

        //default
        public Node()
        {
            data = null;
            next = null; 
        }

        //input object for data, node for point to next element
        public Node(object newData, Node newNext)
        {
            data = newData;
            next = newNext;
        }

        public object Data { get { return data; } set { data = value; } }

        public Node Next { get { return next; } set { next = value; } }
    }
}
