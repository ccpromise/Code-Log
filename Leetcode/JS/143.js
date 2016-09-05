var ListNode = function(val) {
	this.val = val;
	this.next = next;
};

var reorder = function(head) {
	if(head === null || head.next === null)
	{
		return;
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
	pre = null;
	while(s != null)
	{
		var tmp = s.next;
		s.next = pre;
		pre = s;
		s = tmp;
	}
	var l1 = head;
	var l2 = pre;
	while(l1 !== null && l2 !== null)
	{
		var tmp1 = l1.next;
		var tmp2 = l2.next;
		l1.next = l2;
		l2.next = tmp1;
		l1 = tmp1;
		l2 = tmp2;
	}
};