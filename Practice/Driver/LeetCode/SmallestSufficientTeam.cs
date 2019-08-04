using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class SmallestSufficientTeam
    {
        public int Get(int r, IList<IList<string>> p, int[][] dp, int[][] dpParent, int start, Dictionary<string, int> bitmap)
        {
            if (start == dp[0].Length)
                return r == (dp.Length-1) ? 0 : 1000000;
            if (dp[r][start] != -1)
                return dp[r][start];

            //include start
            int tempR = r;
            foreach (String s in p[start])
            {
                if (bitmap.ContainsKey(s))
                {
                    tempR |= 1 << bitmap[s];
                }
            }

            int a = 1 + Get(tempR, p, dp,dpParent, start + 1, bitmap);
            int b = Get(r, p, dp, dpParent, start + 1, bitmap);
            int res = 100000;
            if (a < b)
            {
                dpParent[r][start] = -tempR;
                res = a;
            }
            else
            {
                dpParent[r][start] = r;
                res = b;
            }
            dp[r][start] = res;
            return res;
        }
        public int[] SmallestSufficientTeamGet(string[] r, IList<IList<string>> p)
        {
            int n = r.Length;
            int sets = (1 << n) - 1;
            int[][] dp = new int[1 << n][];
            int[][] dpParent = new int[1 << n][];
            Dictionary<string, int> bitmap = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
                bitmap[r[i]] = i;

            for (int i = 0; i <= sets; i++)
            {
                dp[i] = new int[p.Count];
                dpParent[i] = new int[p.Count];
                for (int j = 0; j < p.Count; j++)
                {
                    dp[i][j] = -1;

                }
                    
            }
           
            Get(0, p, dp, dpParent, 0, bitmap);
            for (int i = 0; i <= sets; i++)
            {
                for (int j = 0; j < p.Count; j++)
                    Console.Write(dp[i][j] + ",");
                Console.WriteLine();
            }
            int sx = 0;
            int sy = 0;
            List<int> res = new List<int>();
            while(sx!=sets && sy!= p.Count)
            {
                int tempR = dpParent[sx][sy];
                if(tempR<0)
                {
                    res.Add(sy);
                    sx = -tempR;
                }
                else
                {
                    sx = tempR;
                }
                sy = sy + 1;
            }
            return res.ToArray();
        }

        public static void Test()
        {
            String[] r = new string[] { "mmcmnwacnhhdd", "vza", "mrxyc" };

            IList<IList<String>> p = new List<IList<String>>();
            int n = r.Length;
            int sets = (1 << n) - 1;
            p.Add(new List<String>(new String[] { "mmcmnwacnhhdd" }));
            p.Add(new List<String>(new String[] { }));
            p.Add(new List<String>(new String[] { }));
            p.Add(new List<String>(new String[] { "vza", "mrxyc"}));


            int[] res = new SmallestSufficientTeam().SmallestSufficientTeamGet(r, p);
            
            Console.WriteLine(String.Join(",",res));
        }
        
    }
}
