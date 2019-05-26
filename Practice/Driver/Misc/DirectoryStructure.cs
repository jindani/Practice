using System;
using System.Collections.Generic;
using System.Text;

namespace Misc
{
    public class DirectoryStructure
    {
        public static int GetMax(String s)
        {
            int i = 0;
            int currLevel = 0;
            int currLen = 0;
            int res = 0;
            Stack<int> stack = new Stack<int>();
            while(i<s.Length)
            {
                switch(s[i])
                {
                    case '\t':
                        currLevel++;
                        break;
                    case '\n':
                        while (stack.Count >= currLevel + 1)
                            stack.Pop();
                        if (currLevel == stack.Count)
                        {
                            stack.Push((stack.Count > 0 ? stack.Peek(): 0) + currLen);
                            res = Math.Max(res, stack.Peek());
                        }
                        currLen = 0;
                        currLevel = 0;
                        break;
                    default:
                        currLen++;
                        break;
                }
                i++;
            }

            while (stack.Count >= currLevel + 1)
                stack.Pop();
            if (currLevel  == stack.Count)
            {
                stack.Push((stack.Count > 0 ? stack.Peek() : 0)+ currLen);
                res = Math.Max(res, stack.Peek());
            }
            return res;
        }

        public static void Test()
        {
            string s = "abc\n\taaaaaaaaaaa\n\tb\n\t\tccccc\n\t\t\tdddddddd\n\td\n\t\teee\n\t\t\txyz";
            Console.Write(s);
            Console.WriteLine();
            Console.WriteLine(GetMax(s));
        }
    }
}
