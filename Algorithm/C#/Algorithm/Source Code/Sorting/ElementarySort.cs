using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Source_Code.Chapter2
{
    public static class ElementarySort
    {
        /// <summary>
        /// Complexity: N^2
        /// No extra space, not stable
        /// </summary>
        /// <param name="arr"></param>
        public static void SelectionSort(IComparable[] arr)
        {
            var N = arr.Count();
            for (var i = 0; i < N - 1; i++)
            {
                var min = i;
                for (var j = i + 1; j < N; j++)
                {
                    if (Less(arr[j], arr[min]))
                    {
                        min = j;
                    }
                }
                Swap(arr, i, min);
            }
        }

        /// <summary>
        /// Complexity: N^2
        /// No extra space, stable
        /// </summary>
        /// <param name="arr"></param>
        public static void InsertionSort(IComparable[] arr)
        { 
            var N = arr.Count();
            for (var i = 1; i < N; i++)
            {
                var j = 0;
                var key = arr[i];
                while (j < i && LessOrEqual(arr[j], arr[i]))
                {
                    j++;
                }
                for(var k = i; k > j; k--)
                {
                    arr[k] = arr[k - 1];
                }
                arr[j] = key;
            }
        }

        public static void BubbleSort(IComparable[] arr)
        { 
            var N = arr.Count();
            for (var i = 0; i < N - 1; i++)
            {
                var flag = false;
                for (var j = N - 1; j > i; j--)
                {
                    if (Less(arr[j], arr[j - 1]))
                    {
                        Swap(arr, j, j - 1);
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    return;
                }
            }
        }

        private static bool Less(IComparable p, IComparable q)
        {
            return p.CompareTo(q) < 0;
        }

        private static bool LessOrEqual(IComparable p, IComparable q)
        {
            return p.CompareTo(q) <= 0;
        }

        private static void Swap(IComparable[] arr, int i, int j)
        {
            var tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }
    }
}
