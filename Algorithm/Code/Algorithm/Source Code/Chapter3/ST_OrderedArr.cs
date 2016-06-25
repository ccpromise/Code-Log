using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Source_Code.Chapter3
{
    /// <summary>
    /// Implement symbol table using sorted array so that ordered operation is available, such as Max() Min().
    /// Another pros is that ordered array enable binary search, which is much faster than sequential search.
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class ST_OrderedArr<K , V> where K:IComparable<K>
    {
        private Node[] arr;
        private int size;
        private int amount;
        private static int initialSize;

        public ST_OrderedArr()
        {
            arr = new Node[initialSize];
            amount = initialSize;
            size = 0;
        }

        // O(N):because of data movement
        public void Insert(K key, V value)
        {
            var idx = Rank(key);

            if (size !=0 && arr[idx].key.Equals(key))
            {
                arr[idx].value = value;
                return;
            }
            for (var i = size - 1; i >= idx; i--)
            {
                arr[i + 1] = arr[i];
            }
            arr[idx] = new Node(key, value);
            size++;
            if (size > amount / 2)
            {
                Resize(amount * 2);
            }
        }

        // O(lgN)
        public V Search(K key)
        {
            var idx = Rank(key);

            if (size != 0 && arr[idx].key.Equals(key))
            {
                return arr[idx].value;
            }
            throw new InvalidOperationException();
        }

        // O(N)
        public bool Delete(K key)
        {
            var idx = Rank(key);

            if (size != 0 && arr[idx].key.Equals(key))
            {
                for (var i = idx + 1; i < size; i++)
                {
                    arr[i - 1] = arr[i];
                }
                size--;
                if (size < amount / 4 && amount>initialSize)
                {
                    Resize(amount / 2);
                }
                return true;
            }
            return false;
        }

        // O(lgN)
        public bool Contains(K key)
        {
            var idx = Rank(key);

            if (size != 0 && arr[idx].key.Equals(key))
            {
                return true;
            }
            return false;
        }

        public K[] Keys()
        {
            var ret = new K[size];

            for (var i = 0; i < size; i++)
            {
                ret[i] = arr[i].key;
            }
            return ret;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public int Size()
        {
            return size;
        }

        public K Max()
        {
            if (size == 0)
            {
                throw new InvalidOperationException();
            }
            return arr[size - 1].key;
        }

        public K Min()
        {
            if(size==0)
            {
                throw new InvalidOperationException();
            }
            return arr[0].key;
        }

        // # keys smaller than key
        private int Rank(K key)
        {
            var lo = 0;
            var hi = size - 1;

            while (lo <= hi)
            {
                var mid = lo + (hi - lo) / 2;

                if (Less(arr[mid].key, key))
                {
                    lo = mid + 1;
                }
                else if (Less(key, arr[mid].key))
                {
                    hi = mid - 1;
                }
                else
                {
                    return mid;
                }
            }
            return lo;
        }

        private bool Less(K p, K q)
        {
            return p.CompareTo(q) < 0;
        }

        private void Resize(int amount)
        {
            this.amount = amount;
            var resize = new Node[amount];

            for (var i = 0; i < size; i++)
            {
                resize[i] = arr[i];
            }
            arr = resize;
        }

        private class Node
        {
            public K key;
            public V value;

            public Node(K key, V value)
            {
                this.key = key;
                this.value = value;
            }
        }
    }
}
