/**
 * Definition for singly-linked list.
 * function ListNode(val) {
 *     this.val = val;
 *     this.next = null;
 * }
 */
/**
 * @param {ListNode} head
 * @return {ListNode}
 */
var oddEvenList = function(head) {
    if(head === null)
    {
        return head;
    }
    var evenHead = head.next;
    var odd = head;
    var even = head.next;
    
    while(even !== null && even.next !== null)
    {
        odd.next = even.next;
        even.next = even.next.next;
        odd = odd.next;
        even = even.next;
    }
    odd.next = evenHead;
    return head;
};