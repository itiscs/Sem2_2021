using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList2
{
    public class MyClass:IComparable
    {
        public int P1 { get; set; }
        public int P2 { get; set; }

        public MyClass(int p1, int p2)
        {
            P1 = p1;
            P2 = p2;
        }
        public int CompareTo(object obj)
        {
            var ob = obj as MyClass;
            if(ob != null)
            {
                if (P1 + P2 == ob.P1 + ob.P2)
                    return 0;
                if (P1 + P2 > ob.P1 + ob.P2)
                    return 1;
                if (P1 + P2 < ob.P1 + ob.P2)
                    return -1;
                //return (P1 + P2).CompareTo(ob.P1 + ob.P2);
            }
            throw new ArgumentException("object not clear");
        }


        public override string ToString()
        {
            return $"({P1},{P2})";
        }
    }



    public class Elem<T> //where T:IComparable 
    {
        public T Info { get; set; }
        public Elem<T> Next { get; set; }
    }


    public class MyList<T> where T:IComparable
    {
        public Elem<T> First { get; private set; }


        
        public void AddFirst(T x)
        {
            var newElem = new Elem<T>() { Info = x, Next = First };
            First = newElem;
        }

        public void AddLast(T x)
        {
            var newElem = new Elem<T>() { Info = x };

            if (First == null)
            {
                First = newElem;
                return;
            }
            var elem = First;
            while (elem.Next != null)
                elem = elem.Next;

            elem.Next = newElem;
        }

        public int Count()
        {
            //ToDo
            return 0;
        }

        public int FindByIndex(int ind)
        {
            //ToDo
            return 0;
        }

        public Elem<T> FindByValue(T x)
        {
            //ToDo
            return null;
        }

        public bool IsSorted()
        {
            Elem<T> el = First;
            
            while (el.Next != null)
            {
                if (el.Info.CompareTo(el.Next.Info) > 0 )
                    return false;
                el = el.Next;
            }

            return true;
        }


        public void DeleteByIndex(int ind)
        {
            if (First == null)
                throw new ArgumentException();
            if (ind == 0)
                First = First.Next;
            else
            {
                var prevElem = First;
                for (int i = 1; i < ind; i++)
                {
                    prevElem = prevElem.Next;
                    if (prevElem == null)
                        throw new ArgumentException();
                }
                if (prevElem.Next != null)
                    prevElem.Next = prevElem.Next.Next;

            }

        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            var elem = First;
            while (elem != null)
            {
                sb.Append($"{elem.Info} -> ");
                elem = elem.Next;
            }
            sb.Append("null");
            return sb.ToString();
        }





    }

}
