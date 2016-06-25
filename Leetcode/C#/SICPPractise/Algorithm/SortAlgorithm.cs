using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SICPPractise.Algorithm
{
    public static class SortAlgorithm
    {
        public static void HeapSort(int[] arr)
        {
            for (var i = arr.Count(); i >= 2; i--)
            {
                int temp;
                for (var j = i / 2; j >= 1; j--)
                {
                    if (arr[j - 1] < arr[2 * j - 1])
                    {
                        temp = arr[j - 1];
                        arr[j - 1] = arr[2 * j - 1];
                        arr[2 * j - 1] = temp;
                    }
                    if (2 * j < i && arr[j - 1] < arr[2 * j])
                    {
                        temp = arr[j - 1];
                        arr[j - 1] = arr[2 * j];
                        arr[2 * j] = temp;
                    }
                }
                temp = arr[0];
                arr[0] = arr[i - 1];
                arr[i - 1] = temp;
            }
        }

        public static void QuickSort(int[] arr)
        {
            QuickSortIter(arr, 0, arr.Length - 1);
        }
        private static void QuickSortIter(int[] arr, int start, int end)
        {
            if (start < end)
            {
                var i = start + 1;
                var j = i;
                int temp;
                while (j <= end)
                {
                    if (arr[j] < arr[start])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                        i++;
                    }
                    j++;
                }
                temp = arr[i - 1];
                arr[i - 1] = arr[start];
                arr[start] = temp;
                QuickSortIter(arr, start, i - 2);
                QuickSortIter(arr, i, end);
            }
        }

        public static void BubbleSort(int[] arr)
        {
            for (var i = 0; i < arr.Length-1; i++)
            {
                for (var j = arr.Length - 1; j > i; j--)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        Swap(arr, j, j-1);
                    }
                }
            }
        }

        public static void InsertSort(int[] arr)
        {
            for (var i = 1; i < arr.Length; i++)
            {
                var j = 0;
                while (j < i && arr[j] < arr[i])
                {
                    j++;
                }
                var temp = arr[i];
                for (var k = i - 1; k >= j; k--)
                {
                    arr[k + 1] = arr[k];
                }
                arr[j] = temp;
            }
        }

        public static void MergeSort(int[] arr)
        {
            MergeSortIter(arr, 0, arr.Length - 1);
        }
        private static void MergeSortIter(int[] arr, int lo, int hi)
        {
            if (lo < hi)
            {
                var mid = (lo + hi) / 2;
                MergeSortIter(arr, lo, mid);
                MergeSortIter(arr, mid + 1, hi);
                var sorted = new int[hi - lo + 1];
                var i = lo;
                var j = mid + 1;
                var k = 0;
                while (i <= mid && j <= hi)
                {
                    if (arr[i] < arr[j])
                    {
                        sorted[k++] = arr[i++];
                    }
                    else
                    {
                        sorted[k++] = arr[j++];
                    }
                }
                while (i <= mid)
                {
                    sorted[k++] = arr[i++];
                }
                while (j <= hi)
                {
                    sorted[k++] = arr[j++];
                }
                k = lo;
                foreach (var n in sorted)
                {
                    arr[k++] = n;
                }
            }
        }

        private static void Swap(int[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
