// ConsoleApplication2.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
using namespace std;

class Box
{
public:
	Box()
	{
		cout<<"hello"<<endl;
	}
};

int _tmain(int argc, _TCHAR* argv[])
{
	Box * p  = new Box[4];
	return 0;
}

