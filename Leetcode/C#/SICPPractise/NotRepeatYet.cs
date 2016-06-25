using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SICPPractise
{
    class NotRepeatYet
    {
        //TODO: To improve, more clear
        public int NumDecodings1(string s)
        {
            NumDecodings1Helper(s, 0);
            return countforDecoding;
        }
        private int countforDecoding = 0;
        private void NumDecodings1Helper(string s, int begin)
        {
            if (begin == s.Length)
            {
                countforDecoding++;
                return;
            }
            if (begin < s.Length && s[begin] != '0')
            {
                NumDecodings1Helper(s, begin + 1);
                if (begin + 1 < s.Length)
                {
                    if (s[begin] == '1' || (s[begin] == '2' && s[begin + 1] <= '6'))
                    {
                        NumDecodings1Helper(s, begin + 2);
                    }
                }
            }
        }

        public int NumDecodings2(string s)
        {
            if (s == "" || s[0] == '0')
            {
                return 0;
            }
            var count = new int[s.Length + 1];
            count[0] = 1;
            count[1] = 1;

            for (var i = 2; i <= s.Length; i++)
            {
                if (s[i - 1] == '0')
                {
                    if (s[i - 2] == '1' || s[i - 2] == '2')
                    {
                        count[i] = count[i - 2];
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    count[i] = count[i - 1];
                    if (s[i - 2] == '1' || (s[i - 2] == '2' && s[i - 1] <= '6'))
                    {
                        count[i] += count[i - 2];
                    }
                }
            }
            return count.Last();
        }

        public int NumDecodings3(string s)
        {
            if(s.Length==0)
            {
                return 0;
            }
            var count = new int[s.Length + 1];
            count[0] = 1;
            count[1] = s[0] == '0' ? 0 : 1;

            for(var i = 2;i<= s.Length;i++)
            {
                if(s[i-1]=='0')
                {
                    continue;
                }
                count[i] = count[i - 1];
                if(s[i-2]=='1' || s[i-2]=='2' && s[i-1]<='6')
                {
                    count[i] += count[i - 2];
                }
            }
            return count.Last();
        }

        public int IntegerBreak(int n)
        {
            var count = new int[n + 1];
            count[1] = 2;

            for(var i = 2; i<= n;i++)
            {
                count[i] = int.MinValue;
                for(var j = 1; j<=i-1;j++)
                {
                    count[i] = Math.Max(count[i], Math.Max(i - j, count[i - j]) * j);
                }
            }
            return count.Last();
        }

        public int MaximalSquare(char[,] matrix)
        {
            var s = 0;
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);

            for(var i = 0; i<m- s;i++)
            {
                for(var j = 0; j<n- s;j++)
                {
                    if(IsSquare(i, j, s+1, matrix))
                    {
                        s++;
                        j--;
                    }
                }
            }
            return s;
        }
        private bool IsSquare(int i, int j, int size, char[,] matrix)
        {
            for(var p = i;p< i+ size;p++)
            {
                for(var q = j;q<j+ size;q++)
                {
                    if(matrix[p,q]=='0')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public int MaxProduct(int[] nums)
        {
            var n = nums.Length;
            var localMax = nums[0];
            var localMin = nums[0];
            var globalMax = nums[0];

            for(var i = 1; i< n;i++)
            {
                if(nums[i]>=0)
                {
                    localMax = Math.Max(localMax * nums[i], nums[i]);
                    localMin = Math.Min(localMin * nums[i], nums[i]);
                }
                else
                {
                    localMax = Math.Max(localMin * nums[i], nums[i]);
                    localMin = Math.Min(localMax * nums[i], nums[i]);
                }
                globalMax = Math.Max(globalMax, localMax);
            }
            return globalMax;
        }

        public int Calculate(string s)
        {
            var n = new List<int>();
            var op = new List<int>();
            var result = 0;
            var i = 0;

            while (i < s.Length)
            {
                if (s[i] == ' ')
                {
                    continue;
                }
                else if (s[i] == '+' || s[i] == '-')
                {
                    op.Add(s[i] == '+' ? 1 : -1);
                }
                else if (s[i] == '*' || s[i] == '/')
                {
                    var first = n.Last();
                    var second = 0;
                    var oper = s[i];
                    i++;
                    while (s[i] == ' ')
                    {
                        i++;
                    }
                    while (i < s.Length && s[i] >= '0' && s[i] <= '9')
                    {
                        second = second * 10 + s[i] - '0';
                        i++;
                    }
                    n[n.Count() - 1] = oper == '*' ? first * second : first / second;
                }
                else
                {
                    var tmp = 0;
                    while (i < s.Length && s[i] >= '0' && s[i] <= '9')
                    {
                        tmp = tmp * 10 + s[i] - '0';
                        i++;
                    }
                    n.Add(tmp);
                }
            }
            result = n[0];
            for (i = 1; i < n.Count(); i++)
            {
                result += op[i - 1] * n[i];
            }
            return result;
        }

        public string ReverseVowels(string s)
        {
            var arr = s.ToCharArray();
            var vowels = "aAeEoOiIuU";
            var n = arr.Count();
            var i = 0;
            var j = n - 1;

            while (i < j)
            {
                while (i < j && vowels.IndexOf(arr[i])==-1)
                {
                    i++;
                }
                while (j > i && vowels.IndexOf(arr[j]) == -1)
                {
                    j--;
                }
                Swap<char>(arr, i, j);
                i++;
                j--;
            }
            return new string(arr);
        }
        private void Swap<T>(T[] arr, int i, int j)
        {
            T tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }
    }

    public class Solution207
    {
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

