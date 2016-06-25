#include <string>
#include <algorithm>`
#include <queue>
#include <vector>
#include <set>
#include <map>
#include "DefaultClass.h"

using namespace std;

class Solution344
{
public:
	static string reverseString(string s)
	{
		int i = 0;
		int j = s.length - 1;

		while (j > i)
		{
			swap(s, i, j);
			i++;
			j--;
		}
		return s;
	}

private:
	static void swap(string &s, int i, int j)
	{
		char tmp = s[i];
		s[i] = s[j];
		s[j] = s[i];
	}
};

class Solution293
{
public:
	bool canWinNim(int n)
	{
		return n % 4 != 0;
	}
};

class Solution258
{
public:
	int addDigits(int num)
	{
		return (num - 1) % 9 + 1;
	}
};

class Solution104
{
public:
	int maxDepth(TreeNode* root)
	{
		if (!root)
		{
			return 0;
		}
		return 1 + max(maxDepth(root->left), maxDepth(root->right));
	}
};

class Solution226
{
public:
	TreeNode* invertTree(TreeNode* root)
	{
		if (root==nullptr)
		{
			return root;
		}
		queue<TreeNode*> q;
		q.push(root);

		while (q.size() != 0)
		{
			int size = q.size();

			for (int i = 0; i < size; i++)
			{
				TreeNode* node = q.front();
				q.pop();

				if (node->left!=nullptr)
				{
					q.push(node->left);
				}
				if (node->right!=nullptr)
				{
					q.push(node->right);
				}

				TreeNode* tmp = node->left;
				node->left = node->right;
				node->right = tmp;				
			}
		}
		return root;
	}
};

class Solution283
{
public:
	void moveZeros(vector<int>& nums)
	{
		int i = 0;
		int j = 0;

		while (j < nums.size())
		{
			if (nums[j] != 0)
			{
				nums[i++] = nums[j];
			}
			j++;
		}
		while (i < j)
		{
			nums[i++] = 0;
		}
	}
};

class Solution349
{
public:
	vector<int> intersection(vector<int>& nums1, vector<int>& nums2)
	{
		set<int>* s = new set<int>();
		vector<int> ret;
	
		for(auto n:nums1)
		{
			s->insert(n);
		}
		for (auto n: nums2)
		{
			if (s->count(n))
			{
				ret.push_back(n);
				s->erase(n);
			}
		}
		return ret;
	}
};

class Solution237
{
public:
	void deleteNode(ListNode* node)
	{
		if (node->next == nullptr)
		{
			node = nullptr;
			return;
		}
		node->val = node->next->val;
		node->next = node->next->next;
	}
};

class Solution100
{
public:
	bool isSameTree(TreeNode* p, TreeNode* q)
	{
		if (p == nullptr&&q == nullptr)
		{
			return true;
		}
		if (p == nullptr || q == nullptr)
		{
			return false;
		}
		queue<TreeNode*> q1;
		queue<TreeNode*> q2;
		q1.push(p);
		q2.push(q);

		while (q1.size() != 0 && q2.size() != 0)
		{
			TreeNode* node1 = q1.front();
			TreeNode* node2 = q2.front();
			q1.pop();
			q2.pop();

			if (node1->val != node2->val)
			{
				return false;
			}
			if (node1->left != nullptr)
			{
				q1.push(node1->left);
			}
			if (node2->left != nullptr)
			{
				q2.push(node2->left);
			}
			if (q1.size() != q2.size())
			{
				return false;
			}
			if (node1->right != nullptr)
			{
				q1.push(node1->right);
			}
			if (node2->right != nullptr)
			{
				q2.push(node2->right);
			}
		}
		return true;

	}
};

class Solution171
{
public:
	int titleToNumber(string s)
	{
		int ret = 0;
		int l = s.length();

		for (int i = 0; i < l; i++)
		{
			ret += pow(26, l - i - 1)*(s[i] - 'A' + 1);
		}
		return ret;
	}
};

class Solution242
{
public:
	bool isAnagram(string s, string t)
	{
		int count[26] = {0};

		for (auto c : s)
		{
			count[c - 'a']++;
		}
		for (auto c : t)
		{
			count[c - 'a']--;
		}
		for (auto i : count)
		{
			if (i != 0)
			{
				return false;
			}
		}
		return true;
	}
};

class Solution169
{
public:
	int majorityNumber(vector<int>& nums)
	{
		int max = nums[0];
		int count = 1;

		for (int i = 1; i < nums.size(); i++)
		{
			if (nums[i] != max)
			{
				count--;
			}
			else
			{
				count++;
			}
			if (count == 0)
			{
				max = nums[i];
				count = 1;
			}
		}
		return max;
	}
};

class Solution217
{
public:
	bool containsDuplicate(vector<int>& nums)
	{
		set<int> s;

		for (auto n : nums)
		{
			if (s.count(n) != 0)
			{
				return true;
			}
			s.insert(n);
		}
		return false;
	}
};

class Solution350
{
public:
	vector<int> interset(vector<int>& nums1, vector<int>& nums2)
	{
		map<int, int> dic;
		vector<int> ret;

		for (auto n : nums1)
		{
			if (dic.count(n) == 0)
			{
				dic.insert(std::pair<int, int>(n, 1));
			}
			else
			{
				dic[n]++;
			}
		}
		for (auto n : nums2)
		{
			if (dic.count(n) != 0 && dic[n] > 0)
			{
				ret.push_back(n);
				dic[n]--;
			}
		}
		return ret;
	}

	vector<int> intersect_ifordered(vector<int>& nums1, vector<int>& nums2)
	{
		vector<int> ret;
		int i = 0;
		int j = 0;
		int N = nums1.size();
		int M = nums2.size();

		while (i<N&&j<M)
		{
			while (i<N && j<M && nums1[i] != nums2[j])
			{
				if (nums1[i]<nums2[j])
				{
					i++;
				}
				else
				{
					j++;
				}
			}
			while (i < N&&j < M && nums1[i]==nums2[j])
			{
				ret.push_back(nums1[i]);
				i++;
				j++;
			}
		}
		return ret;
	}
};