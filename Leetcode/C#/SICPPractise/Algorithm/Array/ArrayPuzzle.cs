using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SICPPractise.Algorithm.Array
{
    public class ArrayPuzzle
    {
        public static void MoveZeros(int[] arr)
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

        public static int RemoveElement(int[] nums, int val)
        {
            var i = 0;
            var j = 0;
            while (j < nums.Length)
            {
                if (nums[j] != val)
                {
                    nums[i] = nums[j];
                    i++;
                }
                j++;
            }
            return i;
        }

        public static int RemoveDuplicates(int[] nums)
        {
            var i = 0;
            var j = 1;
            while (j < nums.Length)
            {
                if (nums[j] != nums[i])
                {
                    nums[i + 1] = nums[j];
                    i++;
                }
                j++;
            }
            return i;
        }

        //public class TreeLinkNode
        //{
        //    public int val;
        //    public TreeLinkNode left;
        //    public TreeLinkNode right;
        //    public TreeLinkNode next;
        //    TreeLinkNode(int x)
        //    {
        //        val = x;
        //        left=null;
        //        right = null;
        //        next = null;
        //    }
        //}
        //public static void Connect(TreeLinkNode root)
        //{
        //    var tree = new List<TreeLinkNode>();
        //    if (root != null)
        //    {
        //        ConnectIter(root, 0, tree);
        //    }
        //}
        //private static void ConnectIter(TreeLinkNode node, int n, IList<TreeLinkNode> tree)
        //{
        //    if (n == tree.Count())
        //    {
        //        tree.Add(node);
        //        node.next = null;
        //    }
        //    else
        //    {
        //        tree[n].next = node;
        //        tree[n] = node;
        //        tree[n].next = null;
        //    }
        //    if (node.left != null)
        //    {
        //        ConnectIter(node.left, n + 1, tree);
        //    }
        //    if (node.right != null)
        //    {
        //        ConnectIter(node.right, n + 1, tree);
        //    }
        //}

        //public static void Connect2(TreeLinkNode root)
        //{
        //    if (root != null)
        //    {
        //        root.next = null;
        //        Connect2Iter(root);
        //    }
        //}
        //private static void Connect2Iter(TreeLinkNode node)
        //{
        //    node.left.next = node.right;
        //    node.right.next = node.next == null ? null : node.next.left;
        //    if (node.left != null)
        //    {
        //        Connect2Iter(node.left);
        //    }
        //    if (node.right != null)
        //    {
        //        Connect2Iter(node.right);
        //    }
        //}

        public static int[,] GenerateSquare(int n)
        {
            var square = new int[n, n];

            var i = 0;
            var j = 0;
            var num = 1;
            var or = 0;

            while (num <= n * n)
            {
                if (or == 0)
                {
                    if (i + j == n - 1)
                    {
                        or = 1;
                    }
                    else
                    {
                        square[i, j] = num;
                        j++;
                        num++;
                    }
                }
                else if (or == 1)
                {

                    if (i == j)
                    {
                        or = 2;
                    }
                    else
                    {
                        square[i, j] = num;
                        i++;
                        num++;
                    }
                }
                else if (or == 2)
                {

                    if (i + j == n - 1)
                    {
                        or = 3;
                    }
                    else
                    {
                        square[i, j] = num;
                        j--;
                        num++;
                    }
                }
                else
                {
                    if (i == j)
                    {
                        or = 0;
                        j = j + 1;
                        i = i + 1;
                    }
                    else
                    {
                        square[i, j] = num;
                        i--;
                        num++;
                    }
                }
            }
            return square;
        }

        public static int[] PlusOne(int[] digits)
        {
            var flag = 0;
            var i = digits.Length - 1;
            do
            {
                flag = 0;
                if (digits[i] < 9)
                {
                    digits[i] = digits[i] + 1;
                }
                else
                {
                    digits[i] = 0;
                    flag = 1;
                }
                i--;
            } while (flag == 1 && i >= 0);
            if (i == -1)
            {
                var newDigits = new int[digits.Length + 1];
                newDigits[0] = 1;
                digits.CopyTo(newDigits, 1);
                return newDigits;
            }
            return digits;
        }

        public static IList<IList<int>> Generate(int numRows)
        {
            var ret = new List<IList<int>>();
            if (numRows == 0)
            {
                return ret;
            }
            ret.Add(new List<int> { 1 });

            for (var i = 2; i <= numRows; i++)
            {
                var newRow = new List<int>();
                var lastRow = ret[i - 2];
                newRow.Add(1);
                for (var j = 1; j < i - 1; j++)
                {
                    newRow.Add(lastRow[j - 1] + lastRow[j]);
                }
                newRow.Add(1);
                ret.Add(newRow);
            }
            return ret;
        }

        public static IList<IList<int>> CombinationSum3(int k, int n)
        {
            var ret = new List<IList<int>>();

            CombinationSum3Iter(k, n, new List<int>(), ret);
            return ret;
        }
        private static void CombinationSum3Iter(int k, int n, IList<int> combination, IList<IList<int>> ret)
        {
            if (k == 0 && n == 0)
            {
                var newCom = new int[combination.Count()];
                combination.CopyTo(newCom, 0);
                ret.Add(newCom);
                return;
            }
            if (k > 0 && n > 0)
            {
                for (var i = combination.Count() == 0 ? 1 : combination.Last() + 1; i <= 9; i++)
                {
                    combination.Add(i);
                    CombinationSum3Iter(k - 1, n - i, combination, ret);
                    combination.Remove(i);
                }
            }
        }

        public static IList<IList<int>> CombinationSum32(int k, int n)
        {
            var ret = new List<IList<int>>();

            CombinationSum32Iter(k, n, 1, new List<int>(), ret);
            return ret;
        }
        private static void CombinationSum32Iter(int k, int n, int min, IList<int> combination, IList<IList<int>> ret)
        {
            if (k == 0 && n == 0)
            {
                var newCom = new int[combination.Count()];
                combination.CopyTo(newCom, 0);
                ret.Add(newCom);
                return;
            }
            if (k > 0 && n >= min && min <= 9)
            {
                combination.Add(min);
                CombinationSum32Iter(k - 1, n - min, min + 1, combination, ret);
                combination.Remove(min);
                CombinationSum32Iter(k, n, min + 1, combination, ret);
            }
        }

        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (n > 0)
            {
                var i = m - 1;
                while (i >= 0 && nums1[i] > nums2[n - 1])
                {
                    i--;
                }
                for (var j = m - 1; j >= i + 1; j--)
                {
                    nums1[j + 1] = nums1[j];
                }
                nums1[i + 1] = nums2[n - 1];
                Merge(nums1, m + 1, nums2, n - 1);
            }
        }
        public static void Merge2(int[] nums1, int m, int[] nums2, int n)
        {
            var j = 0;
            for (var i = 0; i < n; i++)
            {
                while (j < m + i && nums1[j] < nums2[i])
                {
                    j++;
                }
                for (var k = m + i - 1; k >= j; k++)
                {
                    nums1[k + 1] = nums1[k];
                }
                nums1[j] = nums2[i];
            }
        }

        public static bool ContainNearbyDuplicate(int[] nums, int k)
        {
            var set = new HashSet<int>();

            for (var i = 0; i < nums.Length; i++)
            {
                if (set.Count == k + 1)
                {
                    set.Remove(set.First());
                }
                if (!set.Add(nums[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public static int[,] GenerateMatrix(int n)
        {
            var matrix = new int[n, n];
            var i = 0;
            var j = 0;
            var num = 1;
            var or = 0;

            while (num < n * n)
            {
                matrix[i, j] = num;
                num++;
                switch (or)
                {
                    case 0:
                        {
                            j++;
                            if (j + i == n - 1)
                            {
                                or = 1;
                            }
                            break;
                        }
                    case 1:
                        {
                            i++;
                            if (i == j)
                            {
                                or = 2;
                            }
                            break;
                        }
                    case 2:
                        {
                            j--;
                            if (j + i == n - 1)
                            {
                                or = 3;
                            }
                            break;
                        }
                    case 3:
                        {
                            i--;
                            if (i == j)
                            {
                                i++;
                                j++;
                                or = 0;
                            }
                            break;
                        }
                }
            }
            return matrix;
        }

        public static int[,] GenerateMatrix2(int n)
        {
            var matrix = new int[n, n];
            var i = 0;
            var j = 0;
            var num = 1;
            while (num < n * n)
            {
                while (i + j != n - 1)
                {
                    matrix[i, j++] = num++;
                }
                while (i != j)
                {
                    matrix[i++, j] = num++;
                }
                while (i + j != n - 1)
                {
                    matrix[i, j--] = num++;
                }
                while (i != j)
                {
                    matrix[i--, j] = num++;
                }
                i++;
                j++;
            }
            if (num == n * n)
            {
                matrix[i, j] = num;
            }
            return matrix;
        }

        public static void SortColors(int[] nums)
        {
            var first = 0;
            var last = nums.Length - 1;
            for (var i = 0; i <= last; i++)
            {
                if (nums[i] == 0)
                {
                    Swap(nums, i, first++);
                }
                if (nums[i] == 2)
                {
                    Swap(nums, i--, last--);
                }
            }
        }
        private static void Swap(int[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public static bool IsIsomorphic(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            var dictionary = new Dictionary<char, char>();
            for (var i = 0; i < s.Length; i++)
            {
                if (!dictionary.ContainsKey(s[i]) && !dictionary.ContainsValue(t[i]))
                {
                    dictionary.Add(s[i], t[i]);
                }
                else if (dictionary.ContainsKey(s[i]) && dictionary[s[i]] != t[i] || !dictionary.ContainsKey(s[i]) && dictionary.ContainsValue(t[i]))
                {
                    return false;
                }
            }
            return true;
        }


        public int[] TwoSum(int[] nums, int target)
        {
            var indices = new int[2];
            var dic = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(target - nums[i]))
                {
                    indices[0] = dic[target - nums[i]];
                    indices[1] = i;
                    return indices;
                }
                dic.Add(nums[i], i);
            }
            return indices;
        }

        public class MinStack
        {
            private Stack<int> s = new Stack<int>();
            private Stack<int> mins = new Stack<int>();

            public void Push(int x)
            {
                s.Push(x);
                if (mins.Count() == 0 || x < mins.Peek())
                {
                    mins.Push(x);
                }
            }

            public void Pop()
            {
                if (mins.Peek() == s.Peek())
                {
                    mins.Pop();
                }
                s.Pop();
            }

            public int Top()
            {
                return s.Peek();
            }

            public int GetMin()
            {
                return mins.Peek();
            }
        }

        public void Rotate(int[] nums, int k)
        {
            k = k % 7;

            var right = new int[k];
            System.Array.Copy(nums, nums.Length - k, right, 0, k);

            for (var i = nums.Length - k - 1; i >= 0; i--)
            {
                nums[i + k] = nums[i];
            }
            for (var i = 0; i < k; i++)
            {
                nums[i] = right[i];
            }
        }

        public int MaxSubArray(int[] nums)
        {
            var n = nums.Length;
            var localMax = new int[n];
            var globalMax = new int[n];

            localMax[0] = nums[0];
            globalMax[0] = nums[0];
            for (var i = 1; i < n; i++)
            {
                localMax[i] = Math.Max(localMax[i - 1] + nums[i], nums[i]);
                globalMax[i] = Math.Max(globalMax[i - 1], localMax[i]);
            }
            return globalMax[n - 1];
        }

        public IList<int> GrayCode(int n)
        {
            var ret = new List<int>();
            ret.Add(0);

            for (var i = 0; i < n; i++)
            {
                var key = Convert.ToInt32(Math.Pow(2, i));
                for (var j = ret.Count() - 1; j >= 0; j--)
                {
                    ret.Add(ret[j] + key);
                }
            }
            return ret;
        }

        public int MaxProfit(int[] prices)
        {
            var localExtreme = new List<int>();
            var i = 0;

            while (i < prices.Length)
            {
                while (i < prices.Length - 1 && prices[i] >= prices[i + 1])
                {
                    i++;
                }
                localExtreme.Add(prices[i]);
                while (i < prices.Length - 1 && prices[i] <= prices[i + 1])
                {
                    i++;
                }
                localExtreme.Add(prices[i]);
                i++;
            }
            var max = 0;
            for (var j = 0; j < localExtreme.Count(); j += 2)
            {
                for (var k = j + 1; k < localExtreme.Count(); k += 2)
                {
                    max = localExtreme[k] - localExtreme[j] > max ? localExtreme[k] - localExtreme[j] : max;
                }
            }
            return max;
        }

        public void SortColor(int[] nums)
        {
            var i = 0;
            var j = nums.Length - 1;
            var k = 0;

            while (k < j)
            {
                if (nums[k] == 0)
                {
                    Swap(nums, k, i);
                    i++;
                }
                if (nums[k] == 2)
                {
                    Swap(nums, k, j);
                    j--;
                }
            }
        }

        public void Rotate(int[,] matrix)
        {
            var n = matrix.GetLength(0);
            var i = 0;
            var j = 0;
            while (i < n / 2)
            {
                while (i + j < n - 1)
                {
                    Swap(matrix, i, j, j, n - 1 - i);
                    j++;
                }
                i = j;
                while (i + j > n - 1)
                {
                    Swap(matrix, i, j, n - 1 - i, n - 1 - j);
                    j--;
                }
                while (i > j)
                {
                    Swap(matrix, i, j, j, n - 1 - i);
                    i--;
                }
                i++;
                j++;
            }
        }
        private void Swap(int[,] matrix, int i, int j, int m, int n)
        {
            var temp = matrix[i, j];
            matrix[i, j] = matrix[m, n];
            matrix[m, n] = temp;
        }

        public int MaxArea1(int[] height)
        {
            var max = 0;

            for (var i = 0; i < height.Length - 1; i++)
            {
                for (var j = i + 1; j < height.Length; j++)
                {
                    var area = (j - 1) * Math.Min(height[i], height[j]);
                    max = area > max ? area : max;
                }
            }
            return max;
        }

        public int MaxArea2(int[] height)
        {
            var max = 0;

            for (var i = 0; i < height.Length - 1; i++)
            {
                for (var j = max / height[i] + i; j < height.Length; j++)
                {
                    var area = (j - 1) * Math.Min(height[i], height[j]);
                    max = area > max ? area : max;
                }
            }
            return max;
        }
        public int MaxArea3(int[] height)
        {
            var max = 0;
            var i = 0;
            while (i < height.Length - 1)
            {
                var j = height.Length;
                do
                {
                    j--;
                    var area = (j - i) * Math.Min(height[i], height[j]);
                    max = area > max ? area : max;
                } while (j > i + 1 && height[j] < height[i]);
                i++;
            }
            return max;
        }

        public int MaxArea4(int[] height)
        {
            var lo = 0;
            var hi = height.Length - 1;
            var max = 0;
            while (lo < hi)
            {
                var area = (hi - lo) * Math.Min(height[lo], height[hi]);
                max = area > max ? area : max;
                if (height[hi] > height[lo])
                {
                    lo++;
                }
                else
                {
                    hi--;
                }
            }
            return max;
        }

        public static int LengthOfLIS(int[] nums)
        {
            var size = nums.Length;
            var count = new int[size];
            for (var i = 0; i < size; i++)
            {
                count[i] = 1;
            }

            for (var i = size - 2; i >= 0; i--)
            {
                for (var j = i + 1; j <= size - count[i]; j++)
                {
                    if (nums[i] < nums[j])
                    {
                        count[i] = count[i] > nums[j] + 1 ? count[i] : nums[j] + 1;
                    }
                }
            }
            return count.Max();
        }

        public bool SearchMatrix(int[,] matrix, int target)
        {
            var n = matrix.GetLength(0);
            var m = matrix.GetLength(1);
            var i = 0;

            while (i < n)
            {
                if (matrix[i, 0] > target || matrix[i, m - 1] < target)
                {
                    i++;
                    continue;
                }
                var j = 0;
                while (j < m && matrix[i, j] < target)
                {
                    j++;
                }
                if (j < m && matrix[i, j] == target)
                {
                    return true;
                }
                i++;
            }
            return false;
        }

        public IList<IList<int>> Combine(int n, int k)
        {
            var pre = new List<IList<int>>();
            if (k == 0)
            {
                return pre;
            }
            for (var i = 1; i <= n; i++)
            {
                pre.Add(new[] { i });
            }

            for (var i = 2; i <= k; i++)
            {
                var next = new List<IList<int>>();
                for (var j = 0; j < pre.Count(); j++)
                {
                    for (var m = pre[j].Last() + 1; m <= n; m++)
                    {
                        next.Add(pre[j].Concat(new[] { m }).ToList());
                    }
                }
                pre = next;
            }
            return pre;
        }

        public bool SearchMatrix2(int[,] matrix, int target)
        {
            var n = matrix.GetLength(0);
            var m = matrix.GetLength(1);
            var lo = 0;
            var hi = n - 1;

            while (hi - lo > 1)
            {
                var mid = (lo + hi) / 2;
                if (target < matrix[mid, 0])
                {
                    hi = mid - 1;
                }
                else
                {
                    lo = mid;
                }
            }
            var row = target >= matrix[hi, 0] ? hi : lo;

            lo = 0;
            hi = m - 1;
            while (hi > lo)
            {
                var mid = (lo + hi) / 2;
                if (target < matrix[row, mid])
                {
                    hi = mid - 1;
                }
                else if (target > matrix[row, mid])
                {
                    lo = mid + 1;
                }
                else
                {
                    return true;
                }
            }
            return target == matrix[row, lo] ? true : false;
        }

        public void SetZeroes(int[,] matrix)
        {
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);
            var row0 = 0;
            for (var i = 0; i < n; i++)
            {
                if (matrix[0, i] == 0)
                {
                    row0 = 1;
                    break;
                }
            }
            for (var i = 1; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        matrix[i, 0] = 0;
                        matrix[0, j] = 0;
                    }
                }
            }
            for (var i = m - 1; i >= 1; i--)
            {
                for (var j = n - 1; j >= 0; j--)
                {
                    if (matrix[i, 0] == 0 || matrix[0, j] == 0)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
            if (row0 == 1)
            {
                for (var i = 0; i < n; i++)
                {
                    matrix[0, i] = 0;
                }
            }
        }

        public bool IncreasingTriplet(int[] nums)
        {
            if (nums.Count() <= 2)
            {
                return false;
            }
            var count = 1;
            var min = nums[0];
            var mid = 0;
            var i = 1;

            while (i < nums.Count())
            {
                switch (count)
                {
                    case 1:
                        {
                            if (nums[i] > min)
                            {
                                mid = nums[i];
                                count = 2;
                            }
                            else if (nums[i] < min)
                            {
                                min = nums[i];
                            }
                            break;
                        }
                    case 2:
                        {
                            if (nums[i] > mid)
                            {
                                return true;
                            }
                            if (nums[i] < mid && nums[i] > min)
                            {
                                mid = nums[i];
                            }
                            else if (nums[i] < min)
                            {
                                while (i + 1 < nums.Count() && nums[i + 1] <= nums[i])
                                {
                                    i++;
                                }
                                if (nums[i + 1] > mid)
                                {
                                    return true;
                                }
                                min = i;
                                mid = i + 1;
                                i++;
                                count = 2;
                            }
                            break;
                        }
                }
                i++;
            }
            return false;
        }

        public static int FindPeakElement(int[] nums)
        {
            var i = 1;
            var flag = 1;

            while (i + 1 < nums.Count())
            {
                if (nums[i] > nums[i + 1])
                {
                    if (flag == 1)
                    {
                        return i;
                    }
                    flag = 0;
                }
                else
                {
                    flag = 1;
                }
                i++;
            }
            return nums.Count() - 1;
        }

        public int FindKthLargest1(int[] nums, int k)
        {
            k = nums.Length - k;
            for (var i = nums.Length; i > k; i--)
            {
                for (var j = i / 2; j >= 1; j--)
                {
                    if (nums[j - 1] < nums[2 * j - 1])
                    {
                        Swap(nums, j - 1, 2 * j - 1);
                    }
                    if (2 * j < i && nums[j - 1] < nums[2 * j])
                    {
                        Swap(nums, j - 1, 2 * j);
                    }
                }
                Swap(nums, 0, i - 1);
            }
            return nums[k];
        }

        public int FindKthLargest2(int[] nums, int k)
        {
            var lo = 0;
            var hi = nums.Length - 1;
            k = nums.Length - k;

            while (lo < hi)
            {
                var i = lo + 1;
                var j = lo + 1;

                while (j <= hi)
                {
                    if (nums[j] < nums[lo])
                    {
                        Swap(nums, j, i);
                        i++;
                    }
                    j++;
                }
                Swap(nums, lo, i - 1);
                if (i - 1 > k)
                {
                    hi = i - 2;
                }
                else if (i - 1 < k)
                {
                    lo = i;
                }
                else
                {
                    break;
                }
            }
            return nums[k];
        }

        public int HIndex(int[] citations)
        {
            for (var i = citations.Length; i >= 2; i--)
            {
                for (var j = i / 2; j >= 1; j--)
                {
                    if (citations[j - 1] > citations[2 * j - 1])
                    {
                        Swap(citations, j - 1, 2 * j - 1);
                    }
                    if (2 * j < i && citations[j - 1] > citations[2 * j])
                    {
                        Swap(citations, j - 1, 2 * j);
                    }
                }
                Swap(citations, 0, i - 1);
            }
            var hIndex = 0;
            for (var i = 0; i < citations.Length; i++)
            {
                var tmp = Math.Min(i + 1, citations[i]);
                hIndex = hIndex > tmp ? hIndex : tmp;
            }
            return hIndex;
        }

        public int RemoveDuplicates2(int[] nums)
        {
            if (nums.Length <= 2)
            {
                return nums.Length;
            }
            var i = 0;
            var j = 1;
            var count = 1;

            while (j < nums.Length)
            {
                if (nums[j] != nums[i] || count == 1)
                {
                    nums[i + 1] = nums[j];
                    count = 1;
                    i++;
                }
                else if (count == 1)
                {
                    nums[i + 1] = nums[j];
                    count = 2;
                    i++;
                }
                j++;
            }
            return i + 1;
        }

        public int MaxProfit2(int[] prices)
        {
            var days = prices.Length;

            if (days <= 1)
            {
                return 0;
            }
            var buy = new int[days];
            var sell = new int[days];

            buy[0] = -prices[0];
            buy[1] = prices[0] > prices[1] ? -prices[1] : -prices[0];
            sell[0] = 0;
            sell[1] = -prices[0] + prices[1] > 0 ? -prices[0] + prices[1] : 0;

            for (var i = 2; i < days; i++)
            {
                buy[i] = Math.Max(buy[i - 1], sell[i - 2] - prices[i]);
                sell[i] = Math.Max(sell[i - 1], buy[i - 1] + prices[i]);
            }
            return sell[days - 1];
        }

        public void Rotate2(int[,] matrix)
        {
            var size = matrix.GetLength(0);

            for (var i = 0; i < size; i++)
            {
                var m = 0;
                var n = size - 1;
                while (m > n)
                {
                    Swap(matrix, m, i, n, i);
                    m++;
                    n--;
                }
            }
            for (var i = 0; i < size; i++)
            {
                for (var j = i + 1; j < size; j++)
                {
                    Swap(matrix, i, j, j, i);
                }
            }
        }

        public int MaxArea(int[] height)
        {
            var left = 0;
            var right = height.Count() - 1;
            var max = 0;

            while (left < right)
            {
                max = Math.Max(Math.Min(height[left], height[right]) * (right - left), max);
                if (height[left] < height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
            return max;
        }

        public IList<IList<int>> Combination1(int n, int k)
        {
            var ret = new List<IList<int>>();
            if (k == 0)
            {
                return ret;
            }
            for (var i = 1; i <= n; i++)
            {
                ret.Add(new[] { i });
            }

            for (var i = 2; i <= k; i++)
            {
                var next = new List<IList<int>>();
                for (var j = 0; j < ret.Count(); j++)
                {
                    for (var p = ret[j].Last() + 1; p <= n; p++)
                    {
                        var arr = new int[i];
                        ret[j].CopyTo(arr, 0);
                        arr[i - 1] = p;
                        next.Add(arr);
                    }
                }
                ret = next;
            }
            return ret;
        }

        Dictionary<int[], IList<IList<int>>> doc = new Dictionary<int[], IList<IList<int>>>();
        public IList<IList<int>> Combination2(int n, int k)
        {
            if (n == k)
            {
                var ret = new List<IList<int>>();
                var arr = new List<int>();
                for (var i = 1; i <= n; i++)
                {
                    arr.Add(i);
                }
                ret.Add(arr);
                doc.Add(new[] { n, k }, ret);
                return ret;
            }
            else if (k == 1)
            {
                var ret = new List<IList<int>>();
                for (var i = 1; i < n; i++)
                {
                    ret.Add(new[] { i });
                }
                doc.Add(new[] { n, k }, ret);
                return ret;
            }
            else
            {
                IList<IList<int>> ret1;
                IList<IList<int>> ret2;
                if (doc.ContainsKey(new[] { n - 1, k }))
                {
                    ret1 = doc[new[] { n - 1, k }];
                }
                else
                {
                    ret1 = Combination2(n - 1, k);
                }
                if (doc.ContainsKey(new[] { n - 1, k - 1 }))
                {
                    ret2 = doc[new[] { n - 1, k - 1 }];
                }
                else
                {
                    ret2 = Combination2(n - 1, k - 1);
                }
                for (var i = 0; i < ret2.Count(); i++)
                {
                    var tmp = new int[k];
                    ret2[i].CopyTo(tmp, 0);
                    tmp[k - 1] = n;
                    ret1.Add(tmp);
                }
                return ret1;
            }
        }

        public bool IncreasingTriplet2(int[] nums)
        {
            var min = Int32.MaxValue;
            var mid = Int32.MaxValue;

            for (var i = 0; i < nums.Length; i++)
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

        public int Search(int[] nums, int target)
        {
            var lo = 0;
            var hi = nums.Length - 1;

            while (lo < hi)
            {
                var mid = (lo + hi) / 2;
                if (nums[mid] < nums[hi])
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
                    if (target <= nums[mid] && target >= nums[lo])
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

        public IList<IList<int>> Subsets(int[] nums)
        {
            var ret = new List<IList<int>>();

            System.Array.Sort(nums);
            for (var i = 0; i <= nums.Count(); i++)
            {
                Helper(nums, new List<int>(), i, 0, ret);
            }
            return ret;
        }
        private void Helper(int[] nums, List<int> subset, int n, int start, IList<IList<int>> ret)
        {
            if (n == 0)
            {
                var arr = new int[subset.Count()];
                subset.CopyTo(arr);
                ret.Add(arr);
                return;
            }
            for (var i = start; i < nums.Count(); i++)
            {
                subset.Add(nums[i]);
                Helper(nums, subset, n - 1, i + 1, ret);
                subset.Remove(nums[i]);
            }
        }

        public IList<IList<int>> Subsets2(int[] nums)
        {
            var ret = new List<IList<int>>();

            System.Array.Sort(nums);
            Helper(nums, new List<int>(), 0, ret);
            return ret;
        }
        private void Helper(int[] nums, List<int> sub, int begin, IList<IList<int>> ret)
        {
            var arr = new int[sub.Count()];

            sub.CopyTo(arr);
            ret.Add(arr);
            for (var i = begin; i < nums.Count(); i++)
            {
                sub.Add(nums[i]);
                Helper(nums, sub, i + 1, ret);
                sub.Remove(nums[i]);
            }
        }

        public IList<IList<int>> Subsets3(int[] nums)
        {
            var ret = new List<IList<int>>();

            ret.Add(new List<int>());
            for (var i = 0; i < nums.Count(); i++)
            {
                var n = ret.Count();
                for (var j = 0; j < n; j++)
                {
                    var arr = new int[ret[j].Count + 1];
                    ret[j].CopyTo(arr, 0);
                    arr[ret[j].Count()] = nums[i];
                    ret.Add(arr);
                }
            }
            return ret;
        }

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var ret = new List<IList<int>>();

            Helper(candidates, 0, target, new List<int>(), ret);
            return ret;
        }
        private void Helper(int[] candidates, int begin, int target, IList<int> set, IList<IList<int>> ret)
        {
            if (target == 0)
            {
                var tmp = new int[set.Count()];
                set.CopyTo(tmp, 0);
                ret.Add(tmp);
            }
            if (begin < candidates.Count() && target > candidates[begin])
            {
                set.Add(candidates[begin]);
                Helper(candidates, begin, target - candidates[begin], set, ret);
                set.Remove(candidates[begin]);
                Helper(candidates, begin + 1, target, set, ret);
            }
        }

        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            var ret = new List<IList<int>>();

            Helper(nums, 0, new List<int>(), ret);
            return ret;
        }
        private void Helper(int[] nums, int begin, IList<int> set, IList<IList<int>> ret)
        {
            var tmp = new int[set.Count()];
            set.CopyTo(tmp, 0);
            ret.Add(tmp);
            if (begin < nums.Count())
            {
                var pre = nums[begin] - 1;
                for (var i = begin; i < nums.Count(); i++)
                {
                    if (nums[i] != pre)
                    {
                        set.Add(nums[i]);
                        Helper(nums, i + 1, set, ret);
                        set.Remove(nums[i]);
                        pre = nums[i];
                    }
                }
            }
        }

        public int Rob(int[] nums)
        {
            var n = nums.Length;
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return nums[0];
            }
            if (n == 2)
            {
                return Math.Max(nums[0], nums[1]);
            }
            var t1 = Helper(nums, 0, n - 2);
            var t2 = Helper(nums, 1, n - 1);
            return Math.Max(t1, t2);
        }
        private int Helper(int[] nums, int lo, int hi)
        {
            var amount = new int[hi - lo + 1];
            amount[0] = nums[lo];
            amount[1] = Math.Max(nums[lo], nums[hi]);

            for (var i = 2; i < amount.Count(); i++)
            {
                amount[i] = Math.Max(amount[i - 2] + nums[lo + i], amount[i - 1]);
            }
            return amount.Last();
        }

        public int FibonacciSubSequence(int[] nums)
        {
            var sum = 0;
            var count = 0;
            for(var i = 0;i< nums.Length;i++)
            {
                if(nums[i]==1)
                {
                    count++;
                    sum = sum + count;
                }
                else if(nums[i]==2 && count>=2)
                {
                    Helper(nums, i + 1, 1, 2, 3, sum-count, 2 * sum - count);
                }
            }
            return globalSum;
        }
        public int globalSum= 0;
        private void Helper(int[] nums, int begin, int count, int cur, int next, int localSum, int sum)
        {
            if(begin==nums.Length)
            {
                globalSum += sum;
            }
            for(var i = begin;i<nums.Length;i++)
            {
                if(nums[i]==cur)
                {
                    Helper(nums, i + 1, count+1, cur, next, localSum*(count+1)/count, sum+localSum/count);
                }
                else if(nums[i] == next)
                {
                    Helper(nums, i + 1, 1, next, cur + next, localSum, sum+localSum);
                }
            }
        }

        public int MinimumTotal(IList<IList<int>> triangle)
        {
            if(triangle.Count() == 0)
            {
                return 0;
            }
            var total = new List<IList<int>>();
            total.Add(new[] { triangle[0][0] });

            for(var i = 1;i<triangle.Count();i++)
            {
                var n = triangle[i].Count();
                total.Add(new int[n]);
                total[i][0] = total[i - 1].First() + triangle[i][0];
                for (var j = 1; j < n - 1; j++)
                {
                    total[i][j] = Math.Min(total[i - 1][j - 1], total[i - 1][j]) + triangle[i][j];
                }
                total[i][n - 1] = total[i - 1].Last() + triangle[i][n - 1];
            }
            var min = total.Last().First();
            foreach(var x in total.Last())
            {
                min = Math.Min(min, x);
            }
            return min;
        }
        public int MinmumTotal(IList<IList<int>> triangle)
        {
            if(triangle.Count()==0)
            {
                return 0;
            }
            for(var i = 1;i<triangle.Count();i++)
            {
                var n = triangle[i].Count();
                triangle[i][0] += triangle[i - 1].First();
                triangle[i][n - 1] += triangle[i - 1].Last();
                for(var j = 1; j < n - 1; j++)
                {
                    triangle[i][j] += Math.Min(triangle[i - 1][j], triangle[i - 1][j - 1]);
                }
            }
            return triangle.Last().Min();
        }

        public int[] SearchRange(int[] nums, int target)
        {
            var lo = 0;
            var hi = nums.Length - 1;
            var ret = new int[2];

            while(lo<hi)
            {
                var mid = (lo + hi) / 2;

                if(nums[mid]<target)
                {
                    lo = mid + 1;
                }
                else if(nums[mid]>target)
                {
                    hi = mid - 1;
                }
                else
                {
                    var i = mid;
                    while(i<nums.Length && nums[i] == target)
                    {
                        i++;
                    }
                    ret[1] = i - 1;
                    i = mid;
                    while(i>=0 && nums[i]==target)
                    {
                        i--;
                    }
                    ret[0] = i + 1;
                    return ret;
                }
            }
            return nums[lo] == target ? new[] { lo, lo } : new[] { -1, -1 };
        }

        public int MinPatches(int[] nums, int n)
        {
            var set = new int[n+1];
            Helper(nums, 0, 0, n, set);
            var patches = 0;
            var i = 1;

            while(i<=n)
            {
                while(i<=n && set[i]==1)
                {
                    i++;
                }
                if(i<=n)
                {
                    patches++;
                    for(var j = 1; j <= n - i; j++)
                    {
                        if(set[j]==1)
                        {
                            set[j + i] = 1;
                        }
                    }
                    set[i] = 1;
                }
                i++;
            }
            return patches;
        }
        private void Helper(int[] nums, int begin, int sum, int target, int[] set)
        {
            if(begin >= nums.Length)
            {
                return;
            }
            if(sum>0 && sum<=target)
            {
                set[sum] = 1;
            }
            for(var i = begin; i<nums.Count();i++)
            {
                Helper(nums, begin + 1, sum + nums[begin], target, set);
            }
            return;
        }

        public bool CanJump(int[] nums)
        {
            var i = nums.Length - 2;
            var j = 1;
            var flag = 0;

            while (i >= 0)
            {
                if (nums[i] >= j)
                {
                    flag = 1;
                    j = 1;
                }
                else
                {
                    flag = 0;
                    j++;
                }
                i--;
            }
            return flag == 1;
        }

        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            var ret = new List<IList<int>>();
            System.Array.Sort(nums);
            PermuteUniqueHelper(nums, 0, ret);
            return ret;
        }
        private void PermuteUniqueHelper(int[] nums, int begin, IList<IList<int>> ret)
        {
            var copy = new int[nums.Length];
            nums.CopyTo(copy, 0);
            if (begin == copy.Length)
            {
                ret.Add(copy);
                return;
            }
            System.Array.Sort(copy, begin, copy.Length - begin);
            for (var i = begin; i < copy.Length; i++)
            {
                if (i == begin || copy[i] != copy[i - 1])
                {
                    Swap(copy, i, begin);
                    PermuteUniqueHelper(copy, begin + 1, ret);
                    Swap(copy, i, begin);
                }
            }
        }

        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            var ret = new List<IList<int>>();

            System.Array.Sort(candidates);
            CombinationSum2Helper(candidates, 0, target, new List<int>(), ret);
            return ret;
        }
        private void CombinationSum2Helper(int[] candidates, int begin, int target, IList<int> comb, IList<IList<int>> ret)
        {
            if (target == 0)
            {
                var copy = new int[comb.Count()];
                comb.CopyTo(copy, 0);
                ret.Add(copy);
                return;
            }
            if (begin < candidates.Length)
            {
                for (var i = begin; i < candidates.Length && candidates[i] <= target; i++)
                {
                    if (i == begin || candidates[i] != candidates[i - 1])
                    {
                        comb.Add(candidates[i]);
                        CombinationSum2Helper(candidates, i + 1, target - candidates[i], comb, ret);
                        comb.Remove(candidates[i]);
                    }
                }
            }
        }

        public int NumIslands(char[,] grid)
        { 
            var m = grid.GetLength(0);
            var n = grid.GetLength(1);
            var hasChecked = new bool[m, n];

            var count = 0;
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (hasChecked[i, j] == false && grid[i, j] == '1')
                    {
                        count++;
                        TagIslands(grid, i, j, hasChecked);
                    }
                }
            }
            return count;
        }
        private void TagIslands(char[,] grids, int x, int y, bool[,] hasChecked)
        {
            hasChecked[x, y] = true;
            if (x < grids.GetLength(0) - 1 && hasChecked[x+1, y]==false && grids[x + 1, y] == '1')
            {
                TagIslands(grids, x + 1, y, hasChecked);
            }
            if (y < grids.GetLength(1) - 1 && hasChecked[x, y+1]==false &&grids[x, y + 1] == '1')
            {
                TagIslands(grids, x, y + 1, hasChecked);
            }
            if (x > 0 && hasChecked[x - 1, y] == false && grids[x - 1, y] == '1')
            {
                TagIslands(grids, x - 1, y, hasChecked);
            }
            if (y > 0 && hasChecked[x, y - 1] == false && grids[x, y - 1] == '1')
            {
                TagIslands(grids, x, y - 1, hasChecked);
            }
        }

        public int CanCompleteCircuit1(int[] gas, int[] cost)
        {
            var n = gas.Length;
            var remain = new int[n];

            for (var i = 0; i < n; i++)
            {
                remain[i] = gas[i] - cost[i];
            }
            for (var i = 0; i < n; i++)
            {
                var j = i+1;
                var sum = remain[i];
                while (sum >= 0 && j != i)
                {
                    if (j == n)
                    {
                        j = 0;
                    }
                    else
                    {
                        j++;
                    }
                    sum += remain[j];
                }
                if (sum >= 0)
                {
                    return i;
                }
            }
            return -1;
        }

        public int CanCompleteCircuit2(int[] gas, int[] cost)
        {
            var remain = 0;
            var start = 0;
            var sum = 0;

            for (var i = 0; i < gas.Length; i++)
            {
                sum += gas[i] - cost[i];
                remain += gas[i] - cost[i];
                if (remain < 0)
                {
                    start = i + 1;
                    remain = 0;
                }
            }
            return sum >= 0 ? start : -1;
        }

        public int MinSubArrayLen(int s, int[] nums)
        {
            var i = 0;
            var j = 0;
            var sum = 0;
            var min = int.MaxValue;

            while (j < nums.Length)
            {
                while (j < nums.Length && sum < s)
                {
                    sum += nums[j++];
                }
                while (sum >= s)
                {
                    sum -= nums[i++];
                }
                min = System.Math.Min(min, j - i + 1);
            }
            return min > nums.Length ? 0 : min;
        }

        public void NextPermutation(int[] nums)
        {
            var i = nums.Length - 1;

            while (i > 0 && nums[i-1]>=nums[i])
            {
                i--;
            }
            if (i > 0)
            {
                var min = int.MaxValue;
                var idx = 0;
                for (var j = i; j < nums.Length; j++)
                {
                    if (nums[j] > nums[i - 1])
                    {
                        idx = min < nums[j] ? idx : j;
                        min = min < nums[j] ? min : nums[j];
                    }
                }
                Swap(nums, i, idx);
                System.Array.Sort(nums, i, nums.Length - i);
            }
            else
            {
                Reverse(nums, 0, nums.Length - 1);
            }
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

        public IList<int> MajorityElement(int[] nums)
        {
            var ret = new List<int>();
            if (nums.Length == 0)
            {
                return ret;
            }
            var a = nums[0];
            var b = nums[0];
            var n1 = 1;
            var n2 = 1;

            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i] == a)
                {
                    n1++;
                }
                else if (nums[i] == b)
                {
                    n2++;
                }
                else if (n1 <= 0)
                {
                    a = nums[i];
                    n1 = 1;
                }
                else if (n2 <= 0)
                {
                    b = nums[i];
                    n2 = 1;
                }
                else
                {
                    n1--;
                    n2--;
                }
            }
            n1 = 0;
            n2 = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] == a)
                {
                    n1++;
                }
                else if (nums[i] == b)
                {
                    n2++;
                }
            }

            if (n1 > nums.Length / 3)
            {
                ret.Add(a);
            }
            if (n2 > nums.Length / 3)
            {
                ret.Add(b);
            }
            return ret;
        }
    }
}
