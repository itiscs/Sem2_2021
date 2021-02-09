using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList lst = new MyList();


            lst.AddLast(100);

            for(int i=1; i<=10; i++)
            {
                lst.AddLast(i);
            }


            Console.WriteLine(lst);


        }
    }
}
