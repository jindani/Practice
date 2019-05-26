using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Candy
    {
        public static int Get(int []a)
        {
            int n = a.Length;
            int[] left = new int[n];
            int[] right = new int[n];
            left[0] = 1;
            for(int i=1;i<n;i++)
            {
                if (a[i] == a[i - 1])
                    left[i] = left[i - 1];
                else if (a[i] < a[i-1])
                    left[i] = 1;
                else
                {
                    left[i] = left[i - 1] + 1;
                }
            }
            right[n - 1] = 1;
            for (int i =n-2; i >= 0 ; i--)
            {
                if (a[i] == a[i + 1])
                    right[i] = right[i + 1];
                else if (a[i] < a[i + 1])
                    right[i] = 1;
                else
                {
                    right[i] = right[i + 1] + 1;
                }
            }

            int res = 0;
            for (int i = 0; i < n; i++)
                res += Math.Max(left[i], right[i]);
            return res;
        }

        public static void Test()
        {
            int[] a = new int[] {1,2,3,4,5,4,3,2,1,0,-1,1,0,1 };
            Console.WriteLine(Get(a));
        }
    }
}
