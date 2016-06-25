using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SICPPractise.Algorithm.Internal;

namespace SICPPractise.Algorithm
{
    public static class Temp
    {
        static List<IList<int>> traversal;
        
        public static IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }
            LevelOrderBottomIter(root, 0);
            traversal.Reverse();
            return traversal;
        }

        private static void LevelOrderBottomIter(TreeNode node, int index)
        {
            if (index == traversal.Count())
            {
                traversal.Add(new List<int>());
            }
            traversal[index].Add(node.val);
            if (node.left != null)
            {
                LevelOrderBottomIter(node.left, index + 1);
            }
            if (node.right != null)
            {
                LevelOrderBottomIter(node.right, index + 1);
            }
        }

        public static int MinDepthOfTree(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            var tree = new Stack<Tuple<TreeNode, int>>();
            tree.Push(new Tuple<TreeNode, int>(root, 1));

            while (tree.Count() != 0)
            {
                var item = tree.Pop();
                var node = item.Item1;
                var level = item.Item2;

                if (node.left == null && node.right == null)
                {
                    return level;
                }
                if (node.left != null)
                {
                    tree.Push(new Tuple<TreeNode, int>(node.left, level + 1));
                }
                if (node.right != null)
                {
                    tree.Push(new Tuple<TreeNode, int>(node.right, level + 1));
                }
            }
            return 0;
        }

        public static int TitleToNumber(string s)
        {
            var ret = 0;
            var k = 1;
            for (var i = s.Length - 1; i >= 0; i--)
            {
                ret += (s[i] - 'A' + 1) * k;
                k *= 26;
            }
            return ret;
        }
    }
}
