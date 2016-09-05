var ListNode = function(val) {
	this.val = val;
	this.next = next;
};

var removeDuplicate = function(head) {
	    if (head === null || head.next === null)
	{
		return head;
	}
	var newHead = new ListNode(0);
	newHead.next = head;
	var i = newHead;
	var j = head;
	
	while (j !== null && j.next !== null)
	{
		if(j.val !== j.next.val)
		{
			i = j;
			j = j.next;
			continue;
		}
		while(j.next !== null && j.val === j.next.val)
		{
			j = j.next;
		}
		i.next = j.next;
		j = j.next;
	}
	return newHead.next;
};
};