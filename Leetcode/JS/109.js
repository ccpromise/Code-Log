var ListNode = function(var) {
	this.val = val;
	this.next = null;
};

var TreeNode = function(var) {
	this.val = val;
	this.left = null;
	this.right = null;
};

var sortedListToBST = function(head) {
	if(head === null)
	{
		return null;
	}
	if(head.next === null)
	{
	    return new TreeNode(head.val);
	}
	var pre = null;
	var s = head;
	var f = head;
	
	while(f !== null && f.next !== null)
	{
		pre = s;
		s = s.next;
		f = f.next.next;
	}
	pre.next = null;
	var root = new TreeNode(s.val);
	root.left = sortedListToBST(head);
	root.right = sortedListToBST(s.next);
	return root;	
};