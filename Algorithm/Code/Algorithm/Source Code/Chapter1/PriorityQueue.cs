using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Source_Code.Chapter1
{
    /// <summary>
    /// Implement priority queue using heap.
    /// Complexity:
    /// Insert: lg(N)
    /// DelMin: lg(N)
    /// Elementary implementation for priority queue is N for insert or delete.
    /// </summary>
    public class MinPQ<K> where K:IComparable<K>
    {
        private K[] arr;
        private int size;
        private int capacity;

        public MinPQ(int N)
        {
            arr = new K[N];
            size = 0;
            capacity = N;
        }

        public bool Insert(K item)
        {
            if (size == capacity)
            {
                return false;
            }
            arr[size] = item;
            Swim(size);
            size++;
            return true;
        }

        public K DelMin()
        {
            if (size == 0)
            {
                throw new InvalidOperationException();
            }
            Swap(0, size - 1);
            Sink(0);
            size--;
            return arr[size];
        }

        public int Size()
        {
            return size;
        }

        private void Swim(int n)
        {
            while (n > 0 && Less(n, n / 2 - 1))
            {
                Swap(n, n / 2 - 1);
                n = n / 2 - 1;
            }
        }

        private void Sink(int n)
        {
            while (n*2+1 < size)
            {
                var min = n;
                if (Less(n * 2 + 1, min))
                {
                    min = n * 2 + 1;
                }
                if (n * 2 + 2 < size && Less(n * 2 + 2, min))
                {
                    min = n * 2 + 2;
                }
                if (min == n)
                {
                    break;
                }
                Swap(n, min);
                n = min;
            }
        }

        private void Swap(int i, int j)
        {
            var tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }

        private bool Less(int i, int j)
        {
            return arr[i].CompareTo(arr[j]) < 0;
        }
    }

    public class MaxPQ<K>where K:IComparable<K>
    { 
        private K[] arr;
        private int size;
        private int capacity;

        public MaxPQ(int N)
        {
            arr = new K[N];
            size = 0;
            capacity = N;
        }

        public bool Insert(K item)
        {
            if (size == capacity)
            {
                return false;
            }
            arr[size] = item;
            Swim(size);
            size++;
            return true;
        }

        public K DelMin()
        {
            if (size == 0)
            {
                throw new InvalidOperationException();
            }
            Swap(0, size - 1);
            Sink(0);
            size--;
            return arr[size];
        }

        public int Size()
        {
            return size;
        }

        private void Swim(int n)
        {
            while (n > 0 && Greater(n, n / 2 - 1))
            {
                Swap(n, n / 2 - 1);
                n = n / 2 - 1;
            }
        }

        private void Sink(int n)
        {
            while (n*2+1 < size)
            {
                var max = n;
                if (Greater(n * 2 + 1, max))
                {
                    max = n * 2 + 1;
                }
                if (n * 2 + 2 < size && Greater(n * 2 + 2, max))
                {
                    max = n * 2 + 2;
                }
                if (max == n)
                {
                    break;
                }
                Swap(n, max);
                n = max;
            }
        }

        private void Swap(int i, int j)
        {
            var tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }

        private bool Greater(int i, int j)
        {
            return arr[i].CompareTo(arr[j]) > 0;
        }
    }
}