using System;
using System.Collections.Generic;
using System.Text;

namespace Uber
{
    class ArrayToList
    {
        internal class Node
        {
            public int val;
            public Node next;
            public Node(int val)
            {
                this.val = val;
            }
        }
        public static List<Node> Get(int []a)
        {
            Dictionary<int, Node> nodeMap = new Dictionary<int, Node>();
            List<Node> res = new List<Node>();
            int[] degree = new int[a.Length];
            for (int i=0;i<a.Length;i++)
            {
                nodeMap[i] = new Node(a[i]);
                if(a[i]>=0 && a[i]<a.Length)
                {
                    degree[a[i]]++;
                }
            }

            for(int i=0;i<a.Length;i++)
            {
                if(a[i]>=0 && a[i]<a.Length)
                {
                    if(a[a[i]] == -1)
                    {
                        continue;
                    }
                    nodeMap[i].next = nodeMap[a[i]];
                }
            }

            for(int i=0;i<a.Length;i++)
            {
                if(degree[a[i]]==0 && a[i] != -1)
                {
                    res.Add(nodeMap[i]);
                }
            }
            

            return null;
        }
    }
}
