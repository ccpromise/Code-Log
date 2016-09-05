using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SICPPractise.Algorithm.Array
{
    public class Median
    {
        public static void Swap(int[] nums, int i, int j)
        {
            var tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }
        public class Solution16
        {
            public int ThreeSumClosest(int[] nums, int target)
            {
                var num = nums.ToList();
                num.Sort();
                var N = num.Count;
                var ret = nums[0] + nums[1] + nums[2];

                for(var i = 0; i < N-2; i++)
                {
                    var lo = i + 1;
                    var hi = N - 1;

                    while(lo<hi)
                    {
                        var sum = nums[i] + nums[lo] + nums[hi];

                        if(Math.Abs(sum - target) < Math.Abs(ret - target))
                        {
                            ret = sum;
                        }
                        if(sum > target)
                        {
                            hi--;
                        }
                        else if(sum < target)
                        {
                            lo++;
                        }
                    }
                }
                return ret;
            }
        }

        public class Solution215
        {
            public IList<IList<int>> CombinationSum3(int k, int n)
            {
                var ret = new List<IList<int>>();

                Helper(k, n, new List<int>(), ret);
                return ret;
            }

            private void Helper(int k, int n, IList<int> comb, IList<IList<int>> ret)
            {
                if(comb.Count == k && n == 0)
                {
                    var tmp = new int[k];
                    comb.CopyTo(tmp, 0);
                    ret.Add(tmp.ToList());
                }
                for(var i = comb.Count==0?1:comb.Last()+1;i<=9;i++)
                {
                    if(i<=n)
                    {
                        comb.Add(i);
                        Helper(k, n - i, comb, ret);
                        comb.Remove(i);
                    }
                }
            }
        }

        public class Solution209
        {
            public int MinSubArrLen(int[] nums, int s)
            {
                var lo = 0;
                var hi = 0;
                var sum = 0;
                var minLen = Int32.MaxValue;

                while (hi < nums.Length)
                {
                    while(hi < nums.Length && sum < s)
                    {
                        sum += nums[hi];
                        hi++;
                    }
                    if(sum < s)
                    {
                        break;
                    }
                    while(sum >= s)
                    {
                        sum -= nums[lo];
                        lo++;
                    }
                    minLen = Math.Min(minLen, hi - lo + 1);
                }
                return minLen == Int32.MaxValue ? 0 : minLen;
            }

            public int MinSubArrayLen2(int s, int[] nums)
            {
                var lo = 0;
                var hi = 0;
                var sum = 0;
                var minLen = Int32.MaxValue;

                while (lo < nums.Length)
                {
                    while (hi < nums.Length && sum < s)
                    {
                        sum += nums[hi];
                        hi++;
                    }
                    if (sum < s)
                    {
                        break;
                    }
                    minLen = Math.Min(minLen, hi - lo);
                    sum -= nums[lo];
                    lo++;
                }
                return minLen == Int32.MaxValue ? 0 : minLen;
            }
        }

        public class Solution18
        {
            public IList<IList<int>> FourSum(int[] nums, int target)
            {
                var ret = new List<IList<int>>();
                var N = nums.Length;
                var num = nums.ToList();
                num.Sort();

                for(var i = 0; i < N - 3; i++)
                {
                    if(i > 0 && nums[i] == nums[i-1])
                    {
                        continue;
                    }
                    for(var j = i + 1; j < N-2; j++)
                    {
                        if (j > i + 1 && nums[j] == nums[j - 1])
                        {
                            continue;
                        }
                        var lo = j + 1;
                        var hi = N - 1;

                        while(lo < hi)
                        {
                            var sum = nums[i] + nums[j] + nums[lo] + nums[hi];

                            if(sum < target)
                            {
                                lo++;
                            }
                            else if(sum > target)
                            {
                                hi--;
                            }
                            else
                            {
                                ret.Add(new List<int>() { nums[i], nums[j], nums[lo], nums[hi] });
                                while(lo < hi && nums[lo] == nums[lo+1])
                                {
                                    lo++;
                                }
                                while (lo < hi && nums[hi] == nums[hi - 1])
                                {
                                    hi--;
                                }
                                lo++;
                                hi--;                           
                            }
                        }
                    }                  
                }
                return ret;
            }
        }

        public class Solution31
        {
            public void NextPermutation(int[] nums)
            {
                var N = nums.Count();
                var i = N - 1;

                while(i > 0 && nums[i-1] >= nums[i])
                {
                    i--;
                }
                if(i == 0)
                {
                    System.Array.Reverse(nums);
                    return;
                }
                var j = i - 1;
                i = N - 1;
                var max = Int32.MaxValue;
                var idx = 0;
                while(i > j)
                {
                    if(nums[i] > nums[j] &&  nums[i] < max)
                    {
                        max = nums[i];
                        idx = i;
                    }
                    i--;
                }
                Swap(nums, j, idx);
                System.Array.Sort(nums, j + 1, nums.Length - j - 1);
            }
        }

        public class Solution162
        {
            public int FindPeakElement(int[] nums)
            {
                var N = nums.Count();
                var lo = 0;
                var hi = N - 1;

                while (hi - lo >= 2)
                {
                    var mid = (lo + hi) / 2;

                    if (nums[mid] < nums[mid - 1])
                    {
                        hi = mid - 1;
                    }
                    else if(nums[mid] < nums[mid+1])
                    {
                        lo = mid + 1;
                    }
                    else
                    {
                        return mid;
                    }
                }
                return nums[lo] < nums[hi] ? hi : lo;
            }
        }

        public class Solution153
        {
            public int FindMin(int[] nums)
            {
                var lo = 0;
                var hi = nums.Count() - 1;

                while(lo<hi)
                {
                    if(nums[lo] < nums[hi])
                    {
                        return nums[lo];
                    }
                    var mid = (lo + hi) / 2;
                    if(nums[lo] <= nums[mid])
                    {
                        lo = mid + 1;
                    }
                    else
                    {
                        hi = mid;
                    }
                }
                return nums[lo];
            }
        }

        public class Solution152
        {
            public int MaxProduct(int[] nums)
            {
                var maxVal = nums[0];
                var minVal = nums[0];
                var maxGlobal = nums[0];

                for(var i = 1; i < nums.Count();i++)
                {
                    if(nums[i]>=0)
                    {
                        maxVal = Math.Max(maxVal * nums[i], nums[i]);
                        minVal = Math.Min(minVal * nums[i], nums[i]);
                    }
                    else
                    {
                        var tmp = maxVal;
                        maxVal = Math.Max(minVal * nums[i], nums[i]);
                        minVal = Math.Min(tmp * nums[i], nums[i]);
                    }
                    if(maxVal > maxGlobal)
                    {
                        maxGlobal = maxVal;
                    }
                }
                return maxGlobal;
            }
        }

        public class Solution122
        {
            public int MaxProfit(int[] prices)
            {
                var ret = 0;

                for(var i = 0; i < prices.Count() - 1;i++)
                {
                    if(prices[i+1] > prices[i])
                    {
                        ret += prices[i + 1] - prices[i];
                    }
                }
                return ret;
            }
        }

        public class Solution120
        {
            public int TMinimumTotal(IList<IList<int>> triangle)
            {
                var rows = triangle.Count;
                var q = triangle[rows - 1];

                for(var i = rows - 2; i >= 0;i--)
                {
                    var p = new List<int>();

                    for(var j = 0; j <= i; j++)
                    {
                        p.Add(triangle[i][j] + Math.Min(q[j], q[j + 1]));
                    }
                    q = p;
                }
                return q[0];
            }
        }

        public class Solution34
        {
            public int[] SearchRange(int[] nums, int target)
            {
                var ret = new int[2];
                var lo = 0;
                var hi = nums.Count() - 1;

                while(lo <= hi)
                {
                    var mid = (lo + hi) / 2;

                    if (nums[mid] > target)
                    {
                        hi = mid - 1;
                    }
                    else if (nums[mid] < target)
                    {
                        lo = mid + 1;
                    }
                    else
                    {
                        var tmp = mid;

                        while(mid >= lo && nums[mid]==target)
                        {
                            mid--;
                        }
                        ret[0] = mid + 1;
                        mid = tmp;
                        while(mid <= hi && nums[mid] == target)
                        {
                            mid++;
                        }
                        ret[1] = mid - 1;
                        return ret;
                    }                  
                }
                ret[0] = ret[1] = -1;
                return ret;
            }

            public int[] SearchRange2(int[] nums, int target)
            {
                var ret = new int[2];
                var lo = 0;
                var hi = nums.Count() - 1;

                while(lo < hi)
                {
                    var mid = (lo + hi) / 2;

                    if(nums[mid] >= target)
                    {
                        hi = mid;
                    }
                    else if(nums[mid] < target)
                    {
                        lo = mid + 1;
                    }
                }
                if(nums[lo]!=target)
                {
                    ret[0] = ret[1] = -1;
                    return ret;
                }
                ret[0] = lo;
                hi = nums.Count() - 1;
                while(lo <= hi)
                {
                    var mid = (lo + hi) / 2;

                    if (nums[mid] > target)
                    {
                        hi = mid - 1;
                    }
                    else if (nums[mid] <= target)
                    {
                        lo = mid + 1;
                    }
                }
                ret[1] = lo - 1;
                return ret;
            }
        }

        public class Solution35
        {
            public int SearchInsert(int[] nums, int target)
            {
                var lo = 0;
                var hi = nums.Count() - 1;

                while(lo < hi)
                {
                    var mid = (lo + hi) / 2;

                    if(nums[mid] > target)
                    {
                        hi = mid;
                    }
                    else if(nums[mid] < target)
                    {
                        lo = mid + 1;
                    }
                    else
                    {
                        return mid;
                    }
                }
                return nums[lo] >= target ? lo : lo + 1;
            }
        }

        public class Solution90
        {
            public IList<IList<int>> Subsets(int[] nums)
            {
                var ret = new List<IList<int>>();
                System.Array.Sort(nums);
                Helper(nums, 0, new List<int>(), ret);
                return ret;
            }

            private void Helper(int[] nums, int begin, IList<int> subset, IList<IList<int>> ret)
            {
                var copy = new int[subset.Count()];
                subset.CopyTo(copy, 0);
                ret.Add(subset.ToList());
               

                for(var i = begin; i < nums.Count();i++)
                {
                    if(i==begin || nums[i]!=nums[i-1])
                    {
                        subset.Add(nums[i]);
                        Helper(nums, i + 1, subset, ret);
                        subset.Remove(nums[i]);
                    }
                }
            }
        }

        public class Solution289
        {
            public void GameOfLife(int[,] board)
            {
                long long 
                var m = board.GetLength(0);
                var n = board.GetLength(1);

                for(var i = 0; i < m; i++)
                {
                    for(var j = 0; j < n; j++)
                    {
                        var count = 0;
                        for(var p = Math.Max(0, i-1); p <= Math.Min(m-1, i+1); p++)
                        {
                            for(var q = Math.Max(0, j-1); q <= Math.Min(n-1, j+1); q++)
                            {
                                count += board[p, q] % 2;
                            }
                        }
                        if(count == 3 || count - board[i, j] == 3)
                        {
                            board[i, j] += 2;
                        }
                    }
                }
                for(var i = 0; i < m; i++)
                {
                    for(var j = 0; j < n; j++)
                    {
                        board[i, j] >>= 1;
                    }
                }
            }
        }
    }
}
