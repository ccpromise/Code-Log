using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SICPPractise.Algorithm.Internal;

namespace SICPPractise.Algorithm.Tree
{
    public class TreePuzzle
    {
        public static int MaxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            if (root.left == null && root.right == null)
            {
                return 1;
            }
            return 1 + System.Math.Max(MaxDepth(root.left), MaxDepth(root.right));
        }

        public static int MinDepthOfTree1(TreeNode root)

        {
            if (root == null)
            {
                return 0;
            }
            var tree = new Stack<Tuple<TreeNode, int>>();
            tree.Push(new Tuple<TreeNode, int>(root, 1));

            while (tree.Count() != 0)
            {
                var item = tree.Pop();
                var node = item.Item1;
                var level = item.Item2;

                if (node.left == null && node.right == null)
                {
                    return level;
                }
                if (node.left != null)
                {
                    tree.Push(new Tuple<TreeNode, int>(node.left, level + 1));
                }
                if (node.right != null)
                {
                    tree.Push(new Tuple<TreeNode, int>(node.right, level + 1));
                }
            }
            return 0;
        }

        public static int MinDepthOfTree2(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            var queue = new Queue<Tuple<TreeNode, int>>();

            queue.Enqueue(new Tuple<TreeNode, int>(root, 1));
            while (queue.Count() != 0)
            {
                var item = queue.Dequeue();
                var node = item.Item1;
                var level = item.Item2;

                if (node.left == null && node.right == null)
                {
                    return level;
                }
                if (node.left != null)
                {
                    queue.Enqueue(new Tuple<TreeNode, int>(node.left, level + 1));
                }
                if (node.right != null)
                {
                    queue.Enqueue(new Tuple<TreeNode, int>(node.right, level + 1));
                }
            }
            return 0;
        }
        public static TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }
            Queue<TreeNode> nodeQueue = new Queue<TreeNode>();
            nodeQueue.Enqueue(root);

            while (nodeQueue.Count != 0)
            {
                var node = nodeQueue.Dequeue();

                if (node.left != null)
                {
                    nodeQueue.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    nodeQueue.Enqueue(node.right);
                }
                var tmp = node.left;
                node.left = node.right;
                node.right = tmp;
            }
            return root;
        }

        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
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

        public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
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

            while (indexP > 0 && indexQ > 0)
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

        public static bool IsBalanced1(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }
            return System.Math.Abs(Depth(root.left) - Depth(root.right)) <= 1 && IsBalanced1(root.left) && IsBalanced1(root.right);
        }

        public static int Depth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            return 1 + System.Math.Max(Depth(root.right), Depth(root.left));
        }

        public static bool IsBalanced2(TreeNode root)
        {
            return IsBalanced2Iter(root) != -1;
        }
        private static int IsBalanced2Iter(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }
            var leftHeight = IsBalanced2Iter(node.left);
            if (leftHeight == -1) return -1;
            var rightHeight = IsBalanced2Iter(node.right);
            if (rightHeight == -1) return -1;
            if (System.Math.Abs(leftHeight - rightHeight) <= 1)
            {
                return -1;
            }
            return System.Math.Max(leftHeight, rightHeight) + 1;
        }

        public static int KthSmallest(TreeNode root, int k)
        {
            var tree = new Stack<int>();
            if (root != null)
            {
                KthSmallestIter(root, tree);
            }
            int ret = 0;
            for (var i = 1; i <= k; i++)
            {
                ret = tree.Pop();
            }
            return ret;
        }
        private static void KthSmallestIter(TreeNode node, Stack<int> tree)
        {
            if (node.right != null)
            {
                KthSmallestIter(node.right, tree);
            }
            tree.Push(node.val);
            if (node.left != null)
            {
                KthSmallestIter(node.left, tree);
            }          
        }

        public static IList<int> BinaryTreeInorderTraversal(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }
            var tree = new List<int>();
            TreeTraversalIter(root, tree);
            return tree;
        }
        private static void TreeTraversalIter(TreeNode root, IList<int> tree)
        {
            if (root.left != null)
            {
                TreeTraversalIter(root.left, tree);
            }
            tree.Add(root.val);
            if (root.right != null)
            {
                TreeTraversalIter(root.right, tree);
            }
        }

        /// <summary>
        /// #101 Symmetric Tree
        /// Two Ways:
        ///     1\Recursive
        ///     2\traversal using queue or f(node, variable)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static bool IsSymmetric(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }
            return IsSymmetricIter(root.left, root.right);
        }
        private static bool IsSymmetricIter(TreeNode r1, TreeNode r2)
        {
            if (r1 == null && r2 == null)
            {
                return true;
            }
            if (r1 == null || r2 == null)
            {
                return false;
            }
            return r1.val == r2.val && IsSymmetricIter(r1.left, r2.right) && IsSymmetricIter(r1.right, r2.left);
        }

        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
            var tree = new List<IList<int>>();
            if (root != null)
            {
                LevelOrderIter(root, 0, tree);
            }
            return tree;
        }
        private static void LevelOrderIter(TreeNode node, int level, IList<IList<int>> tree)
        {
            if (level == tree.Count())
            {
                tree.Add(new List<int>());
            }
            tree[level].Add(node.val);
            if (node.left != null)
            {
                LevelOrderIter(node.left, level + 1, tree);
            }
            if (node.right != null)
            {
                LevelOrderIter(node.right, level + 1, tree);
            }
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

        public static int Rob(TreeNode root)
        {
            if(root==null)
            {
                return 0;
            }

            var value = 0;
            
            if(root.left!=null)
            {
                value+=Rob(root.left.left)+Rob(root.left.right);
            }
            if(root.right!=null)
            {
                value+=Rob(root.right.left)+Rob(root.right.right);
            }
            return Math.Max(value+root.val, Rob(root.left)+Rob(root.right));
        }

        public static TreeNode SortedArrayToBST2(int[] nums)
        {
            return SortedArrayToBSTIter2(nums, 0, nums.Length - 1);
        }
        private static TreeNode SortedArrayToBSTIter2(int[] nums, int lo, int hi)
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
            root.left = SortedArrayToBSTIter2(nums, lo, mid - 1);
            root.right = SortedArrayToBSTIter2(nums, mid + 1, hi);
            return root;
        }

        public class BSTIterator
        {
            public Stack<TreeNode> s = new Stack<TreeNode>();

            public BSTIterator(TreeNode root)
            {
                if (root != null)
                {
                    FindLeft(root);
                }
            }

            public bool HasNext()
            {
                return s.Count() != 0;
            }

            public int Next()
            {
                var top = s.Pop();

                if (top.right != null)
                {
                    FindLeft(top.right);
                }
                return top.val;
            }

            private void FindLeft(TreeNode root)
            {
                s.Push(root);
                if (root.left != null)
                {
                    FindLeft(root.left);
                }
            }

            public IList<int> RightSideView(TreeNode root)
            {
                var ret = new List<int>();
                if (root == null)
                {
                    return ret;
                }
                var queue = new Queue<TreeNode>();
                queue.Enqueue(root);

                while (queue.Count() != 0)
                {
                    var size = queue.Count();
                    var node = queue.Dequeue();

                    ret.Add(node.val);
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    for (var i = 2; i <= size; i++)
                    {
                        node = queue.Dequeue();
                        if (node.right != null)
                        {
                            queue.Enqueue(node.right);
                        }
                        if (node.left != null)
                        {
                            queue.Enqueue(node.left);
                        }
                    }
                }
                return ret;
            }

            public int SumNumbers(TreeNode root)
            {
                var sum = 0;
                if (root != null)
                {
                    Helper(root, 0, ref sum);
                }
                return sum;
            }

            private void Helper(TreeNode node, int n, ref int sum)
            {
                n = n * 10 + node.val;
                if (node.left == null && node.right == null)
                {
                    sum += n;
                    return;
                }
                if (node.left != null)
                {
                    Helper(node.left, n, ref sum);
                }
                if (node.right != null)
                {
                    Helper(node.right, n, ref sum);
                }
            }
        }

        public static bool IsValidSerialization(string preorder)
        {
            var arr = preorder.Split(new[] { ',' }).ToList();
            if(arr.Count()<3)
            {
                return false;
            }

            var flag = true;

            while(flag)
            {
                flag = false;
                var i = 0;
                while(i<arr.Count()-2 && !(arr[i]!="#"&&arr[i+1]=="#"&&arr[i+2]=="#"))
                {
                    i++;
                }
                if(i<arr.Count()-2)
                {
                    flag = true;
                    arr.RemoveAt(i);
                    arr.RemoveAt(i + 2);
                    continue;
                }
            }
            return arr.Count() == 1;
        }

        public static bool IsValidSerialization2(string preorder)
        {
            var arr = preorder.Split(new[] { ',' });
            var s = new Stack<string>();

            for(var i = 0;i<arr.Length;i++)
            {
                if(arr[i]=="#")
                {
                    while(s.Peek()=="#")
                    {
                        s.Pop();
                        var n = s.Pop();
                        if(n=="#")
                        {
                            return false;
                        }
                    }
                }
                s.Push(arr[i]);
            }
            return s.Count() == 1 && s.Peek() == "#";
        }

        public static void Flatten(TreeNode root)
        {
            var queue = new Queue<TreeNode>();

            if(root!=null)
            {
                Helper(root, queue);
            }
            if(queue.Count!=0)
            {
                var r = queue.Dequeue();
                r.left = null;
                var pre = r;
                while(queue.Count()!=0)
                { 
                    var node = queue.Dequeue();
                    node.left = null;
                    pre.right = node;
                    pre = node;
                }
                pre.left = null;
                pre.right = null;
            }
        }
        private static void Helper(TreeNode node, Queue<TreeNode> q)
        {
            q.Enqueue(node);

            if(node.left!=null)
            {
                Helper(node.left, q);
            }
            if(node.right!=null)
            {
                Helper(node.right, q);
            }
        }

        public static void Flatten2(TreeNode root)
        {
            if(root!=null)
            {
                Helper(root, root.left);
            }
        }
        private static void Helper(TreeNode p, TreeNode c)
        {
            if(c.left!=null)
            {
                Helper(c, c.left);
            }
            if(c.right!=null)
            {
                Helper(c, c.right);
            }
            var tmp = p.right;
            p.right = c;
            p.left = null;
            c.right = p.right;


        }

        public static TreeNode SortedListToBST(ListNode head)
        {
            var arr = new List<int>();

            while(head!=null)
            {
                arr.Add(head.val);
                head = head.next;
            }
            return SortedArrayToBST(arr.ToArray());
        }

        public IList<TreeNode> GenerateTrees(int n)
        {
            return GenerateTreesHelper(1, n);
        }
        public static Dictionary<Tuple<int, int>, IList<TreeNode>> dic = new Dictionary<Tuple<int, int>, IList<TreeNode>>();
        private static IList<TreeNode> GenerateTreesHelper(int lo, int hi)
        {
            if(dic.ContainsKey(new Tuple<int, int>(lo, hi)))
            {
                return dic[new Tuple<int, int>(lo, hi)];
            }
            var ret = new List<TreeNode>();
            if(lo>hi)
            {
                ret.Add(null);
                return ret;
            }
            if(lo==hi)
            {
                ret.Add(new TreeNode(lo));
                return ret;
            }
            for(var i = lo;i<= hi;i++)
            {
                var left = GenerateTreesHelper(lo, i - 1);
                var right = GenerateTreesHelper(i + 1, hi);
                foreach(var l in left)
                {
                    foreach(var r in right)
                    {
                        var root = new TreeNode(i);
                        root.left = l;
                        root.right = r;
                        ret.Add(root);
                    }
                }
            }
            dic.Add(new Tuple<int, int>(lo, hi), ret);
            return ret;
        }

        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            return BuildTreeHelper(inorder, 0, inorder.Length - 1, postorder, 0, postorder.Length - 1);
        }
        private TreeNode BuildTreeHelper(int[] inorder, int ilo, int ihi, int[] postorder, int plo, int phi)
        {
            if(ilo < ihi || plo < phi)
            {
                return null;
            }
            var root = new TreeNode(postorder[phi]);
            var n = 0;
            while(inorder[n+ilo]!=postorder[phi])
            {
                n++;
            }
            root.left = BuildTreeHelper(inorder, ilo, ilo + n - 1, postorder, plo, plo + n - 1);
            root.right = BuildTreeHelper(inorder, ilo + n + 1, ihi, postorder, plo + n, phi);
            return root;
        }

        public int MaxPathSum(TreeNode root)
        {
            LocalMaxSum(root);
            return globalMax;
        }
        int globalMax = int.MinValue;
        private int LocalMaxSum(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            if (root.left == null && root.right == null)
            {
                globalMax = Math.Max(globalMax, root.val);
                return root.val;
            }
            var i = LocalMaxSum(root.left);
            var j = LocalMaxSum(root.right);
            globalMax = Math.Max(Math.Max(Math.Max(Math.Max(i, j) + root.val, i + j + root.val), root.val), globalMax);
            return Math.Max(Math.Max(i, j) + root.val, root.val);
        }

        public int NthSuperUglyNumber(int n, int[] primes)
        {
            var m = primes.Count();
            var pointers = new int[m];
            var ret = new int[n];
            ret[0] = 1;

            for (var i = 0; i < n; i++)
            {
                var min = int.MaxValue;
                for (var j = 0; j < m; j++)
                {
                    min = Math.Min(ret[pointers[j]] * primes[j], min);
                }
                for (var j = 0; j < m; j++)
                {
                    if (ret[pointers[j]] * primes[j] == min)
                    {
                        pointers[j]++;
                    }
                }
                ret[i] = min;
            }
            return ret.Last();
        }

        public int NumSquares(int n)
        {
            var count = new int[n + 1];

            for (var i = 1; i <= n; i++)
            {
                count[i] = int.MaxValue;
                var j = 1;
                while (j * j <= i)
                {
                    count[i] = Math.Min((i - j * j) + 1, count[i]);
                    j++;
                }
            }
            return count.Last();
        }
    }
}
