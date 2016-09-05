/**
 * Definition for a binary tree node.
 * function TreeNode(val) {
 *     this.val = val;
 *     this.left = this.right = null;
 * }
 */
/**
 * @param {TreeNode} root
 * @return {boolean}
 */
var isValidBST = function(root) {
    return helper(root)[0];
};

var helper = function(node){
    if(node===null)
    {
        return [true];
    }
    if(node.left===null && node.right === null)
    {
        return [true, node.val, node.val];
    }
    var left = helper(node.left);
    var right = helper(node.right);
    if(left[0]===false || right[0]===false)
    {
        return [false];
    }
    if(node.val <= (left[2]||Number.NEGATIVE_INFINITY) || node.val >= (right[1]||Number.POSITIVE_INFINITY))
    {
        return [false];
    }
    return [true, left[1]||node.val, right[2]||node.val];
};
