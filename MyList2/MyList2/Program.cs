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

            MyList lst = new MyList();


            lst.AddLast(100);


            Console.WriteLine(lst);

           // lst.DeleteByIndex(0);

            Console.WriteLine(lst);

            

            for (int i = 1; i <= 10; i++)
            {
                lst.AddLast(i);
            }

            lst.DeleteByIndex(0);

            Console.WriteLine(lst);
        }
    }
}
