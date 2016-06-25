using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SICPPractise.Algorithm.Internal;

namespace SICPPractise.Algorithm.List
{
    public static class GoodSolution
    {
        /// <summary>
        /// #328 Odd Even Linked List
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode OddEvenList(ListNode head)
        {
            if (head == null || head.next == null || head.next.next == null)
            {
                return head;
            }
            var evenHead = head.next;
            var odd = head;
            var even = evenHead;
            while (even != null && even.next != null)
            {
                odd.next = even.next;
                even.next = even.next.next;
                odd = odd.next;
                even = even.next;
            }
            odd.next = evenHead;
            return head;
        }

        /// <summary>
        /// #83 Remove Duplicates from Sorted List
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode DeleteDuplicate(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            var node = head;
            while (node != null)
            {
                var i = node.next;
                while (i != null && i.val == node.val)
                {
                    i = i.next;
                }
                node.next = i;
                node = node.next;
            }
            return head;
        }

        /// <summary>
        /// 108. Convert Sorted Array to Binary Search Tree
        /// * Learn from quick sort.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static TreeNode SortedArrayToBST(int[] nums)
        {
            return SortedArrayToBSTIter(nums, 0, nums.Length - 1);
        }
        private static TreeNode SortedArrayToBSTIter(int[] nums, int start, int end)
        {
            if (start > end)
            {
                return null;
            }
            var mid = (start + end) / 2;
            var node = new TreeNode(nums[mid]);
            node.left = SortedArrayToBSTIter(nums, start, mid - 1);
            node.right = SortedArrayToBSTIter(nums, mid + 1, end);
            return node;
        }

        /// <summary>
        /// #6 ZigZag Conversion
        /// * Have a clear mind.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public static string Convert2(string s, int numRows)
        {
            var l = s.Length;
            var gap = numRows == 1 ? 1 : 2 * numRows - 2;
            var ret = "";

            for (var i = 0; i < numRows; i++)
            {
                for (var j = i; j < l; j += gap)
                {
                    ret += s[j];
                    if (j + gap - 2 * i < l && 2 * i != 0 && 2 * i != gap)
                    {
                        ret += s[j + gap - 2 * i];
                    }
                }
            }
            return ret;
        }
    }
}
