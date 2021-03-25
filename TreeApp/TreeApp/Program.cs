using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeApp
{
    public class Elem<T>
    {
        public T Info { get; set; }
        public Elem<T> Left { get; set; }
        public Elem<T> Right { get; set; }

        public override string ToString()
        {
            // если дерево это лист то выводим без скобок 
            if (Left == Right)    //Left == null && Right == null   
                return Info.ToString();
            String strLeft="";
            String strRight = "";
            if (Left != null)
                strLeft = Left.ToString();
            if (Right != null)
                strRight = Right.ToString();

            return $"({Info},{strLeft},{strRight})";
        }

        public T MyOper(Func<T, T, T> oper, T init)
        {
            T result = Info;
            if (Left != null)
                result = oper(result, Left.MyOper(oper,init)) ;
            if (Right != null)
                result = oper(result, Right.MyOper(oper, init));
            return result;
        }



    }

    public class Tree<T>
    {
        public Elem<T> Root { get; set; }

        public override string ToString()
        {
            return Root.ToString();
        }

        public T MyOper(Func<T,T,T> oper, T init)
        {
            if (Root != null)
                return Root.MyOper(oper,init);
            return init;
        }

    }



    class Program
    {
        static void Main(string[] args)
        {

            Tree<int> tree = new Tree<int>();
            tree.Root = new Elem<int>()
            {
                Info = 5,
                Left = new Elem<int>() 
                { 
                    Info = 4,
                    Left = new Elem<int>() { Info = 10 },
                    Right = new Elem<int>() { Info = 8 }
                },
                Right = new Elem<int>()
                {
                    Info = 3,
                    Left = new Elem<int>() { Info = 66 }
                }
            };

            Console.WriteLine(tree);

            Console.WriteLine(tree.MyOper((a, b) => a + b, 0));

            Console.WriteLine(tree.MyOper((a, b) => a>b ? a : b , int.MinValue));




        }
    }
}
