var ListNode = function(val) {
	this.val = val;
	this.next = null;
};

var insertionSort = function(head) {
	if (head === null || head.next === null)
	{
		return head;
	}
	var sorted = head;
	var l = head.next;
	sorted.next = null;
	
	while (l !== null)
	{
		var tmp = l.next;
		if(l.val <= sorted.val)
		{
			l.next = sorted;
			sorted = l;
			l = tmp;
		}
		else
		{
			var n = sorted;
			while(n.next != null && l.val > n.next.val)
			{
				n = n.next;
			}
			var t = n.next;
			n.next = l;
			l.next = t;
			l = tmp;
		}
	}
	return sorted;
};