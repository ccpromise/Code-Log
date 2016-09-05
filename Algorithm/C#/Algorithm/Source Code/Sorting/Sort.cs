using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Source_Code.Chapter2
{
    /// <summary>
    /// Improvement: elementray sort when arr is small;
    /// check for duplicate;
    /// check for pre-sorted;
    /// multiple keys;
    /// </summary>
    public static class Sort
    {
        /// <summary>
        /// complexity: NlgN
        /// stable, requires extra space
        /// </summary>
        /// <param name="arr"></param>
        public static void MergeSort(IComparable[] arr)
        {
            MergeSortHelper(arr, 0, arr.Count() - 1);
        }

        /// <summary>
        /// Complexity: NlgN
        /// not stable, in place
        /// Faster in practise because of less data movement.
        /// </summary>
        /// <param name="arr"></param>
        public static void QuickSort(IComparable[] arr)
        {
            QuickSortHelper(arr, 0, arr.Count() - 1);
        }

        /// <summary>
        /// complexity: NlgN
        /// Not stable, in place
        /// </summary>
        /// <param name="arr"></param>
        public static void HeapSort(IComparable[] arr)
        {
            BuildMaxHeap(arr);

            var i = arr.Count() - 1;

            while (i > 0)
            {
                Swap(arr, 0, i);
                Sink(arr, 0, i-1);
                i--;
            }
        }

        public static void QuickSort_3Way(IComparable[] arr)
        {
            QuickSort_3WayHelper(arr, 0, arr.Count() - 1);
        }

        private static void MergeSortHelper(IComparable[] arr, int lo, int hi)
        {
            if (lo >= hi)
            { 
                return;
            }
            var mid = (lo + hi) / 2;
            var sorted = new IComparable[hi - lo + 1];

            MergeSortHelper(arr, lo, mid);
            MergeSortHelper(arr, mid + 1, hi);

            var i = 0;
            var j = lo;
            var k = mid + 1;
            while (j <= mid && k <= hi)
            {
                if (LessOrEqual(arr[j], arr[k]))
                {
                    sorted[i++] = arr[j++];
                }
                else
                {
                    sorted[i++] = arr[k++];
                }
            }
            while (j <= mid)
            {
                sorted[i++] = arr[j++];
            }
            while (k <= hi)
            {
                sorted[i++] = arr[k++];
            }
            for (i = 0; i < sorted.Count(); i++)
            {
                arr[lo + i] = sorted[i];
            }
        }

        private static void QuickSortHelper(IComparable[] arr, int lo, int hi)
        { 
            if (lo >= hi)
            {
                return;
            }
            var i = lo+1;
            var j = lo+1;
            while (j <= hi)
            {
                if (LessOrEqual(arr[j], arr[lo]))
                {
                    Swap(arr, i, j);
                    i++;
                }
                j++;
            }
            Swap(arr, lo, i);
            QuickSortHelper(arr, lo, i - 1);
            QuickSortHelper(arr, i + 1, hi);
        }

        private static void BuildMaxHeap(IComparable[] arr)
        {
            for (var i = arr.Count() / 2 - 1; i >= 0; i--)
            {
                if (Less(arr[i], arr[i * 2 + 1]))
                {
                    Swap(arr, i, i * 2 + 1);
                }
                if (i * 2 + 2 < arr.Count() && Less(arr[i], arr[i * 2 + 2]))
                {
                    Swap(arr, i, i * 2 + 2);
                }
            }
        }

        private static void QuickSort_3WayHelper(IComparable[] arr, int lo, int hi)
        {
            if (lo >= hi)
            {
                return;
            }

            var le = lo + 1;
            var gr = hi;
            var i = lo + 1;

            while (i <= gr)
            {
                if (Less(arr[lo], arr[i]))
                {
                    Swap(arr, i, gr);
                    gr--;
                }
                else if (Less(arr[i], arr[lo]))
                {
                    Swap(arr, i, le);
                    le++;
                    i++;
                }
                else
                {
                    i++;
                }
            }
            Swap(arr, lo, le - 1);
            QuickSort_3WayHelper(arr, lo, le - 1);
            QuickSort_3WayHelper(arr, gr + 1, hi);
        }

        private static void Sink(IComparable[] arr, int i, int size)
        {
            while (2 * i + 1 <= size)
            {
                var max = Less(arr[i], arr[2*i+1])?2*i+1:i;

                if (2*i+2<=size)
                {
                    max = Less(arr[max], arr[2*i+2])?2*i+2:max;
                }
                if (max == i)
                {
                    return;
                }
                Swap(arr, i, max);
                i = max;
            }
        }

        private static bool LessOrEqual(IComparable p, IComparable q)
        {
            return p.CompareTo(q) <= 0;
        }

        private static bool Less(IComparable p, IComparable q)
        {
            return p.CompareTo(q) < 0;
        }

        private static void Swap(IComparable[] arr, int i, int j)
        {
            var tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }
    }
}
