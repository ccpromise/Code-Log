using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Solution();
            var ans = p.IsPerfectSquare(104976);
            

            Console.ReadKey();
        }
        public class Solution
        {
            public bool IsPerfectSquare(int num)
            {
                if (num == 1)
                {
                    return true;
                }
                long lo = 1;
                long hi = num;
                long target = num;

                while (lo < hi)
                {
                    long mid = lo + (hi - lo) / 2;
                    long tmp = mid * mid;
                    if (tmp > target)
                    {
                        hi = mid - 1;
                    }
                    else if (tmp < target)
                    {
                        lo = mid + 1;
                    }
                    else
                    {
                        return true;
                    }
                }
                return false;
            }
        }

    }
}
