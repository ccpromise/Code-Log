class ListNode:
	def __init(self, val1, val2):
		self.first = val1
		self.second = val2
		self.next = None

class solution:
	# head: ListNode
	# node: ListNode
	def merge(self, head, node):
		t = head
		while t != None and t.next != None:
			