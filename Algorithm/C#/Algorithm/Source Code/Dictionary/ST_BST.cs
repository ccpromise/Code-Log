using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Source_Code.Chapter3
{
    /// <summary>
    /// The pros of ST_LinkedList is that insert or delete in a linked list is very fast. But search is relevantly slow.
    /// Which is opposite to ordered array implementation. Insertation and deletation is slow but search is fast.
    /// BST is to combine the pros of linked list and ordered array.
    /// The different between BST and linked list is that for each BST node, it points to another two nodes.
    /// 
    /// Attention: recursive implementation of Insert and Delete.
    /// Attention: implementation of Range(lo, hi).
    /// </summary>
    public class ST_BST<K, V> where K:IComparable<K>
    {
        private class Node
        {
            public K key;
            public V value;
            public Node left;
            public Node right;

            public Node(K key, V value, Node left = null, Node right = null)
            {
                this.key = key;
                this.value = value;
                this.left = left;
                this.right = right;
            }
        }
        private Node root;
        private int size;

        public ST_BST()
        {
            root = null;
            size = 0;
        }

        // worst case O(N), average case O(lgN)
        public void Insert(K key, V value)
        {
            if (root == null)
            {
                root = new Node(key, value);
                size++;
                return;
            }

            var node = root;
            while (true)
            {
                if (node.key.Equals(key))
                {
                    node.value = value;
                    return;
                }
                if (Less(node.key, key))
                {
                    if (node.right == null)
                    {
                        node.right = new Node(key, value);
                        size++;
                        return;
                    }
                    node = node.right;
                }
                else
                {
                    if (node.left == null)
                    {
                        node.left = new Node(key, value);
                        size++;
                        return;
                    }
                    node = node.left;
                }
            }
        }

        // worst case O(N), average case O(lgN)
        public void Insert_Recursion(K key, V value)
        {
            root = InsertHelper(root, key, value);
        }

        // worst case O(N), average case O(lgN)
        public V Search(K key)
        {
            var node = root;

            while (node != null)
            {
                if (node.key.Equals(key))
                {
                    return node.value;
                }
                if (Less(node.key, key))
                {
                    node = node.right;
                }
                else
                {
                    node = node.left;
                }
            }
            throw new InvalidOperationException();
        }

        // worst case O(N), average case O(lgN)
        public void Delete(K key)
        {
            root = DeleteHelper(root, key);
        }

        public bool Empty()
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

            var node = root;

            while (node.right != null)
            {
                node = node.right;
            }
            return node.key;
        }

        public K Min()
        {
            if (size == 0)
            {
                throw new InvalidOperationException();
            }

            var node = root;

            while (node.left != null)
            {
                node = node.left;
            }
            return node.key;
        }

        public K[] Range(K lo, K hi)
        {
            var ret = new List<K>();

            RangeHelper(root, lo, hi, ret);
            return ret as K[];
        }

        public K[] Keys()
        {
            var ret = new List<K>();

            RangeHelper(root, this.Min(), this.Max(), ret);
            return ret as K[];
        }

        private bool Less(K p, K q)
        {
            return p.CompareTo(q) < 0;
        }

        private Node InsertHelper(Node r, K key, V value)
        {
            if (r == null)
            {
                size++;
                return new Node(key, value);
            }
            if (r.key.Equals(key))
            {
                r.value = value;
            }
            else if (Less(r.key, key))
            {
                r.right = InsertHelper(r.right, key, value);
            }
            else
            {
                r.left = InsertHelper(r.left, key, value);
            }
            return r;
        }

        private Node DeleteHelper(Node node, K key)
        {
            if (node == null)
            {
                throw new InvalidOperationException();
            }
            if (node.key.Equals(key))
            {
                if (node.left == null)
                {
                    return node.right;
                }
                if (node.right == null)
                {
                    return node.left;
                }
                var min = node.right;
                var p = node;

                while (min.left != null)
                {
                    p = min;
                    min = min.left;
                }
                p.left = null;
                min.left = node.left;
                min.right = node.right;
                size--;
                return min;
            }
            if (Less(node.key, key))
            {
                node.right = DeleteHelper(node.right, key);
            }
            else
            {
                node.left = DeleteHelper(node.left, key);
            }
            return node;
        }

        private void RangeHelper(Node node, K lo, K hi, IList<K> ret)
        {
            if (node == null)
            {
                return;
            }
            var cmplo = lo.CompareTo(node.key);
            var cmphi = hi.CompareTo(node.key);

            if (cmplo < 0)
            {
                RangeHelper(node.left, lo, hi, ret);
            }
            if (cmplo <= 0 && cmphi >= 0)
            {
                ret.Add(node.key);
            }
            if (cmphi > 0)
            {
                RangeHelper(node.right, lo, hi, ret);
            }
        }
    }
}
