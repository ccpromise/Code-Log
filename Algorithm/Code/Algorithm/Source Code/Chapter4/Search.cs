using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Source_Code.Chapter3
{
    /// <summary>
    /// 1\ To separate the implementation of gragh algorithms from the gragh representation, it means you should only use the API
    ///     of gragh class.
    ///     If you plan to implement a number of algorithms, you'd better to create individual class for each task.
    /// 2\ Decouple different operations.
    /// 3\ Design Pattern: ***preprocess the gragh in constructor***, build data structures that can efficiently support the client's request.
    /// </summary>
    public class DfsSearch
    {
        private DepthFirstSearch dfs;
        private int V;
        public DfsSearch(Gragh g, int v)
        {
            dfs = new DepthFirstSearch(g, v);
            V = g.NumV();
        }

        public bool IsConnected(int w)
        {
            return dfs.IsConnected(w);
        }

        public int[] ConnectedVertices()
        {
            var ret = new int[dfs.Count()];
            var i = 0;

            for(var w = 0;w< V;w++)
            {
                if(dfs.IsConnected(w))
                {
                    ret[i++] = w;
                }
            }
            return ret;
        }

        public int Count()
        {
            return dfs.Count();
        }
    }

    public class BfsSearch
    {
        private BreadthFirstSearch bfs;
        public BfsSearch(Gragh g, int v)
        {
            bfs = new BreadthFirstSearch(g, v);
        }

        public bool IsConnected(int w)
        {
            return bfs.IsConnected(w);
        }

        public int[] ConnectedVertices()
        {
            return bfs.ConnectedVertices();
        }

        public int Count()
        {
            return bfs.Count();
        }
    }


    internal class DepthFirstSearch
    {
        private bool[] visited;
        private Gragh g;
        private int count;
        private IList<int>[] path;
        public DepthFirstSearch(Gragh g, int v)
        {
            visited = new bool[g.NumV()];
            this.g = g;
            count = 0;

            DFS(v);
        }

        public bool IsConnected(int w)
        {
            return visited[w];
        }

        public int Count()
        {
            return count;
        }
        private void DFS(int v)
        {
            visited[v] = true;
            foreach(var w in g.Adj(v))
            {
                if(!visited[w])
                {
                    count++;
                    DFS(w);
                }
            }
        }
    }

    internal class BreadthFirstSearch
    {
        private int[] path;
        private int count;
        private Gragh g;
        public BreadthFirstSearch(Gragh g, int v)
        {
            this.g = g;
            count = 0;
            path = new int[g.NumV()];

            for(var i = 0; i<path.Count();i++)
            {
                path[i] = -1;
            }
            BFS(v);
        }

        public bool IsConnected(int w)
        {
            return path[w] != -1;
        }

        public int[] ConnectedVertices()
        {
            var ret = new List<int>();

            foreach(var w in path)
            {
                if(path[w]!=-1 && path[w]!=w)
                {
                    ret.Add(w);
                }
            }
            return ret.ToArray();
        }

        public int Count()
        {
            return count;
        }

        public int[] ShortestPathTo(int w)
        {
            var ret = new List<int>();

            while(path[w]!=w)
            {
                ret.Add(w);
                w = path[w];
            }
            ret.Add(w);
            ret.Reverse();

            return ret.ToArray();
        }

        private void BFS(int v)
        {
            var queue = new Queue<int>();

            queue.Enqueue(v);
            path[v] = v;
            while(queue.Count()!=0)
            {
                var n = queue.Count();

                for(var i = 0;i< n;i++)
                {
                    var w = queue.Dequeue();

                    foreach(var x in g.Adj(w))
                    {
                        if(path[x]==-1)
                        {
                            queue.Enqueue(x);
                            path[x] = w;
                            count++;
                        }
                    }
                }
            }
        }
    }
}
