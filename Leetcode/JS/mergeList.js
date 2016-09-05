var ListNode = function(val1, val2){
	this.first = val1;
	this.second = val2;
	this.next = null;
};

var merge = function(head, node) {
	if(head == null)
	{
		return node;
	}
	var newHead = new ListNode(NEGATIVE_INFINITY, NEGATIVE_INFINITY);
	newHead.next = head;
	var t = newHead;
	var lo = find(t, node.first); // lo satisfies: lo.next === null or node.first >= lo.val && node.first < lo.next.val
	var hi = find(lo, node.second);	
	var upper = Math.max(hi.second, node.second);
	
	if(node.first <= lo.second) 
	{
		lo.second = upper;
		lo.next = hi.next;
	}
	else
	{
		if (lo===hi)
		{
			var newNode = ListNode(node.first, node.second);
			var tmp = lo.next;
			lo.next = newNode;
			newNode.next = tmp;
		}
		else
		{
			hi.first = node.first;
			hi.second = upper;
			lo.next = hi;
		}
	}
	return newHead.next;
};

var find = function(node, val) {
	while (node.next!=null && !(val >= node.val && val < node.next.val))
	{
		node = node.next;
	}
	return node;
};