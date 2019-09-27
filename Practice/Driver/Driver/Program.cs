using Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using LeetCode;
namespace Driver
{
    class Program
    {
        class IntComparer : IComparer<int>
        {


            public int Compare(int x, int y)
            {
                return y - x;
            }
        }



        static void Main(string[] args)
        {
            //LeetCode.ReversePair.Test();
            Utils.SegmentTree.Test();
            /*int[] a = { 5, 4,6, 2, 1 };
            IComparer<int> comparer = new IntComparer();
            Utils.PriorityQueue<int> q = new Utils.PriorityQueue<int>(a,comparer);
            q.Add(0);
            q.PrintHeap();

            for(int i = 0; i < a.Length+1; i++)
            {
                Console.WriteLine(q.ExtractMin());
            }*/
            //Misc.ConsicutiveThree.Test();

            //Kadane2D.Test();

            //Uber.First.Test();
            //Console.WriteLine(Utils.SuffixArray.Get(new int[] { 3,2,3,4,1}));
            Console.ReadKey();
        }

        public int MaxRepOpt1(string s)
        {

            int n = s.Length;
            int i = 0;
            int res = 1;
            int[] first = new int[26];
            int[] second = new int[26];
            for (i = 0; i < n; i++)
            {
                first[s[n - i - 1] - 'a'] = n - i;
                second[s[i] - 'a'] = i + 1;
            }
            while (i < n)
            {
                int nextWindow = GetNextWindow(s, i);
                Console.WriteLine(nextWindow + ":" + i);
                int index = s[i] - 'a';
                if (first[index] != 0 && first[index] < i)
                {
                    res = Math.Max(res, nextWindow - i + 1);
                    i = nextWindow + 1;
                }
                else if (second[index] != 0 && second[index] > i)
                {
                    res = Math.Max(res, nextWindow - i + 1);
                    i = nextWindow + 1;
                }
                else
                {
                    res = Math.Max(res, nextWindow - i);
                    i = nextWindow;
                }


            }
            return res;

        }
        public int GetNextWindow(String s, int start)
        {
            bool missMatched = false;
            int res = start;
            for (int i = start + 1; i < s.Length; i++)
            {
                if (s[i - 1] != s[i])
                {
                    if (missMatched)
                        return i - 1;
                    else
                        missMatched = true;
                }
            }
            return s.Length - 1;
        }
    }

   


}
