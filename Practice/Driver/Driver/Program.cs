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
            LeetCode.Candy.Test();
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
    }
}
