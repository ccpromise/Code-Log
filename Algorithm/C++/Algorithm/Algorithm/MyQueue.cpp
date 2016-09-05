#include <exception>
using namespace std;

template <typename T>
class ListNode
{
public:
	T val;
	ListNode<T>* next;
	ListNode(T val)
	{
		this.val = val;
		this.next = nullptr;
	}
};

template <typename T>
class MyQueue
{
private:
	ListNode<T>* head, *tail;
	int size;

public:
	MyQueue();
	void push(T item);
	void pop();
	T front();
	int size();
};

template <typename T> MyQueue::MyQueue()
	:head(nullptr), tail(nullptr), size(0)
{}

template <typename T> void MyQueue::push(T item)
{
	ListNode<T>* node = new ListNode<T>(item);
	if (size == 0)
	{
		head = node;
		tail = node;
	}
	else
	{
		tail->next = node;
		tail = node;
	}
	size++;
}

template <typename T> void MyQueue::pop()
{
	if (size == 0)
	{
		throw exception();
	}
	if (size == 1)
	{
		head = nullptr;
		tail = nullptr;
	}
	else
	{
		head = head->next;
	}
	size--;
}

template <typename T> T MyQueue::front()
{
	return head->val;
}

template <typename T> int MyQueue::size()
{
	return size;
}