using System;
using System.Collections.Generic;
using System.Text;

namespace Misc
{
    public class Node
    {
        public int start;
        public int len;

        public Node(int v1, int v2)
        {
            this.start = v1;
            this.len = v2;
        }
    }
    public class NodeComparer : IComparer<Node>
    {
        public int Compare(Node x, Node y)
        {
            if(x.len == y.len)
            {
                return x.start - y.start;
            }

            return x.len - y.len;
        }
    }
    public class UberInterval
    {
        private SortedSet<Node> priority;
        private Dictionary<int, int> startSet = new Dictionary<int, int>();
        private Dictionary<int, int> endSet = new Dictionary<int, int>();
        private bool[] used;


        public UberInterval(int n)
        {
            used = new bool[n];
            priority  = new SortedSet<Node>(new NodeComparer());
            priority.Add(new Node(0, n));
            startSet.Add(0, n);
            endSet.Add(n - 1, n);
        }

        public int GetCar()
        {
            if(priority.Count == 0)
            {
                return -1;
            }

            Node max = priority.Max;
            priority.Remove(max);
            startSet.Remove(max.start);
            endSet.Remove(max.start + max.len - 1);
            int end = max.start + max.len - 1;
            int start = max.start;
            int res = max.start + (end - start)/2;
            if(res !=max.start)
            {
                priority.Add(new Node(max.start, res - start));
                startSet.Add(start, res - start);
                endSet.Add(res - 1, res - start);
            }
            if(res != end)
            {
                priority.Add(new Node(res + 1, end - res));
                startSet.Add(res + 1, end - res);
                endSet.Add(end, end - res);
            }

            used[res] = true;
            return res;
        }

        public void RemoveCar(int i)
        {
            if (!used[i])
                return;
            int start = -1;
            int end = -1;
            if(i>0 && !used[i-1] && i< used.Length-1 && !used[i+1])
            {
                start = i - endSet[i - 1];
                endSet.Remove(i - 1);
                end = i + 1;
            }
        }

        public static void Test()
        {
            UberInterval test = new UberInterval(10);

            for(int i=0;i<10;i++)
            {
                Console.WriteLine(test.GetCar());
            }

        }
    }
}
