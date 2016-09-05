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
    /// Elementary implementation for priority queue is O(N) for insert or delete.
    /// </summary>
    public class PriorityQueue<K>
    {
        private K[] arr;
        private int size;
        private int capacity;
        private Func<K, K, int> comparator;

        public PriorityQueue(int N, Func<K, K, int> func)
        {
            arr = new K[N];
            size = 0;
            capacity = N;
            comparator = func;
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
            while (n > 0 && comparator(arr[n], arr[n/2-1]) > 0)
            {
                Swap(n, n / 2 - 1);
                n = n / 2 - 1;
            }
        }

        private void Sink(int n)
        {
            while (n*2+1 < size)
            {
                var front = n;
                if (comparator(arr[n], arr[n*2+1]) < 0)
                {
                    front = n * 2 + 1;
                }
                if (n * 2 + 2 < size && comparator(arr[front], arr[n*2+2]) < 0)
                {
                    front = n * 2 + 2;
                }
                if (front == n)
                {
                    break;
                }
                Swap(n, front);
                n = front;
            }
        }

        private void Swap(int i, int j)
        {
            var tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
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