﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public class UnionFind

        public UnionFind(int n)

        public bool Union(int x, int y)

            if (a == b)

        public int GetCount()
    public class UnionFindG<T>
        int addIndex;
        Dictionary<T, int> map = new Dictionary<T, int>();
        public UnionFindG(int n)
            return Find(map[x]);
        }
        public int Find(int x)
        public bool Union(T x, T y)
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
        public bool Union(int x, int y)

            if (a == b)
        {
            return Find(x) == Find(y);
        }

        public int GetCount()
}