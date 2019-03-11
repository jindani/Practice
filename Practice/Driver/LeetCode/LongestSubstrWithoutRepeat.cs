using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class LongestSubstrWithoutRepeat
    {
        Stack<char> st = new Stack<char>();
        public int LengthOfLongestSubstring(string s)
        {
           
            HashSet<char> seen = new HashSet<char>();
            int n = s.Length;
            if (n == 0)
            {
                return 0;
            }
            int start = 0;
            int max = 0;
            for(int i = 0; i < n; i++)
            {
                if (!seen.Contains(s[i]))
                {
                    seen.Add(s[i]);
                }
                else
                {
                    max = Math.Max(max, i - start);
                    while (s[start] != s[i])
                    {
                        seen.Remove(s[start]);
                        start++;
                    }        
                    start++;
                    
                }
            }

            // for the last 
            max = Math.Max(max, n - start);
            return max;
        }

    }
}
