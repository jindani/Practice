using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class RegularExpressionMatch
    {
        public int fill(int [][] dp, string s, string p, int start1, int start2)
        {
            if (start1 == s.Length && start2 == p.Length)
            {
                return 1;
            }

            if (start1 == s.Length)
            {
                if (start2 < p.Length - 1)
                {
                    if (p[start2 + 1] == '*')
                    {
                        return dp[start1][start2] = fill(dp, s, p, start1, start2 + 2);
                    }
                }
            }
            if (start1>=s.Length || start2 >= p.Length)
            {
                return 2;
            }
            if(dp[start1][start2] != 0)
            {
                return dp[start1][start2];
            }


            if (start2 < p.Length - 1)
            {
                if (p[start2 + 1] == '*')
                {
                   // if(start1 == s.Length - 1)
                  //  {
                  //      return dp[start1][start2] = fill(dp, s, p, start1+1, start2 + 2);
                  //  }
                    dp[start1][start2] = p[start2] == '.' || p[start2] == s[start1] ? fill(dp, s, p, start1 + 1, start2) : 2;
                    return dp[start1][start2] = dp[start1][start2] != 1 ? fill(dp, s, p, start1, start2 + 2) : 1;
                }
            }

            if(p[start2] == '.' || p[start2] == s[start1])
            {
                return dp[start1][start2] = fill(dp, s, p, start1 + 1, start2 + 1);
            }
            return dp[start1][start2] = 2;          
        }
        public bool IsMatch(string s, string p)
        {
            int n = s.Length;
            int m = p.Length;
            int[][] dp = new int[n+1][];
            for(int i = 0; i < n+1; i++)
            {
                dp[i] = new int[m+1];
                
            }
            dp[n][m] = 1;
            bool res = fill(dp, s, p, 0, 0) == 2 ? false : true; 
            //Console.WriteLine(fill(dp, s, p, 0, 0));
            for (int i = 0; i <= n; i++)
            {
                //dp[i] = new int[n];
                for (int j = 0; j <= n; j++)
                {
                    Console.Write(dp[i][j]);
                }
                Console.WriteLine();
            }
            //return false;
            return res;
        }

        public static void Test()
        {
            Console.WriteLine(new RegularExpressionMatch().IsMatch("aab", "xc*a*b"));
        }

    }
}
