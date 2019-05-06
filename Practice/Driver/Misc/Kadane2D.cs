using System;
using System.Collections.Generic;
using System.Text;

namespace Misc
{
    public class Kadane2D
    {
        public static int GetMaxSum(int []a)
        {
            int curr = a[0];
            int max = curr;
            for(int i=1;i<a.Length;i++)
            {
                curr = Math.Max(curr + a[i], a[i]);
                max = Math.Max(max, curr);
            }
            return max;
        }
        public static int GetMax(int [][]a)
        {
            int n = a.Length;
            int m = a[0].Length;
            
            int max = 0;
            for(int i=0;i<n;i++)
            {
                int[] temp = new int[m];
                for (int j=i;j<n;j++)
                {
                    for (int k = 0; k < m; k++)
                    {
                        temp[k] += a[j][k];
                    }
                    Console.WriteLine("{0} {1} {2}", i, j, String.Join(",", temp));
                    max = Math.Max(max, GetMaxSum(temp));
                }
            }

            return max;
        }

        public static void Test()
        {
            int[][] a = new int[4][];
            a[0] = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };
            a[1] = new int[] { 1, 1, 1, 1, 1, 1, 1,-1000000 };
            a[2] = new int[] { 1, 1, 1, 1, 1, 1, 1, -1000000 };
            a[3] = new int[] { 1, 1, 1, 1, 1, -1000000, -1000000, -1000000 };

            Console.WriteLine(GetMax(a));
        }

        public int MaximalRectangle(char[,] matrix)
        {
            int[][] a = new int[matrix.GetLength(0)][];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                a[i] = new int[matrix.GetLength(1)];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    a[i][j] = matrix[i, j] == '1' ? 1 : -10000000;
                }
            }

            int res = GetMax(a);
            return res > 0 ? res : 0;
        }
    }
}
