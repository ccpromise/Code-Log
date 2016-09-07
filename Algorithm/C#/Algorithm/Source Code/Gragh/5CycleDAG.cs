using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Source_Code.Chapter3
{
    /// <summary>
    /// The definition of having a cycle: the visiting vertex w has an adjacent vertex v which is on the stack of recursive call.
    /// Detect cycle should maintain three arrays: visited, onstack(current path you're searching) and edgeto.
    /// Once found a cycle, how to stop recursion: think about the recursive process.
    /// </summary>
    public class DigraghCycle
    {
        private CycleDFS dfs;
        public DigraghCycle(Digragh g)
        {
            dfs = new CycleDFS(g);
        }

        public bool HasCycle()
        {
            return dfs.HasCycle();
        }

        public int[] Cycle()
        {
            return dfs.Cycle();
        }
    }

    /// <summary>
    /// DFS: postorder. The last visited vertex is the first in topological order.
    /// BFS: when indegree==0, push into the queue.
    /// </summary>
    public class TopologySort
    {
        private OrderDigragh dfs;
        public TopologySort(Digragh g)
        {
            dfs = new OrderDigragh(g);
        }

        public bool IsDAG()
        {
            return dfs.HasCycle();
        }

        public int[] TopologyOrder()
        {
            return dfs.ReversePostOrder();
        }
    }

    internal class CycleDFS
    {
        private Digragh g;
        private bool[] visited;
        private int[] path;
        private bool[] onStack;
        private bool hasCycle;
        private IList<int> cycle;
        public CycleDFS(Digragh g)
        {
            this.g = g;
            var numV = g.NumV();
            visited = new bool[numV];
            path = new int[numV];
            onStack = new bool[numV];
            hasCycle = false;

            for (var v = 0; v < numV; v++)
            {
                if(!visited[v] && !hasCycle)
                {
                    DFSHelper(v);
                }
            }
        }

        public bool HasCycle()
        {
            return hasCycle;
        }

        public int[] Cycle()
        {
            if(cycle==null)
            {
                return null;
            }
            return cycle.ToArray();
        }

        private void DFSHelper(int v)
        {
            visited[v] = true;
            onStack[v] = true;

            foreach(var w in g.EdgesFrom(v))
            {
                if (hasCycle)
                {
                    return;
                }
                else if (!visited[w])
                {
                    path[v] = w;
                    DFSHelper(w);
                }
                else if(onStack[w])
                {
                    hasCycle = true;
                    cycle = new List<int>();
                    var x = v;

                    while(x!=w)
                    {
                        cycle.Add(x);
                        x = path[x];
                    }
                    cycle.Add(w);
                    cycle.Add(v);
                }
            }
            onStack[v] = false;
        }
    }

    internal class OrderDigragh
    {
        private Digragh g;
        private bool[] visited;
        private Stack<int> post;
        private Queue<int> pre;
        private int[] reversePostOrder;
        private int[] postOrder;
        private int[] preOrder;

        public OrderDigragh(Digragh g)
        {
            this.g = g;
            var numV = g.NumV();
            visited = new bool[numV];
            reversePostOrder = new int[numV];
            postOrder = new int[numV];
            preOrder = new int[numV];
            post = new Stack<int>();
            pre = new Queue<int>();

            for (var v = 0; v < g.NumV(); v++)
            {
                if(!visited[v])
                {
                    DFSHelper(v);
                }
            }

            var i = 0;
            var j = numV - 1;

            while (post.Count != 0)
            {
                var tmp1 = post.Pop();
                var tmp2 = pre.Dequeue();

                reversePostOrder[i++] = tmp1;
                postOrder[j--] = tmp1;
                preOrder[i++] = tmp2;
            }
        }

        public bool HasCycle()
        {
            var dfs = new CycleDFS(g);

            return dfs.HasCycle();
        }

        public int[] ReversePostOrder()
        {
            return reversePostOrder;
        }

        public int[] PostOrder()
        {
           return postOrder;
        }

        public int[] PreOrder()
        {
            return preOrder;
        }

        private void DFSHelper(int v)
        {
            visited[v] = true;
            pre.Enqueue(v);

            foreach(var w in g.EdgesFrom(v))
            {
                if(!visited[w])
                {
                    DFSHelper(w);
                }
            }
            post.Push(v);
        }
    }

    internal class TopoBFS
    {
        private Digragh g;
        private bool[] visited;
        private int[] degree;
        private IList<int> order;
        public TopoBFS(Digragh g)
        {
            this.g = g;
            degree = new int[g.NumV()];
            order = new List<int>();
            var queue = new Queue<int>();

            for(var v= 0;v<g.NumV();v++)
            {
                degree[v] = g.InDegree(v);
                if(degree[v]==0)
                {
                    queue.Enqueue(v);
                }
            }

            while(queue.Count!=0)
            {
                var n = queue.Count;

                for(var i = 0;i<n;i++)
                {
                    var v = queue.Dequeue();
                    order.Add(v);

                    foreach(var w in g.EdgesFrom(v))
                    {
                        degree[w]--;
                        if(degree[w]==0)
                        {
                            queue.Enqueue(w);
                        }
                    }
                }
            }
        }

        public int[] TopologyOrder()
        {
            return order.ToArray();
        }
    }
}
