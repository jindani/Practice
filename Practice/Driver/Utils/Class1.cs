using System;
using System.Collections;


namespace Utils
{
    public class PriorityQueue<T> where T:IComparable<T>
    {
        int len;
        T[] a;
        IComparer comparer;

        public PriorityQueue(T[] a) : this(a, null)
        {
            
            
        }
        public PriorityQueue(T[] a, IComparer comparer)
        {
            this.comparer = comparer;
            this.a = a;
            len = a.Length;
            
            if (a.Length != 0)
            {
                BuildHeap();
            }

        }

        private void BuildHeap()
        {
            for(int i = len / 2; i >= 0; i--)
            {
                Heapyfy(i);
            }
        }

        public void Add(T item)
        {
            if (a.Length == len)
            {
                T[] newArray = new T[a.Length * 2];
                for(int i=0;i<len;i++)
                {
                    newArray[i] = a[i];
                }
                a = newArray;
                
            }
            a[len] = item;
            int parent = (len - 1) / 2;
            int c = len;
            while(parent >= 0 && (comparer != null ? comparer.Compare(a[parent], a[c]) > 0 : a[parent].CompareTo(a[c]) > 0))
            {
                T temp = a[parent];
                a[parent] = a[c];
                a[c] = temp;
                c = parent;
                parent = (c - 1) / 2;
            }
            len++;
        }
        public T ExtractMin()
        {
            if (len > 0)
            {
                T res = a[0];
                a[0] = a[len - 1];
                Heapyfy(0);
                len--;
                return res;
            }
            return default(T);
        }

        private void Heapyfy(int i)
        {
            int l = i * 2 + 1;
            int r = i * 2 + 2;
            int largest = i;
            if(l<len && (comparer!=null?comparer.Compare(a[i],a[l])>0:a[i].CompareTo(a[l])>0))
            {
                largest = l;
            }
            if(r<len && (comparer != null ? comparer.Compare(a[largest], a[r]) > 0 : a[largest].CompareTo(a[r]) > 0))
            {
                largest = r;               
            }

            if (i != largest)
            {
                T temp = a[i];
                a[i] = a[largest];
                a[largest] = temp;
                Heapyfy(largest);
            }
        }

        public void PrintHeap()
        {
            Console.WriteLine("----------------------------");
            for(int i = 0; i < len; i++)
            {
                Console.WriteLine(a[i]);
            }
            Console.WriteLine("----------------------------");
        }
    }
}
