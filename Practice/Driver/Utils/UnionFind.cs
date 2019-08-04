using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public class UnionFind    {        int n;        int count;        int[] p;        int[] r;

        public UnionFind(int n)        {            this.n = n;            p = new int[n];            r = new int[n];            for (int i = 0; i < n; i++)                p[i] = i;            count = n;        }        public int Find(int x)        {            if (x != p[x])                p[x] = Find(p[x]);            return p[x];        }

        public bool Union(int x, int y)        {            int a = Find(x);            int b = Find(y);

            if (a == b)                return false;            count--;            if (r[a] > r[b])                p[b] = a;            else            {                p[a] = b;                if (r[a] == r[b])                    r[b]++;            }            return true;        }        public bool IsConnected(int x, int y)        {            return Find(x) == Find(y);        }

        public int GetCount()        {            return count;        }    }
    public class UnionFindG<T>    {        int n;        int count;        int[] p;        int[] r;
        int addIndex;
        Dictionary<T, int> map = new Dictionary<T, int>();
        public UnionFindG(int n)        {            this.n = n;            p = new int[n];            r = new int[n];            for (int i = 0; i < n; i++)                p[i] = i;            count = n;            addIndex = 0;        }        public int Find(T x)        {
            return Find(map[x]);
        }
        public int Find(int x)        {            if (x != p[x])                p[x] = Find(p[x]);            return p[x];        }
        public bool Union(T x, T y)        {
            int a = -1;
            int b = -1;
            if(map.ContainsKey(x))
            {
                a = map[x];
            }
            else
            {
                a = addIndex++;
                map[x] = a;
            }
            if(map.ContainsKey(y))
            {
                b = addIndex++;
                map[x]=b;
            }
            return Union(x, y);
        }
        public bool Union(int x, int y)        {            int a = Find(x);            int b = Find(y);

            if (a == b)                return false;            count--;            if (r[a] > r[b])                p[b] = a;            else            {                p[a] = b;                if (r[a] == r[b])                    r[b]++;            }            return true;        }        public bool IsConnected(T x, T y)
        {
            return Find(x) == Find(y);
        }        public bool IsConnected(int x, int y)        {            return Find(x) == Find(y);        }

        public int GetCount()        {            return count;        }    }
}
