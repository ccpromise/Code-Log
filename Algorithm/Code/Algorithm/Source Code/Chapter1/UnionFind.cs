using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Source_Code.Chapter1
{
    /// <summary>
    /// complexity: union-O(N) find-O(1)
    /// </summary>
    public class UnionFind_QuickFind
    {
        private int[] objects;
        private int N;

        public UnionFind_QuickFind(int N)
        { 
            objects = new int[N];
            this.N = N;

            for (var i = 0; i < N; i++)
            { 
                object[i] = i;
            }
        }

        public void Union(int p, int q)
        {
            for (var i = 0; i < N; i++)
            {
                if (objects[i] == objects[p])
                {
                    objects[i] = objects[q];
                }
            }
        }

        public bool IsConncected(int p, int q)
        {
            return objects[p] == objects[q];
        }
    }

    //public class UnionFind_QuickUnion
    //{
    //    private int[] ids;
    //    private int N;

    //    public UnionFind_QuickUnion(int N)
    //    {
    //        ids = new int[N];
    //        this.N = N;

    //        for (var k = 0; k < N; k++)
    //        {
    //            ids[k] = k;
    //        }
    //    }

    //    public void Union(int i, int j)
    //    {
    //        while (ids[i] != i)
    //        {
    //            i = ids[i];
    //        }
    //        while (ids[j] != j)
    //        {
    //            j = ids[j];
    //        }
    //        ids[i] = j;
    //    }

    //    public bool Connected(int i, int j)
    //    {
    //        while (ids[i] != i)
    //        {
    //            i = ids[i];
    //        }
    //        while (ids[j] != j)
    //        {
    //            j = ids[j];
    //        }
    //        return i == j;
    //    }
    //}

    // To solve big dataset, you need improve from O(N) to O(lgN)
    /// <summary>
    /// Complexity:
    /// Union: best case: O(1), worst case: O(N), average: O(lgN)
    /// Find: best case: O(1), worst case: O(N), average: O(lgN)
    /// </summary>
    public class UnionFind_QuickUnion
    {
        private int[] objects;
        private int N;

        public UnionFind_QuickUnion(int N)
        {
            objects = new int[N];
            this.N = N;
        }

        public void Union(int p, int q)
        {
            objects[Root(p)] = Root(q);
        }

        public bool IsConnected(int p, int q)
        {
            return Root(p) == Root(q);
        }

        private int Root(int p)
        {
            while (objects[p] != p)
            {
                p = objects[p];
            }
            return p;
        }
    }

    public class Balanced_UnionFind
    {
        private int[] arr;
        private int[] size;

        public Balanced_UnionFind(int N)
        {
            arr = new int[N];
            size = new int[N];
            for (var i = 0; i < N; i++)
            {
                arr[i] = i;
                size[i] = 1;
            }
        }

        public void Union(int p, int q)
        {
            var rootP = Root(p);
            var rootQ = Root(q);

            if (size[rootP] < size[rootQ])
            {
                arr[rootP] = rootQ;
                size[rootQ] += size[rootP];
            }
            else
            {
                arr[rootQ] = rootP;
                size[rootP] += size[rootQ];
            }
        }

        public bool Find(int p, int q)
        {
            return Root(p) == Root(q);
        }

        private int Root(int p)
        {
            while (arr[p] != p)
            {
                p = arr[p];
            }
            return p;
        }
    }
}
