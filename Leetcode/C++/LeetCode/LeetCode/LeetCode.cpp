// LeetCode.cpp : Defines the entry point for the console application.
//

#include <string>
#include <iostream>

using namespace std;

int main()
{
	string s = "hello";
	cout << &s;
	Solution344::reverseString(s);
	cout << &s;

    return 0;
}
