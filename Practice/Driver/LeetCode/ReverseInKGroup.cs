using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class ReverseListK
    {
        public bool IsLengthGEThanK(ListNode head, int k)
        {
            while(head!=null && k > 0)
            {
                head = head.next;
                k--;
            }
            if (k == 0)
                return true;
            return false;
        }
        public ListNode[] ReverseList(ListNode head, int k)
        {
            ListNode prev = null;
            var curr = head;
            if(!IsLengthGEThanK(head, k))
            {
                return new ListNode[] { head, head, null };
            }
            while (curr != null && k > 0)
            {
                var temp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = temp;
                k--;

            }
            head.next = null;
            PrintList(prev);

            Console.WriteLine("-------------------");
            return new ListNode[] { prev, head, curr };
        }
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            ListNode curr = head;
            ListNode[] prevRes = new ListNode[] { new ListNode(-1), new ListNode(-1), new ListNode(-1) };
            ListNode ret = prevRes[1] ;

            do
            {
                ListNode[] temp = ReverseList(curr, k);
                Console.WriteLine(prevRes[0].val + ":" + prevRes[1].val + ":" + (prevRes[2] != null ? prevRes[2].val : -1));
                Console.WriteLine(temp[0].val+":"+ temp[1].val+":"+ (temp[2] != null ? temp[2].val : -1));
                prevRes[1].next = temp[0];
                curr = temp[2];
                prevRes = temp;

            } while (curr != null);

            return ret.next;


        }

        public static void Test()
        {

            ListNode a = new ListNode(1);
            a.next = new ListNode(2);
            a.next.next = new ListNode(3);
            a.next.next.next = new ListNode(4);
            a.next.next.next.next = new ListNode(5);
           // a.next.next.next.next.next = new ListNode(6);

            PrintList(new ReverseListK().ReverseKGroup(a,3));
        }
        public static void PrintList(ListNode a)
        {
            while(a!=null)
            {
                Console.WriteLine(a.val);
                a = a.next;
            }
        }
    }
}
