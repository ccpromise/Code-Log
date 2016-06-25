using System;
using System.Collections.Generic;
using SICPPractise.Algorithm;
using SICPPractise.Algorithm.Internal;


namespace SICPPractise
{
    class Program
    {
        static void Main(string[] args)
        {
            var pre = new int[3,2] { {0,2},{1,2}, {0,1} };
            var i = CanFinish(3, pre);
            Console.ReadKey();


        }
        public static bool CanFinish(int numCourses, int[,] prerequisites)
        {
            var schedule = MakeGragh(numCourses, prerequisites);
            taken = new bool[numCourses];

            for (var i = 0; i < numCourses; i++)
            {
                var path = new HashSet<int>();
                if (!taken[i] && !DFS(schedule, i, path))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool[] taken;

        private static bool DFS(IList<int>[] g, int v, HashSet<int> path)
        {
            if (!path.Add(v))
            {
                return false;
            }
            taken[v] = true;

            foreach (var adj in g[v])
            {
                if (!DFS(g, adj, path))
                {
                    return false;
                }
            }
            path.Remove(v);
            return true;
        }

        private static IList<int>[] MakeGragh(int nVertices, int[,] edges)
        {
            var gragh = new List<int>[nVertices];

            for (var i = 0; i < nVertices; i++)
            {
                gragh[i] = new List<int>();
            }

            for (var i = 0; i < edges.GetLength(0); i++)
            {
                gragh[edges[i, 0]].Add(edges[i, 1]);
            }
            return gragh;
        }
    }
}
