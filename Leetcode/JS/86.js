var ListNode = function(val) {
	this.val = val;
	this.next = null;
};

var partition = function(head, x) {
	var less = new ListNode(0);
	var eg = new ListNode(0);
	var l1 = less;
	var l2 = eg;
	var iter = head;
	
	while (iter !== null)
	{
		if(iter.val < x)
		{
			l1.next = iter;
			l1 = iter;
		}
		else
		{
			l2.next = iter;
			l2 = iter;
		}
		iter = iter.next;
	}
	l1.next = eg.next;
	l2.next = null;
	return less.next;
};