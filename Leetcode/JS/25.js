var ListNode = function(val) {
	this.val = val;
	this.next = null;
}

var reverseGroup = function(head, k) {
	if (k === 0 || k === 1)
	{
		return head;
	}
	var n = head;
	var count = 1;
	while(n.next !== null)
	{
		count += 1;
		n = n.next;
	}
	var loop = Math.floor(count / k);
	var fakeHead = new ListNode(0);
	fakeHead.next = head;
	var pre = fakeHead;
	n = head;
	
	while(loop > 0)
	{
		var h = n;
		var m = n;
		var i = 1;
		n = n.next;
		while(i < k)
		{
			var tmp = n.next;
			n.next = m;
			m = n;
			n = tmp;
			i += 1;
		}
		pre.next = m;
		h.next = n;
		pre = h;
		loop -= 1;
	}
	return fakeHead.next;
}