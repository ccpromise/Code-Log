class Solution368(object):
    def largestDivisibleSubset(self, nums):
        """
        :type nums: List[int]
        :rtype: List[int]
        """
        if len(nums) == 0:
            return []
        nums.sort()
        dic = { 0: (nums[0], ) }
        s = [nums[0]]
        for i in range(1, len(nums)):
            dic[i] = (nums[i],)
            for n in dic:
                if i != n and nums[i] % nums[n] == 0 and len(dic[n]) >= len(dic[i]):
                    dic[i] = dic[n] + (nums[i],)
            if len(dic[i])>len(s):
                s = list(dic[i])
        return s
		
class Solution16(object):
    def threeSumClosest(self, nums, target):
        """
        :type nums: List[int]
        :type target: int
        :rtype: int
        """
        nums.sort()
        ret = nums[0]+nums[1]+nums[2]
        for i in range(0, len(nums)-2):
            for j in range(i+1, len(nums)-1):
                diff = target - nums[i]-nums[j]
                x = nums[i] + nums[j] + nums[j+1]
                lo = j+1
                hi = len(nums)-1
                while lo <= hi:
                    mid = (lo+hi)/2
                    y = nums[i] + nums[j] + nums[mid]
                    if nums[mid] == diff:
                        return y
                    if abs(target - y) < abs(target - x):
                        x = y
                    if nums[mid] < diff:
                        lo = mid + 1
                    else:
                        hi = mid - 1
                if abs(target - x)<abs(target - ret):
                    ret = x
        return ret

# solution341		
class NestedIterator(object):
    def __init__(self, nestedList):
        """
        Initialize your data structure here.
        :type nestedList: List[NestedInteger]
        """
        self.iter = nestedList
    def next(self):
        """
        :rtype: int
        """
        a = self.iter.pop(0)
        while a.isInteger() == False:
            b = a.getList()
            if len(b) == 0:
                break
            a = b.pop(0)
            for i in range(len(b)-1, -1, -1):
                self.iter.insert(0, b[i])
        return a;

    def hasNext(self):
        """
        :rtype: bool
        """
        return len(self.iter)!=0

#Solution 341		
class NestedIterator(object):

    def __init__(self, nestedList):
        """
        Initialize your data structure here.
        :type nestedList: List[NestedInteger]
        """
        self.iter = nestedList

    def next(self):
        """
        :rtype: int
        """
        ret = self.iter.pop(0)
        return ret.getInteger()

    def hasNext(self):
        """
        :rtype: bool
        """
        while len(self.iter)!=0:
            a  = self.iter[0]
            if a.isInteger() == True:
                return True
            self.iter.pop(0)
            l = a.getList()
            for i in range(len(l) - 1, -1, -1):
                self.iter.insert(0, l[i])
        return False
		
class Solution310(object):
    def findMinHeightTrees(self, n, edges):
        """
        :type n: int
        :type edges: List[List[int]]
        :rtype: List[int]
        """
        tree = [[] for i in range(n)]
        for edge in edges:
            tree[edge[0]].append(edge[1])
            tree[edge[1]].append(edge[0])
        height = [n for i in range(n)]
        for i in range(n):
            h = 0
            stack = [i]
            visited = [False for j in range(n)]
            visited[i] = True
            while len(stack) > 0:
                h += 1
                size = len(stack)
                while size > 0:
                    node = stack.pop(0)
                    for adj in tree[node]:
                        if visited[adj] == False:
                            visited[adj] = True
                            stack.append(adj)
                    size -= 1
            if h < height[i]:
                 height[i] = h
        minH = min(height)
        ret = []
        for i in range(n):
            if height[i]== minH:
                ret.append(i)
        return ret
		
class Solution310(object):
    def findMinHeightTrees(self, n, edges):
        """
        :type n: int
        :type edges: List[List[int]]
        :rtype: List[int]
        """
        if n==1:
            return [0]
        tree = [[] for i in range(n)]
        unvisited = n
        leaves = []
        for e in edges:
            tree[e[0]].append(e[1])
            tree[e[1]].append(e[0])
        for v in range(n):
            if len(tree[v])==1:
                leaves.append(v)
                unvisited -= 1
                
        
        while unvisited > 0:
            newLeaves = []
            for v in leaves :
                adj = (tree[v])[0]
                tree[adj].remove(v)
                if len(tree[adj]) == 1:
                    newLeaves.append(adj)
                    unvisited -= 1
            leaves = newLeaves
        return leaves
		
class Solution187(object):
    def findRepeatedDnaSequences(self, s):
        """
        :type s: str
        :rtype: List[str]
        """
        l = []
        ret = []
        for i in range(0, len(s) - 9):
            l.append(s[i : i+10])
        l.sort()
        i = 0
        while i < len(l) - 1:
            if l[i] == l[i+1]:
                ret.append(l[i])
                while i+1 < len(l) and l[i] == l[i+1]:
                    i+=1
            i+=1
        return ret
		
class Solution139(object):
    def wordBreak(self, s, wordDict):
        """
        :type s: str
        :type wordDict: Set[str]
        :rtype: bool
        """
        if s in wordDict:
            return True
        for i in range(1, len(s) + 1):
            if s[0:i] in wordDict:
                if self.wordBreak(s[i:], wordDict) == True:
                    return True
        return False
		
class Solution183(object):
    def wordBreak(self, s, wordDict):
        """
        :type s: str
        :type wordDict: Set[str]
        :rtype: bool
        """
        N = len(s)
        f = [False for i in range(N)]
        
        for i in range(0, N):
            for j in range(0, i+1):
                if s[j:i+1] in wordDict:
                    if j == 0 or f[j-1] == True:
                        f[i] = True
        return f[-1]
		
class Solution60(object):
    def getPermutation(self, n, k):
        """
        :type n: int
        :type k: int
        :rtype: str
        """
        nums = [i for i in range(1, n+1)]
        return self.helper(nums, k)
    def helper(self, nums, k):
        if len(nums) == 1:
            return str(nums[0])
        blockSize = self.fact(len(nums)-1)
        n = (k-1)//blockSize
        m = k - n * blockSize
        num = nums.pop(n)
        return str(num) + self.helper(nums, m)
        
    def fact(self, n):
        ret = 1
        i = 2
        while i <= n:
            ret*=i
            i+=1
        return ret
		
class Solution18(object):
    def fourSum(self, nums, target):
        """
        :type nums: List[int]
        :type target: int
        :rtype: List[List[int]]
        """
        N = len(nums)
        nums.sort()
        ret = []
        for i in range(0, N - 3):
            if i > 0 and nums[i] == nums[i-1]:
                continue
            if nums[i] + nums[i+1] + nums[i+2] + nums[i+3] > target:
                break
            if nums[i] + nums[N-3] + nums[N-2] +nums[N-1] < target:
                continue
            for j in range(i+1, N-2):
                if j > i+1 and nums[j] == nums[j-1]:
                    continue
                curSum = nums[i] + nums[j]
                if curSum + nums[j+1] + nums[j+2] > target:
                    break
                if curSum + nums[N-2] +nums[N-1] < target:
                    continue
                lo = j+1
                hi = N-1
                while lo < hi:
                    sum = curSum + nums[lo] + nums[hi]
                    if sum  > target:
                        hi-=1
                    elif sum < target:
                        lo += 1
                    else:
                        r = [nums[i], nums[j], nums[lo], nums[hi]]
                        ret.append(r)
                        lo += 1
                        hi -= 1
                        while nums[lo] == nums[lo-1] and lo < hi:
                            lo += 1
                        while nums[hi] == nums[hi + 1] and hi > lo:
                            hi -= 1
							
class Solution3(object):
    def lengthOfLongestSubstring(self, s):
        """
        :type s: str
        :rtype: int
        """
        set = []
        maxLen = 1
        for i in range(len(s)):
            while set.count(s[i]) > 0:
                set.pop(0)
            set.append(s[i])
            if len(set) > maxLen:
                maxLen = len(set)
        return maxLen
        return ret
		
class Solution3(object):
    def lengthOfLongestSubstring(self, s):
        """
        :type s: str
        :rtype: int
        """
        map = {}
        start = 0
        maxLen = 0
        
        for i in range(len(s)):
            if s[i] in map :
                start = max(start, map[s[i]]+1)
            maxLen = max(maxLen, i - start+1)
            map[s[i]] = i
        return maxLen
		
class NumMatrix(object):
    def __init__(self, matrix):
        """
        initialize your data structure here.
        :type matrix: List[List[int]]
        """
        row = len(matrix)
        if row == 0:
            return
        col = len(matrix[0])
        if col == 0:
            return
        self.sum = []
        s = 0
        for i in range(row):
            s += matrix[i][0]
            self.sum.append([])
            self.sum[i].append(s)
        s = matrix[0][0]
        for j in range(1, col):
            s += matrix[0][j]
            self.sum[0].append(s)
        for i in range(1, row):
            for j in range(1, col):
                self.sum[i].append(matrix[i][j] + self.sum[i-1][j] + self.sum[i][j-1] - self.sum[i-1][j-1])
                

    def sumRegion(self, row1, col1, row2, col2):
        """
        sum of elements matrix[(row1,col1)..(row2,col2)], inclusive.
        :type row1: int
        :type col1: int
        :type row2: int
        :type col2: int
        :rtype: int
        """
        if row1 == 0 and col1 == 0:
            return self.sum[row2][col2];
        if row1 == 0 :
            return self.sum[row2][col2] - self.sum[row2][col1 -1];
        if col1 == 0:
            return self.sum[row2][col2] - self.sum[row1 - 1][col2];
        return self.sum[row2][col2] - self.sum[row2][col1 - 1] - self.sum[row1-1][col2] + self.sum[row1-1][col1-1];

class Solution79(object):
    def exist(self, board, word):
        """
        :type board: List[List[str]]
        :type word: str
        :rtype: bool
        """
        m = len(board)
        n = len(board[0])
        if word == "":
            return True
        for i in range(m):
            for j in range(n):
                if board[i][j] == word[0]:
                    visited = [[False for p in range(n)] for q in range(m)]
                    visited[i][j] = True
                    if self.helper(i, j, board, word, 1, visited) == True:
                        return True
        return False
    
    def helper(self, i, j, board, word, idx, visited):
        if idx == len(word):
            return True
        m = len(board)
        n = len(board[0])
        neighbors = [[i-1, j], [i+1, j], [i, j-1], [i, j+1]]
        for cor in neighbors:
            if cor[0] >= 0 and cor[0] <= m - 1 and cor[1] >=0 and cor[1] <= n - 1:
                if visited[cor[0]][cor[1]] == False and board[cor[0]][cor[1]] == word[idx]:
                    visited[cor[0]][cor[1]] = True
                    if self.helper(cor[0], cor[1], board, word, idx+1, visited) == True:
                        return True
                    visited[cor[0]][cor[1]] = False
        return False
# Your NumMatrix object will be instantiated and called as such:
# numMatrix = NumMatrix(matrix)
# numMatrix.sumRegion(0, 1, 2, 3)
# numMatrix.sumRegion(1, 2, 3, 4)

class Solution50(object):
    def myPow(self, x, n):
        """
        :type x: float
        :type n: int
        :rtype: float
        """
        if x == 0:
            return 0
        if n < 0:
            return self.myPow(1/x, -n)
        if n == 0:
            return 1
        t = self.myPow(x, n // 2)
        return t * t * (1 if n % 2 == 0 else x)

class SolutionHanNuoTa(object):
    def move(self, n, a, b, c):
        if n == 0：
            return
        self.move(n-1, a, c, b)
        print(a+"->"+c)
        self.move(n-1, b, a, c)

def fibonacci(n):
    i, a, b = 0, 0, 1
    while i < n:
        yield a
        a , b = a, a + b
        i += 1
    return 'done'

f = fibonacci(6)

for x in f:
    print(x)

while True:
    try:
        print(f.next())
    except StopIteration as e:
        print(e.value) 
        break

def triangle():
    a = [1]
    while True:
        yield a
        b = [1]
        for i in range(len(a)-1):
            b.append(a[i]+a[i+1])
        b.append(a[-1])
        a = b

def normalize(name):
    def f(s):
        return s[0].upper() + s[1:].lower()
    map(f, name)

def prod(L):
    reduce(lambda x, y:x*y, L)

def str2float(s):

