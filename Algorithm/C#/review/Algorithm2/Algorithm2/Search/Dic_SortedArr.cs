using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm2.Dictionary
{
    /// <summary>
    /// Compare SortedArr with LinkedList:
    /// binary search is faster than sequential search
    /// besides, order operation like Rank() Min() Max() are more easy.
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class Dic_SortedArr<K, V> where K : IComparable<K>
    {
        IList<Node> arr;
        public Dic_SortedArr()
        {
            arr = new List<Node>();
        }

        public void Insert(K key, V val)
        {
        }

        public V this[K key]
        {
            get { }
            set { }
        }

        public bool ContainsKey(K key)
        { }

        public void Delete(K key)
        { }

        public int Size()
        { }

        // return #keys smaller than key
        private int Rank(K key)
        {
            var i = 0;
            var j = arr.Count() - 1;

            while(i <= j)
            {
                var mid = (i + j) / 2;

                if(arr[mid].key.CompareTo(key) < 0)
                {
                    i = mid + 1;
                }
                else if(arr[mid].key.CompareTo(key) > 0)
                {
                    j = mid - 1;
                }
                else
                {
                    return mid;
                }
            }
            return i;
        }

        private class Node : IComparable<Node>
        {
            public K key;
            public V val;
            public Node next;
            public Node(K k, V v)
            {
                key = k;
                val = v;
                next = null;
            }

            public int CompareTo(Node other)
            {
                return this.key.CompareTo(other.key);
            }
        }

    }
}
