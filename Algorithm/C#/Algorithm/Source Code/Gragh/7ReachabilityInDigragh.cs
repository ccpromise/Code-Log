using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Source_Code.Chapter3
{
    /// <summary>
    /// Every good implementation:
    /// 1\different search strategy use different API, but share the same core code.
    /// 2\build class for specific task. Different API for code reuse.
    /// </summary>
    public static class ReachabilityInDigragh
    {
        public class SingleSource
        {
            private DigraghDFS dfs;
            private int v;
            public SingleSource(Digragh g, int v)
            {
                dfs = new DigraghDFS(g, v);
                this.v = v;
            }

            public bool IsReachable(int w)
            {
                return dfs.IsConnected(v, w);
            }

            public int[] PathTo(int w)
            {
                return dfs.Path(v, w);
            }
        }

        public class DoubleSource
        {
            private DigraghDFS dfs;
            public DoubleSource(Digragh g)
            {
                dfs = new DigraghDFS(g);
            }

            public bool IsReachable(int v, int w)
            {
                return dfs.IsConnected(v, w);
            }

            public int[] Path(int v, int w)
            {
                return dfs.Path(v, w);
            }
        }

        internal class DigraghDFS
        {
            private int[] visited;
            private Digragh g;
            private int count;
            private int[] path;
            public DigraghDFS(Digragh g, int v)
            {
                visited = new int[g.NumV()];
                path = new int[g.NumV()];
                this.g = g;
                count = 1;

                path[v] = v;
                DFSHelper(v);
            }

            public DigraghDFS(Digragh g)
            {
                visited = new int[g.NumV()];
                this.g = g;

                for(var v = 0;v<g.NumV();v++)
                {
                    if(visited[v]==0)
                    {
                        path[v] = v;
                        DFSHelper(v);
                    }
                    count++;
                }
            }

            public bool IsConnected(int v, int w)
            {
                return visited[v] == visited[w];
            }

            public int[] Path(int v, int w)
            {
                var ret = new List<int>();

                while(w != v)
                {
                    ret.Add(w);
                    w = path[w];
                }
                ret.Add(w);
                return ret.ToArray();
            }
            private void DFSHelper(int v)
            {
                visited[v] = count;

                foreach(var w in g.EdgesFrom(v))
                {
                    if(visited[w]==0)
                    {
                        path[w] = v;
                        DFSHelper(w);
                    }
                }
            }
        }
    }
}
