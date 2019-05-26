using System;
using System.Collections.Generic;
using System.Text;

namespace Misc
{
    public class Possible01
    {
        public static void Get(String s, int start, char[] part, List<String> res)
        {
            if(start == s.Length)
            {
                res.Add(new string(part));
                return;
            }

            if(s[start] == '?')
            {
                part[start] = '0';
                Get(s, start + 1, part, res);
                part[start] = '1';
                Get(s, start + 1, part, res);
            }
            else
            {
                part[start] = s[start];
                Get(s, start + 1, part, res);
            }
        }

        public static void Test()
        {
            List<String> res = new List<string>();
            Get("0101?1?", 0, new char[7], res);
            foreach(var s in res)
            {
                Console.WriteLine(s);
            }
        }
    }
}
