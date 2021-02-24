using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackApp
{
    class Program
    {
        static void SafePop(MyQueue st)
        {
            if (!st.IsEmpty())
                Console.WriteLine(st.Pop());
            else
                Console.WriteLine("Queue is empty");           

        }


        static void Main(string[] args)
        {
            
            //var st = new MyStack();

            //st.Push(5);
            //st.Push(2);
            //st.Push(3);
            //st.Push(6);
            //if(!st.IsEmpty())
            //    Console.WriteLine(st.Pop());
            //st.Push(15);
            //st.Push(25);


            //Console.WriteLine(st);

            //SafePop(st);
            //SafePop(st); 
            //SafePop(st); 
            //SafePop(st);
            //SafePop(st);
            //SafePop(st);
            //SafePop(st);
            //SafePop(st);
            //SafePop(st);


            var st = new MyQueue();

            st.Push(5);
            st.Push(2);
            st.Push(3);
            st.Push(6);
            if (!st.IsEmpty())
                Console.WriteLine(st.Pop());
            st.Push(15);
            st.Push(25);


            Console.WriteLine(st);

            SafePop(st);
            SafePop(st);
            SafePop(st);
            SafePop(st);
            SafePop(st);
            SafePop(st);
            SafePop(st);
            SafePop(st);
            SafePop(st);




        }
    }
}
