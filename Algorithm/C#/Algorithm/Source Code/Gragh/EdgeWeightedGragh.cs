using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Source_Code.Chapter3
{
    /// <summary>
    /// An undirected gragh with weighted edges.
    /// </summary>
    public class EdgeWeightedGragh
    {
        private int numV;
        private int numE;
        private IList<Edge>[] g;
        private IList<Edge> edges;

        public EdgeWeightedGragh(int V)
        {
            numV = V;
            numE = 0;
            g = new IList<Edge>[V];
            edges = new List<Edge>();

            for (var v = 0; v < V; v++)
            {
                g[v] = new List<Edge>();
            }
        }

        public void AddEdge(Edge e)
        {
            var v = e.Either();
            var w = e.Another(v);

            g[v].Add(e);
            g[w].Add(e);
            edges.Add(e);
            numE++;
        }

        public IList<Edge> Adj(int v)
        {
            return g[v];
        }

        public IList<Edge> Edges()
        {
            return edges;
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

    public class Edge:IComparable<Edge>
    {
        private int v;
        private int w;
        private double weight;

        public Edge(int v, int w, double weight)
        {
            this.v = v;
            this.w = w;
            this.weight = weight;
        }

        public double Weight()
        {
            return weight;
        }

        public int Another(int x)
        {
            return x == v ? w : v;
        }

        public int Either()
        {
            return v;
        }

        public int CompareTo(Edge other)
        {
            return (int)(this.Weight() - other.Weight());
        }
    }
}
