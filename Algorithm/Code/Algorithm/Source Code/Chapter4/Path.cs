using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Source_Code.Chapter3
{
    public class Path
    {
        private BreadthFirstSearch bfs;
        public Path(Gragh g, int v)
        {
            bfs = new BreadthFirstSearch(g, v);
        }

        public bool HasPathTo(int w)
        {
            return bfs.IsConnected(w);
        }

        public int[] ShortestPathTo(int w)
        {
            return bfs.ShortestPathTo(w);
        }
    }
}
