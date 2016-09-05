var ListNode = function(val) {
	this.val = val;
	this.next = null;
};

var mergeKLists = function(lists) {
	var fakeHead = new ListNode(0);
	var iter = fakeHead;
	var flag = true;
	var N = lists.length;
	
	while(flag)
	{
		flag = false;
		var min = POSITIVE_INFINITY;
		var minIdx = 0;
		for(var i = 0; i < N; i+=1)
		{
			if(lists[i] != null && lists[i].val < min)
			{
				min = lists[i].val;
				minIdx = i;
				flag = true;
			}
		}
		if (flag == true)
		{
			iter.next = lists[minIdx];
			lists[minIdx] = lists[minIdx].next;	
			iter = iter.next;
		}		
	}
	return fakeHead.next;	
};