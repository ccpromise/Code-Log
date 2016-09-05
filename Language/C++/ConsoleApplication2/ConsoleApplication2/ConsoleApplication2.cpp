// ConsoleApplication2.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
using namespace std;
#include <string>
#include <vector>
#include <map>
#include <algorithm>

vector<vector<int>> fourSum(vector<int>& nums, int target)
{
	sort(nums.begin(), nums.end());
	map<int, vector<int>> dic;
	vector<int> idx;
	vector<vector<int>> ret;

	helper(nums, 0, 0, idx, dic);
	for (int i = 0; i < nums.size(); i++)
	{
		if (dic.find(target - nums[i]) != dic.end())
		{
			vector<int> r = dic[target - nums[i]];
			if (i > r[0] && i > r[1] && i > r[2])
			{
				vector<int> tmp;
				tmp.push_back(nums[r[0]]);
				tmp.push_back(nums[r[1]]);
				tmp.push_back(nums[r[2]]);
				tmp.push_back(nums[i]);
				ret.push_back(tmp);
			}
		}
	}
	return ret;
}

void helper(vector<int>& nums, int begin, int sum, vector<int>& idx, map<int, vector<int>>& dic)
{
	if (idx.size() == 3)
	{
		dic.insert(pair<int, vector<int>>(sum, idx));
		return;
	}
	for (int i = begin; i < nums.size(); i++)
	{
		if (i == begin || nums[i] != nums[i - 1])
		{
			idx.push_back(i);
			helper(nums, i + 1, sum + nums[i], idx, dic);
			idx.pop_back();
		}
	}
}

int main()
{
	vector<int> nums{ 1, 0, -1, 0, -2, 2 };
	vector<vector<int>> a = fourSum(nums, 0);


}

