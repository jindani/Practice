using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class DominoComparer
    {
        int x;
        int y;
        public DominoComparer(int x, int y)
        {
            this.x = x > y ? y : x;
            this.y = x > y ? x : y;
        }

        public override bool Equals(object obj)
        {
            DominoComparer otherDomino = obj as DominoComparer;
            return this.x == otherDomino.x && this.y == otherDomino.y;
        }
        public override int GetHashCode()
        {
            int val = x * 100000 + y;
            return val.GetHashCode();
        }
        public class Node
        {
            public int x;
            public int d;
            public Node(int x, int d)
            {
                this.x = x;
                this.d = d;
            }
        }
        public int[] ShortestAlternatingPaths(int n, int[][] red_edges, int[][] blue_edges)
        {
            List<List<int>> g = new List<List<int>>();
            for (int i = 0; i < 2 * n; i++)
            {
                g.Add(new List<int>());
            }

            foreach (int[] e in red_edges)
            {
                g[e[0]].Add(e[1] + n);
            }

            foreach (int[] e in red_edges)
            {
                g[e[0] + n].Add(e[1]);
            }

            Queue<Node> q = new Queue<Node>();
            int[] d = new int[n];
            for (int i = 0; i < n; i++)
                d[i] = -1;

            bool[] visited = new bool[n * 2];

            q.Enqueue(new Node(0, 0));
            q.Enqueue(new Node(n, 0));
            visited[0] = true;
            visited[n] = true;
            d[0] = 0;

            while (q.Count > 0)
            {
                Node curr = q.Dequeue();
                foreach (int e in g[curr.x])
                {
                    if (!visited[e])
                    {
                        visited[e] = true;
                        q.Enqueue(new Node(e, curr.d + 1));
                        if (d[e % n] == -1)
                            d[e % n] = curr.d + 1;
                        else
                            d[e % n] = Math.Min(curr.d, d[e % n]);
                    }
                }
            }

            return d;

        }
        public static int Get(int[][] a)
        {
            Dictionary<DominoComparer, int> map = new Dictionary<DominoComparer, int>();
            for (int i = 0; i < a.Length; i++)
            {
                DominoComparer dc = new DominoComparer(a[i][0], a[i][1]);
                if (map.ContainsKey(dc))
                {
                    map[dc]++;
                }
                else
                {
                    map[dc] = 1;
                }
            }
            int res = 0;
            foreach (int val in map.Values)
            {
                if (val > 1)
                {
                    res += val * (val + 1) / 2;
                }
            }
            return res;
        }
    }
    
}
