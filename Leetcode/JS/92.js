/**
 * Definition for singly-linked list.
 * function ListNode(val) {
 *     this.val = val;
 *     this.next = null;
 * }
 */
/**
 * @param {ListNode} head
 * @param {number} m
 * @param {number} n
 * @return {ListNode}
 */
var reverseBetween = function(head, m, n) {
    if (m == n)
    {
        return head;
    }
    var preHead = new ListNode(0);
    preHead.next = head;
    
    var pre = preHead;
    var node = head;
    while(m>1)
    {
        pre = node;
        node = node.next;
        m -= 1;
        n -= 1;
    }
    s = node;
    node = node.next;
    while(n>1)
    {
        var tmp = node.next;
        node.next = s;
        s = node;
        node = tmp;
        n -= 1;
    }
    pre.next.next = node;
    pre.next = s;
    return preHead.next;
};

