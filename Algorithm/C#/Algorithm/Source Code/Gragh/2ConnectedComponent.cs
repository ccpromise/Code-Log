using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Source_Code.Chapter3
{
    /// <summary>
    /// If you need to check whether two points is connected in a gragh many times, then do dfs one time for entire gragh.
    /// </summary>
    public class ConnectedComponent
    {
        private GraghDFS dfs;
        public ConnectedComponent(Gragh g)
        {
            dfs = new GraghDFS(g);
        }

        public int NumComponent()
        {
            return dfs.NumComponent();
        }
        public bool IsConnected(int v, int w)
        {
            return dfs.IsConnected(v, w);
        }
    }

    internal class GraghDFS
    {
        private int[] visited;
        private int count;
        private Gragh g;
        public GraghDFS(Gragh g)
        {
            this.g = g;
            visited = new int[g.NumV()];
            count = 0;

            for(var v = 0;v<g.NumV();v++)
            {
                if(visited[v]==0)
                {
                    count++;
                    Dfs(v);
                }
            }
        }

        public bool IsConnected(int v, int w)
        {
            return visited[v] == visited[w];
        }

        public int NumComponent()
        {
            return count;
        }

        private void Dfs(int v)
        {
            visited[v] = count;
            foreach(var w in g.Adj(v))
            {
                if(visited[w]==0)
                {
                    Dfs(w);
                }
            }
        }
    }
}
