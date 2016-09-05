using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Source_Code.Chapter3
{
    public class Gragh
    {
        private IList<int>[] g;
        private int V;
        private int E;
        public Gragh(int V)
        {
            this.V = V;
            E = 0;
            g = new IList<int>[V];

            for(var v = 0;v< V;v++)
            {
                g[v] = new List<int>();
            }
        }

        public void AddEdge(int v, int w)
        {
            if(!g[v].Contains(w))
            {
                g[v].Add(w);
                g[w].Add(v);
                E++;
            }
        }

        public int NumV()
        {
            return V;
        }

        public int NumE()
        {
            return E;
        }

        public int[] Adj(int v)
        {
            return g[v] as int[];
        }

        public int Degree(int v)
        {
            return g[v].Count;
        }
    }
}
