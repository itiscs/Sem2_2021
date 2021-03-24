using System;
using System.Collections.Generic;
using System.Text;

namespace LinqApp
{
    public class Product
    {
        public int IdProduct { get; set; }

        public string Category { get; set; }

        public string Country { get; set; }

        public override string ToString()
        {
            return $"Product - {IdProduct} {Category} {Country}";
        }


        public static List<Product> GenerateData()
        {
            var lst = new List<Product>();
            lst.Add(new Product()
            {
                IdProduct = 101,
                Category = "A",
                Country = "Canada"
            });
            lst.Add(new Product()
            {
                IdProduct = 102,
                Category = "A",
                Country = "Russia"
            });
            lst.Add(new Product()
            {
                IdProduct = 103,
                Category = "B",
                Country = "Russia"
            });
            lst.Add(new Product()
            {
                IdProduct = 104,
                Category = "A",
                Country = "China"
            });
            lst.Add(new Product()
            {
                IdProduct = 105,
                Category = "B",
                Country = "China"

            });
            lst.Add(new Product()
            {
                IdProduct = 106,
                Category = "B",
                Country = "China"
            });
            lst.Add(new Product()
            {
                IdProduct = 107,
                Category = "C",
                Country = "China"
            });

            return lst;
        }

    }

    public class Prices
    {
        public string Shop { get; set; }
        public int IdProduct { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return $"Price - {IdProduct} {Shop} {Price}";
        }

        public static List<Prices> GenerateData()
        {
            var lst = new List<Prices>();

            lst.Add(new Prices()
            {
                IdProduct = 101,
                Shop = "Ашан",
                Price = 100
            });
            lst.Add(new Prices()
            {
                IdProduct = 102,
                Shop = "Магнит",
                Price = 10
            });
            lst.Add(new Prices()
            {
                IdProduct = 104,
                Shop = "Магнит",
                Price = 20
            });
            lst.Add(new Prices()
            {
                IdProduct = 105,
                Shop = "Пятерочка",
                Price = 40
            });
            lst.Add(new Prices()
            {
                IdProduct = 104,
                Shop = "Пятерочка",
                Price = 50
            });
            lst.Add(new Prices()
            {
                IdProduct = 102,
                Shop = "Магнит",
                Price = 300
            });
            lst.Add(new Prices()
            {
                IdProduct = 101,
                Shop = "Пятерочка",
                Price = 60
            });
            lst.Add(new Prices()
            {
                IdProduct = 102,
                Shop = "Пятерочка",
                Price = 80
            });
            lst.Add(new Prices()
            {
                IdProduct = 101,
                Shop = "Перекресток",
                Price = 70
            });
            lst.Add(new Prices()
            {
                IdProduct = 111,
                Shop = "Перекресток",
                Price = 70
            });
            lst.Add(new Prices()
            {
                IdProduct = 107,
                Shop = "Перекресток",
                Price = 60
            });
            lst.Add(new Prices()
            {
                IdProduct = 207,
                Shop = "Перекресток",
                Price = 160
            });

            return lst;
        }

    }



}
