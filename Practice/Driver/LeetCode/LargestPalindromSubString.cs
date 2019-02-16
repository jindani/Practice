using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class LargestPalindromSubString
    {
        public int fill(int[][] dp, string s, int start, int end)
        {
            if (end - start + 1 == 0)
            {
                return 1;
            }
            if(dp[start][end] != -1)
            {
                return dp[start][end];
            }

            
            if (start == end)
            {
                return dp[start][end] = 1;
            }

            if(s[start] == s[end])
            {
                if (fill(dp, s, start + 1, end - 1) > 0)
                {
                    return dp[start][end] = 1;
                }
            }
            return dp[start][end]=0;
        }
        
        public string LongestPalindrome(string s)
        {
            int n = s.Length;
            int[][] dp = new int[n][];
            for(int i = 0; i < n; i++)
            {
                dp[i] = new int[n];
                for(int j = 0; j < n; j++)
                {
                    dp[i][j] = -1;
                }
            }
            int max = 1, maxStart = 0, maxEnd = 0;
            for(int i = 0; i < n; i++)
            {
                for(int j = i; j < n; j++)
                {
                    int t = fill(dp, s, i, j);
                    if (t >0 && j-i+1>max)
                    {
                        max = j-i+1;
                        maxStart = i;
                        maxEnd = j;

                    }
                }
            }

            /*for (int i = 0; i < n; i++)
            {
                //dp[i] = new int[n];
                for (int j = i; j < n; j++)
                {
                    Console.Write(dp[i][j]);
                }
                Console.WriteLine();
            }*/
            return s.Substring(maxStart, maxEnd - maxStart + 1);
            
        }

        public static void Test()
        {
            LargestPalindromSubString test = new LargestPalindromSubString();
            Console.WriteLine(test.LongestPalindrome("aaaaaaaaaaaa"));
        }
    }
}
