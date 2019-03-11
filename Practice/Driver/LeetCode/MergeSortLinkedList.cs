using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class MergeSortLinkedList
    {
        public ListNode FindMedian(ListNode head)
        {
            ListNode fast = head;
            ListNode slow = head;
            ListNode prev = null;
            while (fast != null)
            {
                fast = fast.next;
                if (fast != null && fast.next !=null)
                {
                    fast = fast.next;
                }
                else
                    break;
                prev = slow;
                slow = slow.next;

            }

            return slow;
        }

        public ListNode SortList(ListNode head)
        {
            return MergeSort(head);
        }

        public ListNode MergeSort(ListNode head)
        {
            /*Console.WriteLine("SS-------------------");
            var curr = head;
            while (curr != null)
            {
                Console.WriteLine(curr.val);
                curr = curr.next;
            }
            Console.WriteLine("SS-------------------");*/
            if (head == null || head.next == null)
                return head;
            ListNode med = FindMedian(head);
            ListNode second = med.next;
            med.next = null;
            //Console.WriteLine("Mediun" + med.val);
            ListNode curr1 = MergeSort(head);
            ListNode curr2 = MergeSort(second);

            ListNode temp = new ListNode(-1);
            ListNode res = temp;
            while (curr1 != null && curr2 != null)
            {
                if (curr1.val <= curr2.val)
                {
                    temp.next = curr1;
                    curr1 = curr1.next;

                }
                else
                {
                    temp.next = curr2;
                    curr2 = curr2.next;
                }
                temp = temp.next;
            }
            while(curr1!=null)
            {
                temp.next = curr1;
                curr1 = curr1.next;
                temp = temp.next;
            }

            while (curr2 != null)
            {
                temp.next = curr2;
                curr2 = curr2.next;
                temp = temp.next;
            }
            //curr = res.next;
            /*Console.WriteLine("-------------------");
            while (curr != null)
            {
                Console.WriteLine(curr.val);
                curr = curr.next;
            }
            Console.WriteLine("-------------------");*/
            return res.next;
        }

        public static void Test()
        {
            ListNode head = new ListNode(5);
            head.next = new ListNode(4);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(2);
            head.next.next.next.next = new ListNode(1);
            new MergeSortLinkedList().MergeSort(head);
        }
    }
}
