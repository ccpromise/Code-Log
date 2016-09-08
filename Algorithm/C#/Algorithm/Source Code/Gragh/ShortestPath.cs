using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm.Source_Code.Chapter1;

namespace Algorithm.Source_Code.Chapter3
{
    /// <summary>
    /// Summary of Chapter4 Gragh:
    /// 1\ Knowledge: 4 kinds of gragh
    ///     undirected gragh(dfs, bfs, CC)
    ///     directed gragh(cycle detection, topological order, SCC)
    ///     edge-weighted undirected gragh(MST)
    ///     edge-weigthed directed gragh(shortest path)
    /// 2\ Design Pattern:
    ///     Figure out the usage first and design API first according to the usage.
    ///     Figure out data structure and algorithm to implement API.
    ///     Decouple the data and the operation you can apply on this data.
    ///     Preprocess in constructor that can efficiently support clients' query.
    /// </summary>
    
    // no negative weight
    public class ShortestPath
    {
    	public ShortestPath
    }
    
    // no cycle
    public class ShortestPath
    {
    	private IList<int> topologicalOrder;
    	private DirectedGragh g;
    	private int N;
    	private IList<double> distTo;
    	private IList<double> pathTo;
    	
    	public ShortestPath(DirectedGragh g)
    	{
    		this.g = g;
    		topologicalOrder = Gragh.TopologicalSort(g);
    		N = g.numV();
    		distTo = new List<double>(N);
    		pathTo = new List<int>(N);
    		for(var i = 0; i < N; i++)
    		{
    			distTo = double.MaxValue;
    		}
    		distTo[topologicalOrder[0]] = 0;
    		visit(0);
    	}
    	
    	public double shortestDist(int v, int w)
    	{
    		if(v >= N || w >= N)
    		{
    			throw new Exception();
    		}
    		int i = 0;
    		while(i < N && topologicalOrder[i] != v)
    		{
    			if(topologicalOrder[i] == w)
    			{
    				return double.MaxValue;
    			}
    		}
    		return distTo[w] - distTo[v];
    	}
    	
    	public IList<int> shortestPath(int v, int w)
    	{
    		
    	}
    	
    	private void visit(int idx)
    	{
    		var v = topologicalOrder[idx];
    		foreach(var e in g.EdgeFrom(v))
    		{
    			var w = e.To();
    			if(distTo[w] > distTo[v]+e.Weight())
    			{
    				distTo[w] = distTo[v]+e.Weight();
    			}
    		}
    		if(idx <  g.numV()-1)
    		{
    			visitopologicalOrder(idx+1);
    		}    		
    	}
    }
    
    public class ShortestPath
    {
        private EdgeWeightedDigragh g;
        private double[] distTo;
        private IndexMinPQ pq;
        private int[] pathTo;
        private int startPoint;

        public ShortestPath(EdgeWeightedDigragh g, int v)
        {
            var numV = g.NumV();

            this.g = g;
            distTo = new double[numV];
            pq = new IndexMinPQ(numV);
            pathTo = new int[numV];
            startPoint = v;
            for (var i = 0; i < numV; v++)
            {
                distTo[i] = double.MaxValue;
            }
            distTo[v] = 0;
            Visit(0);

            while (pq.Size() != 0)
            {
                var min = pq.DelMin();

                Visit(min.Item1);
            }
        }

        public double DistTo(int w)
        {
            return distTo[w];
        }

        public IList<int> ShortestPathTo(int w)
        {
            var ret = new List<int>();

            while (w != startPoint)
            {
                ret.Add(w);
                w = pathTo[w];
            }
            ret.Add(w);
            return ret;
        }

        private void Visit(int v)
        {
            foreach (var e in g.Adj(v))
            {
                var w = e.To();

                if (distTo[w] > distTo[v] + e.Weight())
                {
                    distTo[w] = distTo[v] + e.Weight();
                    pathTo[w] = v;
                    if (pq.Contains(w))
                    {
                        pq[w] = distTo[w];
                    }
                    else
                    {
                        pq.Insert(w, distTo[w]);
                    }
                }
            }
            var next = pq.DelMin();
            Visit(next.Item1());
        }
    }

    public class IndexMinPQ
    {
        private double[] arr;
        public IndexMinPQ(int n)
        { }

        public int Size()
        {
            return 0;
        }

        public Tuple<int, double> DelMin()
        {
            return new Tuple<int, double>(0, 0);
        }

        public bool Contains(int v)
        {
            return true;
        }

        public double this[int i]
        {
            get { return i; }
            set { arr[i] = value; }
        }

        public void Insert(int i, double j)
        { }

    }

    //public class IndexMinPQ<T> where T:IComparable<T>
    //{
    //    private T[] keys;
    //    private ST_HashTable_SeparateChaining<int, T> st;
    //    private int amount;
    //    private int size;
    //    private int minIdx;
    //    private int maxIdx;

    //    public IndexMinPQ(int N)
    //    {
    //        keys = new T[N];
    //        st = new ST_HashTable_SeparateChaining<int, T>(N);
    //        amount = N;
    //        size = 0;
    //    }

    //    public void Insert(int idx, T key)
    //    {
    //        if (idx >= amount || st.Contains(idx))
    //        {
    //            throw new InvalidOperationException();
    //        }
    //        keys[size] = key;
    //        Swim(size);
    //        st.Insert(idx, key);
    //        size++;
    //    }

    //    public Tuple<int, T> DelMin()
    //    {
    //        Swap(0, size - 1);
    //    }

    //    public T MinKey()
    //    {
    //        return keys[0];
    //    }

    //    public int MinIdx()
    //    {
    //        return index[minIdx];
    //    }

    //    public bool Contains(int idx)
    //    {
    //        return index[idx] != -1;
    //    }

    //    public void Change(int idx, T key)
    //    {
    //        if (index[idx] == -1)
    //        {
    //            throw new InvalidOperationException();
    //        }
    //        keys[index[idx]] = key;

    //        Swim(index[idx]);
    //        Sink(index[idx]);
    //    }

    //    public int Size()
    //    {
    //        return size;
    //    }

    //    public T this[int idx]
    //    { }

    //    private void Swim(int i)
    //    {
    //        var p = (i - 1) / 2;

    //        while (p >= 0 && keys[p].CompareTo(keys[i]) > 0)
    //        {
    //            Swap(p, i);
    //            i = p;
    //            p = (i - 1) / 2;
    //        }

    //    }

    //    private void Sink(int i)
    //    { }
    //}   
    //public class DirectedWeightEdge : IComparable<DirectedWeightEdge>
    //{
    //    private int v;
    //    private int w;
    //    private double weight;

    //    public DirectedWeightEdge(int v, int w, double weight)
    //    {
    //        this.v = v;
    //        this.w = w;
    //        this.weight = weight;
    //    }

    //    public int From()
    //    {
    //        return v;
    //    }

    //    public int To()
    //    {
    //        return w;
    //    }

    //    public double Weight()
    //    {
    //        return weight;
    //    }

    //    public int CompareTo(DirectedWeightEdge other)
    //    {
    //        var ret = this.Weight() - other.Weight();

    //        if(ret>0)
    //        {
    //            return 1;
    //        }
    //        if(ret<0)
    //        {
    //            return -1;
    //        }
    //        else
    //        {
    //            return 0;
    //        }
    //    }
    //}

    ///// <summary>
    ///// Goal: to find the shortest path from s to every other vertex
    ///// </summary>
    //public class EdgeWeightDiGragh
    //{
    //    private int numV;
    //    private IList<DirectedWeightEdge>[] digragh;
    //    public int NumV
    //    {
    //        get { return numV; }
    //        private set { }
    //    }

    //    public EdgeWeightDiGragh(int N)
    //    {
    //        numV = N;
    //        digragh = new IList<DirectedWeightEdge>[N];
    //        for(var v = 0;v< N;v++)
    //        {
    //            digragh[v] = new List<DirectedWeightEdge>();
    //        }
    //    }

    //    public EdgeWeightDiGragh(int N, DirectedWeightEdge[] edges):this(N)
    //    {
    //        foreach (var e in edges)
    //        {
    //            var v = e.From();

    //            digragh[v].Add(e);
    //        }
    //    }

    //    public void AddEdge(DirectedWeightEdge e)
    //    {
    //        digragh[e.From()].Add(e);
    //    }

    //    public IList<DirectedWeightEdge> Adj(int v)
    //    {
    //        return digragh[v];
    //    }
    //}

    ///// <summary>
    ///// very close to MST.What's the connection?
    ///// MST is to choose the next shortest edge that can connect a vertex to the tree.
    ///// SP is to choose the next vertex that has shortest distance to the source vertex.
    ///// </summary>
    //public class DijkstraSP
    //{
    //    private EdgeWeightDiGragh g;
    //    private int numV;
    //    private double[] distTo;
    //    private DirectedWeightEdge[] edgeTo;
    //    private bool[] visited;
    //    private MinPQ queue;

    //    public DijkstraSP(EdgeWeightDiGragh G, int s)
    //    {
    //        numV = G.NumV;
    //        g = G;
    //        distTo = new double[numV];
    //        edgeTo = new DirectedWeightEdge[numV];
    //        visited = new bool[numV];
    //        queue = new IndexMinPQ(numV);

    //        for(var v = 0;v< numV;v++)
    //        {
    //            distTo[v] = int.MaxValue;
    //        }
    //        distTo[s] = 0;

    //        queue.Enqueue(s, 0);
    //        while(queue.Count()!=0)
    //        {
    //            var v = queue.Dequeue();

    //            Relax(v);
    //        }
    //    }

    //    public double DistTo(int v)
    //    {
    //        return distTo[v];
    //    }

    //    public IList<DirectedWeightEdge> PathTo(int v)
    //    {
    //        var ret = new List<DirectedWeightEdge>();
    //        var e = edgeTo[v];
    //        var w = e.From();

    //        while (distTo[w] != 0)
    //        {
    //            ret.Insert(0, e);
    //            e = edgeTo[w];
    //            w = e.From();
    //        }
    //        return ret;
    //    }

    //    public bool HasNegativeCycle()
    //    {
    //        var marked = new bool[numV];
    //        var edges = new DirectedWeightEdge[numV];

    //        return Dfs(0, marked, edges);
    //    }

    //    private bool Dfs(int v, bool[] marked, DirectedWeightEdge[] edges)
    //    {
    //        marked[v] = true;
    //        foreach (var e in g.Adj(v))
    //        {
    //            var w = e.To();
    //            edges[w] = e;
    //            if (marked[w])
    //            {
    //                if(CycleWeight(v, edges) < 0)
    //                {
    //                    return false;
    //                }
    //            }
    //            else
    //            {
    //                Dfs(w, marked, edges);
    //            }
    //        }
    //        marked[v] = false;
    //        return true;
    //    }

    //    private double CycleWeight(int v, DirectedWeightEdge[] edges)
    //    {
    //        var w = v;
    //        var e = edges[v];
    //        var sum = 0.0;

    //        do
    //        {
    //            sum += e.Weight();
    //            w = e.From();
    //            e = edges[w];
    //        } while (w != v);
    //        return sum;
    //    }

    //    private struct Dist:IComparable<Dist>
    //    {
    //        int vertex;
    //        double distance;

    //        public Dist(int x, double d)
    //        {
    //            vertex = x;
    //            distance = d;
    //        }
    //        public int CompareTo(Dist other)
    //        {
    //            var ret = this.distance - other.distance;
    //            if(ret>0)
    //            {
    //                return 1;
    //            }
    //            if(ret<0)
    //            {
    //                return -1;
    //            }
    //            return 0;
    //        }
    //    }
    //    private void Relax(int v)
    //    {
    //        foreach(var e in g.Adj(v))
    //        {
    //            var w = e.To();

    //            if(distTo[w]>distTo[v]+e.Weight())
    //            {
    //                distTo[w] = distTo[v] + e.Weight();
    //                edgeTo[w] = e;
    //                if(queue.Contains(w))
    //                {
    //                    queue.DecreaseKey(w, distTo[w]);
    //                }
    //                else
    //                {
    //                    queue.Enqueue(w, distTo[w]);
    //                }
    //            }
    //        }
    //    }
    //}

    //public class TopologicalOrderSP
    //{
    //    private EdgeWeightDiGragh g;
    //    private int numV;
    //    private double[] distTo;
    //    private DirectedWeightEdge[] edgeTo;
    //    public TopologicalOrderSP(EdgeWeightDiGragh g, int s)
    //    {
    //        numV = g.NumV;
    //        distTo = new double[numV];
    //        edgeTo = new DirectedWeightEdge[numV];
    //        this.g = g;

    //        for (var v = 0; v < numV; v++)
    //        {
    //            distTo[v] = int.MaxValue;
    //        }
    //        distTo[s] = 0;

    //        var order = TopologicalSort.SortDFS(g);
    //        foreach (var v in order)
    //        {
    //            Relax(v);
    //        }
    //    }

    //    public double DistTo(int v)
    //    {
    //        return distTo[v];
    //    }

    //    public IList<DirectedWeightEdge> PathTo(int v)
    //    {
    //        var ret = new List<DirectedWeightEdge>();

    //        while (distTo[v] != 0)
    //        {
    //            var e = edgeTo[v];
    //            ret.Insert(0, e);
    //            v = e.From();
    //        }
    //        return ret;
    //    }

    //    private void Relax(int v)
    //    {
    //        foreach (var e in g.Adj(v))
    //        {
    //            var w = e.To();
    //            edgeTo[w] = e;
    //            if (distTo[w] > distTo[v] + e.Weight())
    //            {
    //                distTo[w] = distTo[v] + e.Weight();
    //            }
    //        }
    //    }
    //}
}
