using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    public class SpiralOrder
    {
        public static void PrintSpiralOrder(int [][] a)
        {
            int rounds = (a.Length+1) / 2;
            int n = a.Length;
            for(int r=0; r< rounds; r++)
            {


                for(int i = r; i < n - r; i++)
                {
                    Console.WriteLine(a[r][i]);
                    
                }

                for (int i = r+1; i < n - r ; i++)
                {
                    Console.WriteLine(a[i][n-r-1]);
                }

                for (int i = n-r-2; i >=r; i--)
                {
                    Console.WriteLine(a[n-r-1][i]);
                }


                for (int i = n-r-2; i > r; i--)
                {
                    Console.WriteLine(a[i][r]);
                }
            }
        }

        public static void Test()
        {
            int n = 3;
            int[][] a = new int[n][];

            for(int i = 0; i < n; i++)
            {
                a[i] = new int[n];
                for(int j = 0; j < n; j++)
                {
                    a[i][j] = i * n + j;
                }
            }

            PrintSpiralOrder(a);

        }

        
    }
}
