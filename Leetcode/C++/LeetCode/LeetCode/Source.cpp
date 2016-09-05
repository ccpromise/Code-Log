#include <string>
#include <algorithm>`
#include <queue>
#include <vector>
#include <set>
#include <map>
#include <stack>
#include <unordered_set>
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

class Solution206
{
public:
	ListNode* reverseList(ListNode* head)
	{
		if (head == nullptr || head->next == nullptr)
		{
			return head;
		}
		ListNode* newHead = reverseList(head->next);
		head->next->next = head;
		head->next = nullptr;
		return newHead;
	}

	ListNode* reverseList_Iterative(ListNode* head)
	{
		if (head == nullptr || head->next == nullptr)
		{
			return head;
		}
		ListNode* pre = nullptr;
		ListNode* next = head;

		while (next != nullptr)
		{
			ListNode* tmp = next->next;
			next->next = pre;
			pre = next;
			next = tmp;
		}
		return pre;
	}
};

class Solution235
{
public:
	TreeNode* lowestCommonAncestor(TreeNode* root, TreeNode* p, TreeNode* q)
	{
		if (root == nullptr)
		{
			return root;
		}
		int tmp1 = root->val - p->val;
		int tmp2 = root->val - q->val;
		if (tmp1*tmp2 <= 0)
		{
			return root;
		}
		if (tmp1 > 0)
		{
			return lowestCommonAncestor(root->left, p, q);
		}
		return lowestCommonAncestor(root->right, p, q);
	}

	TreeNode* lowestCommonAncestor_Iter(TreeNode* root, TreeNode* p, TreeNode* q)
	{
		TreeNode* node = root;

		while (node != nullptr)
		{
			int tmp1 = node->val - p->val;
			int tmp2 = node->val - p->val;

			if (tmp1*tmp2 <= 0)
			{
				return node;
			}
			if (tmp1 > 0)
			{
				node = node->left;
			}
			else
			{
				node = node->right;
			}
		}
	}
};

class Solution236
{
public:
	TreeNode* lowestCommonAncestor(TreeNode* root, TreeNode* p, TreeNode* q)
	{
		
		if (root == nullptr)
		{
			return nullptr;
		}
		if (root == p || root == q)
		{
			return root;
		}
		TreeNode* tmp1 = lowestCommonAncestor(root->left, p, q);
		TreeNode* tmp2 = lowestCommonAncestor(root->right, p, q);
		if (tmp1 != nullptr && tmp2 != nullptr)
		{
			return root;
		}
		return tmp1 != nullptr ? tmp1 : tmp2;

	}
};

class Solution191
{
public:
	int hammingWeight(uint32_t n)
	{
		int ret = 0;

		while (n != 0)
		{
			ret += n % 2;
			n = n / 2;
		}
		return ret;
	}
};

class Solution231
{
public:
	bool isPowOfTwo(int n)
	{
		return n > 0 && (n & (n - 1) == 0);
	}
};

class Solution263
{
public:
	bool isUglyNumber(int num)
	{
		if (num <= 0)
		{
			return false;
		}
		while (num % 2 == 0)
		{
			num = num / 2;
		}
		while (num % 3 == 0)
		{
			num = num / 3;
		}
		while (num % 5 == 0)
		{
			num = num / 5;
		}
		return num == 1;
	}
};

class Solution202
{
public:
	bool isHappy(int n)
	{
		set<int> s;

		while (s.count(n) == 0)
		{
			int tmp = 0;
			s.insert(n);
			while (n > 0)
			{
				tmp += pow(n % 10, 2);
				n = n / 10;
			}
			n = tmp;
		}
		return n == 1;
	}
};

class Solution83
{
public:
	ListNode* deleteDuplicates(ListNode* head)
	{
		if (head == nullptr || head->next == nullptr)
		{
			return head;
		}
		ListNode* node = head;
		ListNode* next = head->next;

		while (next != nullptr)
		{
			while (next != nullptr && next->val == node->val)
			{
				next = next->next;
			}
			node->next = next;
			node = next;
		}
		return head;
	}

	ListNode* deleteDuplicates_recusice(ListNode* head)
	{
		if (head == nullptr || head->next == nullptr)
		{
			return head;
		}
		if (head->val == head->next->val)
		{
			head = deleteDuplicates_recusice(head->next);
		}
		else
		{
			head->next = deleteDuplicates_recusice(head->next);
		}
		return head;
	}
};

class Solution121
{
public:
	int maxProfit(vector<int>& prices)
	{
		int N = prices.size();
		int lowest = INT32_MAX;
		int ret = 0;

		for (int i = 1; i < N; i++)
		{
			lowest = min(lowest, prices[i - 1]);
			ret = max(ret, prices[i] - lowest);
		}
		return ret;
	}
};

class Solution21
{
public:
	ListNode* mergeTwoLists(ListNode* l1, ListNode* l2)
	{
		ListNode* newhead = new ListNode(0);
		ListNode* l = newhead;

		while (l1 != nullptr && l2 != nullptr)
		{
			if (l1->val < l2->val)
			{
				l->next = l1;
				l1 = l1->next;
			}
			else
			{
				l->next = l2;
				l2 = l2->next;
			}
			l = l->next;
		}
		while (l1 != nullptr)
		{
			l->next = l1;
			l1 = l1->next;
			l = l->next;
		}
		while (l2 != nullptr)
		{
			l->next = l2;
			l2 = l2->next;
			l = l->next;
		}
		return newhead->next;
	}
};

class Solution345
{
public:
	string reverseVowels(string s)
	{
		int i = 0;
		int j = s.length() - 1;

		while (i < j)
		{
			while (i < j && !isVowel(s[i]))
			{
				i++;
			}
			while (j > i && !isVowel(s[j]))
			{
				j--;
			}
			Swap(s, i, j);
			i++;
			j--;
		}
	}

private:
	bool isVowel(char c)
	{
		char vowels[] = { 'a','A','o','O','e','E','u','U','i','I' };

		for (auto x : vowels)
		{
			if (x == c)
			{
				return true;
			}
		}
		return false;
	}

	void Swap(string& s, int i, int j)
	{
		char tmp = s[i];
		s[i] = s[j];
		s[j] = tmp;
	}
};

class Solution24
{
public:
	ListNode* swapPairs(ListNode* head)
	{
		if (head == nullptr || head->next == nullptr)
		{
			return head;
		}
		ListNode* tmp1 = head;
		ListNode* tmp2 = head->next;
		ListNode* ret = head->next;

		while(tmp2!=nullptr && tmp2->next!=nullptr && tmp2->next->next!=nullptr)
		{
			ListNode* tmp3 = tmp2->next;
			tmp2->next = tmp1;
			tmp1->next = tmp3->next;
			tmp1 = tmp3;
			tmp2 = tmp3->next;
		}
		tmp1->next = tmp2->next;
		tmp2->next = tmp1;
		return ret;
	}
};

class Solution198
{
public:
	int rob(vector<int>& nums)
	{
		int N = nums.size();

		if (N == 0)
		{
			return 0;
		}
		int rob = nums[0];
		int notRob = 0;

		for (int i = 1; i < N; i++)
		{
			int tmp = rob;
			rob = notRob + nums[i];
			notRob = max(tmp, notRob);
		}
		return max(rob, notRob);
	}
};

class Solution107
{
public:
	vector<vector<int>> levelOrderBottom_dfs(TreeNode* root)
	{
		vector<vector<int>> ret;

		if (root != nullptr)
		{
			dfs(root, 0, ret);
		}
		vector<vector<int>> reverse;
		for (int i = ret.size() - 1; i >= 0; i--)
		{
			reverse.push_back(ret[i]);
		}
		return reverse;
	}

	vector<vector<int>> levelOrderBottom_bfs(TreeNode* root)
	{
		vector<vector<int>> ret;

		if (root == nullptr)
		{
			return ret;
		}
		queue<TreeNode*> q;
		q.push(root);

		while (q.size() != 0)
		{
			int n = q.size();
			ret.push_back(vector<int>());

			for (int i = 0; i < n; i++)
			{
				TreeNode* node = q.front();
				q.pop();
				ret.back().push_back(node->val);
				if (node->left != nullptr)
				{
					q.push(node->left);
				}
				if (node->right != nullptr)
				{
					q.push(node->right);
				}
			}
		}
		return ret;
	}

private:
	void dfs(TreeNode* root, int level, vector<vector<int>>& ret)
	{
		if (ret.size() == level)
		{
			ret.push_back(vector<int>());
		}
		ret[level].push_back(root->val);
		if (root->left != nullptr)
		{
			dfs(root->left, level + 1, ret);
		}
		if (root->right != nullptr)
		{
			dfs(root->right, level + 1, ret);
		}
	}
};

class Solution27
{
public:
	int removeElement(vector<int>& nums, int val)
	{
		int i = 0;
		int j = 0;
		int N = nums.size();

		while (j < N)
		{
			if (nums[j] != val)
			{
				nums[i++] = nums[j];
			}
			j++;
		}
		return i;
	}
};

class Solution342
{
public:
	bool isPowerOfFour(int num)
	{
		return num > 0 && (num & (num - 1)) == 0 && (num - 1) % 3 == 0;
	}
};

class Solution110
{
public:
	bool isBalanced(TreeNode* root)
	{
		return dfs(root) != -1;
	}
	
private:
	int dfs(TreeNode* root)
	{
		if (root == nullptr)
		{
			return 0;
		}

		int left = dfs(root->left);
		int right = dfs(root->right);

		if (left == -1 || right == -1 || abs(double(left-right)) >= 2)
		{
			return -1;
		}
		return max(left, right) + 1;
	}
};

class Solution101
{
public:
	bool isSymmetric(TreeNode* root)
	{
		return root == nullptr || helper(root->left, root->right);
	}

private:
	bool helper(TreeNode* root1, TreeNode* root2)
	{
		if (root1 == nullptr&&root2 == nullptr)
		{
			return true;
		}
		if (root1 == nullptr || root2 == nullptr)
		{
			return false;
		}
		return root1->val == root2->val && helper(root1->left, root2->right) && helper(root1->right, root2->left);
	}
};

class Solution338
{
public:
	vector<int> countBits(int num)
	{
		vector<int> ret;

		ret.push_back(0);
		for (int i = 1; i <= num; i++)
		{
			ret.push_back(ret[i / 2] + i % 2);
		}
		return ret;
	}
};

class Solution
{
public:
	vector<int> singleNumber(vector<int>& nums)
	{
		int tmp1 = 0;
		int tmp2 = 0;
		int bit = 1;

		for (auto n: nums)
		{
			tmp1 ^= n;
		}
		while ((tmp1 & bit) == 0)
		{
			bit *= 2;
		}
		tmp1 = 0;
		tmp2 = 0;
		for (auto n : nums)
		{
			if ((n&bit) != 0)
			{
				tmp1 ^= n;
			}
			else
			{
				tmp2 ^= n;
			}
		}
		return{ tmp1, tmp2 };
	}
};


class Solution347
{
public:
	vector<int> topKFrequent(vector<int>& nums, int k)
	{
		map<int, int> m;
		priority_queue<pair<int, int>, vector<pair<int, int>>, PairOrder> pq;
		vector<int> ret;

		for (auto n : nums)
		{
			if (m.find(n)==m.end())
			{
				m.insert(pair<int,int>(n, 1));
			}
			else
			{
				m[n]++;
			}
		}

		int n = m.size();

		for (auto it = m.begin(); it != m.end(); it++)
		{
			pq.push(*it);
			if (pq.size() > n - k)
			{
				ret.push_back(pq.top().first);
				pq.pop();
			}
		}
		return ret;
	}

private:
	class PairOrder
	{
	public:
		bool operator() (const pair<int, int>& x, const pair<int, int>& y) const
		{
			return x.second < y.second;
		}
	};
};

class Solution357
{
public:
	int countNumberWithUniqueDigits1(int n)
	{
		if (n == 0)
		{
			return 1;
		}
		if (n == 1)
		{
			return 10;
		}
		int ret = 91;
		int a = 81;

		for (int i = 3; i <= n && i <= 10; i++)
		{
			a *= (11 - i);
			ret += a;
		}
		return ret;
	}

	int countNumberWithUniqueDigits2(int n)
	{
		if (n == 0)
		{
			return 1;
		}

		int count = 0;
		bool used[10] = { false };

		for (int i = 1; i < 10; i++)
		{
			if (used[i] == false)
			{
				used[i] = true;
				count += Helper(i, 1, n, used);
				used[i] = false;
			}
		}
		return count;
	}
private:
	int Helper(int cur, int bits, int n, bool used[])
	{	
		if (bits == n)
		{
			return 1;
		}
		int count = 1;
		bits++;
		for (int i = 0; i < 10; i++)
		{
			if (used[i] == false)
			{
				used[i] = true;
				count += Helper(cur * 10 + i, bits, n, used);
				used[i] = false;
			}
		}
		return count;
	}
};

class Solution343
{
public:
	int integerBreak(int n)
	{
		if (n == 2)
		{
			return 1;
		}
		int ret = 1;
		for (int i = 1; i < n; i++)
		{
			ret = max(ret, max(integerBreak(n - i), n - i)*i);
		}
		return ret;
	}

	int integerBreak2(int n)
	{
		int* ret = new int[n+1];
		ret[1] = 1;

		for (int i = 2; i <= n; i++)
		{
			ret[i] = 1;
			for (int j = 1; j < i; j++)
			{
				ret[i] = max(ret[i], j*max(ret[i - j], i - j));
			}
		}
		return ret[n];
	}
};

class Solution114
{
public:
	vector<int> preorderTraversal(TreeNode* root)
	{
		TreeNode* node = root;
		stack<TreeNode*> s;
		vector<int> ret;
		
		while (node != nullptr)
		{
			ret.push_back(node->val);
			if (node->right != nullptr)
			{
				s.push(node->right);
			}
			if (node->left != nullptr)
			{
				node = node->left;
			}
			else if(s.size()!=0)
			{
				node = s.top();
				s.pop();
			}
			else
			{
				node = nullptr;
			}
		}
		return ret;
	}
};

class Solution94
{
public:
	vector<int> inorderTraversal(TreeNode* root)
	{
		stack<TreeNode*> s;
		TreeNode* node = root;
		vector<int> ret;

		while (node != nullptr)
		{
			s.push(node);
			node = node->left;
		}
		while (s.size() != 0)
		{
			node = s.top();
			s.pop();
			ret.push_back(node->val);

			node = node->right;
			while (node != nullptr)
			{
				s.push(node);
				node = node->left;
			}
		}
		return ret;
	}
};

class Solution328
{
public:
	ListNode* oddEvenList(ListNode* head)
	{
		if (head == nullptr || head->next == nullptr || head->next->next == nullptr)
		{
			return head;
		}
		ListNode* oddHead = head;
		ListNode* evenHead = head->next;
		ListNode* odd = oddHead;
		ListNode* even = evenHead;

		while(even!=nullptr&&even->next!=nullptr)
		{
			odd->next = even->next;
			even->next = even->next->next;
			odd = odd->next;
			even = even->next;
		}
		odd->next = evenHead;
		return oddHead;
	}
};

class Solution337
{
public:
	int rob(TreeNode* root)
	{
		vector<int> ret = Helper(root);

		return max(ret[0], ret[1]);
	}

private:
	vector<int> Helper(TreeNode* node)
	{
		vector<int> ret;

		ret.push_back(0);
		ret.push_back(0);
		if (node == nullptr)
		{
			return ret;
		}

		vector<int> left = Helper(node->left);
		vector<int> right = Helper(node->right);

		ret[0] = max(left[0], left[1]) + max(right[0], right[1]);
		ret[1] = node->val + left[0] + right[0];
		return ret;
	}
};

class Solution22
{
public:
	vector<string> generateParenthess(int n)
	{
		vector<string> ret;

		Helper(n, 0, "", ret);
		return ret;
	}
private:
	void Helper(int left, int right, string s, vector<string> ret)
	{
		if (left == 0 && right == 0)
		{
			ret.push_back(s);
			return;
		}
		if (left > 0)
		{
			Helper(left - 1, right + 1, s + "(", ret);
		}
		if (right > 0)
		{
			Helper(left, right - 1, s + ")", ret);
		}
	}
};

class Solution216
{
public:
	vector<vector<int>> combinationSum(int k, int n)
	{
		vector<vector<int>> ret;
		vector<int> combination;
		Helper(k, n, combination, ret);
		return ret;
	}

private:
	void Helper(int k, int n, vector<int> combination, vector<vector<int>>& ret)
	{
		if (k == 0 && n == 0)
		{
			ret.push_back(combination);
		}
		if (k > 0)
		{
			for (int i = combination.size() == 0 ? 1 : combination.back() + 1; i <= 9; i++)
			{
				if (i <= n)
				{
					combination.push_back(i);
					Helper(k - 1, n - i, combination, ret);
					combination.pop_back();
				}
			}
		}
	}
};

class Solution62
{
public:
	int uniquePaths_DP(int m, int n)
	{
		if (m == 1 || n == 1)
		{
			return 1;
		}
		return uniquePaths_DP(m - 1, n) + uniquePaths_DP(m, n - 1);
	}

	int uniquePaths_BT(int m, int n)
	{
		int count = 0;
		Helper(m, n, count);
		return count;
	}

	int uniquePaths_Iter(int m, int n)
	{
		vector<int> count(m, 1);

		for (int i = 0; i < m; i++)
		{
			count[i] = 1;
		}
		for (int i = 1; i < n; i++)
		{
			for (int j = 1; j < m; j++)
			{
				count[j] += count[j - 1];
			}
		}
		return count[m - 1];
	}

private:
	void Helper(int m, int n, int& count)
	{
		if (m == 1 || n == 1)
		{
			count++;
			return;
		}
		Helper(m - 1, n, count);
		Helper(m, n - 1, count);
	}
};

class Solution46
{
public:
	vector<vector<int>> permutation(vector<int>& nums)
	{
		vector<int> p;
		vector<vector<int>> ret;
		vector<bool> used(nums.size(), false);

		Helper(nums, used, p, ret);
		return ret;
	}

	vector<vector<int>> permutation2(vector<int>& nums)
	{
		vector<vector<int>> ret;

		Helper(nums, 0, ret);
		return ret;
	}

private:
	void Helper(vector<int>& nums, vector<bool>& used, vector<int>& p, vector<vector<int>>& ret)
	{
		if (p.size() == nums.size())
		{
			ret.push_back(p);
			return;
		}
		for (int i = 0; i < nums.size(); i++)
		{
			if (!used[i])
			{
				p.push_back(nums[i]);
				used[i] = true;
				Helper(nums, used, p, ret);
				p.pop_back();
				used[i] = false;
			}
		}
	}

	void Helper(vector<int>& nums, int s, vector<vector<int>>& ret)
	{
		if (s == nums.size() - 1)
		{
			ret.push_back(nums);
			return;
		}
		for (int i = s; i < nums.size(); i++)
		{
			swap(nums, s, i);
			Helper(nums, s + 1, ret);
			swap(nums, s, i);
		}
	}

	void swap(vector<int>& nums, int i, int j)
	{
		int tmp = nums[i];
		nums[i] = nums[j];
		nums[j] = tmp;
	}
};

class Solution116
{
public:
	void connect(TreeLinkNode* root)
	{
		if (root == nullptr)
		{
			return;
		}
		queue<TreeLinkNode*> q;
		q.push(root);

		while (q.size() != 0)
		{
			TreeLinkNode* node = q.front();
			q.pop();
			if (node->left != nullptr)
			{
				node->left->next = node->right;
				node->right->next = node->next == nullptr ? nullptr : node->next->left;
				q.push(node->left);
				q.push(node->right);
			}
		}
	}
};

class TreeLinkNode
{
public:
	int val;
	TreeLinkNode* left;
	TreeLinkNode* right;
	TreeLinkNode* next;
};

class Solution59
{
public:
	vector<vector<int>> generateMatrix(int n)
	{
		vector<vector<int>> matrix(n, vector<int>(n, 0));
		int i = 0, j = 0, num = 1;

		while (num < n*n)
		{
			while (i + j < n - 1)
			{
				matrix[i][j++] = num++;
			}
			while (i < j)
			{
				matrix[i++][j] = num++;
			}
			while (i + j < n - 1)
			{
				matrix[i][j--] = num++;
			}
			while (i > j)
			{
				matrix[i--][j] = num++;
			}
			i++;
			j++;
		}
		return matrix;


	}
};

class Solution173
{
public:
	class BSTIterator
	{
	public:
		BSTIterator(TreeNode* root)
		{
			TreeNode* node = root;
			while (node != nullptr)
			{
				s.push(node);
				node = node->left;
			}
		}

		int next()
		{
			TreeNode* node = s.top();
			s.pop();

			int ret = node->val;
			node = node->right;
			while (node != nullptr)
			{
				s.push(node);
				node = node->left;
			}
			return ret;
		}

		bool hasNext()
		{
			return s.size() != 0;
		}

	private:
		stack<TreeNode*> s;
	};
};

class Solution241
{
public:
	vector<int> diffWaysToCompute(string input)
	{
		vector<int> ret;

		for (int i = 0; i < input.size(); i++)
		{
			if (input[i] == '+' || input[i] == '-' || input[i] == '*')
			{
				vector<int> left = diffWaysToCompute(input.substr(0, i));
				vector<int> right = diffWaysToCompute(input.substr(i + 1));

				for (auto l : left)
				{
					for (auto r : right)
					{
						if (input[i] == '+')
						{
							ret.push_back(l + r);
						}
						else if (input[i] == '-')
						{
							ret.push_back(l - r);
						}
						else
						{
							ret.push_back(l*r);
						}
					}
				}
			}
		}
		if (ret.size() == 0)
		{
			int n = 0;

			for (auto c : input)
			{
				n = n * 10 + c - '0';
			}
			ret.push_back(n);
		}
		return ret;
	}

	vector<int> diffWaysToCompute2(string input)
	{
		map<string, vector<int>> m;
		
		return helper(input, m);
	}
private:
	vector<int> helper(string input, map<string, vector<int>>& m)
	{
		if (m.find(input) != m.end())
		{
			return m[input];
		}
		vector<int> ret;

		for (int i = 0; i < input.size(); i++)
		{
			if (input[i] == '+' || input[i] == '-' || input[i] == '*')
			{
				vector<int> left = diffWaysToCompute(input.substr(0, i));
				vector<int> right = diffWaysToCompute(input.substr(i + 1));

				for (auto l : left)
				{
					for (auto r : right)
					{
						if (input[i] == '+')
						{
							ret.push_back(l + r);
						}
						else if (input[i] == '-')
						{
							ret.push_back(l - r);
						}
						else
						{
							ret.push_back(l*r);
						}
					}
				}
			}
		}
		if (ret.size() == 0)
		{
			int n = 0;

			for (auto c : input)
			{
				n = n * 10 + c - '0';
			}
			ret.push_back(n);
		}
		m.insert(pair<string, vector<int>>(input, ret));
		return ret;
	}
};

class Solution367
{
public:
	bool isPerfectSquare(int n)
	{
		if (n == 1)
		{
			return true;
		}
		int lo = 1;
		int hi = n / 2;

		while (lo <= hi)
		{
			int mid = (lo + hi) / 2;

			if (mid*mid > n)
			{
				hi = mid - 1;
			}
			else if (mid*mid < n)
			{
				lo = mid + 1;
			}
			else
			{
				return true;
			}

		}
		return false;
	}
};

class Solution313
{
public:
	int nthUglyNumber(int n, vector<int>& primes)
	{
		vector<int> nums;
		nums.push_back(1);

		int N = primes.size();
		vector<int> pointers(N, 0);

		for (int i = 1; i < n; i++)
		{
			int min = INT32_MAX;
			for (int j = 0; j < N; j++)
			{
				int tmp = primes[j] * nums[pointers[j]];
				min = min < tmp ? min : tmp;
			}
			nums.push_back(min);
			for (int j = 0; j < N; j++)
			{
				if (primes[j] * nums[pointers[j]] == min)
				{
					pointers[j]++;
				}
			}
		}
		return nums[n - 1];
	}
};

class Solution289
{
public:
	void gameOfLife(vector<vector<int>>& board)
	{
		int m = board.size();
		int n = m == 0 ? 0 : board[0].size();

		for (int i = 0; i < m; i++)
		{
			for (int j = 0; j < n; j++)
			{
				int count = 0;
				for (int p = max(i - 1, 0); p <= min(i + 1, m); p++)
				{
					for (int q = max(j - 1, 0); q <= min(j + 1, n); q++)
					{
						count += board[p][q] & 1;
					}
				}
				if (count == 3 || count - board[i][j] == 3)
				{
					board[i][j] = board[i][j] | 2;
				}
			}
		}
		for (int i = 0; i < m; i++)
		{
			for (int j = 0; j < n; j++)
			{
				board[i][j] >>= 1;
			}
		}
	}
};

class Solution334
{
public:
	bool increasingTriplet(vector<int>& nums)
	{
		int small = INT32_MAX;
		int median = INT32_MAX;

		for (auto n : nums)
		{
			if (n > median)
			{
				return true;
			}
			if (n > small)
			{
				median = n;
			}
			else
			{
				small = n;
			}
		}
		return false;
	}
};

class Solution215
{
public:
	int kThLargest(vector<int>& nums, int k)
	{
		return Helper(nums, 0, nums.size() - 1, k);
	}

private:
	int Helper(vector<int>& nums, int lo, int hi, int k)
	{
		while (lo < hi)
		{
			int i = lo + 1;
			int j = lo + 1;

			if (j <= hi)
			{
				if (nums[j] > nums[lo])
				{
					swap(nums, i, j);
					i++;
				}
				j++;
			}
			swap(nums, i - 1, lo);
			if (i - lo>k)
			{
				return Helper(nums, lo, i - 1, k);
			}
			if (i - lo < k)
			{
				return Helper(nums, i, hi, k - i + lo);
			}
			return nums[i-1];
		}
		return nums[lo];
	}

	void swap(vector<int>& nums, int i, int j)
	{
		int tmp = nums[i];
		nums[i] = nums[j];
		nums[j] = tmp;
	}
};


class Solution284
{
public:
	class Iterator
	{
	public:
		Iterator(const vector<int>& nums)
		{}
		int next()
		{}
		bool hasNext()
		{}
		int lll()
		{}
	};

	class PeekingIterator : public Iterator
	{
	private:
		int next;
		bool hasNext;

	public:
		PeekingIterator(const vector<int>& nums) : Iterator(nums)
		{
			hasNext = Iterator::hasNext();
			if (hasNext)
			{
				next = Iterator::next();
			}
		}

		int peek()
		{
			return next;
		}

		int next()
		{
			int ret = next;
			hasNext = Iterator::hasNext();
			if (hasNext)
			{
				next = Iterator::next();
			}
			return ret;
		}

		bool hasNext()
		{
			return hasNext;
		}
	};
};

class Solution32
{
public:
	int longestValidParenthese(string s)
	{
		stack<int> idx;
		stack<int> match;

		for (int i = 0; i < s.length; i++)
		{
			if (s[i] == '(')
			{
				idx.push(i);
			}
			else
			{
				if (idx.size() > 0)
				{
					match.push(idx.top());
					match.push(i);
					idx.pop();
				}
			}
		}
		int ret= 0;
		while (match.size() != 0)
		{
			int tmp1 = match.top();
			int tmp2 = tmp1;
			match.pop();
			while (match.size() != 0 && match.top() == tmp2 - 1)
			{
				tmp2 = match.top();
				match.pop();
			}
			ret = max(ret, tmp1 - tmp2 + 1);
		}
		return ret;
	}
};

class Solution331
{
public:
	bool isValidSerialization(string preorder)
	{
		stack<char> s;

		for (auto c : preorder)
		{
			if (c == ',')
			{
				continue;
			}
			if (c == '#')
			{
				while (s.size() >= 2 && s.top() == '#')
				{
					s.pop();
					if (s.top() == '#')
					{
						return false;
					}
					s.pop();
				}
			}
			s.push(c);
		}
		return s.size() == 0;
	}
};

class Solution39
{
public:
	vector<vector<int>> combinationSum(vector<int>& candidates, int target)
	{
		vector<vector<int>> ret;
		vector<int> s;

		Helper(candidates, target, 0, s, ret);
		return ret;
	}

private:
	void Helper(vector<int>& candidates, int target, int begin, vector<int>& s, vector<vector<int>>& ret)
	{
		if (target == 0)
		{
			ret.push_back(s);
			return;
		}
		for (int i = begin; i < candidates.size(); i++)
		{
			if (candidates[i] <= target)
			{
				s.push_back(candidates[i]);
				Helper(candidates, target - candidates[i], i, s, ret);
				s.pop_back();
			}
		}
	}
};

class Solution114
{
public:
	void flatten(TreeNode* root)
	{
		stack<TreeNode*> s;
		TreeNode* node = root;

		while (node != nullptr)
		{
			s.push(node);
			node = node->left;
		}
		while (s.size() != 0)
		{
			node = s.top();
			s.pop();
			if (node->right != nullptr)
			{
				node = node->right;
				while (node != nullptr)
				{
					s.push(node);
					node = node->left;
				}
			}
			else
			{
				TreeNode* tmp = s.top();
				node->right = tmp->right;
				tmp->right = node;
			}
		}
	}
};

class Solution16
{
public:
	int threeSumClosest(vector<int>& nums, int target)
	{
		sort(nums.begin(), nums.end());
		double ret = nums[0] + nums[1] + nums[2];
		int N = nums.size();

		for (int i = 0; i < N - 2; i++)
		{
			int lo = i + 1;
			int hi = N - 1;
			
			while (lo < hi)
			{
				double sum = nums[i] + nums[lo] + nums[hi];
				if (abs(target - sum) < abs(target - ret))
				{
					ret = sum;
				}
				if (sum > target)
				{
					hi--;
				}
				else
				{
					lo++;
				}
			}
		}
		return (int)ret;
	}
};

class Solution310
{
public:
	vector<int> findMinHeightTrees(int n, vector<pair<int, int>>& edges)
	{
		vector<vector<int>> tree(n, vector<int>());

		for (auto e : edges)
		{
			tree[e.first].push_back(e.second);
			tree[e.first].push_back(e.second);
		}
		vector<int> p1 = bfs(0, tree);
		vector<int> p2 = bfs(p1.back(), tree);
		vector<int> ret;
		int len = p2.size();
		if (len % 2 == 1)
		{
			ret.push_back(p2[len / 2]);
		}
		else
		{
			ret.push_back(p2[len / 2 - 1]);
			ret.push_back(p2[len / 2]);
		}
		return ret;
	}

private:
	vector<int> bfs(int i, vector<vector<int>>& tree)
	{
		vector<bool> visited(tree.size(), false);
		queue<int> q;
		vector<int> path(tree.size(), i);
		int node;
		q.push(i);

		while (q.size() != 0)
		{
			node = q.front();
			q.pop();
			visited[node] = true;
			for (auto adj : tree[node])
			{
				if (visited[adj] == false)
				{
					q.push(adj);
					path[adj] = node;
				}
			}
		}
		vector<int> ret;
		while (node != i)
		{
			ret.insert(ret.begin(), node);
			node = path[node];
		}
		ret.insert(ret.begin(), i);
		return ret;
	}
};

class Solution {
public:
	int countNodes(TreeNode* root) {
		if (root == nullptr)
		{
			return 0;
		}

		int level = 0;
		int count = 0;
		bool flag = false;
		TreeNode* node = root;
		while (node != nullptr)
		{
			node = node->left;
			level++;
		}
		dfs(root, 1, level, count, flag);
		return pow(2, level - 1) - 1 + count;
	}

private:
	void dfs(TreeNode* node, int curLevel, int& level, int& count, bool& flag)
	{
		if (curLevel == level)
		{
			count++;
			return;
		}
		if (node->left == nullptr && node->right == nullptr)
		{
			flag = true;
			return;
		}
		if (flag == false && node->left != nullptr)
		{
			dfs(node->left, curLevel + 1, level, count, flag);
		}
		if (flag == false && node->right != nullptr)
		{
			dfs(node->right, curLevel + 1, level, count, flag);
		}
	}
};

//Solution208
class TrieNode {
public:
	// Initialize your data structure here.
	bool isString;
	TrieNode* next[26];

	TrieNode() {
		isString = false;
	}
};

class Trie {
public:
	Trie() {
		root = new TrieNode();
	}

	// Inserts a word into the trie.
	void insert(string word) {
		TrieNode* node = root;
		int N = word.size();
		for (int i = 0; i < N; i++)
		{
			if (node->next[word[i] - 'a'] == nullptr)
			{
				node->next[word[i] - 'a'] = new TrieNode();
			}
			node = node->next[word[i] - 'a'];
		}
		node->isString = true;
	}

	// Returns if the word is in the trie.
	bool search(string word) {
		TrieNode* node = root;
		TrieNode* p = find(word);

		return p!=nullptr && node->isString;
	}

	// Returns if there is any word in the trie
	// that starts with the given prefix.
	bool startsWith(string prefix) {
		TrieNode* node = root;
		TrieNode* p = find(prefix);

		return p!=nullptr;
	}

private:
	TrieNode* root;
	TrieNode* find(string s)
	{
		TrieNode* node = root;
		for (int i = 0; i < s.size() && node != nullptr; i++)
		{
			node = node->next[s[i] - 'a'];
		}
		return node;
	}
};

class UndirectedGraphNode
{
public:
	int label;
	vector<UndirectedGraphNode*> neighbors;
	UndirectedGraphNode(int x) :label(x) {};
};

class Solution133 {
public:
	UndirectedGraphNode *cloneGraph(UndirectedGraphNode *node) {
		if (node == nullptr)
		{
			return node;
		}
		UndirectedGraphNode* h = new UndirectedGraphNode(node->label);
		map<int, UndirectedGraphNode*> visited;
		dfs(node, h, visited);
		return h;
	}
private:
	void dfs(UndirectedGraphNode* t, UndirectedGraphNode* s, map<int, UndirectedGraphNode*>& visited)
	{
		visited.insert(pair<int, UndirectedGraphNode*>(s->label, s));
		for (auto n : t->neighbors)
		{
			if (visited.find(n->label) == visited.end())
			{
				UndirectedGraphNode* m = new UndirectedGraphNode(n->label);
				s->neighbors.push_back(m);
				dfs(n, m, visited);
			}
			else
			{
				s->neighbors.push_back(visited[n->label]);
			}
		}
	}
};

class Solution
{
public:
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

private:
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
};

class Solution43
{
public:
	string multiply(string nums1, string nums2)
	{
		vector<string> results;
		int m = nums1.size();
		int n = nums2.size();

		if (m <= n)
		{
			for (int i = m - 1; i >= 0; i--)
			{
				results.push_back(mul(nums2, nums1[i], m-1-i));
			}
		}
		else
		{
			for (int i = n - 1; i >= 0; i--)
			{
				results.push_back(mul(nums1, nums2[i], n - 1 - i));
			}
		}
		string sum = 0;
		int f = 0;
		for (int i = 0; i < results.back().length; i++)
		{
			int c = 0;
			for (auto s : results)
			{
				c += i >= s.length ? 0 : (s[i] - '0');
			}
			c += f;
			sum.push_back(char(c % 10));
			f = c / 10;
		}
		reverse(sum.begin(), sum.end());
		return sum;
	}

private:
	string mul(string num, char p, int t)
	{
		int pp = p - '0';
		int f = 0;
		string ret = "";

		for (int i = num.length - 1; i >= 0; i--)
		{
			int r = (num[i] - '0')*pp + f;
			ret.push_back(char(r%10));
			f = r / 10;
		}
		if (f != 0)
		{
			ret.push_back(char(f));
		}
		while (t > 0)
		{
			ret.insert(ret.begin(), '0');
			t--;
		}
		return ret;
	}
};

class Solution
{
public:
	void reorderList(ListNode* head)
	{
		if (head == nullptr || head->next == nullptr || head->next->next==nullptr)
		{
			return;
		}
		ListNode* f = head;
		ListNode* s = head;

		while (f != nullptr&& f->next != nullptr)
		{
			f = f->next->next;
			s = s->next;
		}
		ListNode* t = nullptr;
		ListNode* tp = s->next;
		s->next = nullptr;
		s = tp;
		while (s != nullptr)
		{
			ListNode* tmp = s->next;
			s->next = t;
			t = s;
			s = tmp;
		}
		s = head;
		while (t != nullptr)
		{
			ListNode* tmp1 = s->next;
			ListNode* tmp2 = t->next;
			s->next = t;
			t->next = tmp1;
			s = tmp1;
			t = tmp2;
		}
	}
};

class Twitter {

private:
	int timeId;
	map<int, vector<int>> follower;
	map<int, vector<pair<int, int>>> tweet; // firstItem is time_id, second item is tweetId
public:
	Twitter()
	{
		timeId = 0;
	}

	void postTweet(int userId, int tweetId)
	{
		tweet[userId].insert(tweet[userId].begin(), pair<int, int>(timeId, tweetId));
		timeId++;
	}

	vector<int> getNewsFeed(int userId)
	{
		vector<int> p;
		p.push_back(userId);
		if (follower.find(userId) != follower.end())
		{
			for (auto f : follower[userId])
			{
				p.push_back(f);
			}
		}
		vector<int> idx(p.size(), 0);
		vector<int> ret;

		while (ret.size() < 10)
		{
			int mostRecentTime = -1;
			int tweetId = 0;
			int user = 0;
			bool flag = false;

			for (int i = 0; i < p.size(); i++)
			{
				if (tweet.find(p[i]) != tweet.end() && idx[i] < tweet[p[i]].size() && (tweet[p[i]])[idx[i]].first > mostRecentTime)
				{
					mostRecentTime = tweet[p[i]][idx[i]].first;
					tweetId = (tweet[p[i]])[idx[i]].second;
					user = i;
					flag = true;
				}
			}
			if (flag == false)
			{
				break;
			}
			idx[user]++;
			ret.push_back(tweetId);
		}
		return ret;
	}

	void follow(int followerId, int followeeId)
	{
		if (followerId != followeeId)
			follower[followerId].push_back(followeeId);
	}

	void unfollow(int followerId, int followeeId)
	{
		int i;
		for (i = 0; i < follower[followerId].size(); i++)
		{
			if (follower[followerId][i] == followeeId)
			{
				break;
			}
		}
		if (i < follower[followerId].size())
		{
			follower[followerId].erase(follower[followerId].begin() + i);
		}
	}
};

class Solution210
{
public: 
	vector<int> findOrder(int numCourses, vector<pair<int, int>>& prerequisites)
	{
		vector<int> degree(numCourses, 0);
		vector<vector<int>> adj(numCourses, vector<int>());

		for (auto p : prerequisites)
		{
			degree[p.first]++;
			adj[p.second].push_back(p.first);
		}

		vector<int> ret;
		queue<int> q;
		for (int i = 0; i < numCourses; i++)
		{
			if (degree[i] == 0)
			{
				q.push(i);
			}
		}
		while (q.size() != 0)
		{
			int s = q.size();
			for (int i = 0; i < s; i++)
			{
				int t = q.front();
				q.pop();
				ret.push_back(t);
				for (auto x : adj[t])
				{
					degree[x]--;
					if (degree[x] == 0)
					{
						q.push(x);
					}
				}
			}
		}
		if (ret.size() == numCourses)
		{
			return ret;
		}
		ret.clear();
		return ret;
	}

	vector<int> findOrder2(int numCourses, vector<pair<int, int>>& prerequisites)
	{
		vector<int> degree(numCourses, 0);
		vector<vector<int>> adj(numCourses, vector<int>());

		for (auto p : prerequisites)
		{
			degree[p.first]++;
			adj[p.second].push_back(p.first);
		}

		vector<int> ret;
		vector<bool> visited(numCourses, false);
		for (int i = 0; i < numCourses; i++)
		{
			if (degree[i] == 0)
			{
				dfs(i, visited, adj, ret);
			}
		}
		if (ret.size() == numCourses)
		{
			return ret;
		}
		ret.clear();
		return ret;
	}

	void dfs(int i, vector<bool>& visited, vector<vector<int>>& adj, vector<int>& ret)
	{
		visited[i] = true;
		for (auto n : adj[i])
		{
			if (visited[n] == false)
			{
				dfs(n, visited, adj, ret);
			}
		}
		ret.push_back(i);
	}
};

class Solution179 {
public:
	string largestNumber(vector<int>& nums) {
		vector<string> s;

		for (auto n : nums)
		{
			s.push_back(to_string(n));
		}
		sort(s.begin(), s.end(), [](string& s1, string& s2) {return s1 + s2 > s2 + s1; });
		string ret;
		for (auto n : s)
		{
			ret += n;
		}
		while (ret[0] == '0' && ret.size() > 1)
		{
			ret = ret.substr(1);
		}
		return ret;
		return ret;
	}
};

class Solution130 {
public:
	void solve(vector<vector<char>>& board) {
		int m = board.size();
		if (m == 0 || m == 1 || m == 2)
		{
			return;
		}
		int n = board[0].size();
		if (n == 1 || n == 2)
		{
			return;
		}

		vector<vector<bool>> visited(m, vector<bool>(n, false));
		for (int i = 1; i < m - 1; i++)
		{
			for (int j = 1; j < n - 1; j++)
			{
				if (board[i][j] == 'O' && visited[i][j] == false)
				{
					vector<pair<int, int>> onStack;
					if (visit(i, j, m, n, board, visited, onStack) == true)
					{
						for (auto p : onStack)
						{
							board[p.first][p.second] = 'X';
						}
					}
				}
			}
		}
	}

private:
	bool visit(int i, int j, int m, int n, vector<vector<char>>& board, vector<vector<bool>>& visited, vector<pair<int,int>> onStack)
	{
		visited[i][j] = true;
		if (i == 0 || i == m - 1 || j == 0 || j == n - 1)
		{
			return false;
		}
		onStack.push_back(pair<int, int>(i, j));
		if (board[i][j - 1] == 'O' && visited[i][j - 1] == false)
		{
			if (visit(i, j - 1, m, n, board, visited, onStack) == false)
			{
				return false;
			}
		}
		if (board[i][j + 1] == 'O' && visited[i][j + 1] == false)
		{
			if (visit(i, j + 1, m, n, board, visited, onStack) == false)
			{
				return false;
			}
		}
		if (board[i - 1][j] == 'O' && visited[i - 1][j] == false)
		{
			if (visit(i - 1, j, m, n, board, visited, onStack) == false)
			{
				return false;
			}
		}
		if (board[i + 1][j] == 'O' && visited[i + 1][j] == false)
		{
			if (visit(i + 1, j, m, n, board, visited, onStack) == false)
			{
				return false;
			}
		}
		return true;
	}
};

class Solution85
{
public:
	int MaxRect(vector<vector<char>>& matrix)
	{
		int m = matrix.size();

		if (m == 0)
		{
			return 0;
		}
		int n = matrix[0].size();
		vector<vector<int>> mat(m, vector<int>(n, 0));

		for (int i = 0; i < m; i++)
		{
			for (int j = 0; j < n; j++)
			{
				if (matrix[i][j] == '1')
				{
					mat[i][j] = j == 0 ? 1 : mat[i][j - 1] + 1;
				}
			}
		}
		int size = 0;
		for (int j = 0; j < n; j++)
		{
			int i = 0;

			while (i < m)
			{
				if (mat[i][j] == 0)
				{
					i++;
					continue;
				}
				int hi = i;
				while (hi < m && mat[hi][j] >= mat[i][j])
				{
					hi++;
				}
				int lo = i;
				while (lo >= 0 && mat[lo][j] >= mat[i][j])
				{
					lo--;
				}
				size = max(size, mat[i][j] * (hi - lo - 1));
				i++;
			}
		}
		return size;
	}
};

class Solution42
{
public:
	int trap(vector<int>& height)
	{
		stack<int> s;
		int i = 0;
		int N = height.size();
		int amount = 0;

		while (i < N)
		{
			while (s.size() != 0 && height[i] > height[s.top()])
			{
				int bottom = height[s.top()];
				s.pop();
				amount += s.size() == 0 ? 0 : (min(height[i], height[s.top()]) - bottom)*(i - s.top() - 1);
			}
			s.push(i++);
		}
		return amount;
	}

};

struct Interval
{
	int start;
	int end;
	Interval() : start(0), end(0) {}
	Interval(int s, int e) : start(s), end(e) {}
};
class Solution56
{
public:
	vector<Interval> mergeIntervals(vector<Interval>& intervals)
	{
		int N = intervals.size();
		int i = 0;
		vector<Interval> ret;

		sort(intervals.begin(), intervals.end(), [](Interval a, Interval b) { return a.start < b.start; });
		while (i < N)
		{
			int left = intervals[i].start;
			int right = intervals[i].end;
			while (i < N - 1 && intervals[i + 1].start <= right)
			{
				right = max(right, intervals[i + 1].end);
				i++;
			}
			Interval tmp(left, right);
			ret.push_back(tmp);
			i++;
		}
		return ret;
	}
};

class Solution57
{
public:
	vector<Interval> insert(vector<Interval>& intervals, Interval newInterval)
	{
		intervals.insert(intervals.begin(), Interval(INT32_MIN, INT32_MIN));
		int i = 0;
		int N = intervals.size();
		int lo = find(intervals, i, newInterval.start);
		int hi = find(intervals, lo, newInterval.end);
		int upper = max(intervals[hi].end, newInterval.end);
		vector<Interval> ret;

		int t = 1;
		while (t <= lo)
		{
			ret.push_back(intervals[t++]);
		}
		if (newInterval.start <= intervals[lo].end)
		{
			ret.back().end = upper;
		}
		else
		{
			newInterval.end = upper;
			ret.push_back(newInterval);
		}
		t = hi + 1;
		while (t < N)
		{
			ret.push_back(intervals[t++]);
		}
		return ret;
	}

	int find(vector<Interval>& intervals, int i, int key)
	{
		int N = intervals.size();

		while (i < N - 1)
		{
			if (intervals[i].start <= key && key < intervals[i + 1].start)
			{
				return i;
			}
			i++;
		}
		return i;
	}

	vector<Interval> insert2(vector<Interval>& intervals, Interval newInterval)
	{
		int i = 0;
		int N = intervals.size();
		vector<Interval> ret;

		while (i < N && newInterval.start > intervals[i].end)
		{
			ret.push_back(intervals[i++]);
		}
		if (i < N)
		{
			newInterval.start = min(newInterval.start, intervals[i].start);
		}
		while (i < N && newInterval.end >= intervals[i].start)
		{
			newInterval.end = max(newInterval.end, intervals[i].end);
			i++;
		}
		ret.push_back(newInterval);
		while (i < N)
		{
			ret.push_back(intervals[i++]);
		}
		return ret;
	};
};

class Solution45
{
public:
	int jump(vector<int>& nums)
	{
		int N = nums.size();
		vector<int> jumps(N, N);
		jumps[0] = 1;
		int i = 0;

		while (i < N - 1)
		{
			if (i + nums[i] == N - 1)
			{
				return jumps[i] + 1;
			}
			for (int j = i + 1; j <= i + nums[i]; j++)
			{
				jumps[j] = min(jumps[j], jumps[i] + 1);
			}
		}
		return jumps.back();
	}

	int jump2(vector<int>& nums)
	{
		int N = nums.size();
		int far = 0;
		int jump = 0;
		int i = 0;

		while (far < N - 1)
		{
			int j = far;
			while (i <= j)
			{
				far = max(far, i + nums[i]);
				i++;
			}
			jump++;
		}
		return jump;
	}
};

class Solution84
{
public:
	int largestRect(vector<int>& heights)
	{
		stack<int> s;
		heights.push_back(0);
		int i = 0;
		int N = heights.size();
		int maxArea = 0;

		while (i < N)
		{
			while (s.size() > 0 && heights[s.top()] > heights[i])
			{
				int h = heights[s.top()];
				s.pop();
				int l = s.size() > 0 ? s.top() : -1;
				maxArea = max(maxArea, h*(i - l - 1));
			}
			s.push(i);
		}
		return maxArea;
	}
};

class Solution126 {
public:
	vector<vector<string>> findLadders(string beginWord, string endWord, unordered_set<string> &wordList) {

	}
};

class Solution {
public:
	int NthSuperUglyNumber(int n, vector<int>& primes) {
		int N = primes.size();
		vector<int> p(N, 0);
		vector<int> ret(n, 1);
		string s = "adf";
		for (int i = 1; i < n; i++)
		{
			int minVal = INT32_MAX;
			pair<int, int> p;
			p.first
			for (int j = 0; j < N; j++)
			{
				minVal = min(minVal, primes[j] * p[j]);
			}
			ret[i] = minVal;
			for (int j = 0; j < N; j++)
			{
				if (primes[j] * p[j] == minVal)
				{
					p[j] ++;
				}
			}
		}
		return ret.back();
	}
}


/**
* Your Twitter object will be instantiated and called as such:
* Twitter obj = new Twitter();
* obj.postTweet(userId,tweetId);
* vector<int> param_2 = obj.getNewsFeed(userId);
* obj.follow(followerId,followeeId);
* obj.unfollow(followerId,followeeId);
*/


