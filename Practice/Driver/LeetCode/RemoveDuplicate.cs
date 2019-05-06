using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class RemoveDuplicate
    {
        public  class Node
        {
            public int index;
            public char c;
            public int[] occ;
            public Node(char c, int index, int[] occ)
            {
                this.c = c;
                this.index = index;
                this.occ = occ;
            }
        }

        public int GetMin(List<Node> nodes, int start, bool[] used)
        {

            int min = start;
            for(int i=start;i<nodes.Count;i++)
            {
                if (used[nodes[i].c - 'a'])
                    continue;
                if (nodes[i].occ[nodes[i].c - 'a'] > 0)
                {
                    min = nodes[min].c <= nodes[i].c ? min : i;
                }
                else
                {
                    min = nodes[min].c <= nodes[i].c ? min : i;
                    break;
                }
                    
            }
            return min;
        }
        public string RemoveDuplicateLetters(string s)
        {
            int n = s.Length;
            int[] occ = new int[26];
            List<Node> nodes = new List<Node>();
            for (int i = n - 1; i >= 0; i--)
            {
                nodes.Add(new Node(s[i], i, (int[])occ.Clone()));
                occ[s[i] - 'a']++;
            }
            nodes.Reverse();
            StringBuilder sb = new StringBuilder();
            bool[] res = new bool[26];
            int j = 0;
            while(j<n)
            {
                if (res[nodes[j].c - 'a'])
                {
                    j++;
                    continue;
                }

                int min = GetMin(nodes, j ,res);
                if(res[nodes[min].c-'a'])
                {
                    j = min + 1;
                }
                else
                {
                    sb.Append(nodes[min].c);
                    res[nodes[min].c - 'a'] = true;
                    j = min + 1;
                }
            }
            return sb.ToString();
        }

        public static void Test()
        {
            Console.WriteLine(new RemoveDuplicate().RemoveDuplicateLetters("sdsdvsd"));
        }
    }
}
