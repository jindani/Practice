﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class LargestValidParenthesis
    {
        public string s;
        int max = 0;
        int n = 0;
        public int get(int i, int j)
        {
            if (j <= i) return 0;


            if (dp[i][j] != -1) return dp[i][j];
            Console.WriteLine(i+":"+j);
            if (j - i == 1)
            {
                if (s[i] == '(' && s[j] == ')')
                {
                    dp[i][j] = 2;
                    //max = Math.Max(max, dp[i][j]);
                    return dp[i][j];
                }
                dp[i][j] = 0;
                return dp[i][j];
            }

            if (i + 1 < n && j - 1 >= 0 && get(i + 1, j - 1) > 0 && s[i] == '(' && s[j] == ')')
            {
                dp[i][j] = j - i + 1;

                //max = Math.Max(max, dp[i][j]);     
                return dp[i][j];
            }
            for (int k = i + 1; k <= j - 1; k++)
            {
                int res1 = get(k + 1, j);
                int res2 = get(i, k);
                if (res1 > 0 && res2 > 0)
                {
                    dp[i][j] = j - i + 1;
                    //max = Math.Max(max, dp[i][j]);
                }
                else
                {
                    dp[i][j] = 0;
                }
            }

            return dp[i][j];
        }
        int[][] dp;
        public int LongestValidParentheses(string s)
        {
            n = s.Length;
            this.s = s;
            dp = new int[n][];

            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[s.Length];
                for (int j = 0; j < n; j++)
                {
                    dp[i][j] = -1;

                }
            }

            int res = get(0, n - 1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i < j && dp[i][j] == -1)
                        get(i, j);
                    max = Math.Max(max, dp[i][j]);
                    //Console.Write(dp[i][j]+",");

                }
                //Console.WriteLine();
            }
            return max;
        }
        public static void Test()
        {
            String s = "((())())(()))(()()(()(()))(()((((()))))))((()())()))()()(()(((((()()()())))()())(()()))((((((())))((()))()()))))(()))())))()))()())((()()))))(()(((((())))))()((()(()(())((((())(())((()()(()())))())(()(())()()))())(()()()))()(((()())(((()()())))(((()()()))(()()))()))()))))))())()()((()(())(()))()((()()()((())))()(((()())(()))())())))(((()))))())))()(())))()())))())()((()))((()))()))(((())((()()()(()((()((())))((()()))())(()()(()))))())((())))(()))()))))))()(()))())(()())))))(()))((())(()((())(((((()()()(()()())))(()())()((()(()()))(()(())((()((()))))))))(()(())()())()(()(()(()))()()()(()()())))(())(()((((()()))())))(())((()(())())))))())()()))(((())))())((()(()))(()()))((())(())))))(()(()((()((()()))))))(()()()(()()()(()(())()))()))(((()(())()())(()))())))(((()))())(()((()))(()((()()()(())()(()())()(())(()(()((((())()))(((()()(((()())(()()()(())()())())(()(()()((()))))()(()))))(((())))()()))(()))((()))))()()))))((((()(())()()()((()))((()))())())(()((()()())))))))()))(((()))))))(()())))(((()))((()))())))(((()(((())))())(()))))(((()(((((((((((((())(((()))((((())())()))())((((())(((())))())(((()))))()())()(())())(()))))()))()()()))(((((())()()((()))())(()))()()(()()))(())(()()))()))))(((())))))((()()(()()()()((())((((())())))))((((((()((()((())())(()((()))(()())())())(()(())(())(()((())((())))(())())))(()()())((((()))))((()(())(()(()())))))))))((()())()()))((()(((()((()))(((((()()()()()(()(()((()(()))(()(()((()()))))()(()()((((((()((()())()))((())()()(((((()(()))))()()((()())((()())()(())((()))()()(()))";
 
             Console.WriteLine(new LargestValidParenthesis().LongestValidParentheses(s));
        }
    }
}