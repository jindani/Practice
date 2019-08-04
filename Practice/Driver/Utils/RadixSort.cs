using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public class Node<T>
    {
        public int key;
        public T value;
        public Node(int key, T value)
        {
            this.key = key;
            this.value = value;
        }
    }
    public class RadixSort
    {
        public static void Test()
        {
            int n = 10;
            Node<int>[] nodes = new Node<int>[n];
            Random r = new Random();
            for(int i=0;i<n;i++)
            {
                int val = r.Next(0, 100000);
                Console.Write(val + ",");
                nodes[i] = new Node<int>(val, val);
            }
            DoRadixSort(nodes);
            for(int i=0;i<n;i++)
            {
                Console.WriteLine(nodes[i].key);
            }
        }

        public static void DoRadixSort(Node<int>[] a)
        {
            int n = a.Length;
            int[] c = new int[10];
            Node<int>[] b = new Node<int>[n];

            int div = 1;
            for(int d=0;d<10;d++)
            {
                for(int i=0;i<10;i++)
                {
                    c[i] = 0;
                }

                for(int i=0;i<n;i++)
                {
                    c[(a[i].key/div) % 10]++;
                }
                for (int i = 1; i < 10; i++)
                    c[i] = c[i] + c[i - 1];

                for(int i=n-1;i>=0;i--)
                {
                    b[c[(a[i].key / div) % 10] - 1] = a[i];
                    c[(a[i].key / div) % 10]--;
                }
                for (int i = 0; i < n; i++)
                    a[i] = b[i];
                div *= 10;
            }
        }
    }
}
