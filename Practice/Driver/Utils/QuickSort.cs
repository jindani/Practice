using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public class QuickSort
    {
        public static void Test()
        {
            int[] a = new int[] { 5,3,4,2,234,222,111,21,22,2,22,22,2 };
            DoQuickSort(a, 0, a.Length - 1);
            Console.WriteLine(String.Join(",", a));
        }

        public static void DoQuickSort(int []a, int s, int e)
        {
            if (s >= e)
                return;
            int p = new Random().Next(s,e+1);
            //int p = s+1;
            int t = a[p];
            a[p] = a[e];
            a[e] = t;
            p = HoarePartition(a, s, e);
            DoQuickSort(a, s, p);
            DoQuickSort(a, p + 1, e);
            Console.WriteLine(String.Join(",", a));
        }

        public static int Partition(int []a, int s, int e)
        {
            Console.WriteLine(s + "?" + e);
            int i = s - 1;
            for(int j = s;j<e;j++)
            {
                if (a[j] <= a[e])
                {
                    i++;
                    int tt = a[i];
                    a[i] = a[j];
                    a[j] = tt;
                }
            }
            int t = a[i + 1];
            a[i + 1] = a[e];
            a[e] = t;
            return i + 1;
        }

        public static int HoarePartition(int[] a, int s, int e)
        {
            Console.WriteLine(s + "?" + e);
            int i = s;
            int j = e;
            while(true)
            {
                while (a[i] < a[e])
                    i++;
                while (a[j] > a[e])
                    j--;
                if(i<j)
                {
                    int t = a[i];
                    a[i] = a[j];
                    a[j] = t;
                }
                else
                {
                    return j;
                }
                i++;
                j--;
            }
        }
    }
}
