using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList2
{
    class Program
    {

        
        static void Main(string[] args)
        {
            Queue<int> q = new Queue<int>();
            q.Dequeue();
            

            Stack<MyClass> st = new Stack<MyClass>();
            
            

            MyList<string> lst = new MyList<string>();

            MyList<double> lst1 = new MyList<double>();

            MyList<MyClass> lst2 = new MyList<MyClass>();


            lst2.AddLast(new MyClass(1, 1));

            lst2.AddLast(new MyClass(2, 1));
            lst2.AddLast(new MyClass(2, 20));
            lst2.AddLast(new MyClass(1, 5));
            lst2.AddLast(new MyClass(1, 10));
            lst2.AddLast(new MyClass(11, 11));

            Console.WriteLine(lst2);
            Console.WriteLine(lst2.IsSorted());


            lst.AddLast("first");


            Console.WriteLine(lst);

           // lst.DeleteByIndex(0);

            Console.WriteLine(lst);

            

            for (int i = 1; i <= 10; i++)
            {
                lst.AddLast(Convert.ToChar(Convert.ToInt32('A')+i-1).ToString());
                lst1.AddFirst(Convert.ToDouble(20-i)/7);
            }

            lst.DeleteByIndex(0);

            Console.WriteLine(lst);
            Console.WriteLine(lst.IsSorted());

            Console.WriteLine(lst1);
            Console.WriteLine(lst1.IsSorted());

        }
    }
}
