using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class RandomPointer
    {
        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node() { }
            public Node(int _val, Node _next, Node _random)
            {
                val = _val;
                next = _next;
                random = _random;
            }
        }
            public static Node CopyRandomList(Node head)
        {
            Node curr = head;

            while (curr != null)
            {
                Node temp = new Node(curr.val, curr.next, curr.random);

                curr.next = temp;
                curr = temp.next;

            }
            curr = head;
            while (curr != null)
            {
                Console.WriteLine(curr.val);
                curr = curr.next;
            }
            curr = head;
            Node result = new Node(0, null, null);
            Node resultHead = result;
            curr = head;
            while (curr != null)
            {
                result.next = curr.next;
                curr.next.random = curr.next.random.next;

                result = result.next;
                curr = result.next;
            }
            curr = resultHead.next;
            while (curr != null)
            {
                Console.WriteLine(curr.val);
                curr = curr.next;
            }
            return resultHead.next;
        }

        public static void Test()
        {
            Node head = new Node(1, null, null);
            Node second = new Node(2, null, null);
            head.next = second;
            head.random = second;
            second.random = second;
            Node res = CopyRandomList(head);
            

        }
    }
}
