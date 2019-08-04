using System;
using System.Collections;
using System.Collections.Generic;

namespace Utils
{
    public class PriorityQueue<T>
    {
        int len;
        T[] a;
        IComparer<T> comparer;
        private static readonly int DEFAULT_INITIAL_CAPACITY = 11;

        public int Count
        {
            get
            {
                return len;
            }
        }
        public PriorityQueue() : this(null,null)
        {
        }

        public PriorityQueue(T[] a) : this(a, null)
        {
        }
        public PriorityQueue(T[] a, IComparer<T> comparer)
        {
            this.comparer = comparer ?? Comparer<T>.Default;
            if (a == null || a.Length == 0)
            {
                this.a = new T[DEFAULT_INITIAL_CAPACITY];
                return;
            }

            this.a = new T[a.Length];
            for(int i = 0;i<a.Length;i++)
            {
                this.a[i] = a[i];
            }

            len = a.Length;
            
            if (a.Length != 0)
            {
                BuildHeap();
            }

        }

        public PriorityQueue(Comparer<T> @default)
        {
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
            while(parent >= 0 && comparer.Compare(a[parent], a[c]) > 0)
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
            throw new IndexOutOfRangeException();
        }
        public T Peek()
        {
            if (len > 0)
                return a[0];
            throw new IndexOutOfRangeException();
        }

        private void Heapyfy(int i)
        {
            int l = i * 2 + 1;
            int r = i * 2 + 2;
            int largest = i;
            if(l<len && comparer.Compare(a[i],a[l])>0)
            {
                largest = l;
            }
            if(r<len && comparer.Compare(a[largest], a[r]) > 0)
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
