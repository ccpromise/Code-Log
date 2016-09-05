#include <iostream>
#include <queue>
using namespace std;

template<typename T>
class PriorityQueue {
private:
	vector<T> arr;
	std::function<int(T, T)> comparator;
	void swim(int i);
	void sink(int i);

public:
	PriorityQueue(std::function<int (T, T)> func);
	void push(T item);
	void pop();
	T front();
	int size();
};

template<typename T> PriorityQueue::PriorityQueue(std::function<int(T, T)> func)
{
	comparator = func;
}

template<typename T> void PriorityQueue::push(T item)
{
	arr.push_back(item);
	swim(arr.size() - 1);
}

template<typename T> void PriorityQueue::pop()
{
	if (arr.size() == 0)
	{
		throw exception();
	}
	swap(arr, 0, arr.size() - 1);
	sink(0);
	arr.pop_back();
}

template<typename T> T PriorityQueue::front()
{
	return arr[0];
}

template<typename T> int PriorityQueue::size()
{
	return arr.size();
}

template<typename T> void PriorityQueue::swim(int i)
{
	while (i > 0 && comparator(arr[i], arr[(i - 1) / 2)] > 0)
	{
		swap(arr, i, (i - 1) / 2);
		i = (i - 1) / 2;
	}
}

template<typename T> void PriorityQueue::sink(int i)
{
	while (2 * i + 1 < arr.size())
	{
		int minIdx = comparator(arr[i], arr[2 * i + 1]) > 0 ? i : 2 * i + 1;
		if (2 * i + 2 < arr.size())
		{
			minIdx = comparator(arr[minIdx], arr[2 * i + 2]) > 0 ? minIdx : 2 * i + 2;
		}
		if (minIdx == i)
		{
			break;
		}
		swap(arr, i, minIdx);
		i = minIdx;
	}
}