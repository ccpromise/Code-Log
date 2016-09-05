using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm2.Search
{
    public class Dic_BST<K, V>
    {
        /// <summary>
        /// Binary search in BST:
        /// insert node at the leaf.
        /// </summary>
        private class TreeNode
        {
            public K key;
            public V val;
            public TreeNode left;
            public TreeNode right;
        }

        private TreeNode root;

        public Dic_BST()
        { }

        public void Insert(K key, V val)
        { }
    }
}
