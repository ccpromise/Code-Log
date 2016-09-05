/**
 * Definition for singly-linked list.
 * function ListNode(val) {
 *     this.val = val;
 *     this.next = null;
 * }
 */
/**
 * @param {ListNode} l1
 * @param {ListNode} l2
 * @return {ListNode}
 */
var addTwoNumbers = function(l1, l2) {
    var s1 = "";
    var s2 = "";
    
    while(l1!==null)
    {
        s1 += l1.val;
        l1 = l1.next;
    }
    while(l2!==null)
    {
        s2 += l2.val;
        l2 = l2.next;
    }
    var tmp = (Number(s1[0])+Number(s2[0]));
    var ret = new ListNode(tmp%10);
    var node = ret;
    var f = Math.floor(tmp/10);
    var l  =Math.max(s1.length, s2.length);
    var i = 1;
    while(i<l)
    {
        var a = i < s1.length ? Number(s1[i]):0;
        var b = i < s2.length?Number(s2[i]):0;
        var sum = a+b+f;
        node.next = new ListNode(sum%10);
        node = node.next;
        f = Math.floor(sum/10);
        i+=1;
    }
    if(f!==0)
    {
        node.next = new ListNode(f);
    }
    return ret;
    
};

/**
 * Definition for singly-linked list.
 * function ListNode(val) {
 *     this.val = val;
 *     this.next = null;
 * }
 */
/**
 * @param {ListNode} l1
 * @param {ListNode} l2
 * @return {ListNode}
 */
var addTwoNumbers = function(l1, l2) {
    var f = 0;
    var t1 = l1;
    var t2 = l2;
    var newHead = new ListNode(0);
    var node = newHead;
    
    while(t1!==null || t2!==null)
    {
        var a = t1===null?0:t1.val;
        var b= t2===null?0:t2.val;
        var sum = a+b+f;
        node.next = new ListNode(sum%10);
        node = node.next;
        f = Math.floor(sum/10);
        t1 = t1===null?t1:t1.next;
        t2 = t2===null?t2:t2.next;
    }
    if(f!==0)
    {
        node.next = new ListNode(f);
    }
    return newHead.next;
};