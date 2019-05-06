using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class InFixToPostFix
    {       
        public static int Eval(List<String> post)
        {
            Stack<int> s = new Stack<int>();
            foreach (String str in post)
            {
                if (str[0] >= '0' && str[0] <= '9')
                {
                    s.Push(Int32.Parse(str));
                }
                else
                {
                    int b = s.Pop();
                    int a = s.Pop();
                    switch (str) { 
                        case "+":
                            s.Push(a + b);
                            break;
                        case "-":
                            s.Push(a - b);
                            break;
                        case "*":
                            s.Push(a * b);
                            break;
                        case "/":
                            s.Push(a / b);
                            break;
                    }
                }
            }
            return s.Pop();
        }
        public static int Get(String s)
        {
            Stack<char> stack = new Stack<char>();
            List<String> postFix = new List<string>();
            Dictionary<char, int> priority = new Dictionary<char, int>();
            priority.Add('+', 1);
            priority.Add('-', 1);
            priority.Add('*', 2);
            priority.Add('/', 2);
            priority.Add('(', -1);
            //priority.Add(')', 50);
            int i = 0;
            while (i < s.Length)
            {
                if(s[i]>='0' && s[i]<='9' || s[i]=='.')
                {
                    StringBuilder sb = new StringBuilder();
                    while(i<s.Length && s[i] >='0' && s[i]<='9')
                    {
                        sb.Append(s[i++]);
                    }
                    postFix.Add(sb.ToString());
                    continue;
                }

                if (s[i] == ' ')
                {
                    i++;
                    continue;
                }
                    

                switch(s[i])
                {
                    case '+':
                 
                    case '*':
                    case '/':
                        while (stack.Count !=0 && priority[stack.Peek()] >=priority[s[i]])
                        {
                            postFix.Add(""+stack.Pop());
                        }
                        stack.Push(s[i]);
                        break;
                    case '-':
                        // Binary one 
                        if(i > 0 && ((s[i-1] >='0' && s[i-1]<='9') || s[i-1] ==')'))
                        {
                            while (stack.Count != 0 && priority[stack.Peek()] >= priority[s[i]])
                            {
                                postFix.Add("" + stack.Pop());
                            }
                            stack.Push(s[i]);
                            break;
                        }
                        else
                        {
                            postFix.Add("0");
                            stack.Push('-');
                            break;
                        }
                    case '(':
                        stack.Push(s[i]);
                        break;
                    case ')':
                        while (stack.Count != 0 && stack.Peek() !='(')
                        {
                            postFix.Add("" + stack.Pop());
                        }
                        stack.Pop();
                        break;
                }
                i++;
            }
            while (stack.Count != 0)
            {
                postFix.Add("" + stack.Pop());
            }
            StringBuilder res = new StringBuilder();
            foreach(var token in postFix)
            {
                res.Append(token);
            }
            Console.WriteLine(res.ToString());
            return Eval(postFix);
        }
        public static void Test()
        {
            //Console.WriteLine(Get("1+1"));
            Console.WriteLine(Get("-2*-(3*4)"));
        }
    }

    
}
