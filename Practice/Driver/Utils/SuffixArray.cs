using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public class SuffixArray
    {
        public static int GetIndexAfterCommonPrefix(string s, string t)
        {
            int res = 0;
            while(res<s.Length && res<t.Length)
            {
                if (s[res] != t[res])
                    return res;
                res++;
            }
            
            return res;
        }
        public static bool IsPossible(int[] preProcess, int start, int end)
        {
            bool res = false;
            if (start == 0)
                res = preProcess[end] % 2 == 1;
            else if (preProcess[end] - preProcess[start] == 0)
                res = true;
            else
            {
                res = ((preProcess[end] - preProcess[start]) % 2 == 1);
            }
            
            for(int i=start;i<=end;i++)
            {
                Console.Write(preProcess[i] + ",");
            }
            Console.WriteLine(res);
            return res;
        }
        public static int Get(int []a)
        {
            StringBuilder sb = new StringBuilder();
            int[] preProcess = new int[a.Length];
            sb.Append((char)a[0]);
            preProcess[0] = (a[0] % 2 == 1 ? 1 : 0);
            for (int i=1;i<a.Length;i++)
            {
                sb.Append((char)a[i]);
                preProcess[i] = preProcess[i - 1] + (a[i] % 2 == 1 ? 1 : 0);
            }
            Console.WriteLine(String.Join(",", preProcess));
            
            string s = sb.ToString();
            String[] suffix = new string[s.Length];
            for (int i = 0; i < s.Length; i++)
                suffix[i] = s.Substring(i);

            // N^2LogN
            Array.Sort(suffix);

            int res = 0;
            // First Suffix
            // O(N)
            int start = s.Length - suffix[0].Length;
            for(int i=0;i<suffix[0].Length;i++)
            {
                res += IsPossible(preProcess, start,start+i)?1:0;
            }
            // o(N2)
            for(int i = 1;i< suffix.Length;i++)
            {
                start = GetIndexAfterCommonPrefix(suffix[i - 1], suffix[i]);
                for (int j = start; j < suffix[i].Length; j++)
                {
                    res += IsPossible(preProcess, start, start + j) ? 1 : 0;
                }
            }
            return res;
        }

    }
}
