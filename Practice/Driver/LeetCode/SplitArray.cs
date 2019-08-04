using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class SplitArrayLeet
    {
        public int Helper(int[] a, int[][] dp, int m, int start)
        {
            if (start == a.Length && m == 0)
                return 0;
            if (start == a.Length || m == 0)
                return Int32.MaxValue;

            if (dp[start][m] != 0)
                return dp[start][m];
            if (m == 1)
            {
                for (int i = start; i < a.Length; i++)
                    dp[start][m] += a[i];
                return dp[start][m];
            }
            int sum = 0;
            int res = Int32.MaxValue;
            for (int i = start; i < a.Length; i++)
            {
                sum += a[i];
                res = Math.Min(res, Math.Max(sum, Helper(a, dp, m - 1, i + 1)));
            }
            dp[start][m] = res;
            return res;
        }
        public int SplitArray(int[] a, int m)
        {
            int n = a.Length;
            int[][] dp = new int[n + 1][];
            for (int i = 0; i < n; i++)
                dp[i] = new int[m + 1];
            int res = Helper(a, dp, m, 0);
            for (int i = 0; i < n; i++)
                Console.WriteLine(String.Join(",", dp[i]));
            return res;

        }

        public static void Test()
        {
            SplitArrayLeet s = new SplitArrayLeet();
            Console.WriteLine(s.SplitArray(new int[] { 7, 2, 5, 10, 8 },2));
        }
    }
}
