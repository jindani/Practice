using System;
using System.Collections.Generic;
using System.Text;

namespace Uber
{
    public class MinimumSubStringWithAll
    {
        public static int GetMinLen(String s, char[] set)
        {
            Dictionary<char,int> count = new Dictionary<char, int>();
            if (s.Length == 1)
                if (set.Length == 1)
                    return set[0] == s[0] ? 1 : -1;
                else
                    return -1;

                      
            int start = 0;
            int end = 0;
            int distinct = 0;
            int res = int.MaxValue;
            foreach (char c in set)
                count[c] = 0;
                
            while(end<s.Length)
            {
                if (count.ContainsKey(s[end]))
                {
                    count[s[end]] = count[s[end]] + 1;
                    if (count[s[end]] == 1)
                        distinct++;
                }

                while (distinct == set.Length && start <= end)
                {
                    res = Math.Min(res, end - start+1);
                    if (count.ContainsKey(s[start]))
                    {
                        count[s[start]] = count[s[start]] - 1;
                        if (count[s[start]] == 0)
                            distinct--;
                    }
                    start++;
                }
                end++;
            }
            return res == int.MaxValue ? -1 : res ;
        }

        public static void Test()
        {
            Console.WriteLine(GetMinLen("xaguadfydsfdsffyz", new char[] {'x','y','u','z' }));
        }
    }
}
