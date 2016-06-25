using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SICPPractise.Algorithm.Internal;

namespace SICPPractise.Algorithm.List
{
    public class ListPuzzle
    {
        /// <summary>
        /// #21 Merge Two Sorted Lists:  Normal Process
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public static ListNode MergeTwoLists1(ListNode l1, ListNode l2)
        {
            if (l1 == null)
            {
                return l2;
            }
            if (l2 == null)
            {
                return l1;
            }
            ListNode head = null;
            if (l1.val < l2.val)
            {
                head = l1;
                l1 = l1.next;
            }
            else
            {
                head = l2;
                l2 = l2.next;
            }
            var node = head;
            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    node.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    node.next = l2;
                    l2 = l2.next;
                }
                node = node.next;
            }
            node.next = l1 == null ? l2 : l1;
            return head;
        }

        /// <summary>
        /// #21 Merge Two Sorted Lists: recursive process.
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public static ListNode MergeTwoLists2(ListNode l1, ListNode l2)
        {
            if (l1 == null)
            {
                return l2;
            }
            if (l2 == null)
            {
                return l1;
            }
            var head = l1.val < l2.val ? l1 : l2;
            head.next = l1.val < l2.val ? MergeTwoLists2(l1.next, l2) : MergeTwoLists2(l1, l2.next);
            return head;
        }

        public static ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            while (headA != headB && !(headA == null && headB == null))
            {
                headA = headA.next == null ? headB : headA.next;
                headB = headB.next == null ? headA : headB.next;
            }
            return headA;
        }

        public static ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            var newHead = head.next;
            var node1 = head.next;
            var node2 = head;
            while (node1 != null && node1.next != null)
            {
                var temp = node1.next;
                node1.next = node2;
                node2.next = temp.next == null ? temp : temp.next;
                node1 = temp.next;
                node2 = temp;
            }
            if (node1 != null)
            {
                node1.next = node2;
                node2.next = null;
            }
            return newHead;
        }

        public class MinStack
        {
            private Stack<int> s = new Stack<int>();
            private Stack<int> p = new Stack<int>();
            public void Push(int x)
            {
                s.Push(x);
                if (p.Count() == 0 || x <= p.Peek())
                {
                    p.Push(x);
                }
            }

            public void Pop()
            {
                var i = s.Pop();
                if (i == p.Peek())
                {
                    p.Pop();
                }
            }

            public int Top()
            {
                return s.Peek();
            }

            public int GetMin()
            {
                return p.Peek();
            }
        }

        public bool HasCycle(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return false;
            }
            var slow = head;
            var fast = head.next.next;

            while (slow != fast && fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow == fast;
        }

        public ListNode DetectCycle(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return null;
            }
            var slow = head;
            var fast = head.next.next;

            while (slow != fast && fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow == fast ? null : slow;
        }

        public ListNode Partition1(ListNode head, int x)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            var node = head;
            ListNode pre = null;

            while (node != null && node.val < x)
            {
                pre = node;
                node = node.next;
            }
            var partition = pre;
            while (node != null)
            {
                while (node != null && node.val >= x)
                {
                    pre = node;
                    node = node.next;
                }
                if (node != null)
                {
                    if (partition == null)
                    {
                        var tmp = node.next;
                        node.next = head;
                        partition = node;
                        pre.next = tmp;
                        head = node;
                        node = tmp;
                    }
                    else
                    {
                        var tmp1 = node.next;
                        var tmp2 = partition.next;
                        partition.next = node;
                        node.next = tmp2;
                        pre.next = tmp1;
                        partition = node;
                        node = tmp1;
                    }
                }
            }
            return head;
        }

        public ListNode Partition2(ListNode head, int x)
        {
            ListNode h1 = null;
            ListNode h2 = null;
            ListNode n1 = null;
            ListNode n2 = null;
            var node = head;

            while (node != null)
            {
                if (node.val < x)
                {
                    if (h1 == null)
                    {
                        h1 = node;
                        n1 = h1;
                    }
                    else
                    {
                        n1.next = node;
                        n1 = node;
                    }
                }
                else
                {
                    if (h2 == null)
                    {
                        h2 = node;
                        n2 = h2;
                    }
                    else
                    {
                        n2.next = node;
                        n2 = node;
                    }
                }
                node = node.next;
            }
            if (h1 == null || h2 == null)
            {
                return head;
            }
            n1.next = h2;
            n2.next = null;
            return h1;
        }

        public ListNode InsertionSortList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            var node = head.next;
            head.next = null;

            while (node != null)
            {
                var cur = head;
                ListNode pre = null;
                while (cur != null && cur.val <= node.val)
                {
                    pre = cur;
                    cur = cur.next;
                }
                var tmp = node.next;
                if (cur == head)
                {
                    node.next = head;
                    head = node;
                }
                else
                {
                    pre.next = node;
                    node.next = cur;
                }
                node = tmp;
            }
            return head;
        }

        public ListNode ReverseBetween1(ListNode head, int m, int n)
        {
            if (m == n)
            {
                return head;
            }
            ListNode pre = null;
            var start = head;
            var j = 1;

            while (j < m)
            {
                pre = start;
                start = start.next;
                j++;
            }
            var node1 = start;
            var node2 = start.next;
            while (j < n)
            {
                var tmp = node2.next;
                node2.next = node1;
                node1 = node2;
                node2 = tmp;
                j++;
            }
            start.next = node2;
            if (pre != null)
            {
                pre.next = node1;
                return head;
            }
            return node1;
        }

        public ListNode ReverseBetween2(ListNode head, int m, int n)
        {
            if (m == n)
            {
                return head;
            }
            ListNode pre = null;
            var node1 = head;

            while (m > 1)
            {
                pre = node1;
                node1 = node1.next;
                m--;
                n--;
            }
            var node2 = node1.next;
            while (n > 1)
            {
                var tmp = node2.next;
                node2.next = node1;
                node1 = node2;
                node2 = tmp;
                n--;
            }
            if (pre == null)
            {
                head.next = node2;
                return node1;
            }
            pre.next.next = node2;
            pre.next = node1;
            return head;
        }

        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            ListNode pre = null;
            var node = head;

            while (node != null)
            {
                var tmp = node.next;
                while (tmp != null && tmp.val == node.val)
                {
                    tmp = tmp.next;
                }
                if (tmp == node.next)
                {
                    pre = node;
                }
                else if (pre == null)
                {
                    head = tmp;
                }
                else
                {
                    pre.next = tmp;
                }
                node = tmp;
            }
            return head;
        }

        public ListNode SortList1(ListNode head)
        {            
            return SortList1Helper(head);
        }
        private ListNode SortList1Helper(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            var smallHead = new ListNode(0);
            var largeHead = new ListNode(0);
            var small = smallHead;
            var equal = head;
            var large = largeHead;
            var node = head.next;

            while (node != null)
            {
                if (node.val == head.val)
                {
                    equal.next = node;
                    equal = equal.next;
                }
                else if (node.val < head.val)
                {
                    small.next = node;
                    small = small.next;
                }
                else
                {
                    large.next = node;
                    large = large.next;
                }
                node = node.next;
            }
            small.next = null;
            large.next = null;
            var s = SortList1Helper(smallHead.next);
            var l = SortList1Helper(largeHead.next);
            if(s==null)
            {
                equal.next = l;
                return head;
            }
            var tmp = s;
            while (s.next != null)
            {
                s = s.next;
            }
            s.next = head;
            equal.next = l;
            return tmp;
        }

        public static ListNode SortList2(ListNode head)
        {
            return SortList2Helper(head);
        }
        private static ListNode SortList2Helper(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            var fast = head;
            var slow = head;
            var pre = head;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                pre = slow;
                slow = slow.next;
            }
            pre.next = null;
            var l1 = SortList2Helper(head);
            var l2 = SortList2Helper(slow);
            ListNode newHead = null;
            if (l1.val < l2.val)
            {
                newHead = l1;
                l1 = l1.next;
            }
            else
            {
                newHead = l2;
                l2 = l2.next;
            }
            var node = newHead;
            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    node.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    node.next = l2;
                    l2 = l2.next;
                }
                node = node.next;
            }
            while (l1 != null)
            {
                node.next = l1;
                l1 = l1.next;
                node = node.next;
            }
            while (l2 != null)
            {
                node.next = l2;
                l2 = l2.next;
                node = node.next;
            }
            return newHead;
        }

        //TODO: complete merge sort from bottom to up. complete quick sort.
        //Compare and detail of kinds of sorting algorithm

    }
}
