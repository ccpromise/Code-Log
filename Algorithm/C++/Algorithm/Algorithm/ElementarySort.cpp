#include <iostream>
using namespace std;

class ElementarySort
{
private:
	int* arr;
	int len;
	void swap(int i, int j);

public:
	ElementarySort(int* array, int size);
	void BubbleSort();
	void InsertSort();
	void SelectionSort();
};

ElementarySort::ElementarySort(int* array, int size)
	:arr(array), len(size)
{}

void ElementarySort::BubbleSort()
{

}

void ElementarySort::InsertSort()
{

}

void ElementarySort::SelectionSort()
{

}

