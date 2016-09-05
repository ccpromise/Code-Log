var ListNode = function(val) {
	this.val = val;
	this.next = null;
};

var rotateList = function(head, k) {
	if(head === null || k === 0)
	{
		return head;
	}
	var count = 1;
	var n = head;
	
	while(n.next !== null)
	{
		count += 1;
		n = n.next;
	}
	n.next = head;
	k = count - k % count;
	n = head;
	while(k > 1)
	{
		n = n.next;
		k -= 1;
	}
	var ret = n.next;
	n.next = null;
	return ret;
};