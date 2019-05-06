using System;
using System.Collections.Generic;
using System.Text;

namespace Misc
{
    public class PathWithKObstecle
    {
        public class Node
        {
            public int x, y, d, rem;
            public Node(int x, int y, int d, int rem)
            {
                this.x = x;
                this.y = y;
                this.d = d;
                this.rem = rem;
            }
        }
        public static int GetPath(int [][] a, int sx, int sy, int tx, int ty,int maxObs)
        {
            int[][][] visited = new int[a.Length][][];
            for(int i=0;i<a.Length;i++)
            {
                visited[i] = new int[a[0].Length][];
                for(int j=0;j<a[0].Length;j++)
                {
                    visited[i][j] = new int[maxObs+1];
                    for(int k=0;k<= maxObs;k++)
                    {
                        visited[i][j][k] = -1;
                    }
                }
            }

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(new Node(sx, sy, 0, a[sx][sy] ==1?maxObs-1:maxObs));
            while(q.Count > 0)
            {
                Node curr = q.Dequeue();
                if (visited[curr.x][curr.y][curr.rem]!=-1)
                    continue;

                if (curr.x == tx && curr.y == ty)
                    return curr.d;
                
                if(curr.x>0)
                {
                    if(a[curr.x - 1][curr.y] == 0 || curr.rem>0)
                        q.Enqueue(new Node(curr.x - 1, curr.y, curr.d + 1, a[curr.x - 1][curr.y]==1?curr.rem-1:curr.rem));
                }
                if (curr.x <a.Length-1)
                {
                    if (a[curr.x + 1][curr.y] == 0 || curr.rem > 0)
                        q.Enqueue(new Node(curr.x + 1, curr.y, curr.d + 1, a[curr.x + 1][curr.y] == 1 ? curr.rem - 1 : curr.rem));
                }
                if (curr.y > 0)
                {
                    if (a[curr.x][curr.y-1] == 0 || curr.rem > 0)
                        q.Enqueue(new Node(curr.x, curr.y-1, curr.d + 1, a[curr.x][curr.y -1] == 1 ? curr.rem - 1 : curr.rem));
                }
                if (curr.y < a[0].Length-1)
                {
                    if (a[curr.x][curr.y+1] == 0 || curr.rem > 0)
                        q.Enqueue(new Node(curr.x, curr.y+1, curr.d + 1, a[curr.x][curr.y+1] == 1 ? curr.rem - 1 : curr.rem));
                }
                visited[curr.x][curr.y][curr.rem] = curr.d;
            }
            return -1;
        }

        public static void Test()
        {
            int[][] a = new int[4][];
            a[0] = new int[] { 0, 1, 1, 0, 1, 1, 1, 1 };
            a[1] = new int[] { 0, 0, 0, 1, 1, 1, 1, 0 };
            a[2] = new int[] { 0, 1, 1, 1, 1, 1, 1, 0};
            a[3] = new int[] { 0, 0, 0, 1, 0 ,0, 0, 0 };
            Console.WriteLine(GetPath(a, 0,0, 0, 7, 2));
        }
    }
}
