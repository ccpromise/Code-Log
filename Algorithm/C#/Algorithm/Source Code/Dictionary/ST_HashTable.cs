using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Source_Code.Chapter3
{
    /// <summary>
    /// If keys are small integers, we can use an array to implement an unordered symbol table, 
    /// by interpreting the key as an array index so that we can store the value associated with key i in array entry i, 
    /// ready for immediate access.
    /// 
    /// Hash table is an efficient expansion of it.
    /// Use hash function to transform keys into array indices by doing arithmetic operations.
    /// 
    /// Attention: HashTable_SeparateChaing is developed on ST_LinkedList, which is a very good example of effecient development.
    /// 
    /// Two important parts in hash table:
    /// 1\ Design hash function:
    ///     The function output should be among a certain range.
    ///     The index should be uniformly distributed.
    /// 2\ Collision resolution:
    ///     Separate chaining: avoid single list too long
    ///     Linear probing: avoid large cluster
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class ST_HashTable_SeparateChaining<K, V>
    {
        private ST_LinkedList<K, V>[] arr;
        private int M;
        public ST_HashTable_SeparateChaining(int M)
        {
            this.M = M;
            arr = new ST_LinkedList<K, V>[M];
        }


        public void Delete(K key)
        {
            var idx = Hash(key);

            if (arr[idx] == null)
            {
                throw new InvalidOperationException();
            }
            arr[idx].Delete(key);
        }

        public V Get(K key)
        {
            var idx = Hash(key);

            if (arr[idx] == null)
            {
                throw new InvalidOperationException();
            }
            return arr[idx].Search(key);
        }

        public bool Contains(K key)
        {
            var idx = Hash(key);

            if (arr[idx] == null || !arr[idx].Contains(key))
            {
                return false;
            }
            return true;
        }

        public bool IsEmpty()
        {
            foreach(var l in arr)
            {
                if(l != null && !l.IsEmpty())
                {
                    return false;
                }
            }
            return true;
        }

        public int Size()
        {
            var size = 0;

            foreach(var l in arr)
            {
                if(l!=null)
                {
                    size += l.Size();
                }
            }
            return size;
        }

        private int Hash(K key)
        {
            return key.GetHashCode() % M;
        }
    }

    public class ST_HahsTable_LinearProbing<K, V> 
        where K:class 
        where V:class
    {
        private V[] values;
        private K[] keys;
        private int M;
        private int N;
        public ST_HahsTable_LinearProbing(int M)
        {
            this.M = M;
            N = 0;
            values = new V[M];
            keys = new K[M];
        }

        public void Insert(K key, V value)
        {
            if(N==M)
            {
                throw new InvalidOperationException();
            }

            var idx = Find(key);

            if(keys[idx]==null)
            {
                N++;
                keys[idx] = key;
            }
            values[idx] = value;
        }

        // re-hash after delete a key.
        public void Delete(K key)
        {
            var idx = Find(key);

            if (keys[idx] == null)
            {
                throw new InvalidOperationException();
            }
            keys[idx] = null;
            values[idx] = null;
            N--;
            idx = (idx + 1) % M;

            while (keys[idx]!=null)
            {
                var k = keys[idx];
                var v = values[idx];

                keys[idx] = null;
                values[idx] = null;

                var newIdx = Find(k);
                keys[newIdx] = k;
                values[newIdx] = v;
                idx = (idx + 1) % M;
            }
        }

        public V Get(K key)
        {
            var idx = Find(key);
                       
            if(keys[idx]==null)
            {
                throw new InvalidOperationException();
            }
            return values[idx];
        }

        public bool Contains(K key)
        {
            try
            {
                var idx = Find(key);

                if(keys[idx]==null)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private int Hash(K key)
        {
            return key.GetHashCode() % M;
        }

        private int Find(K key)
        {
            var start = Hash(key);
            var idx = start;

            while (keys[idx] != null && !keys[idx].Equals(key))
            {
                idx = (idx + 1) % M;
                if(idx==start)
                {
                    throw new InvalidOperationException();
                }
            }
            return idx;
        }
    }
}
