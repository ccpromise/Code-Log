using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SICPPractise.Algorithm.Others
{
    class Puzzle
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0 || (x > 0 && x % 10 == 0))
            {
                return false;
            }
            var reverse = 0;
            while (x > reverse)
            {
                reverse = reverse * 10 + x % 10;
                x = x / 10;
            }
            return x == reverse || x == reverse / 10;
        }

        public static IList<string> GenerateParenthesis1(int n)
        {
            var last = new List<string>();
            var next = new List<string>();
            if (n <= 0)
            {
                return last;
            }
            last.Add("()");
            for (var i = 1; i < n; i++)
            {
                for (var j = 0; j < last.Count(); j++)
                {
                    var item = last[j];
                    next.Add("(" + item + ")");
                    var s1 = "()" + item;
                    var s2 = item + "()";
                    next.Add(s1);
                    if (s2 != s1)
                    {
                        next.Add(s2);
                    }
                }
                last = next;
                next.Clear();
            }
            return last;
        }

        public static IList<string> GenerateParenthesis2(int n)
        {
            var ret = new List<string>();
            helper(ret, "", n, 0);
            return ret;
        }
        private static void helper(IList<string> ret, string s, int left, int right)
        {
            if (left == 0 && right == 0)
            {
                ret.Add(s);
                return;
            }
            if (left > 0)
            {
                helper(ret, s + "(", left - 1, right + 1);
            }
            if (left > right)
            {
                helper(ret, s + ")", left, right - 1);
            }
        }

        public static int UniquePaths1(int m, int n)
        {
            int count = 0;
            helper1(ref count, m, n);
            return count;
        }
        private static void helper1(ref int count, int m, int n)
        {
            if (m == 0 && n == 0)
            {
                count++;
                return;
            }
            if (m > 0)
            {
                helper1(ref count, m - 1, n);
            }
            if (n > 0)
            {
                helper1(ref count, m, n - 1);
            }
        }

        public static int UniquePaths2(int m, int n)
        {
            long ret = 1;
            var i = m;
            while (i <= m + n - 2)
            {
                ret = ret * i;
                i++;
            }
            i = 2;
            while (i <= n - 1)
            {
                ret = ret / i;
                i++;
            }
            return Convert.ToInt32(ret);
        }

        public int UniquePaths3(int m, int n)
        {
            if (m == 1 || n == 1)
            {
                return 1;
            }
            return UniquePaths2(m - 1, n) + UniquePaths2(m, n - 1);
        }

        public static int UniquePahts4(int m, int n)
        {
            var count = new int[m, n];

            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        count[i, j] = 1;
                    }
                    else
                    {
                        count[i, j] = count[i - 1, j] + count[i, j - 1];
                    }
                }
            }
            return count[m - 1, n - 1];
        }

        public static int UniquePaths5(int m, int n)
        {
            var paths = new int[m];

            for (var i = 0; i < n; i++)
            {
                paths[0] = 1;
                for (var j = 1; j < m; j++)
                {
                    paths[j] = paths[j - 1] + paths[j];
                }
            }
            return paths[m - 1];
        }

        public static bool IsValidSudoku(char[,] board)
        {
            var rows = new HashSet<int>[9];
            var cols = new HashSet<int>[9];
            var boards = new HashSet<int>[9];

            for (var i = 0; i < 9; i++)
            {
                for (var j = 0; j < 9; j++)
                {
                    if (board[i, j] != '.')
                    {
                        if (!(rows[i].Add(board[i, j]) && cols[j].Add(board[i, j]) && boards[i / 3 * 3 + j / 3].Add(board[i, j])))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public static int MinPathSum(int[,] grid)
        {
            var m = grid.GetLength(1);
            var n = grid.GetLength(2);
            var pre = new int[m];
            var after = new int[m];

            pre[0] = grid[0, 0];
            for (var i = 1; i < m; i++)
            {
                pre[i] = grid[i, 0] + pre[i - 1];
            }
            for (var i = 1; i < n; i++)
            {
                after[0] = pre[0] + grid[0, i];
                for (var j = 1; j < m; j++)
                {
                    after[j] = Math.Min(pre[j], after[j - 1]) + grid[i, j];
                }
                pre = after;
            }
            return pre[m - 1];
        }

        public static int Rob(int[] nums)
        {
            return RobIter(nums, 0);
        }
        private static int RobIter(int[] nums, int start)
        {
            if (start >= nums.Length)
            {
                return 0;
            }
            return Math.Max(nums[start] + RobIter(nums, start + 2), RobIter(nums, start + 1));
        }

        public static int Rob2(int[] nums)
        {
            var cur = new int[nums.Length];
            if (nums.Length == 1)
            {
                return nums[0];
            }
            cur[0] = nums[0];
            cur[1] = Math.Max(nums[0], nums[1]);

            for (var i = 2; i < nums.Length; i++)
            {
                cur[i] = Math.Max(cur[i - 2] + nums[i], cur[i - 1]);
            }
            return cur.Last();
        }

        public static int TrailingZeros(int n)
        {
            var ret = 0;
            for (var i = 5; i <= n; i *= 5)
            {
                ret += n / i;
            }
            return ret;
        }

        public class Stack
        {
            private Queue<int> queue;

            // Push element x onto stack.
            public void Push(int x)
            {
                queue.Enqueue(x);
                for (var i = 0; i < queue.Count() - 1; i++)
                {
                    var item = queue.Dequeue();
                    queue.Enqueue(item);
                }
            }

            // Removes the element on top of the stack.
            public void Pop()
            {
                queue.Dequeue();
            }

            // Get the top element.
            public int Top()
            {
                return queue.First();
            }

            // Return whether the stack is empty.
            public bool Empty()
            {
                return queue.Count() == 0;
            }
        }

        public int[] CountBits(int num)
        {
            var ret = new int[num + 1];

            for (var i = 0; i <= num; i++)
            {
                var count = 0;
                while (i != 0)
                {
                    count += i % 2;
                    i /= 2;
                }
                ret[i] = count;
            }
            return ret;
        }

        public static IList<IList<int>> Permute(int[] nums)
        {
            var ret = new List<IList<int>>();

            helper(nums, 0, ret);
            return ret;
        }
        private static void helper(int[] nums, int begin, IList<IList<int>> ret)
        {
            if (begin == nums.Length - 1)
            {
                var newArr = new int[nums.Length];
                nums.CopyTo(newArr, 0);
                ret.Add(newArr);
                return;
            }
            for (var i = begin; i < nums.Length; i++)
            {
                swap(nums, begin, i);
                helper(nums, begin + 1, ret);
                swap(nums, begin, i);
            }
        }
        private static void swap(int[] nums, int i, int j)
        {
            var temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;

        }

        public IList<IList<int>> Permute2(int[] nums)
        {
            var ret = new List<IList<int>>();
            for (var i = 1; i <= f(nums.Length); i++)
            {
                ret.Add(new List<int> { nums[0] });
            }

            for (var i = 1; i < nums.Length; i++)
            {
                for (var j = 0; j < ret.Count(); j++)
                {
                    ret[j].Insert(j % (i + 1), nums[i]);
                }
            }
            return ret;
        }
        private int f(int n)
        {
            var ret = 1;
            while (n > 1)
            {
                ret *= n;
                n--;
            }
            return ret;
        }

        public int NthSuperUglyNumber(int n, int[] primes)
        {
            var k = primes.Count();
            var pointer = new int[k];
            var uglyNumbers = new int[n];
            uglyNumbers[0] = 1;

            for (var i = 1; i < n; i++)
            {
                var min = uglyNumbers[pointer[0]] * primes[0];
                for (var j = 1; j < k; j++)
                {
                    min = Math.Min(min, uglyNumbers[pointer[j]] * primes[j]);
                }
                for (var j = 0; j < k; j++)
                {
                    if (uglyNumbers[pointer[j]] * primes[j] == min) pointer[j]++;
                }
                uglyNumbers[i] = min;
            }
            return uglyNumbers[n - 1];
        }

        public int NumSquares(int n)
        {
            var count = new int[n + 1];
            count[0] = 0;

            for (var i = 1; i < n; i++)
            {
                var min = count[i - 1] + 1;
                var j = 2;
                while (j * j <= i)
                {
                    min = Math.Min(min, 1 + count[i - j * j]);
                }
                count[i] = min;
            }
            return count[n];
        }

        public int RangeBitwiseAnd(int m, int n)
        {
            if (m == 0)
            {
                return 0;
            }
            var step = 0;
            while (m != n)
            {
                m = m >> 1;
                n = n >> 1;
                step++;
            }
            return m << step;
        }

        public int UniquePathsWithObstacles(int[,] obstacleGrid)
        {
            var m = obstacleGrid.GetLength(0);
            var n = obstacleGrid.GetLength(1);
            var pre = new int[m];
            var cur = new int[m];

            for (var i = 0; i < m; i++)
            {
                pre[i] = 1 - obstacleGrid[i, 0];
            }
            for (var i = 1; i < n; i++)
            {
                cur[0] = 1 - obstacleGrid[i, 0];
                for (var j = 1; j < m; j++)
                {
                    if (obstacleGrid[j, i] == 1)
                    {
                        cur[j] = 0;
                    }
                    else
                    {
                        cur[j] = cur[j - 1] + pre[j];
                    }
                }
                pre = cur;
            }
            return cur.Last();
        }

        public double MyPow1(double x, int n)
        {
            if (n == 0)
            {
                return 1;
            }
            var m = n;
            var ret = x;
            if (n < 0)
            {
                m = -n;
            }
            while (m >= 2)
            {
                ret = ret * x;
                m--;
            }
            return n < 0 ? 1 / ret : ret;
        }

        public double MyPow2(double x, int n)
        {
            if (n == 0)
            {
                return 1;
            }
            var m = n > 0 ? n : -n;
            if (m == 1)
            {
                return n > 0 ? x : 1 / x;
            }
            var tmp = MyPow2(x, n / 2);
            return tmp * tmp * MyPow2(x, n % 2);
        }

        public double MyPow3(double x, int n)
        {
            if (n == 0)
            {
                return 1;
            }
            if (n < 0)
            {
                n = -n;
                x = 1 / x;
            }
            return n % 2 == 0 ? MyPow3(x * x, n / 2) : x * MyPow3(x * x, n / 2);
        }

        public int sqrt(int x)
        {
            long lo = 0;
            long hi = x;

            while (lo < hi)
            {
                var mid = lo + (hi - lo) / 2 + 1;

                if (mid * mid < x)
                {
                    lo = mid;
                }
                else if (mid * mid > x)
                {
                    hi = mid - 1;
                }
                else
                {
                    return (int)mid;
                }
            }
            return (int)lo;
        }

        public int CoinChange1(int[] coins, int amount)
        {
            return CoinChange1Helper(coins, amount, new int[amount]);
        }
        private int CoinChange1Helper(int[] coins, int amount, int[] count)
        {
            if (amount == 0)
            {
                return 0;
            }
            if (amount < 0)
            {
                return -1;
            }
            if (count[amount - 1] != 0)
            {
                return count[amount - 1];
            }
            var min = int.MaxValue;
            foreach (var n in coins)
            {
                var tmp = CoinChange1(coins, amount - n);
                if (tmp >= 0)
                {
                    min = Math.Min(min, tmp + 1);
                }
            }
            count[amount - 1] = min;
            return min == int.MaxValue ? -1 : min;
        }

        public int CoinChange2(int[] coins, int amount)
        {
            var count = new int[amount + 1];

            for (var i = 1; i <= amount; i++)
            {
                count[i] = int.MaxValue;
                for (var j = 0; j < coins.Length; j++)
                {
                    if (i - coins[j] >= 0 && count[i - coins[j]] != -1)
                    {
                        count[i] = Math.Min(count[i], count[i - coins[j]] + 1);
                    }
                }
                if (count[i] == int.MaxValue)
                {
                    count[i] = -1;
                }
            }
            return count[amount];
        }
    }
}
