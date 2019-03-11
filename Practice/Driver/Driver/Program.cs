using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arrays;
using LeetCode;
namespace Driver
{
    class Program
    {
        class IntComparer : System.Collections.IComparer
        {
            public int Compare(object x, object y)
            {
                return (int)x - (int)y;
            }
        }
        static void Main(string[] args)
        {
            //Multiply.Test();
            /*int[] a = { 5, 4,6, 2, 1 };
            System.Collections.IComparer comparer = new IntComparer();
            Utils.PriorityQueue<int> q = new Utils.PriorityQueue<int>(a,null);
            q.Add(0);
            q.PrintHeap();

            for(int i = 0; i < a.Length+1; i++)
            {
                Console.WriteLine(q.ExtractMin());
            }*/

            MergeSortLinkedList.Test();
            Console.ReadKey();
        }
    }
}
