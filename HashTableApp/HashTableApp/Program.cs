using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashTableApp
{

    public class Elem
    {
        public int Key { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return $"{Key}->{Value}";
        }

    }

    public class MyHashTable
    {
        public int Size { get; private set; }

        private List<Elem>[] table;

        private Func<int, int> hashFunc;


        public MyHashTable(int _size, Func<int, int> _hashFunc)
        {
            Size = _size;
            table = new List<Elem>[Size];
            hashFunc = _hashFunc;
        }


        public void Insert(Elem el)
        {
            var hash = hashFunc(el.Key) % Size; // Func
            var lst = table[hash];
            if (lst == null)
            {
                lst = new List<Elem>();

            }
            lst.Add(el);
            table[hash] = lst;
        }

        public Elem GetElem(int key)
        {
            var hash = hashFunc(key) % Size; // Func

            var lst = table[hash];
            if (lst == null)
                throw new KeyNotFoundException();

            foreach (var el in lst)
            {
                if (el.Key == key)
                    return el;
            }
            throw new KeyNotFoundException();
        }

        public void Show()
        {
            for (int i = 0; i < Size; i++)
            {
                var lst = table[i];
                if (lst == null)
                    Console.WriteLine(i);
                else
                {
                    Console.Write($"{i} -- ");
                    foreach (var el in lst)
                        Console.Write($"{el.Key} {hashFunc(el.Key)} {el.Value} ->");
                    Console.WriteLine();
                }
            }
        }


    }










        class Program
    {
        static void Main(string[] args)
        {
            Int64 k = 2654435769;

            MyHashTable tbl = new MyHashTable(50, x => (((x % 1000) * (x % 1000))
                                                            % 1000) * 2153 % 1000);

            tbl.Insert(new Elem() { Key = 52, Value = "rrrrrrrrrrr" });
            tbl.Insert(new Elem() { Key = 73, Value = "gggggg" });
            tbl.Insert(new Elem() { Key = 16, Value = "kkkkkkkkkk" });
            tbl.Insert(new Elem() { Key = 461, Value = "aaaaaaaa" });
            tbl.Insert(new Elem() { Key = 33349, Value = "bbbbbbbbbbb" });
            tbl.Insert(new Elem() { Key = 462, Value = "cccccccccc" });

            tbl.Show();

             
            Console.WriteLine(tbl.GetElem(460));



            }
        }
}
