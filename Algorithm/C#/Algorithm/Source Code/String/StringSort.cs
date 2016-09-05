using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Source_Code.Chapter3
{
    /// <summary>
    /// 1\ sorting:
    ///     The best performance of compare-based sorting is NlgN. Key-indexed counting is N.
    /// 2\ LSD:
    ///     order from the least significant digit
    /// 3\ MSD:
    ///     order from the most significant digit;
    ///     think about the recursive process.
    /// 4\ ThreeWay Quick Sort:
    ///     think about the recursive process.
    /// </summary>
    public class Sort
    {
        public static void LSD(string[] arr)
        {
            var length = arr[0].Count();
            var N = arr.Count();
            var R = 256;

            for (var i = length - 1; i >= 0; i--)
            {
                var count = new int[R + 1];
                var ordered = new string[N];

                foreach (var s in arr)
                {
                    count[s[i] + 1]++;
                }
                for (var j = 0; j < R; j++)
                {
                    count[j + 1] += count[j];
                }
                foreach (var s in arr)
                {
                    var idx = count[s[i]]++;
                    ordered[idx] = s;
                }
                for (var j = 0; j < N; j++)
                {
                    arr[j] = ordered[j];
                }
            }
        }

        public static void MSD(string[] arr)
        {
            MSDHelper(arr, 0, 0, arr.Count() - 1);
        }

        public static void ThreeWayQS(string[] arr)
        {
            ThreeWayQSHelper(arr, 0, 0, arr.Count() - 1);
        }

        private static void MSDHelper(string[] arr, int key, int lo, int hi)
        {
            if(hi<=lo || key==arr[0].Count())
            {
                return;
            }

            var R = 256;
            var count = new int[R+1];
            var ordered = new string[hi - lo + 1];

            for (var i = lo; i <= hi; i++)
            {
                count[arr[i][key]+1]++;
            }
            for (var i = 0; i < R; i++)
            {
                count[i + 1] += count[i];
            }
            for (var i = lo; i <= hi; i++)
            {
                var idx = count[arr[lo][key]]++;

                ordered[idx] = arr[lo];
            }
            for (var i = 0; i < hi - lo + 1; i++)
            {
                arr[i + lo] = ordered[i];
            }
            for (var i = 0; i < R; i++)
            {
                var p = lo + (i == 0 ? 0 : count[i - 1]);
                var q = lo + count[i] - 1;

                MSDHelper(arr, key + 1, p, q);
            }
        }

        private static void ThreeWayQSHelper(string[] arr, int key, int lo, int hi)
        {
            if (hi <= lo || key == arr[0].Count())
            {
                return;
            }

            var flag = arr[lo][key];
            var less = lo+1;
            var greater = hi;
            var i = lo + 1;

            while (i <= greater)
            {
                if (arr[i][key] < flag)
                {
                    Swap(arr, i, less);
                    less++;
                }
                else if (arr[i][key] > flag)
                {
                    Swap(arr, i, greater);
                    greater--;
                    i--;
                }
                i++;
            }
            Swap(arr, lo, less-1);
            ThreeWayQSHelper(arr, key, lo, less - 1);
            ThreeWayQSHelper(arr, key, greater + 1, hi);
            ThreeWayQSHelper(arr, key + 1, less, greater);
        }

        private static void Swap(string[] arr, int i, int j)
        {
            var tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }
    }
}
