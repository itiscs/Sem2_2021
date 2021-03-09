using System;

namespace DelegApp
{
    public class ArOper
    {
        public static int Sum(int a, int b)
        {
            return a + b;
        }
        public static int Minus(int a, int b)
        {
            return a - b;
        }
        public static int Mult(int a, int b)
        {
            return a * b;
        }
        public static int Div(int a, int b)
        {
            return a / b;
        }

        public static double SumDouble(double x, double y)
        {
            return x + y;
        }

        public static void Print2()          
            {
                Console.WriteLine("Hello 2");
            }
        public static void Print3()
        {
            Console.WriteLine("Hello 3");
        }
    }



    class Program
    {
        delegate int Oper(int x, int y); //сигнатура метода
        delegate void PrintMessage();


        static int VarOperArray(int[] mas, int init, Oper op)
        {
            int res = init;
            for (int i = 0; i < mas.Length; i++)
                res = op(res, mas[i]);

            return res;
        }



        static void Main(string[] args)
        {
            int k = 32, l = 200;

            Oper oper = new Oper(ArOper.Sum);
            PrintMessage print = new PrintMessage(() => { Console.WriteLine("Hello 1"); });

            print();


            print += () => {Console.WriteLine("Hello 4");};

            print += ArOper.Print2;
            print += ArOper.Print3;
            print += ArOper.Print3;
            print -= ArOper.Print3;

            if(print != null)
                print.Invoke();
            

            Console.WriteLine($" {k} + {l} = {oper(k,l)} ");

            oper = ArOper.Minus;
            

            Console.WriteLine($" {k} - {l} = {oper(k, l)} ");

            oper = (a,b) => a > b? a : b;

            Console.WriteLine($" {k} max {l} = {oper(k, l)} ");


            oper = ArOper.Mult;





            var N = 5;
            var a = new int[N];
            var r = new Random();
            for (int i = 0; i < N; i++)
                a[i] = r.Next(1,10);

            Console.WriteLine($"{VarOperArray(a, 1, (a,b) => a*b )}");




        }
    }
}
