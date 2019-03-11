using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace LeetCode
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        int len;
        T[] a;
        IComparer comparer;

        public PriorityQueue(T[] a) : this(a, null)
        {


        }
        public PriorityQueue(T[] a, IComparer comparer)
        {
            this.comparer = comparer;
            this.a = a;
            len = a.Length;
            if (a.Length != 0)
            {
                BuildHeap();
            }

        }

        private void BuildHeap()
        {
            for (int i = len / 2; i >= 0; i--)
            {
                Heapyfy(i);
            }
        }

        public void Add(T item)
        {
            if(a.Length == 0)
            {
                a = new T[10];
            }
            if (a.Length == len)
            {
                T[] newArray = new T[a.Length * 2];
                for (int i = 0; i < len; i++)
                {
                    newArray[i] = a[i];
                }
                a = newArray;

            }
            a[len] = item;
            int parent = len>0?(len - 1) / 2:-1;
            if(parent == -1)
            {
                len++;
                return;
            }
            int c = len;
            while (parent >= 0 && (comparer != null ? comparer.Compare(a[parent], a[c]) > 0 : a[parent].CompareTo(a[c]) > 0))
            {
                T temp = a[parent];
                a[parent] = a[c];
                a[c] = temp;
                c = parent;
                parent = (c - 1) / 2;
            }
            len++;
        }
        public T ExtractMin()
        {
            if (len > 0)
            {
                T res = a[0];
                a[0] = a[len - 1];
                Heapyfy(0);
                len--;
                return res;
            }
            return default(T);
        }
        public int Count()
        {
            return len;
        }

        private void Heapyfy(int i)
        {
            int l = i * 2 + 1;
            int r = i * 2 + 2;
            int largest = i;
            if (l < len && (comparer != null ? comparer.Compare(a[i], a[l]) > 0 : a[i].CompareTo(a[l]) > 0))
            {
                largest = l;
            }
            if (r < len && (comparer != null ? comparer.Compare(a[largest], a[r]) > 0 : a[largest].CompareTo(a[r]) > 0))
            {
                largest = r;
            }

            if (i != largest)
            {
                T temp = a[i];
                a[i] = a[largest];
                a[largest] = temp;
                Heapyfy(largest);
            }
        }

        public void PrintHeap()
        {
            Console.WriteLine("----------------------------");
            for (int i = 0; i < len; i++)
            {
                Console.WriteLine(a[i]);
            }
            Console.WriteLine("----------------------------");
        }
    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    public class PriorityNode: IComparable<PriorityNode>
    {
        public ListNode data;
        public int index;

        public PriorityNode(ListNode data, int index)
        {
            this.data = data;
            this.index = index;
        }

        public int CompareTo(PriorityNode other)
        {
            return this.data.val - other.data.val;
        }
    }

    public class MergeKSortedList
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            PriorityQueue<PriorityNode> q = new PriorityQueue<PriorityNode>(new PriorityNode[0]);
            ListNode res = new ListNode(0);
            ListNode ret = res;
            for(int i = 0; i < lists.Length; i++)
            {
                if (lists[i] != null)
                {
                    q.Add(new PriorityNode(lists[i],i));
                }
            }

            while (q.Count() > 0)
            {
                PriorityNode node = q.ExtractMin();
                res.next = node.data;
                res = res.next;
                if(node.data.next !=null)
                    q.Add(new PriorityNode(node.data.next,node.index));
            }
            
            return ret.next;
        }

        public static void Test()
        {
            ListNode[] lists = new ListNode[1];
            ListNode a = new ListNode(1);
            a.next=new ListNode(2);
            a.next.next = new ListNode(3);
            lists[0] = a;
            ListNode sort = new MergeKSortedList().MergeKLists(lists);
        }

    }
}
