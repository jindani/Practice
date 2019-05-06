using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class SearchIn2D
    {
        private bool Check(int p, int n)
        {
            if (p < 0 || p > n)
                return true;
            return false;
        }

        public bool BinarySearch(int[][] a, int r0, int c0, int r1, int c1, int target)
        {
            if (r0 > r1 || c0 > c1 || Check(r0, a.Length) || Check(r1, a.Length) || Check(c0, a[0].Length) || Check(c1, a[0].Length))
                return false;
            if (r0 == r1 && c0 == c1)
                return a[r0][c1] == target;
            Console.WriteLine("{0} {1} {2} {3}", r0, c0, r1, c1);
            int midr = r0 + (r1 - r0) / 2;
            int midc = c0 + (c1 - c0) / 2;

            if (a[midr][midc] == target)
                return true;
            if (a[midr][midc] > target)
                return BinarySearch(a, r0, c0, midr, midc, target);

            return BinarySearch(a, r0, midc + 1, midr, c1, target) ||
                 BinarySearch(a, midr + 1, c0, r1, midc, target) ||
                 BinarySearch(a, midr + 1, midc + 1, r1, c1, target);

        }
        public bool SearchMatrix(int[][] matrix, int target)
        {
            return BinarySearch(matrix, 0, 0, matrix.Length-1, matrix[0].Length-1, target);
        }
        
        public static void Test()
        {
            int[][] a = new int[1][];
            a[0] = new int[] { 1, 3, 5, 7 };

            Console.WriteLine(new SearchIn2D().SearchMatrix(a, 32));
        }

    }
}
