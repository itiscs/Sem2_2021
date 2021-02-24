using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackApp
{
    public class Elem
    {
        public int Info { get; set; }
        public Elem Next { get; set; }
    }


    public class MyList
    {
        public Elem First { get; private set; }

        public void AddFirst(int x)
        {
            var newElem = new Elem() { Info = x, Next = First };
            First = newElem;
        }

        public void AddLast(int x)
        {
            var newElem = new Elem() { Info = x };

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

        public Elem FindByValue(int x)
        {
            //ToDo
            return null;
        }

        public bool IsSorted()
        {
            //ToDo
            return false;
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
