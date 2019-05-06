using System;
using System.Collections.Generic;
using System.Text;

namespace Misc
{
    public class PrintRepeat
    {
        public static String Get(String s,ref int start)
        {
            StringBuilder currPart = new StringBuilder();
            if (start == s.Length)
            {
                return currPart.ToString();
            }
            while (start < s.Length )
            {
                if (s[start] >= '0' && s[start] <= '9')
                {
                    int count = 0;
                    while (s[start] >= '0' && s[start] <= '9')
                    {
                        count = count * 10 + s[start] - '0';
                        start++;
                    }
                    // Next char is [
                    start++;
                    String part = Get(s, ref start);
                    for (int i = 0; i < count; i++)
                    {
                        currPart.Append(part);
                    }
                }
                else if(s[start] == ']')
                {
                    start++;
                    return currPart.ToString();
                }
                else
                {
                    
                    currPart.Append(s[start]);
                    start++;
                }
            }
            return currPart.ToString();
            
        }

        public static void Test()
        {
            int start = 0;
            String s = "1[x1[y1[z1[a1[b1[c]]]]]]";
            StringBuilder res = new StringBuilder();
            while (start < s.Length)
            {
                res.Append(Get(s, ref start));
            }
            Console.WriteLine(res);
        }
    }
}
