using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Source_Code.Chapter3
{
    /// <summary>
    /// 1\ prove of algorithm: dfs(g) in the reverse postorder of dfs(gr).
    /// 2\ design API first.
    /// 3\ visited[] id[] can integrated. But to make things moer clear, separate them.
    /// </summary>
    public class StrongConnectedComponent
    {
        private Digragh g;
        private bool[] visited;
        private int[] id;
        private int count;

        public StrongConnectedComponent(Digragh g)
        {
            this.g = g;
            visited = new bool[g.NumV()];
            id = new int[g.NumV()];
            count = 0;
            var order = new OrderDigragh(g.Reverse()).ReversePostOrder();

            foreach (var v in order)
            {
                if (!visited[v])
                {
                    count++;
                    Dfs(v);
                }
            }
        }

        public bool IsStrongConnected(int v, int w)
        {
            return id[v] == id[w];
        }

        public int NumStrongConnectedComponent()
        {
            return count;
        }

        private void Dfs(int v)
        {
            visited[v] = true;
            id[v] = count;

            foreach (var w in g.EdgesFrom(v))
            {
                if (!visited[w])
                {
                    Dfs(w);
                }
            }
        }
    }



    /// <summary>
    /// two dfs: reverse g, dfs and obtain the topological order. Do dfs to g again.
    /// if you define function parameters as the the field of class, then no need to pass by reference.
    /// </summary>
    //public class StrongConnectedComponent
    //{
    //    private int[] cc;
    //    private int count;
    //    private bool[] visited;
    //    private Digragh g;

    //    public StrongConnectedComponent(Digragh g)
    //    {
    //        var N = g.NumV();
    //        var h = g.Reverse();
    //        var sort = TopologicalSort.SortDFS(h);
    //        this.g = g;
    //        visited = new bool[N];
    //        cc = new int[N];
    //        count = 0;

    //        foreach (var v in sort)
    //        {
    //            if (!visited[v])
    //            {
    //                count++;
    //                Dfs(v);
    //            }
    //        }
    //    }
    //    private void Dfs(int v)
    //    {
    //        cc[v] = count;
    //        visited[v] = true;

    //        foreach (var w in g.EdgesFrom(v))
    //        {
    //            if (!visited[w])
    //            {
    //                Dfs(w);
    //            }
    //        }
    //    }
    //}
}
