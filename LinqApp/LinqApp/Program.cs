using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqApp
{
    public class Student
    {
        public int IdStudent { get; set; }
        public string FIO{ get; set; }
        public List<int> Marks { get; set; } = new List<int>();
    }



    public class Fitness
    {
        public int ClientId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Duration { get; set; }

        public override string ToString()
        {
            return $"Client - {ClientId} Year- {Year} Month - {Month} Duration - {Duration}";
        }

        public static List<Fitness> CreateList()
        {
            var lst = new List<Fitness>();
            lst.Add(new Fitness() { ClientId = 1, Year = 2020, Month = 1, Duration = 10 });
            lst.Add(new Fitness() { ClientId = 1, Year = 2020, Month = 2, Duration = 23 });
            lst.Add(new Fitness() { ClientId = 1, Year = 2020, Month = 3, Duration = 14 });
            lst.Add(new Fitness() { ClientId = 3, Year = 2020, Month = 12, Duration = 8 });
            lst.Add(new Fitness() { ClientId = 3, Year = 2021, Month = 11, Duration = 12 });
            lst.Add(new Fitness() { ClientId = 4, Year = 2020, Month = 10, Duration = 13 });
            lst.Add(new Fitness() { ClientId = 4, Year = 2021, Month = 9, Duration = 30 });
            lst.Add(new Fitness() { ClientId = 2, Year = 2021, Month = 1, Duration = 5 });
            lst.Add(new Fitness() { ClientId = 2, Year = 2020, Month = 3, Duration = 8 });
            lst.Add(new Fitness() { ClientId = 2, Year = 2020, Month = 4, Duration = 7 });


            return lst;

        }


    }

    class Program
    {
        public delegate int MyDeleg(int a, int b);

        static void Main(string[] args)
        {
            //TestLinqWithListOfInt();

            //TestFitness();

            TestSelectMany();


            var prods = Product.GenerateData();
            var prices = Prices.GenerateData();

            foreach (var p in prods)
                Console.WriteLine(p);


            foreach (var pr in prices)
                Console.WriteLine(pr);

            //var lst = prods.Join(prices, p => p.IdProduct, pr => pr.IdProduct,
            //    (prod, price) => new
            //    {
            //        prod.IdProduct,
            //        price.Shop,
            //        prod.Category,
            //        prod.Country,
            //        price.Price
            //    });

            var lst = prods.Join(prices, p => p.IdProduct, pr => pr.IdProduct,
                (prod, price) => new
                {
                    prod.IdProduct,
                    price.Shop,
                    prod.Category,
                    prod.Country,
                    price.Price
                }).GroupBy(a => new { a.Shop, a.Category })
                .Select(g => new { g.Key.Shop, g.Key.Category, Count =  g.Count()})
                .OrderBy(s=>s.Shop).ThenBy(s=>s.Category);

            foreach (var l in lst)
            {
                Console.WriteLine(l);
            }




        }

        static void TestFitness()
        {
            var lst = Fitness.CreateList();
            lst.ForEach(f => { Console.WriteLine(f); });
            Console.WriteLine("***************************");

            //   var res = lst.Where(f => f.Year == 2020).Select(f => new { Id = f.ClientId, f.Duration });
            //.TakeWhile(f=>f.Month!=4);

            var f1 = lst.FirstOrDefault(f => f.Duration > 50);
            if (f1 != null)
                Console.WriteLine($"first - {f1}");
            else
                Console.WriteLine($"first - null");

            var res1 = lst.GroupBy(f => f.ClientId).Select(gr => new { Sum = gr.Sum(f => f.Duration), Id = gr.Key })
                        .OrderByDescending(f => f.Sum).ThenBy(f => f.Id);
            var res = lst.GroupBy(f => new { f.ClientId, f.Year });

            foreach (var gr in res)
            // Console.WriteLine($"Client - {fit.Key}  {fit.Where(f=>f.Year==2020).Count()} ");
            {
                Console.WriteLine($"Client - {gr.Key}  {gr.Sum(f => f.Duration)}:");
                foreach (var fit in gr)
                    Console.WriteLine($"      {fit} ");
            }

            foreach (var f in res1)
                Console.WriteLine(f);


        }


        static void TestSelectMany()
        {
            var studs = new List<Student>();
            studs.Add(new Student()
               { IdStudent=1, FIO="Ivanov", Marks={4,3,2,5,4,3,4,3});
            studs.Add(new Student()
               { IdStudent = 2, FIO = "Petrov", Marks = { 3, 3, 3, 5, 3, 3, 3, 3 });


            foreach (var m in studs.SelectMany(s => s.Marks))
                Console.WriteLine(m);            


            
        }

        static void TestLinqWithListOfInt()
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
            for (int i = 0; i < 100; i++)
            {
                arr[i] = i + 1;
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

            foreach (int num in t)
            {
                Console.WriteLine(num);
            }



            Console.WriteLine("Hello World!");

            Console.WriteLine(lst.Where(x => x < 10).Skip(3).Average());
        }


        
    }
}
