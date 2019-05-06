using System;
using System.Collections.Generic;
using System.Text;

namespace Misc
{
    public class ConsicutiveThree
    {
        public static int GetMissing(string s)
        {
            int n = s.Length;
            int start = 0;
            int end = n / 3;
            while(start < end)
            {
                int mid = start + (end - start) / 2;

                if(s[mid*3] == s[mid*3+1] && s[mid*3+2] == s[mid*3])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid;
                }
            }
            return s[start*3]-'0';
        }

        public static void Test()
        {
            Console.WriteLine(GetMissing("11"));
        }
    }
}
