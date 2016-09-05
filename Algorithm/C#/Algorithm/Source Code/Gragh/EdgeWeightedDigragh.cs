using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Source_Code.Chapter3
{
    public class EdgeWeightedDigragh
    {
        private int numV;
        private int numE;
        private IList<DiEdge>[] g;

        public EdgeWeightedDigragh(int V)
        {
            numV = V;
            numE = 0;
            g = new IList<DiEdge>[V];

            for (var v = 0; v < V; v++)
            {
                g[v] = new List<DiEdge>();
            }
        }

        public void AddEdge(DiEdge e)
        {
            g[e.From()].Add(e);
            numE++;
        }

        public IList<DiEdge> Adj(int v)
        {
            return g[v];
        }

        public IList<DiEdge> Edges()
        {
            var ret = new List<DiEdge>();

            foreach (var edges in g)
            {
                ret.AddRange(edges);
            }
            return ret;
        }

        public int NumV()
        {
            return numV;
        }

        public int NumE()
        {
            return numE;
        }
    }

    public class DiEdge
    {
        private int v;
        private int w;
        private double weight;

        public DiEdge(int v, int w, double weight)
        {
            this.v = v;
            this.w = w;
            this.weight = weight;
        }

        public double Weight()
        {
            return weight;
        }

        public int From()
        {
            return v;
        }

        public int To()
        {
            return w;
        }
    }
}
