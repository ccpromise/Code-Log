public int MaxPathSumFromNodeToNode(TreeNode root){
	if(root == null) return 0;
	var globalMax = Int32.MinValue; // TO CHECK
	Helper(root, ref globalMax);
	return globalMax;
}

// returns the maximum path ending with node.
private int Helper(TreeNode node, ref int globalMax) {
	var left = node.left != null ? Helper(node.left, ref globalMax) : 0;
	var right = node.right != null ? Helper(node.right, ref globalMax) : 0;
	var ret = node.val + Math.Max(Math.Max(left, right), 0);
	// update globalMax using the max path containing node.
	globalMax = Math.Max(globalMax, node.val + Math.Max(left, 0) + Math.Max(right, 0));
	return ret;
}