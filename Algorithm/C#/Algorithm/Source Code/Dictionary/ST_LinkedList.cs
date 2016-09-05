using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Source_Code.Chapter3
{
    /// <summary>
    /// The subject of this section is to implement Insert/Search/Delete operation for key-value pair.
    /// If ordered operation needed like Max/Min, use binary search tree.
    /// Otherwise, hash table is better.
    /// Dictionary is implemented using either BST or hash table.
    /// </summary>
    public class ST_LinkedList<K, V>
    {
        private Node head;
        private int size;

        public ST_LinkedList()
        {
            head = null;
            size = 0;
        }

        // O(N)
        public void Insert(K key, V value)
        {
            var node = SearchKey(key);

            if (node != null)
            {
                node.value = value;
            }
            else
            {
                node = new Node(key, value);
                node.next = head;
                head = node;
                size++;
            }
        }

        // O(N)
        public V Search(K key)
        {
            var node = SearchKey(key);

            if (node == null)
            {
                throw new InvalidOperationException();
            }
            return node.value;
        }

        // O(N)
        public bool Contains(K key)
        {
            var node = SearchKey(key);

            return node != null;
        }

        // O(N)
        public void Delete(K key)
        {
            var node = head;
            Node pre = null;

            while (node != null && !node.key.Equals(key))
            {
                pre = node;
                node = node.next;
            }
            if (node == null)
            {
                throw new InvalidOperationException();
            }
            else if (pre == null)
            {
                head = node.next;
            }
            else
            {
                pre.next = node.next;
            }
            size--;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public int Size()
        {
            return size;
        }

        public K[] Keys()
        {
            var arr = new K[size];
            var node = head;
            var i = 0;

            while (node != null)
            {
                arr[i++] = node.key;
                node = node.next;
            }
            return arr;
        }

        private class Node
        {
            public K key;
            public V value;
            public Node next;

            public Node(K key, V value, Node next = null)
            {
                this.key = key;
                this.value = value;
                this.next = next;
            }
        }

        private Node SearchKey(K key)
        {
            var node = head;

            while (node != null && !node.key.Equals(key))
            {
                node = node.next;
            }
            return node;
        }
    }
    //public class MyDictionaryOfLinkedList<K, V>
    //{
    //    private Node head;
    //    private int size;
    //    public MyDictionaryOfLinkedList()
    //    {
    //        size = 0;
    //    }

    //    public void Add(K key, V value)
    //    {
    //        var node = head;

    //        while(node!=null&&!node.key.Equals(key))
    //        {
    //            node = node.next;
    //        }
    //        if(node==null)
    //        {
    //            var tmp = new Node(key, value);
    //            tmp.next = head;
    //            head = tmp;
    //            size++;
    //        }
    //        else
    //        {
    //            node.value = value;
    //        }
    //    }

    //    public bool Delete(K key)
    //    {
    //        var node = head;
    //        Node pre = null;

    //        while(node!=null && !node.key.Equals(key))
    //        {
    //            pre = node;
    //            node = node.next;
    //        }
    //        if(node==null)
    //        {
    //            return false;
    //        }
    //        if(pre==null)
    //        {
    //            head = head.next;
    //        }
    //        else
    //        {
    //            pre.next = node.next;
    //        }
    //        size--;
    //        return true;
    //    }

    //    public V Get(K key)
    //    {
    //        var node = head;

    //        while (node != null && !node.key.Equals(key))
    //        {
    //            node = node.next;
    //        }
    //        if(node==null)
    //        {
    //            return default(V);
    //        }
    //        return node.value;
    //    }

    //    public bool Contains(K key)
    //    {
    //        var node = head;

    //        while (node != null && !node.key.Equals(key))
    //        {
    //            node = node.next;
    //        }
    //        if(node==null)
    //        {
    //            return false;
    //        }
    //        return true;
    //    }
        
    //    public int Size()
    //    {
    //        return size;
    //    }
    //    private class Node
    //    {
    //        public K key;
    //        public V value;
    //        public Node next;

    //        public Node(K key, V value)
    //        {
    //            this.key = key;
    //            this.value = value;
    //            this.next = null;
    //        }
    //    }
    //}

    //public class MyDictionaryOfArray<K, V>
    //{ }

    //public class MyDictionaryOfBST<K, V>
    //{
    //    private TreeNode root;
    //    private int size;
    //    public MyDictionaryOfBST()
    //    {
    //        root = null;
    //        size = 0;
    //    }

    //    public void Add(K key, V value)
    //    {
    //        root = Add(root, key, value);
    //    }

    //    public void Add(K key, V value)
    //    {
    //        if (root == null)
    //        {
    //            root = new TreeNode(key, value);
    //            return;
    //        }
    //        var node = root;
    //        while (true)
    //        {
    //            if (key.CompareTo(node.key) < 0)
    //            {
    //                if (node.left == null)
    //                {
    //                    node.left = new TreeNode(key, value);
    //                    return;
    //                }
    //                node = node.left; 
    //            }
    //            else if (key.CompareTo(node.key) > 0)
    //            {
    //                if (node.right == null)
    //                {
    //                    node.right = new TreeNode(key, value);
    //                    return;
    //                }
    //                node = node.right;
    //            }
    //            else
    //            {
    //                node.value = value;
    //                return;
    //            }
    //        }
    //        return;
    //    }

    //    public void Delete(K key)
    //    {
    //        root = Delete(root, key);
    //    }
        

    //    public void DeleteMin()
    //    {
    //        root = DeleteMin(root);
    //    }
        

    //    public V Get(K key)
    //    { }

    //    public bool Contains(K key)
    //    { }

    //    public int Size()
    //    { }

    //    public bool Empty()
    //    { }

    //    //Ordered operations
    //    public K Max()
    //    { }

    //    public K Min()
    //    {
    //        var min = Min(root);
    //        if(min==null)
    //        {
    //            return default(K);
    //        }
    //        return min.key;
    //    }

    //    private TreeNode Delete(TreeNode node, K key)
    //    {
    //        if (node == null)
    //        {
    //            return null;
    //        }
    //        var cmp = key.CompareTo(node.key);
    //        if (cmp < 0)
    //        {
    //            node.left = Delete(node.left, key);
    //        }
    //        else if (cmp > 0)
    //        {
    //            node.right = Delete(node.right, key);
    //        }
    //        else
    //        {
    //            if (node.right == null)
    //            {
    //                return node.left;
    //            }
    //            var x = node;
    //            node = Min(x.right);
    //            node.left = x.left;
    //            node.right = DeleteMin(x.right);
    //        }
    //        return node;
    //    }
    //    private TreeNode DeleteMin(TreeNode node)
    //    {
    //        if (node == null)
    //        {
    //            return null;
    //        }
    //        if (node.left == null)
    //        {
    //            return node.right;
    //        }
    //        node.left = DeleteMin(node.left);
    //        return node;
    //    }
    //    private TreeNode Min(TreeNode node)
    //    {
    //        if(node==null)
    //        {
    //            return node;
    //        }
    //        var x = node;
    //        while(x.left!=null)
    //        {
    //            x = x.left;
    //        }
    //        return x;
    //    }

    //    private TreeNode Add(TreeNode node, K key, V value)
    //    {
    //        if (node == null)
    //        {
    //            return new TreeNode(key, value);
    //        }
    //        if (key.CompareTo(node.key) < 0)
    //        {
    //            node.left = Add(node.left, key, value);
    //        }
    //        else if (key.CompareTo(node.key) > 0)
    //        {
    //            node.right = Add(node.right, key, value);
    //        }
    //        else
    //        {
    //            node.value = value;
    //        }
    //        return node;
    //    }

    //    private class TreeNode
    //    {
    //        public K key;
    //        public V value;
    //        public TreeNode left;
    //        public TreeNode right;

    //        public TreeNode(K key, V value)
    //        {
    //            this.key = key;
    //            this.value = value;
    //        }
    //    }
    //}

    ///// <summary>
    /////  Separate chaining symbol table
    ///// </summary>
    ///// <typeparam name="K"></typeparam>
    ///// <typeparam name="V"></typeparam>
    //public class MyDictionnaryOfHashTable<K, V>
    //{
    //    private Node[] hashTable;
    //    private int M;

    //    public MyDictionnaryOfHashTable(int n)
    //    {
    //        hashTable = new Node[n];
    //        M = n;
    //    }

    //    public void Add(K key, V value)
    //    {
    //        var idx = HashFunction(key);
    //        var node = hashTable[idx];

    //        while (node != null && node.value.Equals(value))
    //        {
    //            node = node.next;
    //        }
    //        if (node == null)
    //        {
    //            var newNode = new Node(key, value);
    //            newNode.next = hashTable[idx];
    //            hashTable[idx] = newNode;
    //        }
    //        else
    //        {
    //            node.value = value;
    //        }
    //        return;

    //    }

    //    private int HashFunction(K key)
    //    {
    //        return key.GetHashCode() % M;
    //    }

    //    private class Node
    //    {
    //        public K key;
    //        public V value;
    //        public Node next;

    //        public Node(K key, V value)
    //        {
    //            this.key = key;
    //            this.value = value;
    //        }
    //    }
    //}

    ///// <summary>
    ///// linear probing
    ///// </summary>
    ///// <typeparam name="K"></typeparam>
    ///// <typeparam name="V"></typeparam>
    //public class MyDictionaryOfHashTable2<K, V>
    //{ 
    
    //}
}
