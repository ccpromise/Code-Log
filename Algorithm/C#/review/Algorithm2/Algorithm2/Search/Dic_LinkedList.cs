using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm2.Dictionary
{
    /// <summary>
    /// APIs in dictionary include:
    /// insert getValue delete contains size
    /// 
    /// Encapsulate key-value pairs in a private class.
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class Dic_LinkedList<K, V>
    {
        private class Node
        {
            public K key;
            public V val;
            public Node next;
            public Node(K x, V y)
            {
                key = x;
                val = y;
                next = null;
            }
        }

        private Node head;
        private int size;
        public Dic_LinkedList()
        {
            head = null;
            size = 0;
        }

        // if key already exsits, value will be updated to new val.
        public void Insert(K key, V val)
        {
            var node = Search(key);
            if(node == null)
            {
                var newNode = new Node(key, val);
                newNode.next = head;
                head = newNode;
                size++;
                return;
            }
            node.val = val;
        }

        public V this[K key]
        {
            get
            {
                var node = Search(key);
                if(node==null)
                {
                    throw new Exception();
                }
                return node.val;
            }

            set
            {
                var node = Search(key);
                if (node == null)
                {
                    throw new Exception();
                }
                node.val = value;
            }
        }

        public void Delete(K key)
        {
            size--;
        }

        public bool ContainsKey(K key)
        {
            return Search(key) != null;
        }

        public int Size()
        {
            return size;
        }

        private Node Search(K key)
        {
            var node = head;
            while (node != null && !node.key.Equals(key))
            {
                node = node.next;
            }
            return node;
        }
    }
}
