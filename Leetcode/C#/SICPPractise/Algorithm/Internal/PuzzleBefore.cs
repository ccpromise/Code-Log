using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.SymbolStore;
using System.Globalization;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters;
using System.Threading;
using SICPPractise.Algorithm.Internal;


namespace SICPPractise.Algorithm.Internal
{
    public class Puzzle
    {
        public static int CountChange(double x)
        {
            return CountChangeIter(x, new[] { 1, 0.5, 0.25, 0.1, 0.05, 0.01 });
        }

        public static bool CanWinNim(int n)
        {
            return CanWinNimIter(n, 0);
        }

        public static List<Tuple<int, int>> TwoSum(IList<int> numbers, int target)
        {
            var n = numbers.Count;
            var indexes = new List<Tuple<int, int>>();

            for (var i = 0; i <= n - 1; i++)
            {
                for (var j = i + 1; j <= n - 1; j++)
                {
                    if (numbers[i] + numbers[j] == target)
                    {
                        indexes.Add(new Tuple<int, int>(i + 1, j + 1));
                    }
                }
            }
            return indexes;
        }

        public static int AddDigits1(int number)
        {
            if (number < 10)
            {
                return number;
            }
            int sum = 0;
            while (number != 0)
            {
                sum = sum + number%10;
                number = number/10;
            }
            return AddDigits1(sum);
        }
        


        public static int AddDigits2(int num)
        {
            var n = num%9;
            switch (n)
            {
                case 0:
                    return 9;
                default:
                    return n;
            }
        }

        public static int MaxDepth1(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            if (root.left == null && root.right == null)
            {
                return 1;
            }
            return 1 + System.Math.Max(MaxDepth1(root.left), MaxDepth1(root.right));
        }

        public static int MaxDepth2(TreeNode root)
        {
            var count = 1;
            if (root == null)
            {
                return 0;
            }
            return MaxDepth2Iter(root, ref count);
        }

        public static void DeleteNode(ListNode node)
        {
            ListNode next = node.next;
            node.val = next.val;
            node.next = next.next;
        }

        public static TreeNode InvertTree1(TreeNode root)
        {
            if(root == null)
            {
                return null;
            }
            if (root.left == null && root.right == null)
            {
                return root;
            }
            TreeNode tmp = root.left;
            root.left = root.right;
            root.right = tmp;
            root.left = InvertTree1(root.left);
            root.right = InvertTree1(root.right);
            return root;
        }

        public static TreeNode InvertTree2(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }
            Queue<TreeNode> nodeQueue = new Queue<TreeNode>();
            nodeQueue.Enqueue(root);

            while(nodeQueue.Count != 0)
            {
                var node = nodeQueue.Dequeue();

                if(node.left != null)
                {
                    nodeQueue.Enqueue(node.left);
                }
                if(node.right != null)
                {
                    nodeQueue.Enqueue(node.right);
                }
                var tmp = node.left;
                node.left = node.right;
                node.right = tmp;
            }
            return root;
        }

        public static void MoveZeros1(int[] arr)
        {
            var i = 0;
            var j = 0;
            var n = arr.Count();
            while (j <= n - 1)
            {
                while (arr[i] != 0 && i <= n - 2)
                {
                    i = i + 1;
                }
                if (i > n - 2)
                {
                    break;
                }
                j = i + 1;
                while (j <= n - 1 && arr[j] != 0)
                {
                    j = j + 1;
                }
                if (j > n - 1)
                {
                    break;
                }
                var tmp = arr[i];
                arr[i] = arr[j];
                arr[j] = tmp;
                i = i + 1;
                j = j + 1;
            }
        }

        public static void MoveZeros2(int[] arr)
        { 
            var n = arr.Count();
            int[] newArr = new int[n];
            var i = 0;
            var j = 0;
            for (; i <= n - 1; i++)
            {
                if (arr[i] != 0)
                {
                    newArr[j] = arr[i];
                    j = j + 1;
                }
            }
            for (i = j; i <= n - 1; i++)
            {
                newArr[i] = 0;
            }
            newArr.CopyTo(arr, 0);
        }

        public static void MoveZeros3(int[] nums)
        {
            int i = 0;
            int j = 0;
            var n = nums.Count();

            for (; i <= n - 1; i++)
            {
                if (nums[i] != 0)
                {
                    nums[j] = nums[i];
                    j++;
                }
            }

            for (; j <= n - 1; j++)
            {
                nums[j] = 0;
            }
        }

        public static bool IsSameTree1(TreeNode p, TreeNode q)
        {
            //if (p == null )
            //{
            //    return q == null;
            //}
            //if (q == null)
            //{
            //    return false;
            //}
            //if (p.val != q.val)
            //{
            //    return false;
            //}
            //return IsSameTree1(p.left, q.left) && IsSameTree1(p.right, q.right);
            return p == null || q == null ? p == q : (p.val == q.val) && IsSameTree1(p.left, q.left) && IsSameTree1(p.right, q.right);
        }

        public static bool IsSameTree2(TreeNode p, TreeNode q)
        {
            //if (p == null)
            //{
            //    return q == null;
            //}
            //if (q == null)
            //{
            //    return false;
            //}

            if (p == null || q == null)
            {
                return p == q;
            }

            Queue<TreeNode> nodesP = new Queue<TreeNode>();
            Queue<TreeNode> nodesQ = new Queue<TreeNode>();
            nodesP.Enqueue(p);
            nodesQ.Enqueue(q);
            while (nodesP.Count != 0)
            {
                TreeNode a = nodesP.Dequeue();
                TreeNode b = nodesQ.Dequeue();
                //if (a.val != b.val)
                //{
                //    return false;
                //}
                //if ((a.left == null && b.left != null) || (a.left != null && b.left == null))
                //{
                //    return false;
                //}
                //if ((a.right == null && b.right != null) || (a.right != null && b.right == null))
                //{
                //    return false;
                //}
                //if (a.left != null && b.left != null)
                //{
                //    nodesP.Enqueue(a.left);
                //    nodesQ.Enqueue(b.left);
                //}
                //if (a.right != null && b.right != null)
                //{
                //    nodesP.Enqueue(a.right);
                //    nodesQ.Enqueue(b.right);
                //}
                if (a.val != b.val)
                    return false;
                if (a.left != null)
                    nodesP.Enqueue(a.left);
                if (b.left != null)
                    nodesQ.Enqueue(b.left);
                if (nodesP.Count != nodesQ.Count)
                    return false;
                if (a.right != null)
                    nodesP.Enqueue(a.right);
                if (b.right != null)
                    nodesQ.Enqueue(b.right);
                if (nodesP.Count != nodesQ.Count)
                    return false;
            }
            return true;
        }

        public static bool IsAnagram1(string s, string t)
        {
            Hashtable ht = new Hashtable();
            var n = s.Length;

            if (n != t.Length)
            {
                return false;
            }

            for (var i = 0; i <= n - 1; i++)
            {
                if (!ht.ContainsKey(s[i]))
                {
                    ht.Add(s[i], 1);
                }
                else
                {
                    ht[s[i]] = (int)ht[s[i]] + 1;
                }
            }
            for (var i = 0; i <= n - 1; i++)
            {
                if (!ht.ContainsKey(t[i]))
                {
                    return false;
                }
                if ((int)ht[t[i]] == 0)
                {
                    return false;
                }
                ht[t[i]] = (int)ht[t[i]] - 1;
            }
            var values = ht.Values;
            foreach (var v in values)
            {
                if ((int)v != 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsAnagram2(string s, string t)
        {
            var count = new int[128];
            if (s.Length != t.Length)
            {
                return false;
            }
            foreach (var c in s)
            {
                count[c]++;
            }
            foreach (var c in t)
            {
                if (count[c] == 0)
                {
                    return false;
                }
                count[c]--;
            }
            foreach (var n in count)
            {
                if (n != 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool ContainsDuplicate(int[] nums)
        {
            var ht = new Hashtable();
            if (nums == null)
            {
                return false;
            }
            if (nums.Count() == 0)
            {
                return false;
            }
            foreach (var n in nums)
            {
                if (!ht.ContainsKey(n))
                {
                    ht.Add(n, 1);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public static bool ContainsDuplicate2(int[] nums)
        {
            HashSet<int> a = new HashSet<int>();
            if (nums == null || nums.Count() == 0)
            {
                return false;
            }
            foreach (var n in nums)
            {
                if (a.Add(n) == false)
                {
                    return true;
                }
            }
            return false;
        }

        public static int TitleToNumber(string s)
        {
            var n = s.Length;
            var colnum = 0;
            for (var i = 0; i < n; i++)
            {
                colnum = colnum + (int)System.Math.Pow(26, n - i - 1)*(s[i] - 'A' + 1);
            }
            return colnum;
        }

        public static int MajorityNumber1(int[] nums)
        {
            Dictionary<int, int> countValues = new Dictionary<int, int>();
            var length = nums.Length;
            foreach (var n in nums)
            {
                if (!countValues.ContainsKey(n))
                {
                    countValues.Add(n, 0);
                }
                countValues[n] += 1;
                if (countValues[n] > length/2)
                {
                    return n;
                }
            }
            return 0;
        }

        public static int MajorityNumber2(int[] nums)
        {
            Dictionary<int, int> countValues = new Dictionary<int, int>();
            var length = nums.Length;
            for(var i=0;i<length;i++)
            {
                var n = nums[i];
                if (countValues.ContainsKey(n) && countValues[n] + length - i <= length / 2)
                {
                    countValues.Remove(n);
                    if (countValues[n] + length - i > length/2)
                    {
                        countValues[n] += 1;
                    }
                    if (countValues[n] > length/2)
                    {
                        return n;
                    }
                }
                else if (i < length/2)
                {
                    countValues.Add(n, 1);
                }
            }
            return 0;
        }

        /// <summary>
        /// this one is not right.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public static TreeNode LowestCommonAncestor1(TreeNode root, TreeNode p, TreeNode q)
        {
            if (p == q || (p.left != null && p.left == q) || (p.right != null && p.right == q))
            {
                return p;
            }
            if ((q.left != null && q.left == p) || (q.right != null && q.right == p))
            {
                return q;
            }

            var parentP = FindParent(root, p);
            var parentQ = FindParent(root, q);

            return LowestCommonAncestor1(root, parentP, parentQ);
        }



        public static TreeNode LowestCommonAncestor2(TreeNode root, TreeNode p, TreeNode q)
        {
            var parentsP = FindAllParents(root, p);
            var parentsQ = FindAllParents(root, q);
            foreach (var x in parentsP)
            {
                if (parentsQ.Contains(x))
                {
                    return x;
                }
            }
            return null;
        }

        public static TreeNode LowestCommonAncestor3(TreeNode root, TreeNode p, TreeNode q)
        {
            var index = new Dictionary<TreeNode, int>();

            TagNodes(root, 0, index);

            var n = index[p];
            var m = index[q];

            while (n != m)
            {
                if (n > m)
                {
                    n = (n - 1) / 2;
                }
                if (m > n)
                {
                    m = (m - 1) / 2;
                }
            }
            foreach (var x in index)
            {
                if (x.Value == n)
                {
                    return x.Key;
                }
            }
            return root;
        }

        public static TreeNode LowestCommonAncestor4(TreeNode root, TreeNode p, TreeNode q)
        {
            if ((p.val - root.val)*(q.val - root.val) < 0 || p==root || q==root)
            {
                return root;
            }
            if (p.val - root.val > 0 && q.val - root.val > 0)
            {
                return LowestCommonAncestor4(root.right, p, q);
            }
            return LowestCommonAncestor4(root.left, p, q);
        }

        public static ListNode OddEvenList1(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            var e = head;
            var o = head.next;
            var o1 = head.next;
            while (e.next!=null&&e.next.next!=null&&o.next!=null&&o.next.next!=null)
            {
                e.next = e.next.next;
                o.next = o.next.next;
                e = e.next;
                o = o.next;
            }
            if (o.next != null)
            {
                e.next = o.next;
                e = e.next;
                o.next = null;
            }
            e.next = o1;
            return head;
        }

        public static ListNode OddEvenList2(ListNode head)
        {
            if (head == null)
            {
                return null;
            }
            var o = head;
            var e = head.next;
            var e1 = e;
            while (o.next != null && o.next.next != null)
            {
                o.next = o.next.next;
                o = o.next;
                if(e.next != null && e.next.next != null)
                {
                    e.next = e.next.next;
                    e = e.next;
                }
            }
            o.next = e1;
            if (e != null)
            {
                e.next = null;
            }
            return head;
        }

        public static ListNode OddEvenList3(ListNode head)
        {
            if (head==null)
            {
                return null;
            }
            var odd = head;
            var even = head.next;
            var evenHead = head.next;
            while (even != null && even.next != null)
            {
                odd.next = odd.next.next;
                even.next = even.next.next;
                odd = odd.next;
                even = even.next;
            }
            odd.next = evenHead;
            return head;
        }

        public static ListNode ReverseList1(ListNode head)
        {
            if (head == null)
            {
                return null;
            }
            var nodes = new Stack<ListNode>();
            var n = head;

            while (n.next != null)
            {
                nodes.Push(n);
                n = n.next;
            }
            head = n;
            while(nodes.Count != 0)
            {
                n.next = nodes.Pop();
                n = n.next;
            }
            n.next = null;
            return head;
        }

        public static ListNode ReverseList2(ListNode head)
        {
            if (head == null)
            {
                return null;
            }
            var x = head;
            var y = head.next;
            head.next = null;
            while (y != null)
            {
                var tmp = y.next;
                y.next = x;
                x = y;
                y = tmp;
            }
            return x;
        }


        public static int HammingWeight(uint n)
        {
            uint weight = 0;

            while (n != 0)
            {
                weight += n%2;
                n = n/2;
            }
            return (int)weight;
        }

        internal enum RomanSymbol
        {
            I = 1,
            V = 5,
            X = 10,
            L = 50,
            C = 100,
            D = 500,
            M = 1000
        }

        public static int RomanToInt(string s)
        {
            var x = 0;
            RomanSymbol n;
            RomanSymbol m;
            var i = 0;

            for (; i < s.Length - 1; i++)
            {
                RomanSymbol.TryParse(s[i].ToString(), out n);
                RomanSymbol.TryParse(s[i+1].ToString(), out m);


                if (n == RomanSymbol.I && (m == RomanSymbol.V || m == RomanSymbol.X))
                {
                    x = x - (int)n + (int)m;
                    i = i + 1;
                }
                else if (n == RomanSymbol.X && (m == RomanSymbol.L || m ==  RomanSymbol.C))
                {
                    x = x - (int)n + (int)m;
                    i = i + 1;
                }
                else if (n == RomanSymbol.C && (m == RomanSymbol.D || m == RomanSymbol.M))
                {
                    x = x - (int)n + (int)m;
                    i = i + 1;
                }
                else
                {
                    x = x + (int) n;
                }
            }
            if (i == s.Length - 1)
            {
                RomanSymbol.TryParse(s.Last().ToString(), out n);
                x = x + (int)n;
            }
            return x;
        }

        public static ListNode DeleteDuplicates1(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            var h = head;
            while (h != null)
            {
                var n = h.next;
                while (n != null && n.val == h.val)
                {
                    n = n.next;
                }
                h.next = n;
                h = h.next;
            }

            return head;
        }

        public static ListNode DeleteDuplicates2(ListNode head)
        {
            if (head == null)
            {
                return null;
            }
            var p = head;
            var q = head.next;

            while(q!=null)
            {
                if (p.val!=q.val)
                {
                    p.next = q;
                    p = p.next;
                }
                q= q.next;
            }
            p.next = null;
            return head;
        }

        public static ListNode DeleteDuplicates3(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            head.next = DeleteDuplicates3(head.next);
            return head.val == head.next.val ? head.next : head;
        }

        public static int ClimbStairs1(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            if (n < 0)
            {
                return 0;
            }
            return ClimbStairs1(n - 1) + ClimbStairs1(n - 2);
        }

        public static int ClimbStairs2(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }
            var a = 1;
            var b = 1;
            int c = 0;
            while (n > 1)
            {
                c = a + b;
                a = b;
                b = c;
                n--;
            }
            return c;
        }

        public static bool IsUgly1(int n)
        {
            if (n == 1)
            {
                return true;
            }
            if (n%2 == 0)
            {
                return IsUgly1(n/2);
            }
            if (n%3 == 0)
            {
                return IsUgly1(n/3);
            }
            if (n%5 == 0)
            {
                return IsUgly1(n/5);
            }
            return false;
        }

        public static bool IsUgly2(int n)
        {
            if (n <= 0)
            {
                return false;
            }
            while (n%2 == 0) n = n/2;
            while (n%3 == 0) n = n/3;
            while (n%5 == 0) n = n/5;
            return n == 1;
        }

        public static bool IsHappyNumber(int n)
        {
            var set = new HashSet<int>();
            int sum;

            do
            {
                sum = 0;
                while (n > 0)
                {
                    sum = sum + (int)System.Math.Pow(n%10, 2);
                    n = n/10;
                }
                n = sum;
            } while (set.Add(sum));
            return sum == 1;
        }

        public static bool IsPowOfThree1(int n)
        {
            switch (n)
            {
                case 0:
                    return false;
                case 1:
                    return true;
                default:
                    return n%3 == 0 && IsPowOfThree1(n/3);
            }
        }

        public static bool IsPowOfThree2(int n)
        {
            if (n == 0)
                return false;
            while (n%3 == 0)
                n = n/3;
            return n == 1;
        }

        public static bool IsPowOfTwo(int n)
        {
            return n>0&&(n&(n-1))!=0;
        }

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
            ListNode h = null;
            if (l1.val <= l2.val)
            {
                h = l1;
                l1 = l1.next;
            }
            else
            {
                h = l2;
                l2 = l2.next;
            }
            ListNode m = h;
            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    m.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    m.next = l2;
                    l2 = l2.next;
                }
                m = m.next;
            }
            var l3 = l1 == null ? l2 : l1;
            while (l3 != null)
            {
                m.next = l3;
                l3 = l3.next;
                m = m.next;
            }
            m.next = null;
            return h;
        }

        public static ListNode MergeTwoLists2(ListNode l1, ListNode l2)
        {
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;
            ListNode h = null;
            var x = l1.val <= l2.val;
            h = x ? l1 : l2;
            h.next = x ? MergeTwoLists2(l1.next, l2) : MergeTwoLists2(l1, l2.next);
            return h;
        }

        public static class Queue
        {
            private static Stack h = new Stack();
            private static Stack t = new Stack();

            public static void Push(int x)
            {
                h.Push(x);
            }

            public static void Pop()
            {
                while (h.Count != 0)
                {
                    t.Push(h.Pop());
                }
                t.Pop();
                while (t.Count != 0)
                {
                    h.Push(t.Pop());
                }
            }

            public static int Peak()
            {
                while (h.Count != 0)
                {
                    t.Push(h.Pop());
                }
                var x = (int)t.Pop();
                while (t.Count != 0)
                {
                    h.Push(t.Pop());
                }
                return x;
            }

            public static bool Empty()
            {
                return h.Count == 0;
            }
        }

        public static bool IsBalanced(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }
            Console.WriteLine(MaxDepth2(root.left));
            Console.WriteLine(MaxDepth2(root.right));
            return System.Math.Abs(MaxDepth2(root.left) - MaxDepth2(root.right)) <= 1 && IsBalanced(root.right) && IsBalanced(root.left);
        }

        public static bool IsSymmetric1(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }
            var lQueue = new Queue<TreeNode>();
            var rQueue = new Queue<TreeNode>();

            if (root.left != null)
            {
                lQueue.Enqueue(root.left);
            }
            if (root.right != null)
            {
                rQueue.Enqueue(root.right);
            }
            if (lQueue.Count != rQueue.Count)
            {
                return false;
            }

            while (lQueue.Count != 0)
            {
                var l = lQueue.Dequeue();
                var r = rQueue.Dequeue();

                if (l.val != r.val)
                {
                    return false;
                }
                if (l.left != null)
                {
                    lQueue.Enqueue(l.left);
                }
                if (r.right != null)
                {
                    rQueue.Enqueue(r.right);
                }
                if (lQueue.Count != rQueue.Count)
                {
                    return false;
                }
                if (l.right != null)
                {
                    lQueue.Enqueue(l.right);
                }
                if (r.left != null)
                {
                    rQueue.Enqueue(r.left);
                }
                if (lQueue.Count != rQueue.Count)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsSymmetric2(TreeNode root)
        {
            return root==null||IsSymmetricIter(root.left, root.right);
        }

        public static bool IsSymmetricIter(TreeNode l, TreeNode r)
        {
            if (l == null && r == null)
            {
                return true;
            }
            if (l == null || r == null)
            {
                return false;
            }
            return l.val == r.val && IsSymmetricIter(l.left, r.right) && IsSymmetricIter(l.right, r.left);
        }

        public static int RemoveElements(int[] nums, int val)
        {
            var flag = 0;

           for (var k = 0; k < nums.Length; k++)
            {
                if (nums[k] != val)
                {
                    nums[flag] = nums[k];
                    flag++;
                }
            }
            return flag;
        }

        public static int RemoveDuplicates(int[] nums)
        {
            var flag = 0;

            for (var k = 1; k < nums.Length; k++)
            {
                if (nums[k] != nums[flag])
                {
                    flag++;
                    nums[flag] = nums[k];
                }
            }
            return flag+1;
        }

        public static int[] PlusOne(int[] digits)
        {
            var i = digits.Length - 1;

            while (i >= 0)
            {
                if (digits[i] >= 0 && digits[i] < 9)
                {
                    digits[i]++;
                    break;
                }
                digits[i] = 0;
                i--;
            }
            if (i == -1)
            {
                var n = digits.Length + 1;
                var newDigits = new int[n];
                newDigits[0] = 1;
                digits.CopyTo(newDigits, 1);
                return newDigits;
            }
            return digits;
        }

        public static IList<IList<int>> Generate(int numRows)
        {
            var pascalTri = new List<IList<int>>(numRows);
            var i = 2;
            pascalTri.Add(new[] {1});
            while (i <= numRows)
            {
                var line = new int[i];
                line[0] = 1;
                for (var j = 0; j < i - 2; j++)
                {
                    line[j+1]= pascalTri[i-2][j]+pascalTri[i-2][j+1];
                }
                line[i-1] = 1 ;
                pascalTri.Add(line);
                i++;
            }
            return pascalTri;
        }

        public static IList<IList<int>> LevelOrderBottom1(TreeNode root)
        {
            var bottomUpTraversal = new List<IList<int>>();

            var nodeTag = new Dictionary<int, TreeNode>();

            if (root != null)
            {
                TagTreeNodes(root, 0, nodeTag);
                var tag = nodeTag.Keys;
                var nLevelMax = System.Math.Floor(System.Math.Log(tag.Max()+1, 2));

                for (var i = nLevelMax; i >=0 ; i--)
                {
                    var level = new List<int>();
                    for (var j = System.Math.Pow(2, i)-1; j <= System.Math.Pow(2, i+1) - 2; j++)
                    {
                        if (nodeTag.ContainsKey((int)j))
                        {
                            level.Add(nodeTag[(int)j].val);
                        }
                    }
                    bottomUpTraversal.Add(level);
                }
            }
            return bottomUpTraversal;
        }

        public static IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            if (root != null)
            {
                TagLevel(root, 0);
            }
            var newNodeTag = new List<IList<int>>();
            for (var i = nodeTag.Count - 1; i >= 0; i--)
            {
                newNodeTag.Add(nodeTag[i]);
            }
            return newNodeTag;
        }

        private static IList<IList<int>> nodeTag = new List<IList<int>>();
        private static void TagLevel(TreeNode node, int level)
        {
            if (level == nodeTag.Count)
            {
                nodeTag.Add(new List<int>());
            }
            nodeTag[level].Add(node.val);
            if (node.left != null)
            {
                TagLevel(node.left, level+1);
            }
            if (node.right != null)
            {
                TagLevel(node.right, level+1);
            }
        }

        public static IList<int> GetRow(int rowIndex)
        {
            var row = new List<int>(rowIndex);
            for(var i = 0; i < rowIndex; i++)
            {
                row[i] = FindTriEle(rowIndex, i+1);
            }
            return row;
        }

        public static IList<IList<int>> LevelOrder(TreeNode root)
        {            
            if(root!=null)
            {
                TagLevel1(root, 1);
            }
            return levelOrder;
        }

        public static bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null)
            {
                return false;
            }
            if (root.left == null && root.right == null)
            {
                return root.val == sum;
            }
            return HasPathSum(root.left, sum - root.val) || HasPathSum(root.right, sum - root.val);
        }

        public static bool IsPalindrome(int x)
        {
            if (x < 0)
            {
                return false;
            }
            var n = x;
            var reverse = 0;
            while (n != 0)
            {
                reverse = reverse * 10 + n % 10;
                n = n / 10;
            }
            return x == reverse;           
        }

        public static bool IsPalindrome2(int x)
        {
            if (x < 0 || (x>0 && x%10==0))
            {
                return false;
            }
            var reverse = 0;
            while (reverse < x)
            {
                reverse = reverse * 10 + x % 10;
                x = x / 10;
            }
            return x == reverse || x == reverse / 10;
        }

        public static int MinDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            var depth = 1;
            return FindMinDepth(root, depth);
        }

        public int MinDepth2(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            var queue = new Queue<Tuple<TreeNode, int>>();
            queue.Enqueue(new Tuple<TreeNode, int>(root, 1));

            while (queue.Count != 0)
            {
                var pair = queue.Dequeue();
                var node = pair.Item1;
                var depth = pair.Item2;
                if (node.left == null && node.right == null)
                {
                    return depth;
                }
                if (node.left != null)
                {
                    queue.Enqueue(new Tuple<TreeNode, int>(node.left, depth + 1));
                }
                if (node.right != null)
                {
                    queue.Enqueue(new Tuple<TreeNode, int>(node.right, depth + 1));
                }
            }
            return 0;
        }

        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            var nodeA = headA;
            var nodeB = headB;

            while (nodeA != null)
            {
                while (nodeB != null)
                {
                    if (nodeB == nodeA)
                    {
                        break;
                    }
                    nodeB = nodeB.next;
                }
                if (nodeB == nodeA)
                {
                    break;
                }
                nodeA = nodeA.next;
            }
            return nodeA;
        }

        // The original structure is changed.
        public ListNode GetIntersectionNode2(ListNode headA, ListNode headB)
        { 
            var listA = new Stack<ListNode>();
            var listB = new Stack<ListNode>();

            while (headA != null)
            {
                listA.Push(headA);
                headA = headA.next;
            }
            ListNode newHeadA = null;
            if (listA.Count != 0)
            {
                newHeadA = listA.Pop();
                var h = newHeadA;
                while (listA.Count != 0)
                {
                    h.next = listA.Pop();
                    h = h.next;
                }
                h.next = null;
            }

            while (headB != null)
            {
                listA.Push(headB);
                headB = headB.next;
            }
            ListNode newHeadB = null;
            if (listB.Count != 0)
            {
                newHeadB = listA.Pop();
                var h = newHeadB;
                while (listB.Count != 0)
                {
                    h.next = listB.Pop();
                    h = h.next;
                }
                h.next = null;
            }
            ListNode intersection = null;
            while (newHeadA == newHeadB && newHeadA!=null && newHeadB!=null)
            {
                intersection = newHeadA;
                newHeadA = newHeadA.next;
                newHeadB = newHeadB.next;
            }
            return intersection;
        }

        public ListNode GetIntersectionNode3(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null)
            {
                return null;
            }
            var a = headA;
            var b = headB;
            while (a != b)
            {
                a = a == null ? headB : a.next;
                b = b == null ? headA : b.next;
            }
            return a;
        }

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            var j = 0;
            for (var i = 0; i < n; i++)
            {
                for (; j < m; j++)
                {
                    if (nums2[i] < nums1[j])
                    {
                        for (var k = m - 1; k >= j; k--)
                        {
                            nums1[k + 1] = nums1[k];
                        }
                        nums1[j] = nums2[i];
                        m = m + 1;
                        break;
                    }
                }
                if (j == m)
                {
                    for (j = m; j < m + n - i; j++)
                    {
                        nums1[j] = nums2[i + j - m];
                    }
                    break;
                }
            }
        }

        public void Merge2(int[] nums1, int m, int[] nums2, int n)
        {
            if (n != 0)
            {
                var i = m-1;
                while (nums1[i] < nums2[n - 1] && i < m)
                {
                    i--;
                }
                for (var k = m; k > i; k--)
                {
                    nums1[k] = nums1[k - 1];
                }
                nums1[i] = nums2[n - 1];
                Merge2(nums1, m+1, nums2, n-1);
            }
        }

        public bool IsValidSudoku(char[,] board)
        {
            var size = board.GetLength(1);
            for (var i = 0; i < size; i++)
            {
                var rowSet = new HashSet<char>();
                for (var j = 0; j < size; j++)
                {
                    if (board[i,j]!='.'&&!rowSet.Add(board[i, j]))
                    {
                        return false;
                    }
                }
                var colSet = new HashSet<char>();
                for (var j = 0; j < size; j++)
                {
                    if (board[j,i]!='.'&&!colSet.Add(board[j, i]))
                    {
                        return false;
                    }
                }
            }
            for (var i = 0; i <= size - 3; i += 3)
            {
                for (var j = 0; j <= size - 3; j += 3)
                {
                    var subBorad = new HashSet<char>();
                    for (var p = 0; p < 3; p++)
                    {
                        for (var q = 0; q < 3; q++)
                        {
                            if (board[i + p, j + q] != '.' && !subBorad.Add(board[i + p, j + q]))
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public bool IsValidSudoku2(char[,] board)
        {
            var colSet = new bool[9, 9];
            var rowSet = new bool[9, 9];
            var boardSet = new bool[9, 9];
            for (var i = 0; i < 9; i++)
            {
                for (var j = 0; j < 9; j++)
                {
                    if (board[i, j] != '.')
                    {
                        var num = board[i, j] - '0' - 1;
                        var k = i / 3 * 3 + j / 3;
                        if (colSet[j, num] || rowSet[i, num] || boardSet[k, num])
                        {
                            return false;
                        }
                        colSet[j, num] = true;
                        rowSet[i, num] = true;
                        boardSet[k, num] = true;
                    }
                }
            }
            return true;
        }

        public int ComputeArea(int A, int B, int C, int D, int E, int F, int G, int H)
        {
            var width = OverLap(A, C, E, G);
            var height = OverLap(B, D, F, H);
            return (C - A)*(D - B) + (G - E)*(H - F) - width*height;
        }

        private int OverLap(int a, int b, int c, int d)
        {
            if (a <= c && b <= d && b >= c)
            {
                return b - c;
            }
            if (c <= a && d <= b && d >= a)
            {
                return d - a;
            }
            if (a >= c && a <= d && b >= c && b <= d)
            {
                return b - a;
            }
            if (c >= a && c <= b && d >= a && d <= b)
            {
                return d - c;
            }
            return 0;
        }

        public bool ContainNearbyDuplicate(int[] nums, int k)
        {
            for (var i = 0; i < nums.Length - 1; i++)
            {
                for (var j = i + 1; j <= i + k && j < nums.Length; j++)
                {
                    if (nums[j] == nums[i])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ContainNearbyDuplicate2(int[] nums, int k)
        {
            var set = new HashSet<int>();

            for (var i = 0; i < nums.Length; i++)
            {
                if (i > k)
                {
                    set.Remove(nums[i - k - 1]);
                }
                if (!set.Add(nums[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public int LengthOfLastWord(string s)
        {
            var i = s.Length - 1;
            var k = 0;
            while (i>=0 && s[i] == ' ')
            {
                i--;
            }
            while (i >= 0 && s[i] != ' ')
            {
                k++;
                i--;
            }
            return k;
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var l = new List<ListNode>();
            var t = head;
            while (t != null)
            {
                l.Add(t);
                t = t.next;
            }

                t = head;
                for (var i = 1; i < l.Count - n; i++)
                {
                    t.next = l[i];
                    t = t.next;
                }
                for (var i = l.Count - n + 1; i < l.Count; i++)
                {
                    t.next = l[i];
                    t = t.next;
                }
                t.next = null;
                return n==l.Count?head.next:head;
        }

        public ListNode RemoveNthFromEnd2(ListNode head, int n)
        {
            var s = new Stack<ListNode>();
            var t = head;
            if (t != null)
            {
                while (t != null)
                {
                    s.Push(t);
                    t = t.next;
                }
                for (var i = 1; i <= n; i++)
                {
                    t = s.Pop();
                }
                if (t == head)
                {
                    return head.next;
                }
                if (t.next == null)
                {
                    t = s.Pop();
                    t.next = null;
                    return head;
                }
                t.val = t.next.val;
                t.next = t.next.next;
                return head;
            }
            return head;
        }

        public bool IsIsomorphic(string s, string t)
        {
            var d1 = new Dictionary<char, int>(s.Length);
            var d2 = new Dictionary<char, int>(t.Length);

            for (var i = 0; i < s.Length; i++)
            {
                var p = d1.ContainsKey(s[i]);
                var q = d2.ContainsKey(t[i]);
                if ((p & !q) || (!p & q))
                {
                    return false;
                }
                if (p & q)
                {
                    if (d1[s[i]] != d2[t[i]])
                    {
                        return false;
                    }
                    continue;
                }
                d1.Add(s[i],i);
                d2.Add(t[i],i);
            }
            return true;
        }

        public bool IsIsomorphic2(string s, string t)
        {
            var charArrays = new int[256];
            var charArrayt = new int[256];

            for (var i = 0; i < s.Length; i++)
            {
                if (charArrays[s[i]] != charArrayt[t[i]])
                    return false;
                charArrays[s[i]] = i+1;
                charArrayt[t[i]] = i+1;
            }
            return true;
        }

        public bool IsValid(string s)
        {
            var i = 0;
            var left = new Stack<char>();
            while (i < s.Length)
            {
                if (s[i] == '(' || s[i] == '{' || s[i] == '[')
                {
                    left.Push(s[i]);                    
                }
                else
                {
                    if (left.Count == 0)
                    {
                        return false;
                    }
                    var tmp = left.Pop();
                    if (tmp == '(' && s[i] != ')' || tmp == '[' && s[i] != ']' || tmp == '{' && s[i] != '}')
                    {
                        return false;
                    }
                }
                i++;
            }
            return left.Count==0;
        }

        public string GetHint(string secret, string guess)
        {
            var bulls = 0;
            var cows = 0;
            var index = new int[9];
            for (var i = 0; i < secret.Length; i++)
            {
                if (secret[i] == guess[i])
                {
                    bulls++;
                }
                else
                {
                    index[secret[i]-'0']++;
                }
            }
            for (var i = 0; i < secret.Length; i++)
            {
                if (secret[i] != guess[i] && index[guess[i]]!=0)
                {
                    cows++;
                    index[guess[i]]--;
                }
            }
            var hint = bulls + "A" + cows + "B";
            return hint;
        }

        public bool WordPattern(string pattern, string str)
        {
            var i = 0;
            var n = -1;
            var words = new Dictionary<string, char>();
            while (i < str.Length)
            {
                var j = i;
                while (j < str.Length && str[j] != ' ')
                {
                    j++;
                }
                n++;
                if (n >= pattern.Length)
                {
                    return false;
                }
                var s = str.Substring(i, j - i);
                if (!words.ContainsKey(s))
                {
                    if (words.ContainsValue(pattern[n]))
                    {
                        return false;
                    }
                    words.Add(s, pattern[n]);
                }
                if (words[s] != pattern[n])
                {
                    return false;
                }
                i = j + 1;
            }
            return n == pattern.Length - 1;
        }

        public static string CountAndSay(int n)
        {
            if (n == 1)
            {
                return "1";
            }
            var s = "11";
            var i = 2;
            while (i < n)
            {
                i++;
                var tmp = "";
                var j = 1;
                while (j < s.Length)
                {
                    var count = 1;
                    while (j < s.Length && s[j] == s[j - 1])
                    {
                        j++;
                        count++;
                    }
                    tmp += count;
                    tmp += s[j-1];
                    if (j == s.Length - 1)
                    {
                        tmp += "1";
                        tmp += s[j];
                        break;
                    }
                    j++;
                }
                s = tmp;
            }
            return s;
        }

        public static ListNode RemoveElements(ListNode head, int val)
        {
            while (head!=null&&head.val == val)
            {
                head = head.next;
            }
            if (head == null)
            {
                return null;
            }
            var h = head;
            var t = head.next;
            while (t != null)
            {
                if(t.val != val)
                {
                    t = t.next;
                    h = h.next;
                    continue;
                }
                h.next = t.next;
                t = t.next;
            }
            return head;
        }

        public static ListNode RemoveElements2(ListNode head, int val)
        {
            if (head == null)
            {
                return null;
            }
            if (head.val == val)
            {
                return RemoveElements2(head.next, val);
            }
            head.next = RemoveElements2(head.next, val);
            return head;
        }

        public string LongestCommonPrefix(string[] strs)
        {
            var comPre = "";
            var i = 0;
            if (strs.Length == 0)
            {
                return "";
            }
            while (i<strs[0].Length)
            {
                for (var j = 1; j < strs.Length; j++)
                {
                    if (i>=strs[j].Length||strs[j][i] != strs[0][i])
                    {
                        return comPre;
                    }
                }
                comPre += strs[0][i];
                i++;
            }
            return comPre;
        }

        public IList<string> BinaryTreePaths(TreeNode root)
        {
            if (root == null)
            {
                return new List<string>();
            }
            var flag = true;
            var path = new List<List<TreeNode>>() {new List<TreeNode>() {root}};
            while (flag)
            {
                flag = false;
                for(var i=0;i<path.Count;i++)
                {
                    var p = path[i];
                    if (p.Last().left != null)
                    {
                        AddNewNode(p.Last().left, p, path);
                        flag = true;
                    }
                    if (p.Last().right != null)
                    {
                        AddNewNode(p.Last().right, p, path);
                        flag = true;
                    }
                }
            }
            var answer = new List<string>();
            foreach (var p in path)
            {
                var tmp = p[0].val.ToString();
                for(var i=1;i<p.Count;i++)
                {
                    tmp += "->";
                    tmp += p[i].val;
                }
                answer.Add(tmp);
            }
            return answer;
        }

        public static IList<string> BinaryTreePaths2(TreeNode head)
        {
            if (head == null)
            {
                return new List<string>();
            }
            IList<string> path1 = new List<string>();
            IList<string> path2 = new List<string>();
            if (head.left != null)
            {
                path1 = BinaryTreePaths2(head.left);
                for (var i = 0; i < path1.Count; i++)
                {
                    path1[i] = head.val + "->" + path1[i];
                }
            }
            if (head.right != null)
            {
                path2 = BinaryTreePaths2(head.right);
                for (var i = 0; i < path2.Count; i++)
                {
                    path2[i] = head.val + "->" + path2[i];
                }
            }
            foreach (var p in path2)
            {
                path1.Add(p);
            }
            return head.left == null && head.right == null?new List<string> { head.val.ToString() }: path1;
        }

        public bool IsPalindrome(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return true;
            }
            var h = head;
            var t = h.next;
            while (t.next != null)
            {
                h = t;
                t = t.next;
            }
            h.next = null;
            return head.val == t.val && IsPalindrome(head.next);
        }

        public bool IsPalindrome2(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return true;
            }
            var stack = new Stack<ListNode>();
            var tmp = head;
            var k = 1;
            while (tmp != null)
            {
                stack.Push(tmp);
                tmp = tmp.next;
                k++;
            }
            var h= head;
            for (var i = 1; i <= k/2; i++)
            {
                var t = stack.Pop();
                if (h.val != t.val)
                {
                    return false;
                }
                h = h.next;
            }
            return true;
        }

        public string AddBinary(string a, string b)
        {
            var bit = 0;
            var sum = "";
            var lengthA = a.Length;
            var lengthB = b.Length;
            if (lengthA < lengthB)
            {
                var i = 0;
                while (i < lengthB - lengthA)
                {
                    a = a.Insert(0, "0");
                    i++;
                }
            }
            if (lengthA > lengthB)
            {
                var i = 0;
                while (i < lengthA - lengthB)
                {
                    b = b.Insert(0, "0");
                    i++;
                }
                
            }
            for (var i = lengthA - 1; i >= 0; i--)
            {
                switch (a[i]-'0'+b[i]-'0'+bit)
                {
                    case 0:
                        sum = sum.Insert(0, "0");
                        bit = 0;
                        break;
                    case 1:
                        sum = sum.Insert(0, "1");
                        bit = 0;
                        break;
                    case 2:
                        sum = sum.Insert(0, "0");
                        bit = 1;
                        break;
                    case 3:
                        sum = sum.Insert(0, "1");
                        bit = 1;
                        break;
                }
            }
            if (bit == 1)
            {
                sum = sum.Insert(0, "1");
            }
            return sum;

        }

        public class NumArray
        {
            private readonly int[] _arr;
            public NumArray(int[] nums)
            {
                _arr = nums;
            }

            public int SumRange(int i, int j)
            {
                var sum = 0;
                for (var k = i; k <= j; k++)
                {
                    sum += _arr[k];
                }
                return sum;
            }
        }

        private static void AddNewNode(TreeNode n, List<TreeNode> p, IList<List<TreeNode>> path)
        {
            var newP = new List<TreeNode>();
            foreach (var node in p)
            {
                var newNode = new TreeNode(node.val);
                newP.Add(newNode);
            }
            newP.Add(n);
            path.Add(newP);
            path.Remove(p);
        }

        private static int FindMinDepth(TreeNode node, int depth)
        {
            if (node.left == null && node.right == null)
            {
                return depth;
            }
            if (node.left == null)
            {
                return FindMinDepth(node.right, depth + 1);
            }
            if(node.right==null)
            {
                return FindMinDepth(node.left, depth + 1);
            }
            return System.Math.Min(FindMinDepth(node.left, depth + 1), FindMinDepth(node.right, depth + 1));
        }

        private static IList<IList<int>> levelOrder = new List<IList<int>>();
        private static void TagLevel1(TreeNode node, int level)
        {
            if (level > levelOrder.Count)
            {
                levelOrder.Add(new List<int>());
            }
            levelOrder[level - 1].Add(node.val);
            if (node.left != null)
            {
                TagLevel1(node.left, level + 1);
            }
            if (node.right != null)
            {
                TagLevel1(node.right, level + 1);
            }
        }

        private static int FindTriEle(int row, int col)
        {
            if (col == 1 || row == col)
                return 1;
            return FindTriEle(row - 1, col) + FindTriEle(row - 1, col - 1);
        }


        private static void TagTreeNodes(TreeNode node, int n, IDictionary<int, TreeNode> nodeTag)
        {
            nodeTag.Add(n, node);
            var l = 2*n + 1;
            var r = 2*n + 2;

            if (node.left != null)
            {
                TagTreeNodes(node.left, l, nodeTag);
            }
            if (node.right != null)
            {
                TagTreeNodes(node.right, r, nodeTag);
            }
        }

        private static void TagNodes(TreeNode p, int n, Dictionary<TreeNode, int> index)
        {
            index.Add(p, n);
            var m = n*2 + 1;
            var l = n*2 + 2;
            if (p.left != null)
            {
                TagNodes(p.left, m, index);
            }
            if (p.right != null)
            {
                TagNodes(p.right, l, index);
            }
        }

        private static List<TreeNode> FindAllParents(TreeNode root, TreeNode p)
        {
            var parents = new List<TreeNode>();

            while (root != p)
            {
                parents.Add(p);
                p = FindParent(root, p);
            }
            parents.Add(root);
            return parents;
        }

        private static TreeNode FindParent(TreeNode root, TreeNode p)
        {
            if (root == null || root == p)
            {
                return root;
            }
            if (root.left == p || root.right == p)
            {
                return root;
            }
            var a = FindParent(root.left, p);
            var b = FindParent(root.right, p);
            return a == null ? b : a;
        }


        private static int MaxDepth2Iter(TreeNode root, ref int count)
        {
            if (root.left == null && root.right == null)
            {
                return count;
            }
            var n = count + 1;
            if (root.right == null)
            {
                return MaxDepth2Iter(root.left, ref n);
            }
            if (root.left == null)
            {
                return MaxDepth2Iter(root.right, ref n);
            }
            return System.Math.Max(MaxDepth2Iter(root.left, ref n), MaxDepth2Iter(root.right, ref n));
        }






        private static int CountChangeIter(double x, ICollection<double> changes)
        {
            var n = changes.Count;
            if (n == 0)
            {
                return 0;
            }
            var minChange = changes.Last();
            if (System.Math.Abs(x - minChange) <= 1e-5)
            {
                return 1;
            }
            if (x < minChange)
            {
                return 0;
            }
            return CountChangeIter(x - minChange, changes) + CountChangeIter(x, changes.Take(n - 1).ToList());
        }

        private static bool CanWinNimIter(int n, int count)
        {
            if (n <= 3)
            {
                return count%2 == 0;
            }
            var win1 = CanWinNimIter(n - 1, count + 1);
            var win2 = CanWinNimIter(n - 2, count + 1);
            var win3 = CanWinNimIter(n - 3, count + 1);
            return win1 || win2 || win3;
        }

        public static int Rreverse(int x)
        {
            long val = System.Math.Abs((long)x);
            long reverse = 0;

            while (val != 0)
            {
                reverse = reverse*10 + val%10;
                val = val/10;
            }
            return reverse > 0x7ffffff ? 0 : (x < 0 ? (int)-reverse : (int)reverse);
        }

        public static int CountPrimes(int n)
        {
            var count = 0;
            for (var i = 2; i < n; i++)
            {
                if (IsPrime(i))
                {
                    count++;
                }
            }
            return count;
        }

        private static bool IsPrime(int n)
        {
            for (var i = 2; i < n; i++)
            {
                if (n%i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static int CountPrimes2(int n)
        {
            var nums = new List<int>(n-1);
            for (var i = 2; i <= n; i++)
            {
                nums.Add(i);
            }
            var count = 0;
            while (nums.Count != 0)
            {
                count++;
                var k = nums[0];
                for (var i = 0; i < nums.Count; i++)
                {
                    if (nums[i] % k == 0)
                    {
                        nums.RemoveAt(i);
                        i--;
                    }
                }
            }
            return count;
        }

        public int CountPrimes3(int n)
        {
            if (n == 0 || n == 1)
            {
                return 0;
            }
            var primes = new List<int> { 2 };
            var count = 1;

            for (var i = 3; i < n; i++)
            {
                var flag = true;
                foreach (var prime in primes)
                {
                    if (i%prime == 0)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    primes.Add(i);
                    count++;
                }
            }
            return count;
        }

        public static int CountPrimes4(int n)
        {
            var nums = new List<int>(n - 1);
            for (var i = 2; i < n; i++)
            {
                nums.Add(i);
            }
            var count = 0;
            while (nums.Count!=0)
            {
                nums.RemoveAll(x => x%nums[0] == 0);
                count++;
            }
            return count;
        }

        public static int CountPrimes5(int n)
        {
            if (n <= 2)
            {
                return 0;
            }
            var nums = new List<bool>(n);
            for(var i =0;i<n;i++)
            {
                nums.Add(false);
            }
            var count = 0;
            for (var i = 2; i < n; i++)
            {
                if (nums[i] == false)
                {
                    count++;
                    for (var j = 2 * i; j < n; j += i)
                        nums[j] = true; 
                }
            }
            return count;
        }

        public static bool IsPalindrome(string s)
        {
            var i = 0;
            var j = s.Length - 1;

            while (i < j)
            {
                while (i < j && !IsAlphaNumeric(s[i]))
                {
                    i++;
                }
                while (j > i && !IsAlphaNumeric(s[j]))
                {
                    j--;
                }
                if (!s[i].ToString().ToLower().Equals(s[j].ToString().ToLower()))
                {
                    return false;
                }
                i++;
                j--;
            }
            return true;
        }

        private static bool IsAlphaNumeric(char c)
        {
            return c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z' || c >= '0' && c <= '9';
        }

        public static IList<string> SummaryRanges(int[] nums)
        {
            var ranges = new List<string>();
            var i = 0;

            while (i < nums.Length)
            {
                var j = i;
                while (i + 1 < nums.Length && nums[i + 1] == nums[i]+1)
                {
                    i++;
                }
                if (i == j)
                {
                    ranges.Add(nums[i].ToString());
                }
                else
                {
                    ranges.Add(nums[j] + "->" + nums[i]);                    
                }
                i++;
            }
            return ranges;
        }

        public int FirstBadVersion(int i)
        {
            var lower = 1;
            var upper = i;
            var mid = (lower + upper)/2;
            while (lower < upper)
            {
                if (IsBadVersion(mid))
                {
                    upper = mid;
                }
                else
                {
                    lower = mid + 1;
                }
                mid = (lower + upper)/2;
            }
            return lower;
        }

        private bool IsBadVersion(int n)
        {
            return n%2 == 0;
        }
        public string ConvertToTitle(int n)
        {
            var title = "";

            while (n != 0)
            {
                title = (char) ((n - 1)%26 + 'A')+title;
                n=(n-1)/ 26;
            }
            return title;
        }

        public void Rotate(int[] nums, int k)
        {
            var right = new List<int>();
            for (var i = nums.Length - k; i < nums.Length; i++)
            {
                right.Add(nums[i]);
            }
            for (var i = nums.Length - k - 1; i >= 0; i--)
            {
                nums[i + k] = nums[i];
            }
            for (var i = 0; i < k; i++)
            {
                nums[i] = right[i];
            }
        }

        public static int CompareVersion(string version1, string version2)
        {
            var i = 0;
            var j = 0;
            var m = version1.Length;
            var n = version2.Length;
            var num1 = 0;
            var num2 = 0;

            while (i < m || j < n)
            {
                while (i < m && version1[i] != '.')
                {
                    num1 = num1 * 10 + version1[i];
                }
                while (j < n && version2[j] != '.')
                {
                    num2 = num2 * 10 + version2[j];
                }
                if (num1 > num2)
                {
                    return 1;
                }
                if (num1 < num2)
                {
                    return 1;
                }
                i++;
                j++;
                num1 = 0;
                num2 = 0;
            }
            return 0;
        }

        public static int SingleNumber(int[] nums)
        {
            var dic = new Dictionary<int, int>();

            for (var i = 0; i < nums.Count(); i++)
            {
                if (!dic.ContainsKey(nums[i]))
                {
                    dic.Add(nums[i], 1);
                }
                else
                {
                    dic.Remove(nums[i]);
                }
            }
            return dic.Keys.First();
        }

        public static int SingleNumber2(int[] nums)
        {
            var count = false;
            for (var i = 0; i < nums.Count(); i++)
            {
                for (var j = i; j < nums.Count(); j++)
                {
                    if (nums[j] - nums[i] == 0)
                    {
                        count = !count;
                    }
                }
                if (count == true)
                {
                    return nums[i];
                }
            }
            return 0;
        }

        public static int[] SingleNumber3(int[] nums)
        {
            var dic = new Dictionary<int, int>();

            for (var i = 0; i < nums.Count(); i++)
            {
                if (!dic.ContainsKey(nums[i]))
                {
                    dic.Add(nums[i], 1);
                }
                else
                {
                    dic.Remove(nums[i]);
                }
            }
            return dic.Keys.ToArray();
        }

        public static int[] ProductExceptSelf(int[] nums)
        {
            var ret = new List<int>();
            for (var i = 0; i < nums.Count(); i++)
            {
                ret.Add(1);
            }
            for (var i = 0; i < nums.Count(); i++)
            {
                for (var j = 0; j < ret.Count(); j++)
                {
                    if (j != i)
                    {
                        ret[j] *= nums[i];
                    }
                }
            }
            return ret.ToArray();
        }

        public static int[] ProductExceptSelf2(int[] nums)
        {
            var n = nums.Length;
            var ret = new int[n];
            var temp = 1;
            ret[0] = 1;

            for (var i = 1; i < n; i++)
            {
                ret[i] = ret[i - 1] * nums[i - 1];
            }
            for (var i = n - 2; i >= 0; i--)
            {
                temp = temp * nums[i + 1];
                ret[i] = ret[i] * temp;
            }
            return ret;
        }

        public static int MaxPolyfit(int[] prices)
        {
            int buy = 0;
            int sell = 0;
            int polyfit = 0;
            for (var i = 0; i < prices.Count()-1; i++)
            {
                if (i == 0 && prices[0] < prices[1])
                {
                    if (prices[0] < prices[1])
                    {
                        buy = prices[0];
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    while (i < prices.Count() - 1 && !(prices[i] < prices[i + 1] && prices[i] < prices[i - 1]))
                    {
                        i++;
                    }
                    if (i < prices.Count() - 1)
                    {
                        buy = prices[i];
                    }
                    else
                    {
                        break;
                    }
                }               
                while (i < prices.Count() - 1 && prices[i] < prices[i + 1])
                {
                    i++;
                }
                sell = prices[i];
                polyfit += sell - buy;
            }
            return polyfit;
        }

        public static int MaxPolyfit2(int[] prices)
        {
            var buy = 0;
            var sell = 0;
            var i = 0;
            for (; i < prices.Count() - 1; i++)
            {
                if (i == 0)
                {
                    if (prices[0] < prices[1])
                    {
                        buy += prices[0];
                    }
                    continue;
                }
                if (prices[i] < prices[i + 1] && prices[i] <= prices[i - 1])
                {
                    buy += prices[i];
                }
                if (prices[i] > prices[i + 1] && prices[i] >= prices[i - 1])
                {
                    sell += prices[i];
                }
            }
            if (prices[i] >= prices[i - 1])
            {
                sell += prices[i];
            }
            return sell - buy;
        }

        public static int BulbSwitch(int n)
        {
            var count = 0;
            var i = 1;
            while (i * i <= n)
            {
                count++;
                i++;
            }
            return count;
        }

        public int MissingNumber(int[] nums)
        {
            var sum = 0;
            var n = nums.Length;
            var i = 0;
            while (i < n)
            {
                sum += nums[i];
                i++;
            }
            return n * (n + 1) / 2 - sum;

        }

        public IList<int> InorderTraversal(TreeNode root)
        {
            var ret = new List<int>();
            if (root != null)
            {
                InorderTraversalIter(root, ret);
            }
            return ret;
        }

        private static void InorderTraversalIter(TreeNode root, IList<int> ret)
        {
            if (root.left!=null)
            {
                InorderTraversalIter(root.left, ret);
            }
            ret.Add(root.val);
            if (root.right != null)
            {
                InorderTraversalIter(root.right, ret);
            }
        }

        public IList<int> InorderTraversal2(TreeNode root)
        {
            var ret = new List<int>();
            if (root != null)
            {
                if (root.left == null && root.right == null)
                {
                    ret.Add(root.val);
                    return ret;
                }
                var retLeft = InorderTraversal2(root.left);
                var retRight = InorderTraversal2(root.right);
                ret.AddRange(retLeft);
                ret.Add(root.val);
                ret.AddRange(retRight);
            }
            return ret;
        }

        public IList<int> InorderTraversal3(TreeNode root)
        {
            var tree = new Stack<int>();
            var ret = new List<int>();

            BuildStack(root, tree);

            while (tree.Count != 0)
            {
                ret.Add(tree.Pop());
            }
            return ret;
        }

        private static void BuildStack(TreeNode root, Stack<int> tree)
        {
            if (root != null)
            {
                if (root.right != null)
                {
                    BuildStack(root.right, tree);
                }
                tree.Push(root.val);
                if (root.left != null)
                {
                    BuildStack(root.left, tree);
                }
            }
        }

        public static int MaxProduct(string[] words)
        {
            var maxPair = new object[3];
            maxPair[0] = (object)"";
            maxPair[1] = (object)"";
            maxPair[2] = (object)0;


            for (var i = 0; i < words.Length - 1; i++)
            {
                for (var j = 1; j < words.Length; j++)
                {
                    if (words[i].Length * words[j].Length > (int)maxPair[2] && IsDistinct(words[i], words[j]))
                    {
                        maxPair[0] = (object)words[i];
                        maxPair[1] = (object)words[j];
                        maxPair[2] = (object)(words[i].Length * words[j].Length);
                    }
                }
            }
            return (int)maxPair[2];
        }

        private static bool IsDistinct(string a, string b)
        {
            var count = new int[26];
            foreach (var ch in a)
            {
                count[ch - 'a']++;
            }
            foreach (var ch in b)
            {
                if (count[ch - 'a'] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        public IList<int> PreorderTraversal(TreeNode root)
        {
            var traversal = new List<int>();
            if (root != null)
            {
                PreorderTraversalIter(root, traversal);
            }
            return traversal;
        }

        private void PreorderTraversalIter(TreeNode node, IList<int> traversal)
        {
            traversal.Add(node.val);
            if (node.left != null)
            {
                PreorderTraversalIter(node.left, traversal);
            }
            if (node.right != null)
            {
                PreorderTraversalIter(node.right, traversal);
            }
        }

        public static int LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        { 
            var tree = new List<Tuple<TreeNode, int>>();
            int indexP = 0;
            int indexQ = 0;
            if (root != null)
            {
                FindAncestorIter(root, 1, tree, ref indexP, ref indexQ, p, q);
            }
            while (indexP != indexQ)
            {
                if (indexP > indexQ)
                {
                    indexP = indexP / 2;
                }
                else
                {
                    indexQ = indexQ / 2;
                }
            }
            foreach (var item in tree)
            {
                if (item.Item2 == indexP)
                    return item.Item1.val;
            }
            return 0;
            
        }
        private static void FindAncestorIter(TreeNode root, int n, IList<Tuple<TreeNode, int>> tree, ref int indexP, ref int indexQ, TreeNode p, TreeNode q)
        {
            tree.Add(new Tuple<TreeNode, int>(root, n));
            if (root == p)
            {
                indexP = n;
            }
            if (root == q)
            {
                indexQ = n;
            }
            if (indexP != 0 && indexQ != 0)
            {
                return;
            }
            if (root.left != null)
            { 
                FindAncestorIter(root.left, 2*n, tree, ref indexP, ref indexQ, p, q);
            }
            if (root.right != null)
            {
                FindAncestorIter(root.right, 2 * n + 1, tree, ref indexP, ref indexQ, p, q);
            }
        }

        public static TreeNode LowestCommonAncestor10(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
            {
                return null;
            }
            var tree = new List<Tuple<TreeNode, int>>();
            var queue = new Queue<Tuple<TreeNode, int>>();
            queue.Enqueue(new Tuple<TreeNode, int>(root, 1));

            var indexP = 0;
            var indexQ = 0;

            while (indexP>0&&indexQ>0)
            {
                var item = queue.Dequeue();
                var node = item.Item1;
                var n = item.Item2;

                tree.Add(item);

                if (node == p)
                {
                    indexP = n;
                }
                if (node == q)
                {
                    indexQ = n;
                }

                if (node.left != null)
                {
                    queue.Enqueue(new Tuple<TreeNode, int>(node.left, 2 * n));
                }
                if (node.right != null)
                {
                    queue.Enqueue(new Tuple<TreeNode, int>(node.right, 2 * n + 1));
                }
            }
            while (indexP != indexQ)
            {
                if (indexP > indexQ)
                {
                    indexP = indexP / 2;
                }
                else
                {
                    indexQ = indexQ / 2;
                }
            }
            foreach (var item in tree)
            {
                if (item.Item2 == indexP)
                    return item.Item1;
            }
            return null;
        }
    }
}

