using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm2.Containers
{
    /// <summary>
    /// 1\ public method must check input validation.
    /// 2\ Make neat code by draw the outline first and add private functions after.
    /// 
    /// complexity:
    /// Union: O(N)
    /// Find: O(1)
    /// </summary>
    public class UnionFind_QuickFind
    {
        private IList<int> groupId;
        private int N;
        public UnionFind_QuickFind(int N)
        {
            groupId = new List<int>(N);
            this.N = N;
            for(var i = 0; i < N; i++)
            {
                groupId[i] = i;
            }
        }

        public void Union(int p, int q)
        {
            if(!(IsValid(p) && IsValid(q)))
            {
                throw new InvalidOperationException();
            }
            for(var i = 0; i < N; i++)
            {
                if(groupId[i] == groupId[q])
                {
                    groupId[i] = groupId[p];
                }
            }
        }

        public bool IsConnected(int p, int q)
        {
            if (!(IsValid(p) && IsValid(q)))
            {
                throw new InvalidOperationException();
            }
            return groupId[p] == groupId[q];
        }
    }

    /// <summary>
    /// complexity:
    /// Union/Find: best O(1), average O(lgN), worst O(N)
    /// </summary>
    public class UnionFind_QuickUnion
    {
        private int[] root;
        private int N;
        public UnionFind_QuickUnion(int N)
        {
            root = new int[N];
            this.N = N;
            for(var i = 0; i < N;i++)
            {
                root[i] = i;
            }
        }

        public void Union(int p, int q)
        {
            if (!(IsValid(p) && IsValid(q)))
            {
                throw new InvalidOperationException();
            }
            var rootP = Root(p);
            var rootQ = Root(q);
            root[rootP] = rootQ;
        }

        public bool IsConnected(int p, int q)
        {
            if (!(IsValid(p) && IsValid(q)))
            {
                throw new InvalidOperationException();
            }
            return Root(p) == Root(q);
        }
    }
}
 