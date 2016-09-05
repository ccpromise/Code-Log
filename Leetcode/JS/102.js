/**
 * Definition for a binary tree node.
 * function TreeNode(val) {
 *     this.val = val;
 *     this.left = this.right = null;
 * }
 */
/**
 * @param {TreeNode} root
 * @return {number[][]}
 */

var levelOrder = function (root) {
    var ret = [];
    if (root === null) {
        return ret;
    }
    dfs(root, 0, ret);
    return ret;
};

var dfs = function (node, level, ret) {
    if (ret.length == level) {
        ret.push([]);
    }
    ret[level].push(node.val);
    if (node.left !== null) {
        dfs(node.left, level + 1, ret);
    }
    if (node.right !== null) {
        dfs(node.right, level + 1, ret);
    }
};