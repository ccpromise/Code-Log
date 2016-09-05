using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Source_Code.Gragh
{
    public class BST
    {
        private class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x)
            {
                val = x;
                left = null;
                right = null;
            }
        }

        private TreeNode root;
        public BST()
        {
            root = null;
        }

       // public void Insert(int val)
       // {
       //     if(root == null)
       //     {
       //         root = new TreeNode(val);
       //         return;
       //     }
       //     var node = root;
       //     while(node != null)
       //     {
       //         if(node.val < val)
       //         {
       //             if(node.left == null)
       //             {
       //                 node.left = new TreeNode(val);
       //                 return;
       //             }
       //             node = node.left;
       //         }
       //         else
       //         {
       //             if(node.right == null)
       //             {
       //                 node.right = new TreeNode(val);
       //                 return;
       //             }
       //             node = node.right;
       //         }
       //     }
       //} 

        public void Insert(int val)
        {
            root = InsertHelper(root, val);
        }

        public void Remove(int val)
        {
            root = RemoveHelper(root, val);
        }

        // search a val in a range [lower, upper]
        public bool Search(int lower, int upper)
        {
            var node = root;
            while(node != null)
            {
                if(node.val >= lower && node.val <= upper)
                {
                    return true;
                }
                if(node.val < lower)
                {
                    node = node.right;
                }
                else
                {
                    node = node.left;
                }
            }
            return false;
        }

        private TreeNode InsertHelper(TreeNode root, int val)
        {
            if(root == null)
            {
                return new TreeNode(val);
            }
            if (val < root.val)
                root.left = InsertHelper(root.left, val);
            else
                root.right = InsertHelper(root.right, val);
            return root;
        }

        private TreeNode RemoveHelper(TreeNode root, int val)
        {
            if(root == null)
            {
                return null;
            }
            if(root.val == val)
            {
                if(root.left == null)
                {
                    root = root.right;
                    return root;
                }
                else if(root.right == null)
                {
                    root = root.left;
                    return root;
                }
                else
                {
                    TreeNode node = root.right;
                    while(node.left != null)
                    {
                        node = node.left;
                    }
                    root.val = node.val;
                    root.right = RemoveHelper(root.right, node.val);
                }
            }
            else if(root.val <val)
            {
                root.right = RemoveHelper(root.right, val);
            }
            else
            {
                root.left = RemoveHelper(root.left, val);
            }
            return root;
        }
    }
}
