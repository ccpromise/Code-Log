var ListNode = function(val){
	this.val = val;
	this.next = next;
};

var addTwoNumbers = function(l1, l2) {
	var n1 = l1;
	var n2 = l2;
	var newHead = new ListNode(0);
	var ret = newHead;
	var c = 0;
	
	while(n1 !== null || n2 !== null)
	{
		var add1 = n1 === null ? 0 : n1.val;
		var add2 = n2 === null ? 0 : n2.val;
		var sum = add1 + add2 + c;
		ret.next = new ListNode(sum % 10);
		c = sum >= 10 ? 1 : 0;
		ret = ret.next;
		n1 = n1 === null ? n1 : n1.next;
		n2 = n2 === null ? n2 : n2.next;
	}
	if(c === 1)
	{
		ret.next = new ListNode(1);
	}
	return newHead.next;
};
