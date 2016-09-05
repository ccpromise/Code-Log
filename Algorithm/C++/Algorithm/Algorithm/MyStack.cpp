#include <iostream.h>
#include <exception>
using namespace std;

// Implementation of MyStack using dynamic-sized array
template <typename T> 
class MyStack
{
private:
	T* arr;
	int amount, size;

public:
	MyStack();
	void push(T item);
	void pop();
	T top();
	int size();
};

template <typename T> MyStack::MyStack()
{
	arr = new T[2];
	amount = 2;
	size = 0;
}

template <typename T> void MyStack::push(T item)
{
	arr[size] = item;
	size++;
	if (size > amount / 2)
	{
		T* tmp = new T[amount * 2];
		for (int i = 0; i < size; i++)
		{
			tmp[i] = arr[i];
		}
		arr = tmp;
		amount *= 2;
		delete tmp;
	}
}

template <typename T> void MyStack::pop()
{
	if (size == 0)
	{
		throw exception();
	}
	size--;
	if (size < amount / 4)
	{
		T* tmp = new T[amount / 2];
		for (int i = 0; i < size; i++)
		{
			tmp[i] = arr[i];
		}
		arr = tmp;
		amount = amount / 2;
		delete tmp;
	}
}

template <typename T> T MyStack::top()
{
	if (size == 0)
	{
		throw exception();
	}
	return arr[size];
}

template <typename T> int MyStack::size()
{
	return size;
}