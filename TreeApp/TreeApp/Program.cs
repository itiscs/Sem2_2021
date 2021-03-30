﻿using System;
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

        public int Calc()
        {
            if (Left == Right)
                return int.Parse(Info.ToString());

            var str = Info.ToString();
            if (str[0] == '(')
                str = str.Remove(0, 1);
            switch (str)
            {
                case "+":
                    return Left.Calc() + Right.Calc();
                case "-":
                    return Left.Calc() - Right.Calc();
                case "*":
                    return Left.Calc() * Right.Calc();
                case "/":
                    return Left.Calc() / Right.Calc();
            }
            return 0;

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

        public Tree()
        {

        }
        public Tree(string str, Func<string, T> parser)
        {
            // (1,(2,4,(5,8,)),(3,6,7))
            // (*,(+,4,(/,8,4)),(-,6,7))
            // (1 (2 4 (5 8 _ _ _ _ (3 6 7 _
            int k = 0;
            Root = Create(str.Split(new char[] { ',', ')' }), ref k, parser);

        }

        public Elem<T> Create(String[] str, ref int k, Func<string, T> parser)
        {
            Elem<T> t = new Elem<T>();
            if (!str[k].Contains('('))
            {
                t.Info = parser(str[k]);
            }
            else
            {
                t.Info = parser(str[k].Remove(0, 1));//убрали '(' 
                k++;
                if (str[k] != "")
                    t.Left = Create(str, ref k, parser);
                k++;
                if (str[k] != "")
                    t.Right = Create(str, ref k, parser);
                k++;
            }
            return t;
        }


        public int Calc()
        {
            return Root.Calc();
        }



    }



    class Program
    {
        static void Main(string[] args)
        {
            //   Tree<int> tree = new Tree<int>("(100,4,)", s => int.Parse(s));

            Tree<int> tree = new Tree<int>("(-10,(23,46,(5,8,)),(13,36,7))", s => int.Parse(s) );

            Tree<string> arTree = new Tree<string>("(/,(*,(+,3,13), 7),6)", s => s);

            //Tree<string> arTree = new Tree<string>("(*, (+, 4, (/, 8, 4)), (-, 6, 7))", s => s);
           // Tree<double> tree = new Tree<double>("(-10,4;(23,4;46,3;(5,2;8;));(13;36;7))", s => double.Parse(s));

            //tree.Root = new Elem<int>()
            //{
            //    Info = 5,
            //    Left = new Elem<int>() 
            //    { 
            //        Info = 4,
            //        Left = new Elem<int>() { Info = 10 },
            //        Right = new Elem<int>() { Info = 8 }
            //    },
            //    Right = new Elem<int>()
            //    {
            //        Info = 3,
            //        Left = new Elem<int>() { Info = 66 }
            //    }
            //};



            Console.WriteLine(arTree);
            Console.WriteLine(arTree.Calc());

            Console.WriteLine(tree.MyOper((a, b) => a + b, 0));

            Console.WriteLine(tree.MyOper((a, b) => a>b ? a : b , int.MinValue));




        }
    }
}
