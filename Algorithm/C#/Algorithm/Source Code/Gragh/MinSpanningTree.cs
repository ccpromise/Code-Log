using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm.Source_Code.Chapter1;

namespace Algorithm.Source_Code.Chapter3
{
    /// <summary>
    /// Prime: add an edge which connects a vertex to the growing tree.
    /// Think about the data structure: what kind of data structures you should maintain? 
    ///     int[] marked: the vertex already in MST to prevent cycle.
    ///     edges[] MST
    ///     MinPQ edges: the candidate edges.
    /// Finish the first natural version. Improve it by defining some common operation as functions.
    /// </summary>
    public class MST_Prim
    {
        private PriorityQueue<Edge> candidates;
        private bool[] marked;
        private IList<Edge> MST;
        private int numV;
        private EdgeWeightedGragh g;
        private double weight;

        public MST_Prim(EdgeWeightedGragh g)
        {
            candidates = new PriorityQueue<Edge>(g.NumE());
            marked = new bool[g.NumV()];
            MST = new List<Edge>();
            this.g = g;
            weight = 0;

            // start from a random point. Add all its edges to the candidates.
            // marked[0]=true means vertex 0 is in the MST.
            Visit(0);

            while (MST.Count() < g.NumV() - 1)
            {
                // candidates maintain all edges that adding one of which will add ONE more vertex to the MST
                // Contrast to Kruskal, which may add ONE or TWO vertices to the MST at one time.
                Edge e = candidates.DelMin();
                var v = e.Either();
                var w = e.Another(v);

                // if v and w are in MST, add an edge v-w will cause a cycle in MST.
                if (marked[v] && marked[w])
                {
                    continue;
                }
                MST.Add(e);
                weight += e.Weight();
                // visit(v) to add edges connecting v to candidates.
                if (!marked[v])
                {
                    Visit(v);
                }
                if (!marked[w])
                {
                    Visit(w);
                }
            }
        }

        public IList<Edge> Edges()
        {
            return MST;
        }

        public double Weight()
        {
            return weight;
        }

        private void Visit(int v)
        {
            marked[v] = true;
            foreach (var edge in g.Adj(v))
            {
                var other = edge.Another(v);

                // marker[other]==true means the edge v-other is already in the candidate.
                if (!marked[other])
                {
                    candidates.Insert(edge);
                }
            }
        }
    }

    /// <summary>
    /// Kruskal: add edges according to the ascending order of weight
    /// </summary>
    public class MST_Kruskal
    {
        private IList<Edge> MST;
        private double weight;

        public MST_Kruskal(EdgeWeightedGragh g)
        {
            // candidates store all edges in g
            // uf to decide whether add an edge to MST will cause a cycle.
            var candidates = new PriorityQueue<Edge>(g.NumE());
            var uf = new UnionFind_QuickUnion(g.NumV());
            MST = new List<Edge>();
            weight = 0;

            foreach (var e in g.Edges())
            {
                // Insert all edges to candidates
                candidates.Insert(e);
            }
            while (MST.Count < g.NumV() - 1)
            {
                // pop out in ascending order of weight
                var e = candidates.DelMin();
                var v = e.Either();
                var w = e.Another(v);

                // add this edge will cause a cycle in MST because v and w is already connected.
                // so skip this edge.
                if (uf.IsConnected(v, w))
                {
                    continue;
                }
                // otherwise add this edge to MST, union v and w.
                MST.Add(e);
                uf.Union(v, w);
                weight += e.Weight();
            }
        }

        public IList<Edge> Edges()
        {
            return MST;
        }

        public double Weight()
        {
            return weight;
        }
    }
}
