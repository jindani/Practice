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

        public static List<String> RepeateV2(String s, ref int start)
        {
            if (start == s.Length)
                return new List<string>();
            StringBuilder curr = new StringBuilder();
            List<String> res = new List<string>();
            while(start < s.Length)
            {
                switch(s[start])
                {
                    case '}':
                        start++;
                        if(curr.Length !=0)
                            res.Add(curr.ToString());
                        return res;
                    case ',':
                        start++;
                        if (curr.Length != 0)
                            res.Add(curr.ToString());
                        curr.Clear();
                        break;
                    case '{':
                        start++;
                        List<string> temp = RepeateV2(s,ref start);
                        String c = curr.ToString();
                        foreach(var str in temp)
                        {
                            res.Add(c + str);
                        }
                        curr.Clear();

                        break;
                    default:
                        curr.Append(s[start]);
                        start++;
                        break;
                }
            }
            if(curr.Length>0)
            {
                List<string> newRes = new List<string>();
                foreach(var ss in res)
                {
                    newRes.Add(ss + curr.ToString());
                }
                return newRes;
            }
            return res;
        }

        public static List<String> GetListFromString(StringBuilder sb)
        {
            List<String> res = new List<string>();
            res.Add(sb.ToString());
            sb.Clear();
            return res;
        }

        public static void Evaluate(List<Object> infix)
        {
            Stack<List<String>> stack = new Stack<List<string>>();

            foreach(Object ob in infix)
            {
                if(ob is char)
                {
                    List<String> b = stack.Pop();
                    List<String> a = stack.Pop();
                    char c =(char)ob;
                    if (c == '.')
                    {
                        stack.Push(Multiply(a, b));
                    }
                    else
                    {
                        stack.Push(Concat(a, b));
                    }
                }
                else
                {
                    stack.Push(ob as List<String>);
                }
            }

            List<String> res = stack.Pop();
            foreach(String s in res)
            {
                Console.WriteLine(s);
            }
        }

        private static List<string> Concat(List<string> a, List<string> b)
        {
            List<String> res = new List<String>();
            res.AddRange(a);
            res.AddRange(b);
            return res;
        }

        private static List<string> Multiply(List<string> a, List<string> b)
        {
            List<String> res = new List<String>();
            foreach (string s in a)
            {
                foreach (string t in b)
                {
                    res.Add(s + t);
                }
            }
            return res;
        }

        public static void RepeateInfix(String s)
        {
            Stack<char> stack = new Stack<char>();
            List<Object> res = new List<Object>();
            StringBuilder sb = new StringBuilder();
            int i = 0;
            while(i<s.Length)
            {
                switch (s[i])
                {
                    case '{':
                        if (sb.Length > 0)
                            res.Add(GetListFromString(sb));
                        stack.Push('.');
                        stack.Push('{');
                        break;
                    case '}':
                        if (sb.Length > 0)
                            res.Add(GetListFromString(sb));
                        while (stack.Peek() != '{')
                            res.Add(stack.Pop());
                        stack.Pop();

                        break;
                    case ',':
                        if (sb.Length > 0)
                            res.Add(GetListFromString(sb));
                        while (stack.Peek() == '.' )
                        {
                            res.Add(stack.Pop());
                        }
                        stack.Push(',');
                        break;
                    default:
                        if (i > 0 && s[i - 1] =='}')
                            stack.Push('.');
                        sb.Append(s[i]);
                        break;
                }
                i++;
            }
            if (sb.Length > 0)
                res.Add(GetListFromString(sb));
            while (stack.Count > 0)
                res.Add(stack.Pop());
            foreach(var item in res)
            {
                if(item is char)
                {
                    Console.WriteLine(item);
                }
                else
                {
                    foreach(string str in item as List<String>)
                    {
                        Console.WriteLine(str);
                    }
                }
            }
            Evaluate(res);
        }
        public static void TestV2()
        {
            /*int start = 0;
            String s = "abc{x{c,d},y{e,df}}xxyy{a{y,b},x{ccc,111}}";
            List<String> res = new List<string>();
            res.Add("");
            while(start < s.Length)
            {
                List<String> temp = RepeateV2(s, ref start);
                List<String> newRes = new List<string>();
                
                foreach(var ss in res)
                {
                    foreach(var tt in temp)
                    {
                        newRes.Add(ss + tt);
                    }
                }
                res = newRes;
            }

            foreach (var ss in res)
                Console.WriteLine(ss);*/

            String s = "a{a,b,c,d,e,f,g{a,b,c,d,e,f,g}}";
            RepeateInfix(s);
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
