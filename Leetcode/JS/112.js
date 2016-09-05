// JavaScript source code

var hasPathSum = function (root, sum) {
    if(root===null)
    {
        return false;
    }
    return dfs(root, sum);
};

var dfs = function (node, sum) {
    if(node.left === null && node.right === null)
    {
        return node.val === sum;
    }
    if(node.left!==null)
    {
        if(dfs(node.left, sum-node.val))
        {
            return true;
        }
    }
    if (node.right != null)
    {
        return dfs(node.right, sum - node.val);
    }
    return false;
};