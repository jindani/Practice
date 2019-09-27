using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public class SegmentTree
    {
        int n;
        int[] tree;

        public static void Test()
        {
            int[] a =new int[] { 0,1, 2, 3, 4, 5, 6, 7 };
            SegmentTree st = new SegmentTree(a);
            Console.WriteLine(st.Query(0, 7));
            Console.WriteLine(st.Query(0, 2));
            Console.WriteLine(st.Query(2, 3));
            Console.WriteLine(st.Query(2, 7));
            st.Update(2, 10);

            Console.WriteLine(st.Query(0, 7));
            Console.WriteLine(st.Query(0, 2));
            Console.WriteLine(st.Query(2, 3));
            Console.WriteLine(st.Query(2, 7));
            Console.WriteLine(st.Query(0, 0));
        }
        public SegmentTree(int[] a)
        {
            this.n = a.Length;
            this.tree = new int[n*4];
            BuildTree(0, a, 0, n-1);
        }

        private void BuildTree(int node, int[] a, int start, int end)
        {
            if (start == end)

            {
                tree[node] = a[start];
                return;
            }

            int mid = start + (end - start) / 2;

            BuildTree(node * 2+1, a, start, mid);
            BuildTree(node * 2 + 2, a, mid + 1, end);

            tree[node] = tree[node * 2+1] + tree[node * 2 + 2];
        }

        public int Query(int l, int r)
        {
            return Query(0, 0, n - 1, l, r);
        }
        private int Query(int node, int start, int end, int l, int r)
        {
            if (start > r || end < l)
            {
                return 0;
            }

            if (l <= start && end <= r)
                return tree[node];

            int mid = start + (end - start) / 2;
            int p1 = Query(node * 2+1, start, mid, l, r);
            int p2 = Query(node * 2 + 2, mid+1, end, l, r); ;
            return p1 + p2;

        }

        public void Update(int id, int val)
        {
            Update(0, 0, n - 1, id, val);
        }
        private void Update(int node, int start, int end, int id, int val)
        {
            if(start == end)
            {
                tree[node] = val;
                return;
            }

            int mid = start + (end - start) / 2;
            if (id <= mid)
                Update(node * 2+1, start, mid, id, val);
            else
                Update(node * 2 + 2, mid + 1, end, id, val);
            tree[node] = tree[node * 2+1] + tree[node * 2 + 2];
        }
    }
}
