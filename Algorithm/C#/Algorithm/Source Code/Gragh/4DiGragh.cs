using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm.Source_Code.Chapter1;
using Algorithm.Source_Code.Chapter2;

namespace Algorithm.Source_Code.Chapter3
{
    /// <summary>
    /// for data abstraction, you should not use g's data structure like g[v]. You should use g.Adj(v) instead.
    /// </summary>
    /// 
    public class Digragh
    {
        private IList<int>[] edgeFrom;
        private IList<int>[] edgeTo;
        private int V;
        private int E;
        public Digragh(int V)
        {
            edgeFrom = new IList<int>[V];
            edgeTo = new IList<int>[V];
            this.V = V;
            E = 0;

            for(var i = 0;i< V;i++)
            {
                edgeFrom[i] = new List<int>();
                edgeTo[i] = new List<int>();
            }
        }

        public void AddEdge(int v, int w)
        {
            if(!edgeFrom[v].Contains(w))
            {
                edgeFrom[v].Add(w);
                edgeTo[w].Add(v);
                E++;
            }
        }

        // Collection of edges pointing from v
        public int[] EdgesFrom(int v)
        {
            return edgeFrom[v].ToArray();
        }

        public int[] EdgesTo(int v)
        {
            return edgeTo[v].ToArray();
        }

        public Digragh Reverse()
        {
            var reverse = new Digragh(this.V);

            for(var v = 0;v< V;v++)
            {
                foreach(var w in EdgesFrom(v))
                {
                    reverse.AddEdge(w, v);
                }
            }
            return reverse;
        }

        public int InDegree(int v)
        {
            return edgeTo[v].Count;
        }

        public int OutDegree(int v)
        {
            return edgeFrom[v].Count;
        }

        public int NumV()
        {
            return V;
        }

        public int NumE()
        {
            return E;
        }
    }

    //public class DiGragh
    //{
    //    private IList<int>[] gragh;
    //    private int numV;
    //    private int numE;
    //    private int[] indegree;
    //    private int[] outdegree;
    //    public int NumV
    //    {
    //        get
    //        {
    //            return this.numV;
    //        }
    //        private set { }
    //    }
    //    public int NumE
    //    {
    //        get
    //        {
    //            return this.numE;
    //        }
    //        private set { }
    //    }

    //    public DiGragh(int numV, int[,] adj)
    //    { 
    //        gragh = new IList<int>[numV];
    //        indegree = new int[numV];
    //        outdegree = new int[numV];
    //        this.numV = numV;
    //        this.numE = 0;
    //        for(var i = 0; i<numV;i++)
    //        {
    //            gragh[i] = new List<int>();
    //        }
    //        for(var i = 0; i<adj.GetLength(0);i++)
    //        {
    //            int v = adj[i, 0];
    //            int w = adj[i, 1];
    //            gragh[v].Add(w);
    //            outdegree[v]++;
    //            indegree[w]++;
    //            numE++;
    //        }
    //    }

    //    public IList<int> Adj(int v)
    //    {
    //        return gragh[v];
    //    }

    //    public int InDegree(int v)
    //    {
    //        return indegree[v];
    //    }

    //    public int OutDegree(int v)
    //    {
    //        return outdegree[v];
    //    }

    //    public void AddEdge(int v, int w)
    //    { 
    //        gragh[v].Add(w);
    //        outdegree[v]++;
    //        indegree[w]++;
    //        numE++;
    //    }

    //    public bool ContainsCycle()
    //    {
    //        var visited = new bool[numV];
    //        var path = new HashSet<int>();

    //        for(var v = 0; v<numV;v++)
    //        {
    //            if(!visited[v] && HasCycle(v, path, visited))
    //            {
    //                return true;
    //            }
    //        }
    //        return false;
    //    }

    //    public bool IsBipartite()
    //    {
    //        var bipartite = new int[numV];

    //        for (var v = 0; v < numV; v++)
    //        {
    //            if (bipartite[v] == 0 && !VisitBipartite(v, bipartite, 1))
    //            {
    //                return false;
    //            }
    //        }
    //        return true;
    //    }

    //    public static void DFS(DiGragh g, int v)
    //    { }

    //    public static void BFS(DiGragh g, int v)
    //    { }

    //    public DiGragh Reverse()
    //    {
    //        var N = numV;
    //        var E = numE;
    //        var adj = new int[E, 2];
    //        var i = 0;

    //        for (var v = 0; v < N; v++)
    //        {
    //            foreach (var w in this.Adj(v))
    //            {
    //                adj[i, 0] = w;
    //                adj[i, 1] = v;
    //                i++;
    //            }
    //        }
    //        return new DiGragh(N, adj);
    //    }

    //    private bool HasCycle(int v, HashSet<int> path, bool[] visited)
    //    {
    //        visited[v] = true;
    //        if (!path.Add(v))
    //        {
    //            return true;
    //        }

    //        foreach (var w in gragh[v])
    //        {
    //            if (HasCycle(w, path, visited))
    //            {
    //                return true;
    //            }
    //        }
    //        path.Remove(v);
    //        return false;
    //    }

    //    private bool VisitBipartite(int v, int[] bipartite, int side)
    //    {
    //        bipartite[v] = side;

    //        foreach (var w in gragh[v])
    //        {
    //            if (bipartite[w] == side || (bipartite[w] == 0 && !VisitBipartite(w, bipartite, -side)))
    //            {
    //                return false;
    //            }
    //        }
    //        return true;
    //        return true;
    //    }
    //}
}
