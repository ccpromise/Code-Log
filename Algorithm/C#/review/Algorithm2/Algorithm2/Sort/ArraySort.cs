using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm2.Sort
{
    /// <summary>
    /// 1\ Template class with Func<> to general the usage.
    /// 2\ Proof of sort algorithm's complexity.
    /// 3\ Learn from merge sort and quick sort.
    /// 
    /// Improvement:
    /// 1\ check for pre-sorted
    /// 2\ deal with duplicate situation
    /// 3\ elementray sort when array is small.
    /// </summary>
    public class ArraySort
    {
        /// <summary>
        /// complexity: O(N^2)
        /// in space, stable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="comparator"></param>
        public static void InsertionSort<T>(T[] arr, Func<T, T, int> comparator)
        {
            var N = arr.Count();

            for(var i = 1; i < N; i++)
            {
                var j = 0;
                while(j < i && comparator(arr[i], arr[j]) < 0) // which means arr[j] should be sorted before arr[i]
                {
                    j++;
                }
                var k = i - 1;
                var x = arr[i];
                while(k >= j)
                {
                    arr[k + 1] = arr[k];
                }
                arr[j] = x;
            }
        }

        /// <summary>
        /// complexity: O(N^2)
        /// in space, not stable because of swap
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="comparator"></param>
        public static void SelectionSort<T>(T[] arr, Func<T, T, int> comparator)
        {
            var N = arr.Count();

            for(var i = 0; i < N; i++)
            {
                var max = i;
                for(var j = i+1; j < N; j++)
                {
                    if(comparator(arr[j], arr[max]) > 0)
                    {
                        max = j;
                    }
                }
                Swap(arr, i, max);
            }
        }

        /// <summary>
        /// complexity: O(N^2)
        /// in space, stable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="comparator"></param>
        public static void BubbleSort<T>(T[] arr, Func<T, T, int> comparator)
        {
            var N = arr.Count();

            for(var i = 0; i < N - 1; i--)
            {
                for(var j = N - 1; j > i; j--)
                {
                    if(comparator(arr[j], arr[j - 1]) > 0)
                    {
                        Swap(arr, j, j + 1);
                    }
                }
            }
        }

        /// <summary>
        /// complexity: O(NlgN)---Proof
        /// not in space, stable
        /// 
        /// Merge: the result of x can be calculated by the result of part of x.
        /// </summary>
        /// <param name="arr"></param>
        public static void MergeSort(IComparable[] arr)
        {
            Helper1(arr, 0, arr.Count() - 1);
        }

        /// <summary>
        /// complexity: O(N*lgN)
        /// in space, not stable because of swap
        /// 
        /// quick sort used in leetcode: find the nth min/max number.
        /// </summary>
        /// <param name="arr"></param>
        public static void QuickSort(IComparable[] arr)
        {
            Helper2(arr, 0, arr.Count() - 1);
        }

        /// <summary>
        /// complexity: O(NlgN)
        /// in space
        /// </summary>
        /// <param name="arr"></param>
        public static void HeapSort(IComparable[] arr)
        {
            BuildHeap(arr);

            var N = arr.Count();
            for(var i = N-1; i > 0; i--)
            {
                Swap(arr, 0, i);
                Sink(arr, 0, 0, i-1);
            }
        }

        private static void Helper1(IComparable[] arr, int lo, int hi)
        {
            if(lo >= hi)
            {
                return;
            }
            var mid = (lo + hi) / 2;
            var sorted = new IComparable[hi - lo + 1];
            var i = lo;
            var j = mid + 1;
            var k = 0;

            Helper1(arr, lo, mid);
            Helper1(arr, mid + 1, hi);
            while(i <= mid && j <= hi)
            {
                if(arr[i].CompareTo(arr[j]) > 0)
                {
                    sorted[k++] = arr[i++];
                }
                else
                {
                    sorted[k++] = arr[j++];
                }
            }
            while(i <= mid)
            {
                sorted[k++] = arr[i++];
            }
            while(j <= hi)
            {
                sorted[k++] = arr[j++];
            }
            Array.Copy(sorted, arr, hi - lo + 1);
        }

        private static void Helper2(IComparable[] arr, int lo, int hi)
        {
            if(lo >= hi)
            {
                return;
            }
            var i = lo + 1;
            var j = lo + 1;
            while(i <= hi)
            {
                if(arr[i].CompareTo(arr[lo]) > 0)
                {
                    Swap(arr, i, j);
                    j++;
                }
                i++;
            }
            Swap(arr, lo, j - 1);
            Helper2(arr, lo, j - 2);
            Helper2(arr, j, hi);
        }
    }
}
