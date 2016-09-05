var ListNode = function(val) {
	this.val = val;
	this.next = null;
};

var sortList = function(head) {
	if (head === null || head.next === null)
	{
		return head;
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
	var l1 = sortList(head);
	var l2 = sortList(s);
	var newHead = new ListNode(0);
	var iter = newHead;
	
	while(l1 !== null && l2 !== null)
	{
		if (l1.val < l2.val)
		{
			var tmp = l1.next;
			l1.next = null;
			iter.next = l1;
			iter = l1;
			l1 = tmp;
		}
		else 
		{
			var tmp = l2.next;
			l2.next = null;
			iter.next = l2;
			iter = l2;
			l2 = tmp;
		}
	}
	while (l1 !== null)
	{
		iter.next = l1;
	}
	while (l2 !== null)
	{
		iter.next = l2;
	}
	return newHead.next;
}