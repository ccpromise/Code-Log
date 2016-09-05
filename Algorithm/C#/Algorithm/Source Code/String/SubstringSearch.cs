using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Source_Code.Chapter3
{
    public class SubstringSearch
    {
        /// <summary>
        /// Find string t in string s.
        /// Neat implementation.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static int BruteForceSearch(string s, string t)
        {
            var N = s.Length;
            var M = t.Length;

            for (var i = 0; i <= N - M; i++)
            {
                var j = 0;
                while (j < M && s[i + j] == t[j])
                {
                    j++;
                }
                if (j == M)
                {
                    return i;
                }
            }
            return -1;
        }

        //public static int KMP(string s, string t)
        //{ 
            
        //}
    }
}
