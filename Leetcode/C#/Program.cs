using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var i = ConsoleApplication1.Program.FindPeakElement(new[] {3, 1, 2});
            Console.Read();
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
            for (var i = nums.Length; i >= 2; i--)
            {
                for (var j = i/2; j >= 1; j--)
                {
                    if (nums[j - 1] < nums[2*j - 1])
                    {
                        Swap(nums, j - 1, 2*j - 1);
                    }
                    if (2*j < i && nums[j - 1] < nums[2*j])
                    {
                        Swap(nums, j - 1, 2*j);
                    }
                }
                Swap(nums, 0, i - 1);
            }
            return nums[nums.Length - k];
        }

        private static void Swap(int[] nums, int i, int j)
        {
            var tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
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
                for (var j = i/2; j >= 1; j--)
                {
                    if (citations[j - 1] > citations[2*j - 1])
                    {
                        Swap(citations, j - 1, 2*j - 1);
                    }
                    if (2*j < i && citations[j - 1] > citations[2*j])
                    {
                        Swap(citations, j - 1, 2*j);
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

        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length <= 2)
            {
                return nums.Length;
            }
            var i = 0;
            var j = 1;
            var count = 1;

            while (j<nums.Length)
            {
                if (nums[j] != nums[i]||count==1)
                {
                    nums[i + 1] = nums[j];
                    count = 1;
                    i++;
                }
                else if(count==1)
                {
                    nums[i + 1] = nums[j];
                    count = 2;
                    i++;
                }
                j++;
            }
            return i + 1;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int x)
            {
                val = x;
            }
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
            n = n*10 + node.val;
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
}
