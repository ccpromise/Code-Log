/*

*/

class Tower
{}

class Disk
{}

class Hanoi
{
private:
    Tower towers[3];
    int N;
public:
    Hanoi(vector<Disk> disks)
    {
        sort(disks.begin(), disks.end());
        for(int i = disks.size()-1; i >= 0; i--)
        {
            towers[0].push(disks[i]);
        }
        N = disks.size();
    }

    void moveHanoi()
    {
        moveHelper(towers[0], towers[1], towers[2], N);
    }

    void moveHelper(Tower start, Tower mid, Tower end, int N)
    {
        if(N == 1)
        {
            Disk t = start.pop();
            end.push(t);
            return;
        }
        moveHelper(start, end, mid, N-1);
        moveHelper(start, mid, end, 1);
        moveHelper(mid, start, end, N-1);
    }
    
}

class Solution
{
public:
    void findPath(TreeNode* root, int val)
    {
        if(root == nullptr)
        {
            return;
        }
        vector<int> path;
        dfs(root, path, val);
    }

    void dfs(TreeNode* root, vector<int>& path, int val)
    {
        path.push_back(root->val);
        int sum = 0;
        for(int i = path.size()-1; i >= 0; i--)
        {
            sum += path[i];
            if(sum == val)
            {
                cout << "Path:" << endl;
                for(int j = i; j < path.size(); j--)
                {
                    cout << path[j] << ' ';
                }
            }
        }
        if(root->left != nullptr)
        {
            dfs(root->left, path, val);
        }
        if(root->right != nullptr)
        {
            dfs(root->right, path, val);
        }
        path.pop_back();
    }
}