using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqApp
{

    class Program
    {
        public delegate int MyDeleg(int a, int b);



        static void Main(string[] args)
        {
            Func<int, int, int> f1 = new Func<int, int, int>((a, b) => a + b);
            Action<int> act = new Action<int>(x => { Console.WriteLine(x); });

            f1 = (a, b) => a - b;

            var lst = new List<int>() { 100, 4, 6, 7, 48, 43, 2, 5, 1, 3, 2, 2 };
            var lst1 = lst.Distinct().Where(x => x < 10).Skip(3).OrderBy(x => x % 3);


            foreach (var k in lst1)
            {
                Console.WriteLine(k);
            }

            var arr = new int[100];
            for(int i=0;i<100;i++)
            {
                arr[i] = i+1;
            }

            int k1 = 24;
            IEnumerable<int> t;
            if (k1 < 10)
                t = arr.Where(x => x % 10 == k1);
            else if (k1 < 21)
                t = arr.Where(x => x % 11 == k1 - 10);
            else
                t = arr.Where(x => (101 - x) % 11 == k1 - 20);

            Console.WriteLine("Номера задач ");
            
            foreach(int num in t)
            {
                Console.WriteLine(num);
            }



            Console.WriteLine("Hello World!");

            Console.WriteLine(lst.Where(x => x < 10).Skip(3).Average());
        }
    }
}
