using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace InheritenceDemo
{
    class MyList<T> : IEnumerable<T>
    {
        T[] myList;
        int index = -1;
        public MyList(T[] myList)
        {
            this.myList = myList;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < 5; i++)
            {
                yield return default(T);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < 4; i++)
            {
                yield return i;
            }
        }

        public static IEnumerator<int> Get(int x)
        {
            for(int i=0;i<x;i++)
            {
                yield return i;
            }
        }
    }

    class MyListEnum<T> : IEnumerator<T>
    {
        T[] list;
        int i = -1;
        public T Current => list[i];

        object IEnumerator.Current => list[i];
        public MyListEnum(T[] list)
        {
            this.list = list;
        }
        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            if(i+2<list.Length)
            {
                i += 2;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            i = -1;
        }
    }
    class ItteratorDemo
    {
        internal static void Test()
        {
            MyList<int> myList = new MyList<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 });
            foreach(string i in new MyList<string>(new string[] { }))
            {
                Console.WriteLine(i);
            }
        }
    }
}
