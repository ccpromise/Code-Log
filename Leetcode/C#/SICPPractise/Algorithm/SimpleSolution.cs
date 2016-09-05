using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SICPPractise.Algorithm.Internal;

namespace SICPPractise.Algorithm
{
    public class SimpleSolution
    {
        public string ReverseString(string s)
        {
            var arr = s.ToCharArray();
            var i = 0;
            var j = arr.Count() - 1;

            while (i < j)
            {
                var tmp = arr[i];
                arr[i] = arr[j];
                arr[j] = tmp;
                i++;
                j--;
            }
            return new string(arr);
        }

        public bool CanWinNim1(int n)
        {
            return CanWinNimHelper(n, true);
        }
        private bool CanWinNimHelper(int n, bool myTurn)
        {
            if (n < 0)
            {
                return false;
            }
            if (n <= 3)
            {
                return myTurn == true;
            }
            if(myTurn == true)
            {
                return CanWinNimHelper(n-1, false) || CanWinNimHelper(n-2, false) || CanWinNimHelper(n-3, false);
            }
            else
            {
                return CanWinNimHelper(n-1, true) && CanWinNimHelper(n-2, true) && CanWinNimHelper(n-3, true);
            }
        }

        public bool CanWinNim2(int n)
        {
            var ret = new bool[n];

            if (n <= 3)
            {
                return true;
            }
            ret[0] = true;
            ret[1] = true;
            ret[2] = true;

            for (var i = 3; i < n; i++)
            {
                ret[i] = !(ret[i - 1] && ret[i - 2] && ret[i - 3]);
            }
            return ret[n - 1];
        }

        public void MoveZeros(int[] nums)
        {
            var i = 0;
            var j = 0;

            while (j < nums.Length)
            {
                if (nums[j] != 0)
                {
                    nums[i++] = nums[j];
                }
                j++;
            }
            while (i < nums.Length)
            {
                nums[i++] = 0;
            }
        }

        public void DeleteNode(ListNode node)
        {
            node.val = node.next.val;
            node.next = node.next.next;
        }

        public bool IsSameTree1(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }
            if (p == null || q == null)
            {
                return false;
            }
            return p.val == q.val && IsSameTree1(p.left, q.left) && IsSameTree1(p.right, q.right);
        }

        public bool IsSameTree2(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }
            if (p == null || q == null)
            {
                return false;
            }
            var ptree = new Queue<TreeNode>();
            var qtree = new Queue<TreeNode>();
            ptree.Enqueue(p);
            qtree.Enqueue(q);

            while (ptree.Count() != 0 && qtree.Count() != 0)
            {
                var pnode = ptree.Dequeue();
                var qnode = qtree.Dequeue();

                if (pnode.val != qnode.val)
                {
                    return false;
                }
                if (pnode.left != null)
                {
                    ptree.Enqueue(pnode.left);
                }
                if (qnode.left != null)
                {
                    qtree.Enqueue(qnode.left);
                }
                if (ptree.Count() != qtree.Count())
                {
                    return false;
                }
                if (pnode.right != null)
                {
                    ptree.Enqueue(pnode.right);
                }
                if (qnode.right != null)
                {
                    qtree.Enqueue(qnode.right);
                }
                if (ptree.Count() != qtree.Count())
                {
                    return false;
                }
            }
            return ptree.Count() == 0 && qtree.Count() == 0;
        }

        public bool IsAnagram(string s, string t)
        {
            var dic = new int[26];

            foreach (var ch in s)
            {
                dic[ch - 'a']++;
            }
            foreach (var ch in t)
            {
                dic[ch - 'a']--;
                if (dic[ch - 'a'] < 0)
                {
                    return false;
                }
            }
            foreach (var n in dic)
            {
                if (n != 0)
                {
                    return false;
                }
            }
            return true;
        }

        public int TitleToNumber(string s)
        {
            var n = 0;

            foreach (var x in s)
            {
                n = n * 26 + x - 'A' + 1;
            }
            return n;
        }

        public int MajorityElement1(int[] nums)
        {
            var count = 1;
            var max = nums[0];

            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i] == max)
                {
                    count++;
                }
                else
                {
                    count--;
                }
                if (count == 0)
                {
                    count = 1;
                    max = nums[i];
                }
            }
            return max;
        }

        public ListNode ReverseList1(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            var h = ReverseList1(head.next);
            head.next.next = head;
            head.next = null;
            return h;
        }

        public ListNode ReverseList2(ListNode head)
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
                node.next = pre;
                pre = node;
                node = tmp;
            }
            return pre;
        }

        public TreeNode LowerstCommonAncestor1(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root == p || root == q)
            {
                return root;
            }
            if (p.val > root.val && q.val > root.val)
            {
                return LowerstCommonAncestor1(root.right, p, q);
            }
            else if (p.val < root.val && q.val < root.val)
            {
                return LowerstCommonAncestor1(root.left, p, q);
            }
            else
            {
                return root;
            }
        }

        public TreeNode LowestCommonAncestor2(TreeNode root, TreeNode p, TreeNode q)
        {
            var node = root;

            while (root != null && root != p && root != q)
            {
                if (p.val > root.val && q.val > root.val)
                {
                    node = node.right;
                }
                else if (p.val < root.val && q.val < root.val)
                {
                    node = node.left;
                }
                else
                {
                    break;
                }
            }
            return root;
        }

        public int HammingWeight(uint n)
        {
            var count = 0;

            while (n != 0)
            {
                count += (int)n & 1;
                n = n >> 1;
            }
            return count;
        }

        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            var cur = head;
            var next = head.next;

            while (next != null)
            {
                while (next != null && next.val == cur.val)
                {
                    next = next.next;
                }
                cur.next = next;
                cur = cur.next;
            }
            return head;
        }

        public bool IsHappy(int n)
        {
            var nums = new HashSet<int>();

            while (n != 1)
            {
                var sum = 0;
                var tmp = n;
                while (tmp != 0)
                {
                    sum += (int)System.Math.Pow(tmp % 10, 2);
                    tmp /= 10;
                }
                if (sum == 1)
                {
                    return true;
                }
                if (nums.Add(sum) == false)
                {
                    return false;
                }
                n = sum;
            }
            return true;
        }

        public int MaxProfit1(int[] prices)
        {
            if (prices.Length == 0)
            {
                return 0;
            }
            var min = prices[0];
            var max = 0;

            for (var i = 1; i < prices.Length; i++)
            {
                max = System.Math.Max(max, prices[i] - min);
                min = System.Math.Min(min, prices[i]);
            }
            return max;
        }

        public ListNode MergeTwoLists1(ListNode l1, ListNode l2)
        {
            if (l1 == null || l2 == null)
            {
                return l2 == null ? l1 : l2;
            }
            ListNode newHead = null;
            var node1 = l1;
            var node2 = l2;

            if (l1.val < l2.val)
            {
                newHead = l1;
                node1 = l1.next;
            }
            else
            {
                newHead = l2;
                node2 = l2.next;
            }

            var node = newHead;

            while (node1 != null && node2 != null)
            {
                if (node1.val < node2.val)
                {
                    node.next = node1;
                    node1 = node1.next;
                }
                else
                {
                    node.next = node2;
                    node2 = node2.next;
                }
                node = node.next;
            }
            while (node1 != null)
            {
                node.next = node1;
                node = node.next;
                node1 = node1.next;
            }
            while (node2 != null)
            {
                node.next = node2;
                node = node.next;
                node2 = node2.next;
            }
            node.next = null;
            return newHead;
        }

        public ListNode MergeTwoLists2(ListNode l1, ListNode l2)
        {
            if (l1 == null || l2 == null)
            {
                return l1 == null ? l2 : l1;
            }
            var head = l1.val < l2.val ? l1 : l2;
            head.next = l1.val < l2.val ? MergeTwoLists2(l1.next, l2) : MergeTwoLists2(l1, l2.next);
            return head;
        }

        public ListNode SwapPairs1(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            var pre = head;
            var cur = head.next;
            var newHead = head.next;

            while (cur.next != null && cur.next.next != null)
            {
                var tmp1 = cur.next;
                cur.next = pre;
                pre.next = tmp1.next;
                pre = tmp1;
                cur = tmp1.next;
            }
            var tmp2 = cur.next;
            cur.next = pre;
            pre.next = tmp2;
            return newHead;
        }

        public ListNode SwapPairs2(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            var tmp = head.next.next;
            var newHead = head.next;
            head.next.next = head;
            head.next = SwapPairs2(tmp);
            return newHead;
        }

        public int Rob1(int[] nums)
        {
            var n = nums.Length;
            if (n == 0)
            {
                return 0;
            }
            var amount = new int[n, 2];
            amount[0, 1] = nums[0];

            for (var i = 1; i < n; i++)
            {
                amount[i, 0] = System.Math.Max(amount[i - 1, 0], amount[i - 1, 1]);
                amount[i, 1] = amount[i - 1, 0] + nums[i];
            }
            return System.Math.Max(amount[n - 1, 0], amount[n - 1, 1]);
        }

        public int Rob2(int[] nums)
        {
            var n = nums.Length;
            if (n == 0)
            {
                return 0;
            }
            var amount = new int[n];
            amount[0] = nums[0];
            amount[1] = System.Math.Max(nums[0], nums[1]);

            for (var i = 2; i < n; i++)
            {
                amount[i] = System.Math.Max(amount[i - 1], amount[i - 2] + nums[i]);
            }
            return amount[n - 1];
        }

        public bool IsBalanced(TreeNode root)
        {
            return DFSDepth(root) != -1;
        }
        private int DFSDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            var i = DFSDepth(root.left);
            if (i == -1)
            {
                return -1;
            }
            var j = DFSDepth(root.right);
            if (j == -1)
            {
                return -1;
            }

            if (System.Math.Abs(i - j) > 1)
            {
                return -1;
            }
            return 1 + System.Math.Max(i, j);
        }

        public class Queue
        {
            private Stack<int> s1 = new Stack<int>();

            public void Push(int x)
            {
                var s2 = new Stack<int>();
                while (s1.Count != 0)
                {
                    s2.Push(s1.Pop());
                }
                s1.Push(x);
                while (s2.Count != 0)
                {
                    s1.Push(s2.Pop());
                }
            }
            public void Pop()
            {
                s1.Pop();
            }
            public int Peek()
            {
                return s1.Peek();
            }
            public bool Empty()
            {
                return s1.Count() == 0;
            }
        }

        public bool IsSymmetric1(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }
            return IsSymmetric1Helper(root.left, root.right);
        }
        private bool IsSymmetric1Helper(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }
            if (p == null || q == null)
            {
                return false;
            }
            return p.val == q.val && IsSymmetric1Helper(p.left, q.right) && IsSymmetric1Helper(p.right, q.left);
        }

        public bool IsSymmetric2(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }
            var s1 = new Queue<TreeNode>();
            var s2 = new Queue<TreeNode>();

            if (root.left != null)
            {
                s1.Enqueue(root.left);
            }
            if (root.right != null)
            {
                s2.Enqueue(root.right);
            }
            if (s1.Count != s2.Count)
            {
                return false;
            }
            while (s1.Count != 0 && s2.Count != 0)
            {
                var node1 = s1.Dequeue();
                var node2 = s2.Dequeue();
                if (node1.val != node2.val)
                {
                    return false;
                }
                if (node1.left != null)
                {
                    s1.Enqueue(node1.left);
                }
                if (node2.right != null)
                {
                    s2.Enqueue(node2.right);
                }
                if (s1.Count != s2.Count)
                {
                    return false;
                }
                if (node1.right != null)
                {
                    s1.Enqueue(node1.right);
                }
                if (node2.left != null)
                {
                    s2.Enqueue(node2.left);
                }
                if (s1.Count != s2.Count)
                {
                    return false;
                }
            }
            return true;
        }

        public int RemoveElement(int[] nums, int val)
        {
            var i = 0;
            var j = 0;

            while (j < nums.Length)
            {
                if (nums[j] != val)
                {
                    nums[i++] = nums[j];
                }
                j++;
            }
            return i;
        }

        public int RemoveDuplicates1(int[] nums)
        {
            if (nums.Length <= 1)
            {
                return nums.Length;
            }
            var i = 0;
            var j = 1;

            while (j < nums.Length)
            {
                if (nums[j] != nums[i])
                {
                    nums[++i] = nums[j];
                }
                j++;
            }
            return i + 1;
        }

        public int[] PlusOne(int[] digits)
        {
            var i = digits.Length - 1;
            var flag = 0;

            do
            {
                flag = 0;
                if (digits[i] >= 0 && digits[i] < 9)
                {
                    digits[i]++;
                }
                else
                {
                    digits[i] = 0;
                    flag = 1;
                }
                i--;
            } while (i >= 0 && flag == 1);
            if (i == -1 && flag == 1)
            {
                var newDigits = new int[digits.Length + 1];
                digits.CopyTo(newDigits, 1);
                newDigits[0] = 1;
                return newDigits;
            }
            return digits;
        }

        public int TrailingZeros(int n)
        {
            var i = 5;
            var count = 0;

            while (i <= n)
            {
                count += n / i;
                i *= 5;
            }
            return count;
        }

        public bool IsPalindrome(int x)
        {
            var y = 0;

            while (x > y)
            {
                y = y * 10 + x % 10;
                x /= 10;
            }
            return x == y || x == y / 10;
        }

        public bool HasPathSum(TreeNode root, int sum)
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

        public class Stack
        {
            private Queue<int> q = new Queue<int>();

            public void Push(int x)
            {
                q.Enqueue(x);
            }
            public void Pop()
            {
                var i = q.Count - 1;
                while (i >= 1)
                {
                    q.Enqueue(q.Dequeue());
                    i--;
                }
                q.Dequeue();
            }
            public int Top()
            {
                return q.Last();
            }
            public bool Empty()
            {
                return q.Count == 0;
            }
        }

        public int MinDepth1(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            var p = MinDepth1(root.left);
            var q = MinDepth1(root.right);
            return p == 0 || q == 0 ? p + q + 1 : System.Math.Min(p, q);
        }

        public int MinDepth2(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            var q = new Queue<TreeNode>();
            var level = 1;
            q.Enqueue(root);

            while (q.Count != 0)
            {
                var size = q.Count;

                for (var i = 0; i < size; i++)
                {
                    var node = q.Dequeue();
                    if (node.left == null && node.right == null)
                    {
                        return level;
                    }
                    if (node.left != null)
                    {
                        q.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        q.Enqueue(node.right);
                    }
                }
                level++;
            }
            return 0;
        }

        public bool ValidSudoku(char[,] board)
        {
            var row = new bool[9, 9];
            var col = new bool[9, 9];
            var square = new bool[9, 9];

            for (var i = 0; i < 9; i++)
            {
                for (var j = 0; j < 9; j++)
                {
                    if (board[i, j] != '.')
                    {
                        var num = board[i, j] - '0';
                        if (row[i, num - 1] || col[j, num - 1] || square[i / 3 * 3 + j / 3, num - 1])
                        {
                            return false;
                        }
                        row[i, num - 1] = true;
                        col[j, num - 1] = true;
                        square[i / 3 * 3 + j / 3, num - 1] = true;
                    }
                }
            }
            return true;
        }

        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            var node1 = headA;
            var node2 = headB;

            while (node1 != node2)
            {
                node1 = node1 == null ? headB : node1.next;
                node2 = node2 == null ? headA : node2.next;
            }
            return node1;
        }

        public void Merge1(int[] nums1, int m, int[] nums2, int n)
        {
            var i = 0;
            var j = 0;

            while (j < n)
            {
                while (i < m + j && nums1[i] < nums2[j])
                {
                    i++;
                }
                if (i < m + j)
                {
                    for (var k = m + j - 1; k >= i; k--)
                    {
                        nums1[k + 1] = nums1[k];
                    }
                    nums1[i] = nums1[j];
                    i++;
                }
                else
                {
                    for (var k = j; k < n; k++)
                    {
                        nums1[i++] = nums2[k];
                    }
                    break;
                }
                j++;
            }
        }

        public void Merge2(int[] nums1, int m, int[] nums2, int n)
        {
            var i = m - 1;
            var j = n - 1;
            var k = m + n - 1;

            while (i >= 0 && j >= 0)
            {
                if (nums1[i] > nums2[j])
                {
                    nums1[k--] = nums1[i--];
                }
                else
                {
                    nums1[k--] = nums2[j--];
                }
            }
            while (j >= 0)
            {
                nums1[k--] = nums2[j--];
            }
        }

        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            if (k == 0)
            {
                return true;
            }
            var set = new HashSet<int>();

            for (var i = 0; i < nums.Length; i++)
            {
                if (!set.Add(nums[i]))
                {
                    return false;
                }
                if (set.Count == k + 1)
                {
                    set.Remove(nums[i - k]);
                }
            }
            return true;
        }

        public bool IsIsomorphic(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            var m = new int[256];
            var n = new int[256];


            for (var i = 0; i < s.Length; i++)
            {
                if (m[s[i]] != n[t[i]])
                {
                    return false;
                }
                m[s[i]] = i + 1;
                n[t[i]] = i + 1;
            }
            return true;
        }

        public string GetHint(string secret, string guess)
        {
            var dic = new int[10];
            var bulls = 0;
            var cows = 0;

            for (var i = 0; i < secret.Length; i++)
            {
                if (secret[i] == guess[i])
                {
                    bulls++;
                }
                else
                {
                    if (dic[secret[i] - '0'] < 0)
                    {
                        cows++;
                    }
                    dic[secret[i] - '0']++;
                    if (dic[guess[i] - '0'] > 0)
                    {
                        cows++;
                    }
                    dic[guess[i] - '0']--;
                }
            }
            return bulls.ToString() + "A" + cows.ToString() + "B";
        }

        public bool IsValid(string s)
        {
            var stack = new Stack<char>();

            foreach (var p in s)
            {
                if (p == '(' || p == '{' || p == '[')
                {
                    stack.Push(p);
                }
                else if (stack.Count() != 0)
                {
                    var q = stack.Pop();
                    if (!(q == '(' && p == ')' || q == '{' && p == '}' || q == '[' && p == ']'))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return stack.Count() == 0;
        }

        public bool WordPattern(string pattern, string str)
        {
            var arr = new int[26];
            var dic = new Dictionary<string, int>();
            var words = str.Split();

            if (pattern.Count() != words.Count())
            {
                return false;
            }
            for (var i = 0; i < pattern.Count(); i++)
            {
                if (arr[pattern[i] - 'a'] == 0 && !dic.ContainsKey(words[i]))
                {
                    arr[pattern[i] - 'a'] = i + 1;
                    dic.Add(words[i], i + 1);
                }
                else if (!dic.ContainsKey(words[i]) || dic.ContainsKey(words[i]) && dic[words[i]] != arr[pattern[i] - 'a'])
                {
                    return false;
                }
            }
            return true;
        }

        public ListNode RemoveElements1(ListNode head, int val)
        {
            var newHead = head;
            while (newHead != null && newHead.val == val)
            {
                newHead = newHead.next;
            }
            if (newHead == null || newHead.next == null)
            {
                return newHead;
            }
            var pre = newHead;
            var node = newHead.next;

            while (node != null)
            {
                if (node.val == val)
                {
                    pre.next = node.next;
                }
                else
                {
                    pre = node;
                }
                node = node.next;
            }
            return newHead;
        }

        public ListNode RemoveElements2(ListNode head, int val)
        {
            if (head == null)
            {
                return head;
            }
            if (head.val == val)
            {
                return RemoveElements2(head.next, val);
            }
            else
            {
                head.next = RemoveElements2(head.next, val);
            }
            return head;
        }

        public IList<string> BinaryTreePaths(TreeNode root)
        {
            var ret = new List<string>();
            if (root == null)
            {
                return ret;
            }
            BinaryTreePathsHelper(root, "", ret);
            return ret;
        }
        private void BinaryTreePathsHelper(TreeNode node, string route, IList<string> ret)
        {
            route += node.val.ToString();
            if (node.left == null && node.right == null)
            {
                ret.Add(route);
                return;
            }
            route += "->";
            if (node.left != null)
            {
                BinaryTreePathsHelper(node.left, route, ret);
            }
            if (node.right != null)
            {
                BinaryTreePathsHelper(node.right, route, ret);
            }
        }

        public bool IsPalindrome(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return true;
            }
            var pre = head;
            var cur = head.next;
            var fast = head;

            while (fast.next != null && fast.next.next != null)
            {
                fast = fast.next.next;
                var tmp = cur.next;
                cur.next = pre;
                pre = cur;
                cur = tmp;
            }
            var node = fast.next == null ? pre.next : pre;
            head.next = null;
            while (pre != null)
            {
                if (pre.val != cur.val)
                {
                    return false;
                }
                pre = pre.next;
                cur = cur.next;
            }
            return true;



        }

        public string AddBinary(string a, string b)
        {
            while (a.Length < b.Length)
            {
                a = "0" + a;
            }
            while (b.Length < a.Length)
            {
                b = "0" + b;
            }
            var n = a.Length;
            var c = 0;
            var sum = "";

            for (var i = n - 1; i >= 0; i++)
            {
                var num = a[i] - '0' + b[i] - '0' + c;
                sum = (num % 2).ToString() + sum;
                c = num >= 2 ? 1 : 0;
            }
            if (c == 1)
            {
                sum = "1" + sum;
            }
            return sum;
        }

        public int StrStr(string haystack, string needle)
        {
            var size = needle.Length;

            for (var i = 0; i < haystack.Length - size + 1; i++)
            {
                if (haystack[i] == needle[0])
                {
                    if (haystack.Substring(i, size) == needle)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public class NumArray
        {
            private IList<int> sums = new List<int>();

            public NumArray(int[] nums)
            {
                var sum = 0;
                for (var i = 0; i < nums.Length; i++)
                {
                    sum += nums[i];
                    sums.Add(sum);
                }
            }

            public int SumRange(int i, int j)
            {
                if (i == 0)
                {
                    return sums[j];
                }
                return sums[j] - sums[i - 1];
            }
        }

        public int CountPrimes(int n)
        {
            if (n <= 2)
            {
                return 0;
            }
            var isNotPrime = new bool[n];
            var count = 0;

            for (var i = 2; i < n; i++)
            {
                if (isNotPrime[i] == false)
                {
                    count++;
                    for (var j = i * 2; j < n; j += i)
                    {
                        isNotPrime[j] = true;
                    }
                }
            }
            return count;
        }

        public string Convert(string s, int numRows)
        {
            var t = "";

            for (var i = 0; i < numRows; i++)
            {
                var j = i;
                while (j < s.Length)
                {
                    t += s[j];
                    if (i != 0 && i != numRows - 1 && j + 2 * numRows - 2 - 2 * i < s.Length)
                    {
                        t += s[j + 2 * numRows - 2 - 2 * i];
                    }
                    j += 2 * numRows - 2;
                }
            }
            return t;
        }

        public int Reverse(int x)
        {
            long y = x < 0 ? -x : x;

            while (y > 0 && y % 10 == 0)
            {
                y /= 10;
            }

            long reverse = 0;
            while (y > 0)
            {
                reverse = reverse * 10 + y % 10;
                y /= 10;
            }
            if (reverse > int.MaxValue)
            {
                return 0;
            }
            return x < 0 ? (int)-reverse : (int)reverse;
        }

        public int[] TwoSum(int[] nums, int target)
        {
            var dic = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(target - nums[i]))
                {
                    return new[] { dic[target - nums[i]], i };
                }
                if (!dic.ContainsKey(nums[i]))
                {
                    dic.Add(nums[i], i);
                }
            }
            return null;
        }

        public class MinStack
        {
            private Stack<int> nums = new Stack<int>();
            private Stack<int> mins = new Stack<int>();

            public void Push(int x)
            {
                nums.Push(x);
                if (mins.Count() == 0 || x <= mins.Peek())
                {
                    mins.Push(x);
                }
            }

            public void Pop()
            {
                var i = nums.Pop();
                if (i == mins.Peek())
                {
                    mins.Pop();
                }
            }

            public int Top()
            {
                return nums.Peek();
            }

            public int GetMin()
            {
                return mins.Peek();
            }
        }

        public string ConvertToTitle(int n)
        {
            var ret = "";

            while (n != 0)
            {
                ret = (char)((n - 1) % 26 + 'A') + ret;
                n = (n - 1) / 26;
            }
            return ret;
        }

        public void Rotate1(int[] nums, int k)
        {
            var n = nums.Length;
            k = k % n;

            while (k > 0)
            {
                var tmp = nums[n - 1];
                for (var i = n - 2; i >= 0; i--)
                {
                    nums[i + 1] = nums[i];
                }
                nums[0] = tmp;
                k--;
            }
        }

        public void Rotate2(int[] nums, int k)
        {
            var n = nums.Length;
            k = k % n;
            var tail = new int[k];

            for (var i = n - k; i < n; i++)
            {
                tail[i - n + k] = nums[i];
            }
            for (var i = n - k - 1; i >= 0; i--)
            {
                nums[i + k] = nums[i];
            }
            for (var i = 0; i < k; i++)
            {
                nums[i] = tail[i];
            }
        }

        public void Rotate3(int[] nums, int k)
        {
            var n = nums.Length;
            k = k % n;

            Reverse(nums, 0, n - k - 1);
            Reverse(nums, n - k, n - 1);
            Reverse(nums, 0, n - 1);
        }
        private void Reverse(int[] nums, int i, int j)
        {
            while (i < j)
            {
                var tmp = nums[j];
                nums[j] = nums[i];
                nums[i] = tmp;
                i++;
                j--;
            }
        }

        public void Rotate4(int[] nums, int k)
        {
            var start = 0;
            var cur = 0;
            var count = 0;
            var n = nums.Length;

            while (count < nums.Length)
            {
                var numToBeRotated = nums[cur];
                do
                {
                    var tmp = nums[(cur + k) % n];
                    nums[(cur + k) % n] = numToBeRotated;
                    numToBeRotated = tmp;
                    cur = (cur + k) % n;
                    count++;
                } while (cur != start);

                start++;
                cur = start;
            }
        }

        public void Rotate5(int[] nums, int k)
        {
            var start = 0;
            var idx = 0;
            var count = 0;
            var n = nums.Length;
            k = k % n;

            while(count<n)
            {
                var num = nums[idx];
                do
                {
                    var tmp = nums[(idx + k) % n];
                    nums[(idx + k) % n] = num;
                    idx = (idx + k) % n;
                    num = tmp;
                    count++;
                } while (idx != start);
                start++;
                idx++;             
            }
        }

        public int CompareVersion(string version1, string version2)
        {
            var i = 0;
            var j = 0;

            while (i < version1.Length || j < version2.Length)
            {
                var n = 0;
                while (i < version1.Length && version1[i] != '.')
                {
                    n = n * 10 + version1[i] - '0';
                    i++;
                }
                var m = 0;
                while (j < version2.Length && version2[j] != '.')
                {
                    m = m * 10 + version2[j] - '0';
                    j++;
                }
                if (n > m)
                {
                    return 1;
                }
                if (n < m)
                {
                    return -1;
                }
                i++;
                j++;
            }
            return 0;
        }

        public int MyAtoi(string str)
        {
            var n = 0;
            var flag = 1;
            var i = 0;
            while (i < str.Length && str[i] == ' ')
            {
                i++;
            }
            if (i == str.Length)
            {
                return 0;
            }
            if (str[i] == '+' || str[i] == '-')
            {
                flag = str[i] == '+' ? 1 : -1;
                i++;
            }
            if (i == str.Length || str[i] < '0' || str[i] > '9')
            {
                return 0;
            }
            while (i < str.Length)
            {
                if (str[i] >= '0' && str[i] <= '9')
                {
                    if (n <= int.MaxValue / 10 && int.MaxValue - n * 10 >= str[i] - '0')
                    {
                        n = n * 10 + str[i] - '0';
                    }
                    else
                    {
                        n = -1;
                        break;
                    }
                }
                else
                {
                    break;
                }
                i++;
            }
            return flag == 1 ? (n == -1 ? int.MaxValue : n) : (n == -1 ? int.MinValue : -n);
        }

        public int[] SingleNumber(int[] nums)
        {
            var a = 0;

            foreach (var n in nums)
            {
                a ^= n;
            }
            var b = 1;
            while ((a & 1) == 0)
            {
                a >>= 1;
                b <<= 1;
            }
            var group1 = new List<int>();
            var group2 = new List<int>();
            foreach (var n in nums)
            {
                if ((n & b) != 0)
                {
                    group1.Add(n);
                }
                else
                {
                    group2.Add(n);
                }
            }
            var ret = new int[2];
            foreach (var n in group1)
            {
                ret[0] ^= n;
            }
            foreach (var n in group2)
            {
                ret[1] ^= n;
            }
            return ret;
        }

        public int[] ProductExceptSelf(int[] nums)
        {
            var size = nums.Length;
            var ret = new int[size];
            var tmp = 1;

            for (var i = 0; i < size; i++)
            {
                ret[i] = tmp;
                tmp *= nums[i];
            }
            tmp = 1;
            for (var i = size - 1; i >= 0; i--)
            {
                ret[i] *= tmp;
                tmp *= nums[i];
            }
            return ret;
        }

        public int MaxProfit2(int[] prices)
        {
            var days = prices.Length;
            var localMax = new int[days, 2];
            localMax[0, 0] = -prices[0];

            for (var i = 1; i < days; i++)
            {
                localMax[i, 0] = System.Math.Max(localMax[i - 1, 0], localMax[i - 1, 1] - prices[i]);
                localMax[i, 1] = System.Math.Max(localMax[i - 1, 1], localMax[i - 1, 0] + prices[i]);
            }
            return localMax[days - 1, 1];
        }

        public IList<int> PreorderTraversal1(TreeNode root)
        {
            var ret = new List<int>();
            if (root == null)
            {
                return ret;
            }
            PreorderTraversal1Helper(root, ret);
            return ret;
        }
        private void PreorderTraversal1Helper(TreeNode root, IList<int> ret)
        {
            ret.Add(root.val);

            if (root.left != null)
            {
                PreorderTraversal1Helper(root.left, ret);
            }
            if (root.right != null)
            {
                PreorderTraversal1Helper(root.right, ret);
            }
        }

        public IList<int> PreorderTraversal2(TreeNode root)
        {
            var ret = new List<int>();
            if (root == null)
            {
                return ret;
            }
            var rights = new Stack<TreeNode>();
            var node = root;

            while (node != null)
            {
                ret.Add(node.val);
                if (node.right != null)
                {
                    rights.Push(node.right);
                }
                if (node.left != null)
                {
                    node = node.left;
                }
                else if (rights.Count != 0)
                {
                    node = rights.Pop();
                }
                else
                {
                    node = null;
                }
            }
            return ret;
        }

        public IList<int> InorderTraversal(TreeNode root)
        {
            var ret = new List<int>();
            if (root == null)
            {
                return ret;
            }
            var node = root;
            var s = new Stack<TreeNode>();

            while (node != null)
            {
                s.Push(node);
                node = node.left;
            }
            while(s.Count!=0)
            {
                node = s.Pop();
                ret.Add(node.val);

                node = node.right;
                while(node!=null)
                {
                    s.Push(node);
                    node = node.left;
                }
            }
            return ret;
        }

        public int MaxProduct(string[] words)
        {
            var n = words.Length;
            var keys = new int[n];
            var ret = int.MinValue;

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < words[i].Length; j++)
                {
                    keys[i] |= (1 << words[i][j] - 'a');
                }
            }
            for (var i = 0; i < n; i++)
            {
                for (var j = i + 1; j < n; j++)
                {
                    if (words[i].Length * words[j].Length > ret && (keys[i] ^ keys[j]) == 0)
                    {
                        ret = words[i].Length * words[j].Length;
                    }
                }
            }
            return ret;
        }

        public ListNode OddEvenList(ListNode head)
        {
            if (head == null || head.next == null || head.next.next == null)
            {
                return head;
            }
            var oddHead = head;
            var evenHead = head.next;
            var odd = oddHead;
            var even = evenHead;

            while (even != null && even.next != null)
            {
                var tmp1 = odd.next.next;
                var tmp2 = even.next.next;
                odd.next = tmp1;
                even.next = tmp2;
                odd = tmp1;
                even = tmp2;
            }
            odd.next = evenHead;
            return oddHead;
        }

        public int KthSmallest1(TreeNode root, int k)
        {
            var s = new Stack<TreeNode>();
            var node = root;
            while (node != null)
            {
                s.Push(node);
                node = node.left;
            }

            while (k > 1)
            {
                node = s.Pop();
                node = node.right;

                while (node != null)
                {
                    s.Push(node);
                    node = node.left;
                }
                k--;
            }
            return s.Peek().val;
        }

        public int KthSmallest2(TreeNode root, int k)
        {
            count = k;
            KthSmallest2Helper(root);
            return num;
        }
        private int num = 0;
        private int count;
        private void KthSmallest2Helper(TreeNode root)
        {
            if (count > 0 && root.left != null)
            {
                KthSmallest2Helper(root.left);
            }
            count--;
            if (count == 0)
            {
                num = root.val;
                return;
            }
            if (count > 0 && root.right != null)
            {
                KthSmallest2Helper(root.right);
            }
        }

        public int KthSmallest3(TreeNode root, int k)
        {
            var left = CountNodes(root.right);

            if(k<=left)
            {
                return KthSmallest3(root.left, k);
            }
            if(k==left+1)
            {
                return root.val;
            }
            return KthSmallest3(root.right, k - left - 1);
        }
        private int CountNodes(TreeNode node)
        {
            return node == null ? 0 : 1 + CountNodes(node.left) + CountNodes(node.right);
        }

        public int NumTrees(int n)
        {
            var ret = new int[n + 1];
            ret[0] = 1;

            for (var i = 1; i <= n; i++)
            {
                var j = 0;
                while (j < i - 1 - j)
                {
                    ret[i] += 2 * ret[j] * ret[i - 1 - j];
                    j++;
                }
                if (j == i - 1 - j)
                {
                    ret[i] += ret[j] * ret[j];
                }
            }
            return ret[n];
        }

        public int Rob1(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            if (dic.ContainsKey(root))
            {
                return dic[root];
            }

            var steal = root.val;
            if (root.left != null)
            {
                steal += Rob1(root.left.left) + Rob1(root.left.right);
            }
            if (root.right != null)
            {
                steal += Rob1(root.right.left) + Rob1(root.right.right);
            }
            var notSteat = Rob1(root.left) + Rob1(root.right);

            dic.Add(root, System.Math.Max(steal, notSteat));
            return System.Math.Max(steal, notSteat);
        }
        private Dictionary<TreeNode, int> dic = new Dictionary<TreeNode, int>();

        public int Rob2(TreeNode root)
        {
            return Rob2Helper(root).Max();
        }
        private int[] Rob2Helper(TreeNode node)
        {
            var ret = new int[2];
            if (node == null)
            {
                return ret;
            }
            var left = Rob2Helper(node.left);
            var right = Rob2Helper(node.right);

            ret[0] = left.Max() + right.Max();
            ret[1] = left[0] + right[0] + node.val;
            return ret;
        }

        public int SearchInsert(int[] nums, int target)
        {
            var lo = 0;
            var hi = nums.Length - 1;

            while (lo < hi)
            {
                var mid = lo + (hi - lo) / 2;

                if (nums[mid] < target)
                {
                    lo = mid + 1;
                }
                else if (nums[mid] > target)
                {
                    hi = mid;
                }
                else
                {
                    return mid;
                }
            }
            return nums[lo] >= target ? lo : lo + 1;
        }

        public TreeNode SortedArrayToBST(int[] nums)
        {
            return SortedArrayToBSTHelper(nums, 0, nums.Length - 1);
        }
        private TreeNode SortedArrayToBSTHelper(int[] nums, int lo, int hi)
        {
            if (lo > hi)
            {
                return null;
            }
            if (lo == hi)
            {
                return new TreeNode(nums[lo]);
            }
            var mid = (lo + hi) / 2;
            var root = new TreeNode(nums[mid]);
            root.left = SortedArrayToBSTHelper(nums, lo, mid - 1);
            root.right = SortedArrayToBSTHelper(nums, mid + 1, hi);
            return root;
        }

        public IList<string> GenerateParenthesis1(int n)
        {
            var ret = new List<string>();

            GenerateParenthesisHelper(n, 0, "", ret);
            return ret;
        }
        private void GenerateParenthesisHelper(int n, int m, string s, IList<string> ret)
        {
            if (n == 0 && m == 0)
            {
                ret.Add(s);
                return;
            }
            if (n > 0)
            {
                GenerateParenthesisHelper(n - 1, m + 1, s + "(", ret);
            }
            if (m > 0)
            {
                GenerateParenthesisHelper(n, m - 1, s + ")", ret);
            }
        }

        public IList<string> GenerateParenthesis2(int n)
        {
            var ret = new List<string>();
            if (n == 0)
            {
                return ret;
            }
            ret.Add("()");

            while (n > 1)
            {
                var cur = new List<string>();

                foreach (var s in ret)
                {
                    cur.Add("(" + s + ")");
                    cur.Add("()" + s);
                    if ("()" + s != s + "()")
                    {
                        cur.Add(s + "()");
                    }
                }
                ret = cur;
                n--;
            }
            return ret;
        }

        public int MaxProfit3(int[] prices)
        {
            var days = prices.Length;

            if (days <= 1)
            {
                return 0;
            }
            var ret = new int[days, 2];
            ret[0, 0] = -prices[0];
            ret[0, 1] = 0;
            ret[1, 0] = Math.Max(ret[0, 0], -prices[1]);
            ret[1, 1] = Math.Max(ret[0, 0] + prices[1], ret[0, 1]);

            for (var i = 2; i < days; i++)
            {
                ret[i, 0] = Math.Max(ret[i - 2, 1] - prices[i], ret[i - 1, 0]);
                ret[i, 1] = Math.Max(ret[i - 1, 0] + prices[i], ret[i - 1, 1]);
            }
            return ret[days - 1, 1];
        }

        public int MaxSubArray1(int[] nums)
        {
            var n = nums.Length;
            if (n == 0)
            {
                return 0;
            }
            var ret = new int[n];
            ret[0] = nums[0];

            for (var i = 1; i < n; i++)
            {
                ret[i] = Math.Max(ret[i - 1] + nums[i], nums[i]);
            }
            return ret.Max();
        }

        public int MaxSubArray2(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            var localMax = nums[0];
            var globalMax = localMax;

            for (var i = 1; i < nums.Length; i++)
            {
                localMax = Math.Max(localMax + nums[i], nums[i]);
                globalMax = Math.Max(globalMax, localMax);
            }
            return globalMax;
        }

        public IList<int> GrayCode(int n)
        {
            var ret = new int[(int)Math.Pow(2, n)];

            for (var i = 1; i <= n; i++)
            {
                for (var j = (int)(Math.Pow(2, i - 1) - 1); j >= 0; j--)
                {
                    ret[(int)(Math.Pow(2, i) - j - 1)] = ret[j] + (1 << (i - 1));
                }
            }
            return ret;
        }

        public int UniquePaths(int m, int n)
        {
            var count = new int[m];
            count[0] = 1;

            for (var i = 0; i < n; i++)
            {
                for (var j = 1; j < m; j++)
                {
                    count[j] += count[j - 1];
                }
            }
            return count.Last();
        }

        public int FindMin(int[] nums)
        {
            var lo = 0;
            var hi = nums.Length - 1;

            while (lo < hi)
            {
                if (nums[lo] < nums[hi])
                {
                    return nums[lo];
                }
                var mid = lo + (hi - lo) / 2;
                if (nums[mid] < nums[hi])
                {
                    hi = mid;
                }
                else
                {
                    lo = mid + 1;
                }
            }
            return nums[lo];
        }

        public IList<IList<int>> Permutation1(int[] nums)
        {
            var ret = new List<IList<int>>();

            PermutationHelper(nums, 0, ret);
            return ret;
        }
        private void PermutationHelper(int[] nums, int begin, IList<IList<int>> ret)
        {
            if (begin == nums.Length - 1)
            {
                var copy = new int[nums.Length];
                nums.CopyTo(copy, 0);
                ret.Add(copy);
                return;
            }
            for (var i = begin; i < nums.Length; i++)
            {
                Swap(nums, i, begin);
                PermutationHelper(nums, begin + 1, ret);
                Swap(nums, i, begin);
            }
        }

        public IList<IList<int>> Permutation2(int[] nums)
        {
            var ret = new List<IList<int>>();
            if (nums.Length == 0)
            {
                return ret;
            }
            ret.Add(new List<int>());
            ret[0].Add(nums[0]);

            for (var i = 1; i < nums.Length; i++)
            {
                var cur = new List<IList<int>>();
                for (var j = 0; j < ret.Count; j++)
                {
                    for (var k = 0; k <= i; k++)
                    {
                        ret[j].Insert(k, nums[i]);
                        var copy = new int[i + 1];
                        ret[j].CopyTo(copy, 0);
                        cur.Add(copy.ToList());
                        ret[j].Remove(nums[i]);
                    }
                }
                ret = cur;
            }
            return ret;
        }
        private void Swap(int[] nums, int i, int j)
        {
            var tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }

        public IList<IList<int>> Combination216(int k, int n)
        {
            var ret = new List<IList<int>>();
            CombinationHelper(n, k, new List<int>(), ret);
            return ret;
        }
        private void CombinationHelper(int n, int k, IList<int> s, IList<IList<int>> ret)
        {
            if (n == 0 && k == 0)
            {
                var copy = new int[s.Count];
                s.CopyTo(copy, 0);
                ret.Add(copy);
                return;
            }
            var start = s.Count == 0 ? 0 : s.Last();
            if (n >  start && k > 0)
            {
                for (var i = start + 1; i <= 10 - k && i <= n; i++)
                {
                    s.Add(i);
                    CombinationHelper(n - i, k - 1, s, ret);
                    s.Remove(i);
                }
            }
        }

        public void Rotate(int[,] matrix)
        {
            var n = matrix.GetLength(0);
            var i = 0;
            var j = 0;

            while(i < n/2)
            {
                while (i + j < n - 1)
                {
                    Swap(matrix, j, n-1-i, i, j);
                    j++;
                }
                j = i;
                while(i+j<n-1)
                {
                    Swap(matrix, n-1-i, n-1-j, i, j);
                    j++;
                }
                j = i;
                while(i+j<n-1)
                {
                    Swap(matrix, n-1-j, i, i, j);
                    j++;
                }
                i++;
                j = i;
            }
        }

        private void Swap(int[,] matrix, int i, int j, int m, int n)
        {
            var temp = matrix[i, j];
            matrix[i, j] = matrix[m, n];
            matrix[m, n] = temp;
        }

        public int MaxArea(int[] height)
        {
            var i = 0;
            var j = height.Length - 1;
            var max = int.MinValue;

            while (i < j)
            {
                max = Math.Max(max, (j - i) * Math.Min(height[i], height[j]));
                if (height[i] < height[j])
                {
                    i++;
                }
                else
                {
                    j--;
                }
            }
            return max;
        }

        public bool SearchMatrix(int[,] matrix, int target)
        {
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);
            var i = 0;
            var j = n - 1;

            while (i < m && j >= 0)
            {
                if (target < matrix[i, j])
                {
                    j--;
                }
                else if (target > matrix[i, j])
                {
                    i++;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public IList<int> RightSideView1(TreeNode root)
        {
            var ret = new List<int>();
            if (root == null)
            {
                return ret;
            }
            RightSideView1Helper(root, 0, ret);
            return ret;
        }
        private void RightSideView1Helper(TreeNode root, int level, IList<int> ret)
        {
            if (level == ret.Count)
            {
                ret.Add(root.val);
            }
            if (root.right != null)
            {
                RightSideView1Helper(root.right, level + 1, ret);
            }
            if (root.left != null)
            {
                RightSideView1Helper(root.left, level + 1, ret);
            }
        }

        public IList<IList<int>> Combination771(int k, int n)
        {
            var ret = new List<IList<int>>();
            if (k == 0)
            {
                return ret;
            }
            for (var i = 1; i <= n; i++)
            {
                ret.Add(new List<int>() { i });
            }

            for (var i = 2; i <= k; i++)
            {
                var cur = new List<IList<int>>();

                for (var j = 0; j <= ret.Count; j++)
                {
                    for (var p = ret[j].Last() + 1; p <= n; p++)
                    {
                        var copy = new int[i];
                        ret[j].CopyTo(copy, 0);
                        copy[i - 1] = p;
                        cur.Add(copy);
                    }
                }
                ret = cur;
            }
            return ret;
        }

        public IList<IList<int>> Combination772(int n, int k)
        {
            var ret = new List<IList<int>>();
            if (k == 1)
            {
                for (var i = 1; i <= n; i++)
                {
                    ret.Add(new List<int>() { i });
                }
                return ret;
            }
            if (k == n)
            {
                ret.Add(new List<int>());
                for (var i = 1; i <= n; i++)
                {
                    ret[0].Add(i);
                }
                return ret;
            }
            var part1 = Combination772(n - 1, k);
            var part2 = Combination772(n - 1, k - 1);
            for (var i = 0; i < part2.Count; i++)
            {
                part2[i].Add(n);
            }
            ret.AddRange(part1);
            ret.AddRange(part2);
            return ret;
        }

        public IList<IList<int>> Combination773(int n, int k)
        {
            var ret = new List<IList<int>>();

            Combination773Helper(n, k, new List<int>(), ret);
            return ret;
        }
        private void Combination773Helper(int n, int k, IList<int> s, IList<IList<int>> ret)
        {
            if (s.Count == k)
            {
                var copy = new int[k];
                s.CopyTo(copy, 0);
                ret.Add(copy);
                return;
            }
            if (s.Count < k)
            {
                for (var i = (s.Count == 0 ? 1 : s.Last() + 1); i <= n; i++)
                {
                    s.Add(i);
                    Combination773Helper(n, k, s, ret);
                    s.Remove(i);
                }
            }
        }

        public bool IncreasingTriplet(int[] nums)
        {
            if (nums.Length <= 2)
            {
                return false;
            }
            var min = nums[0];
            var mid = int.MaxValue;

            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i] <= min)
                {
                    min = nums[i];
                }
                else if (nums[i] <= mid)
                {
                    mid = nums[i];
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public int FindPeakElement(int[] nums)
        {
            var lo = 0;
            var hi = nums.Length - 1;

            while (hi - lo >= 2)
            {
                var mid = lo + (hi - lo) / 2;

                if (nums[mid]<nums[mid+1])
                {
                    lo = mid + 1;
                }
                else if (nums[mid] < nums[mid - 1])
                {
                    hi = mid - 1;
                }
                else
                {
                    return mid;
                }
            }
            return nums[lo] > nums[hi] ? lo : hi;
        }

        public int RemoveDuplicates2(int[] nums)
        {
            if (nums.Length <= 2)
            {
                return nums.Length;
            }
            var i = 0;
            var j = 1;
            var k = 2;

            while (k < nums.Length)
            {
                if (nums[i] != nums[j] || nums[k] != nums[j])
                {
                    ++i;
                    nums[++j] = nums[k];
                }
                k++;
            }
            return j + 1;
        }

        public int SumNumbers(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            var sum = 0;
            SumNumbersHelper(root, 0, ref sum);
            return sum;
        }
        private void SumNumbersHelper(TreeNode root, int route, ref int sum)
        {
            route = route * 10 + root.val;
            if (root.left == null && root.right == null)
            {
                sum += route;
                return;
            }
            if (root.left != null)
            {
                SumNumbersHelper(root.left, route, ref sum);
            }
            if (root.right != null)
            {
                SumNumbersHelper(root.right, route, ref sum);
            }
        }

        public int Search(int[] nums, int target)
        {
            var lo = 0;
            var hi = nums.Length - 1;

            while (lo < hi)
            {
                var mid = lo + (hi - lo) / 2;

                if (nums[mid] == nums[hi])
                {
                    hi--;
                }
                else if (nums[mid] < nums[hi])
                {
                    if (target > nums[mid] && target <= nums[hi])
                    {
                        lo = mid + 1;
                    }
                    else
                    {
                        hi = mid;
                    }
                }
                else
                {
                    if (target >= nums[lo] && target <= nums[mid])
                    {
                        hi = mid;
                    }
                    else
                    {
                        lo = mid + 1;
                    }
                }
            }
            return nums[lo] == target ? lo : -1;
        }

        public bool IsValidSerialization(string preorder)
        {
            var s = new Stack<string>();
            var arr = preorder.Split(',');

            for (var i = 0; i < arr.Length; i++)
            {
                if (arr[i] == "#")
                {
                    while (s.Count != 0 && s.Peek() == "#")
                    {
                        s.Pop();
                        if (s.Count == 0 || s.Peek()=="#")
                        {
                            return false;
                        }
                        s.Pop();
                    }
                }
                s.Push(arr[i]);
            }
            return s.Count == 1 && s.Peek() == "#";
        }

        public IList<IList<int>> Subsets(int[] nums)
        {
            var ret = new List<IList<int>>();

            System.Array.Sort(nums);
            SubsetsHelper(nums, 0, new List<int>(), ret);
            return ret;
        }
        private void SubsetsHelper(int[] nums, int begin, IList<int> s, IList<IList<int>> ret)
        {
            var copy = new int[s.Count];
            s.CopyTo(copy, 0);
            ret.Add(copy);

            for (var i = begin; i < nums.Length; i++)
            {
                s.Add(nums[i]);
                SubsetsHelper(nums, i + 1, s, ret);
                s.Remove(nums[i]);
            }
        }

        public void Flatten(TreeNode root)
        {
            var s = new Stack<TreeNode>();
            var node = root;

            while (node != null)
            {
                if (node.right != null)
                {
                    s.Push(node.right);
                }
                if (node.left != null)
                {
                    node.right = node.left;
                    node.left = null;
                    node = node.right;
                }
                else if (s.Count != 0)
                {
                    node.right = s.Pop();
                    node = node.right;
                }
                else
                {
                    node = null;
                }
            }
        }

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var ret = new List<IList<int>>();

            System.Array.Sort(candidates);
            CombinationSumHelper(candidates, 0, target, new List<int>(), ret);
            return ret;
        }
        private void CombinationSumHelper(int[] candidates, int begin, int target, IList<int> s, IList<IList<int>> ret)
        {
            if(target==0)
            {
                var copy = new int[s.Count];
                s.CopyTo(copy, 0);
                ret.Add(copy);
                return;
            }
            for (var i = begin; i < candidates.Length && candidates[i] <= target; i++)
            {
                s.Add(candidates[i]);
                CombinationSumHelper(candidates, i, target - candidates[i], s, ret);
                s.Remove(candidates[i]);
            }
        }

        public int RangeBitwiseAnd(int m, int n)
        {
            var count = 0;

            while (m != n)
            {
                m >>= 1;
                n >>= 1;
                count++;
            }
            m <<= count;
            return m;
        }

        public int MinmumTotal(IList<IList<int>> triangle)
        {
            var i = triangle.Count - 1;
            var pre = triangle.Last();

            while (i >= 1)
            {
                var n = triangle[i - 1].Count;
                var cur = new int[n];

                for (var j = 0; j < n; j++)
                {
                    cur[j] = triangle[i - 1][j] + Math.Min(pre[j], pre[j + 1]);
                }
                pre = cur;
                i--;
            }
            return pre[0];
        }

        public ListNode Partition(ListNode head, int x)
        {
            var small = new ListNode(0);
            var large = new ListNode(0);
            var smallHead = small;
            var largeHead = large;
            var node = head;

            while (node != null)
            {
                if (node.val < x)
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
            if (smallHead.next == null)
            {
                return head;
            }
            large.next = null;
            small.next = largeHead.next;
            return smallHead.next;
        }

        public ListNode InertionSortList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            var node = head.next;
            head.next = null;

            while (node != null)
            {
                var tmp1 = node.next;
                var tmp2 = head;
                ListNode pre = null;

                while (tmp2 != null && tmp2.val < node.val)
                {
                    pre = tmp2;
                    tmp2 = tmp2.next;
                }
                if (pre == null)
                {
                    node.next = head;
                    head = node;
                }
                else
                {
                    pre.next = node;
                    node.next = tmp2;
                }
                node = tmp1;
            }
            return head;
        }

        public int MinPatches(int[] nums, int n)
        {
            var sum = 0;
            var i = 0;
            var patch = 0;

            while (sum < n)
            {
                if (i < nums.Length && nums[i] <= sum+1)
                {
                    sum += nums[i];
                    i++;
                }
                else
                {
                    patch++;
                    sum = 2 * sum + 1;
                }
            }
            return patch;
        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root == p || root == q)
            {
                return root;
            }
            var i = LowestCommonAncestor(root.left, p, q);
            var j = LowestCommonAncestor(root.right, p, q);
            if (i != null && j != null)
            {
                return root;
            }
            return i == null ? j : i;
        }

        public bool CanJump(int[] nums)
        {
            var i = 1;
            var j = nums[0];

            while (j < nums.Length - 1)
            {
                if (i > j)
                {
                    return false;
                }
                j = Math.Max(j, i + nums[i]);
                i++;
            }
            return true;
        }

        public int Jump1(int[] nums)
        {
            var n = nums.Length;
            var jump = new int[n];

            for (var i = 1; i < n; i++)
            {
                jump[i] = int.MaxValue;
            }
            for (var i = 0; i < n - 1; i++)
            {
                for (var j = i + 1; j <= i + nums[i] && j < n; j++)
                {
                    jump[j] = Math.Min(jump[j], jump[i] + 1);
                }
            }
            return jump.Last();
        }

        public int Jump2(int[] nums)
        {
            var farest = nums[0];
            var jump = 1;
            var i = 1;

            while (farest < nums.Length - 1)
            {
                var max = farest;
                var idx = i;
                while (i <= farest)
                {
                    if (nums[i] + i > max)
                    {
                        max = nums[i] + i;
                        idx = i;
                    }
                    i++;
                }
                i = idx;
                farest = max;
                jump++;
            }
            return jump;
        }

        public int Jump3(int[] nums)
        {
            var farest = nums[0];
            var jump = 1;
            var i = 1;

            while (farest < nums.Length - 1)
            {
                var curFarest = farest;
                while (i <= curFarest)
                {
                    farest = Math.Max(farest, i + nums[i]);
                    i++;
                }
                jump++;
            }
            return jump;
        }

        public IList<IList<int>> PathSum1(TreeNode root, int sum)
        {
            var ret = new List<IList<int>>();

            PathSum1Helper(root, sum, new List<int>(), ret);
            return ret;
        }
        private void PathSum1Helper(TreeNode node, int sum, IList<int> route, IList<IList<int>> ret)
        {
            route.Add(node.val);
            var copy = new int[route.Count];
            route.CopyTo(copy, 0);
            if (node.left==null&&node.right==null&&sum == node.val)
            {
                ret.Add(copy);
                return;
            }
            if (node.left != null)
            {
                PathSum1Helper(node.left, sum - node.val, route, ret);
            }
            if (node.right != null)
            {
                PathSum1Helper(node.right, sum - node.val, copy.ToList(), ret);
            }
        }

        public IList<IList<int>> PathSum2(TreeNode root, int sum)
        {
            var s1 = new Stack<TreeNode>();
            var s2 = new Stack<TreeNode>();
            var route = new List<int>();
            var amount = 0;
            var ret = new List<IList<int>>();
            var node = root;

            while (node != null)
            {
                s1.Push(node);
                route.Add(node.val);
                amount += node.val;
                if (node.left == null && node.right == null)
                {
                    if (amount == sum)
                    {
                        var copy = new int[route.Count];
                        route.CopyTo(copy, 0);
                        ret.Add(copy);
                    }
                    if (s2.Count() == 0)
                    {
                        break;
                    }
                    while (s1.Peek().right != s2.Peek())
                    {
                        s1.Pop();
                        amount -= route.Last();
                        route.RemoveAt(route.Count - 1);
                    }
                    node = s2.Pop();
                    continue;
                }
                if (node.right != null)
                {
                    s2.Push(node.right);
                }
                if (node.left != null)
                {
                    node = node.left;
                }
                else
                {
                    node = s2.Pop();
                }
            }
            return ret;
        }

        public double MyPow(double x, int n)
        {
            if (n < 0 && n != int.MinValue)
            {
                x = 1 / x;
                n = -n;
            }
            if (n == 0)
            {
                return 1;
            }
            if (n == 1)
            {
                return x;
            }
            return MyPow(x * x, n / 2) * MyPow(x, n % 2);
        }

        public int NumIslands(char[,] grid)
        {
            var m = grid.GetLength(0);
            var n = grid.GetLength(1);
            var num = 0;

            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (grid[i, j] == '1')
                    {
                        num++;
                        NumIslandsHelper(grid, i, j);
                    }
                }
            }
            return num;
        }
        private void NumIslandsHelper(char[,] grid, int i, int j)
        {
            var m = grid.GetLength(0);
            var n = grid.GetLength(1);

            grid[i, j] = '0';
            if (i - 1 >= 0 && grid[i - 1, j] == '1')
            {
                NumIslandsHelper(grid, i - 1, j);
            }
            if (i + 1 < m && grid[i + 1, j] == '1')
            {
                NumIslandsHelper(grid, i + 1, j);
            }
            if (j - 1 >= 0 && grid[i, j - 1] == '1')
            {
                NumIslandsHelper(grid, i, j - 1);
            }
            if (j + 1 < n && grid[i, j + 1] == '1')
            {
                NumIslandsHelper(grid, i, j + 1);
            }
        }

        public IList<IList<string>> Partition(string s)
        {
            var ret = new List<IList<string>>();

            PartitionHelper(s, 0, new List<string>(), ret);
            return ret;
        }
        private void PartitionHelper(string s, int begin, IList<string> p, IList<IList<string>> ret)
        {
            if (begin == s.Length)
            {
                ret.Add(p);
                return;
            }
            if (begin < s.Length)
            {
                var i = begin;
                var j = begin;
                while (j < s.Length)
                {
                    if (s[i] != s[j])
                    {
                        j++;
                        continue;
                    }
                    var lo = i;
                    var hi = j;
                    while (hi > lo && s[hi]==s[lo])
                    {
                        hi--;
                        lo++;
                    }
                    if (hi <= lo)
                    {
                        var copy = new string[p.Count+1];
                        p.CopyTo(copy, 0);
                        copy[p.Count] = s.Substring(i, j - i + 1);
                        PartitionHelper(s, j + 1, copy, ret);
                    }
                    j++;
                }
            }
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var dic = new Dictionary<string, IList<string>>();

            for (var i = 0; i < strs.Count(); i++)
            {
                var key = strs[i].ToArray();
                System.Array.Sort(key);
                var s = "";
                foreach (var c in key)
                {
                    s += c;
                }
                if (dic.ContainsKey(s))
                {
                    dic[s].Add(strs[i]);
                }
                else
                {
                    dic.Add(s, new List<string>() { strs[i] });
                }
            }
            var groups = dic.Values;
            var ret = new List<IList<string>>();
            foreach (var item in groups)
            {
                var tmp = item.ToArray();
                System.Array.Sort(tmp);
                ret.Add(tmp);
            }
            return ret;
        }

        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            var sum = 0;
            var start = 0;

            for (var i = 0; i < gas.Length; i++)
            {
                sum = sum + gas[i] - cost[i];
                if (sum < 0)
                {
                    sum = 0;
                    start = i + 1;
                }
            }
            return start < gas.Length ? start : -1;
        }

        public int MinSubArrayLen(int s, int[] nums)
        {
            var lo = 0;
            var hi = 0;
            var sum = 0;
            var minLen = int.MaxValue;

            while (hi < nums.Length)
            {
                while (hi < nums.Length && sum < s)
                {
                    sum += nums[hi++];
                }
                hi--;
                while(sum >= s)
                {
                    sum -= nums[lo++];
                }
                lo--;
                minLen = Math.Min(hi - lo + 1, minLen);
            }
            return nums.Sum() >= s ? minLen : 0;
        }

        public ListNode DeleteDuplicates2(ListNode head)
        {
            if(head==null||head.next==null)
            {
                return head;
            }
            var newHead = new ListNode(0);
            newHead.next = head;
            var pre = newHead;
            var lo = head;
            var hi = head;

            while (hi != null)
            {
                while(hi!=null&&hi.val==lo.val)
                {
                    hi = hi.next;
                }
                if(lo.next==hi)
                {
                    pre = lo;
                }
                else
                {
                    pre.next = hi;
                }
                lo = hi;
            }
            return newHead.next;
        }

        public IList<int> MajorityElements(int[] nums)
        {
            if(nums.Length<=2)
            {
                return nums;
            }
            var candidate1 = nums[0];
            var candidate2 = nums[0];
            var count1 = 0;
            var count2 = 0;

            for(var i = 0;i<nums.Length;i++)
            {
                if(nums[i]==candidate1)
                {
                    count1++;
                }
                else if(nums[i]==candidate2)
                {
                    count2++;
                }
                else if(count1==0)
                {
                    candidate1 = nums[i];
                    count1 = 1;
                }
                else if(count2==0)
                {
                    candidate2 = nums[i];
                    count2 = 1;
                }
                else
                {
                    count1--;
                    count2--;
                }
            }
            count1 = 0;
            count2 = 0;
            for(var i = 0;i<nums.Length;i++)
            {
                if(nums[i]==candidate1)
                {
                    count1++;
                }
                else if(nums[i]==candidate2)
                {
                    count2++;
                }
            }
            var ret = new List<int>();
            if(count1>nums.Length/3)
            {
                ret.Add(candidate1);
            }
            if(count2>nums.Length/3)
            {
                ret.Add(candidate2);
            }
            return ret;
        }

        public bool IsAdditiveNumber(string num)
        {
            var pre = "";
            var cur = "";

            for(var i = 1; i <= num.Length/2;i++)
            {
                pre = num.Substring(0, i);
                if(pre[0]=='0' && i>1)
                {
                    break;
                }
                for(var j = 1; j<num.Length-Math.Max(i,j);j++)
                {
                    cur = num.Substring(i, j);
                    if(cur[0]=='0' && j>1)
                    {
                        break;
                    }
                    var tmp1 = pre;
                    var tmp2 = cur;
                    var tmp3 = StringSum(tmp1, tmp2);
                    var k = i + j;
                    while (k + tmp3.Length - 1 < num.Length && num.Substring(k, tmp3.Length) == tmp3)
                    {
                        tmp1 = tmp2;
                        tmp2 = tmp3;
                        k += tmp3.Length;
                        tmp3 = StringSum(tmp1, tmp2);
                    }
                    if (k==num.Length)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private string StringSum(string a, string b)
        {
            while(a.Length<b.Length)
            {
                a = '0' + a;
            }
            while(b.Length<a.Length)
            {
                b = '0' + b;
            }
            var c = 0;
            var sum = "";

            for(var i = a.Length-1;i>=0;i--)
            {
                var tmp = a[i] - '0' + b[i] - '0' + c;
                sum = (tmp % 10).ToString() + sum;
                c = tmp / 10;
            }
            if(c==1)
            {
                sum = "1" + sum;
            }
            return sum;
        }

        public int Sqrt(int x)
        {
            long lo = 0;
            long hi = x / 2 + 1;

            while(lo<hi)
            {
                long mid = (lo + hi) / 2 + 1;

                if(mid*mid>x)
                {
                    hi = mid - 1;
                }
                else if(mid*mid<x)
                {
                    lo = mid;
                }
                else
                {
                    return (int)mid;
                }
            }
            return (int)lo;
        }
        public int CountChange1(int[] coins, int amount)
        {
            var count = new int[amount + 1];

            for(var i = 1;i<=amount;i++)
            {
                count[i] = int.MaxValue;
                var j = 0;
                while (j < coins.Count())
                {
                    if (i - coins[j] >= 0 && count[i - coins[j]] != int.MaxValue)
                    {
                        count[i] = Math.Min(count[i], count[i - coins[j]] + 1);
                    }
                    j++;
                }
            }
            return count.Last() == int.MaxValue ? -1 : count.Last();
        }

        Dictionary<int, int> dic2 = new Dictionary<int, int>();
        public int CountChange2(int[] coins, int amount)
        {
            if(amount<0)
            {
                return -1;
            }
            if (amount == 0)
            {
                return 0;
            }
            if(dic2.ContainsKey(amount))
            {
                return dic2[amount];
            }
            var ret = int.MaxValue;
            for(var i = 0;i<coins.Count();i++)
            {
                var tmp = CountChange2(coins, amount - coins[i]);
                if(tmp>=0)
                {
                    ret = Math.Min(ret, tmp + 1);
                }
            }
            ret = ret == int.MaxValue ? -1 : ret;
            dic2.Add(amount, ret);
            return ret;
        }

        public int CountChange3(int[] coins, int amount)
        {
            System.Array.Sort(coins);
            coins.Reverse();
            CountChange3Helper(coins, amount, 0, 0);
            return globalMin;
        }
        int globalMin = int.MaxValue;
        private void CountChange3Helper(int[] coins, int amount, int begin, int count)
        {
            if(amount==0)
            {
                globalMin = Math.Min(globalMin, count);
            }
            if(amount>0 && count < globalMin)
            {
                for(var i = begin; i<coins.Length;i++)
                {
                    CountChange3Helper(coins, amount - coins[i], i, count + 1);
                }
            }
        }

        public ListNode SortList(ListNode head)
        {
            if(head==null||head.next==null)
            {
                return head;
            }
            ListNode pre = null;
            var slow = head;
            var fast = head;

            while(fast!=null&&fast.next!=null)
            {
                pre = slow;
                slow = slow.next;
                fast = fast.next.next;
            }
            pre.next = null;
            var left = SortList(head);
            var right = SortList(slow);
            var newHead = new ListNode(0);
            var node = newHead;

            while(left!=null&&right!=null)
            {
                if(left.val<=right.val)
                {
                    node.next = left;
                    left = left.next;
                }
                else
                {
                    node.next = right;
                    right = right.next;
                }
                node = node.next;
            }
            while(left!=null)
            {
                node.next = left;
                left = left.next;
                node = node.next;
            }
            while(right!=null)
            {
                node.next = right;
                right = right.next;
                node = node.next;
            }
            return newHead.next;
        }

        public IList<string> SummaryRanges(int[] nums)
        {
            var ret = new List<string>();
            var head = 0;
            var tail = 0;
            var dif = 0;

            while(head<nums.Length)
            {
                while(tail<nums.Length&&nums[head]+dif==nums[tail])
                {
                    dif++;
                    tail++; 
                }
                var s = nums[head].ToString();
                if(tail-1!=head)
                {
                    s = s + "->" + nums[tail - 1].ToString();
                }
                ret.Add(s);
                head = tail;
                dif = 0;
            }
            return ret;
        } 

        public int NumDecodings1(string s)
        {
            NumDecodings1Helper(s, 0);
            return countforDecoding;
        }
        private int countforDecoding = 0;
        private void NumDecodings1Helper(string s, int begin)
        {
            if(begin==s.Length)
            {
                countforDecoding++;
                return;
            }
            if(begin < s.Length)
            {
                NumDecodings1Helper(s, begin + 1);
                if(begin+1<s.Length)
                {
                    if(s[begin]=='1' || (s[begin]=='2'&&s[begin+1]<='6'))
                    {
                        NumDecodings1Helper(s, begin + 2);
                    }
                }
            }
        }

        public int NumDecodings2(string s)
        {
            if (s == "")
            {
                return 0;
            }
            var count = new int[s.Length + 1];
            count[1] = 1;

            for(var i = 2; i<=s.Length;i++)
            {
                count[i] = count[i - 1];
                if(s[i-1]=='1' || s[i-1]=='2' && s[i]<='6')
                {
                    count[i] += count[i - 2];
                }
            }
            return count.Last();
        }
f       
    }
}

