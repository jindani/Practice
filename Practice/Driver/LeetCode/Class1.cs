using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class LCSGet
    {
        public int Fill(String s1, String s2, int i, int j, int[][] dp, int[][] path)
        {
            if (i == s1.Length && j == s2.Length)
                return 0;

            if (dp[i][j] != 0)
                return dp[i][j];

            int min = Int32.MaxValue;
            if (i < s1.Length && j < s2.Length)
            {
                if (s1[i] == s2[j])
                {
                    int t = Fill(s1, s2, i + 1, j + 1, dp, path);
                    if (t < min)
                    {
                        min = t;
                        path[i][j] = 1;
                    }
                }
                else
                {
                    int t = Fill(s1, s2, i + 1, j, dp, path);
                    if (t < min)
                    {
                        min = t + 1;
                        path[i][j] = 2;
                    }
                    t = Fill(s1, s2, i, j + 1, dp, path);
                    if (t < min)
                    {
                        min = t + 1;
                        path[i][j] = 3;
                    }
                }
            }
            else if (i < s1.Length)
            {
                int t = Fill(s1, s2, i + 1, j, dp, path);
                if (t < min)
                {
                    min = t + 1;
                    path[i][j] = 2;
                }
            }
            else if (j < s2.Length)
            {
                int t = Fill(s1, s2, i, j + 1, dp, path);
                if (t < min)
                {
                    min = t + 1;
                    path[i][j] = 3;
                }
            }
            dp[i][j] = min;
            return min;
        }
        public string ShortestCommonSupersequence(string s1, string s2)
        {
            int n = s1.Length;
            int m = s2.Length;
            int[][] dp = new int[n + m][];
            int[][] path = new int[n + m][];
            for (int i = 0; i < m+n; i++)
            {
                dp[i] = new int[n + m];
                path[i] = new int[m + n];
            }
            Fill(s1, s2, 0, 0, dp, path);
            StringBuilder sb = new StringBuilder();
            int x = 0;
            int y = 0;

            while(true)
            {
                int curr = path[x][y];
                if (curr == 1)
                {
                    sb.Append(s1[x]);
                    x++;
                    y++;
                }
                else if (curr == 2)
                {
                    sb.Append(s1[x]);
                    x++;
                }
                else if (curr == 3)
                {
                    sb.Append(s2[y]);
                    y++;
                }
                else
                    break;
            }
            
            for (int i = 0; i < n; i++)
                Console.WriteLine(String.Join(",", path[i]));
            return sb.ToString() ;
        }

        public void DuplicateZeros(int[] a)
        {

            int n = a.Length;
            int destLength = n;
            int i = 0;
            for (i = 0; i < n; i++)
            {
                if (a[i] == 0)
                    destLength++;
            }
            destLength--;
            for (i = n - 1; i >= 0; i--)
            {
                if (destLength < n)
                {
                    a[destLength] = a[i];
                }

                if (a[i] == 0)
                {
                    if (destLength-1 < n)
                    {
                        a[destLength-1] = 0;
                        destLength--;
                    }
                }
                destLength--;
            }

        }
        public static void Test()
        {
            LCSGet l = new LCSGet();
            l.DuplicateZeros(new int[] { 9, 8, 0, 0, 0, 0 });
        }
    }
}
