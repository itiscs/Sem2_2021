using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp
{




class Program
{
    static void Main(string[] args)
    {
        try
        {

            BankAcc acc1 = new BankAcc("Ivanov", 100);

        acc1.Notify += Listener1;
        acc1.Notify += Listener2;
        acc1.Notify -= Listener2;

        acc1.Put(100);
        acc1.Take(50);
        acc1.Take(250);

        BankAcc acc2 = new BankAcc("Petrov", 1000);

        acc2.Notify += Listener1;
        acc2.Put(100);
        acc2.Take(150);
        acc2.Take(250);


        PowerStation ps2 = new PowerStation("Station 2", 100, 1000);
        ps2.Boom += FireFighters.Work;
        ps2.Boom += Ambulance.Work;
        ps2.Boom += Police.Work;


            for (int i = 0; i < 20; i++)
            {
                ps2.TempUp();
                Console.WriteLine(ps2);
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }



    }


    public static void Listener1(string mes)
    {
        Console.WriteLine(mes);
    }

    public static void Listener2(string mes)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(mes);
        Console.ForegroundColor = ConsoleColor.Black;

    }





}
}
