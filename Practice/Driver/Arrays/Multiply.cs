using System;
using System.Linq;

namespace Arrays
{
    public class Multiply
    {

        public static int[] MultiplyArrays(int []a, int[] b)
        {
            int n = a.Length;
            int m = b.Length;

            int[] res = new int[m+n];

            for(int i = n-1; i >= 0; i--)
            {
                for(int j=m-1; j >= 0; j--)
                {
                    res[i + j + 1] += a[i] * b[j];
                    res[i + j] += res[i + j + 1] / 10;
                    res[i + j + 1] %= 10;
                }
            }
            if(res[0] == 0)
            {
                return res.Skip(1).Take(m+n-1).ToArray();
            }
            return res;
        }

        private static int[] GetArrayOfDigits(int n)
        {
            char []digits = n.ToString().ToCharArray();
            int[] res = new int[digits.Length];
            for(int i = 0; i < digits.Length; i++)
            {
                res[i] = digits[i] - '0';
            }
            return res;
        }
        public static void Test()
        {
            int[] a = new int[] { 1, 2, 3, 4 };
            int[] b = new int[] { 2,2 };

            for (int i = 100; i < 10000; i++)
            {
                for(int j = 100; j < 10000; j++)
                {
                    if (MultiplyArrays(GetArrayOfDigits(i), GetArrayOfDigits(j)).SequenceEqual(GetArrayOfDigits(i*j))){
                        Console.WriteLine("[{0}*{1}={2}, {3}]", i, j, i * j, string.Join(", ", MultiplyArrays(GetArrayOfDigits(i), GetArrayOfDigits(j))));
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[{0}*{1}={2}, {3}]", i, j, i*j, string.Join(", ", MultiplyArrays(GetArrayOfDigits(i), GetArrayOfDigits(j))));
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
            Console.WriteLine("[{0}]", string.Join(", ", MultiplyArrays(a, b)));
        }
    }
}
