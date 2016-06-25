using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SICPPractise.Algorithm.String
{
    class StringPuzzle
    {
        public static bool IsAnagram2(string s, string t)
        {
            var count = new int[26];
            if (s.Length != t.Length)
            {
                return false;
            }
            foreach (var c in s)
            {
                count[c]++;
            }
            foreach (var c in t)
            {
                if (count[c] == 0)
                {
                    return false;
                }
                count[c]--;
            }
            foreach (var n in count)
            {
                if (n != 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static int StrStr(string haystack, string needle)
        {
            if (needle.Length == 0)
            {
                return 0;
            }
            if (haystack.Length == 0)
            {
                return -1;
            }
            for (var i = 0; i <= haystack.Length - needle.Length; i++)
            {
                if (haystack[i] == needle[0])
                {
                    var j = 0;
                    while (j < needle.Length && haystack[i + j] == needle[j])
                    {
                        j++;
                    }
                    if (j == needle.Length)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public static string Convert(string s, int numRows)
        {
            var length = s.Length;
            var space = 2 * numRows - 2;
            var ret = "";
            if (numRows == 1)
            {
                return s;
            }
            for (var i = 0; i < length; i+=space)
            {
                ret += s[i];
            }
            for (var i = 1; i < numRows - 1; i++)
            {
                for (var j = i; j < length; j += space)
                {
                    ret += s[j];
                    if (j + space - 2 * i < length)
                    {
                        ret += s[j + space - 2 * i];
                    }
                }
            }
            for (var i = numRows - 1; i < length; i += space)
            {
                ret += s[i];
            }
                return ret;
        }

        public static string Convert2(string s, int numRows)
        {
            var l = s.Length;
            var gap = numRows == 1 ? 1 : 2 * numRows - 2;
            var ret = "";

            for (var i = 0; i < numRows; i++)
            {
                for (var j = i; j < l; j += gap)
                {
                    ret += s[j];
                    if (j + gap - 2 * i < l && 2 * i != 0 && 2 * i != gap)
                    {
                        ret += s[j + gap - 2 * i];
                    }
                }
            }
            return ret;
        }

        public static string Convert3(string s, int numRows)
        {
            var ret = "";

            for (var i = 0; i < numRows; i++)
            {
                for (var j = i; j < s.Length; j += 2 * numRows - 2)
                {
                    ret += s[j];
                    if (i != 0 && i != numRows - 1 && j+2*numRows-2-2*i<s.Length)
                    {
                        ret += s[j + 2 * numRows - 2 - 2 * i];
                    }
                }
            }
            return ret;
        }

        public static string GetHint(string secret, string guess)
        {
            var bulls = 0;
            var cows = 0;
            var count = new int[10];

            for (var i = 0; i < secret.Length; i++)
            {
                count[secret[i] - '0']++;        
            }
            for (var i = 0; i < guess.Length; i++)
            {
                if (i < secret.Length && guess[i] == secret[i])
                {
                    bulls++;
                }
                else if (count[guess[i]-'0'] > 0)
                {
                    cows++;
                }
                count[guess[i]]--;
            }
            return bulls.ToString() + "A" + cows.ToString() + "B";
        }

        public IList<string> GenerateParenthesis(int n)
        {
            var ret = new List<string>();

            Helper(n, 0, "", ret);
            return ret;
        }
        private void Helper(int n, int m, string s, IList<string> ret)
        {
            if (n == 0 && m == 0)
            {
                ret.Add(s);
            }
            if (n > 0)
            {
                Helper(n - 1, m + 1, s + "(", ret);
            }
            if (m > 0)
            {
                Helper(n, m - 1, s + ")", ret);
            }
        }

        public IList<IList<string>> Partition(string s)
        {
            var ret = new List<IList<string>>();

            PartitionHelper(s, 0, new List<string>(),ret);
            return ret;
        }
        private void PartitionHelper(string s, int begin, IList<string> p, IList<IList<string>> ret)
        {
            if (begin == s.Length)
            {
                ret.Add(p);
                return;
            }
            var i = begin;
            var j = begin;
            while (j < s.Length)
            {
                if (j < s.Length && s[i] != s[j])
                {
                    j++;
                }
                var lo = i;
                var hi = j;
                if(hi<s.Length)
                {
                    while(hi>lo)
                    {
                        if (s[hi] == s[lo])
                        {
                            hi--;
                            lo++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if(hi<=lo)
                    {
                        var q = new List<string>(p);
                        q.Add(s.Substring(i, j-i+1));
                        PartitionHelper(s, j + 1, q, ret);
                    }
                }
                j++;
            }
        }

        public IList<IList<string>> GroupAnagrams1(string[] strs)
        {
            var ret = new List<IList<string>>();

            for (var i = 0; i < strs.Length; i++)
            {
                var j = 0;
                while (j < ret.Count)
                {
                    if (IsAnagram2(strs[i], ret[j].Last()))
                    {
                        ret[j].Add(strs[i]);
                        break;
                    }
                    j++;
                }
                if (j == ret.Count)
                {
                    ret.Add(new List<string>() { strs[i] });
                }
            }
            for (var i = 0; i < ret.Count; i++)
            {
                var j = ret[i].ToArray();
                System.Array.Sort(j, (s, t)=>s[0]-t[0]);
                ret[i] = j;
            }
            return ret;
        }

        public IList<IList<string>> GroupAnagrams2(string[] strs)
        {
            var dic = new Dictionary<string, IList<string>>();

            for (var i = 0; i < strs.Length; i++)
            {
                var count = new int[26];
                foreach (var ch in strs[i])
                {
                    count[ch - 'a']++;
                }
                var str = "";
                foreach (var n in count)
                {
                    str += n.ToString();
                }
                if (dic.ContainsKey(str))
                {
                    dic[str].Add(strs[i]);
                }
                else
                {
                    dic.Add(str, new List<string>() { strs[i] });
                }
            }
            var tmp = dic.Values.ToArray();
            var ret = new List<IList<string>>();
            for (var i = 0; i < tmp.Count(); i++)
            {
                var k = tmp[i].ToArray();
                if (k[0] != "")
                {
                    System.Array.Sort(k, (s, t) => s[0] - t[0]);
                }
                ret.Add(k);
            }
            return ret;
        }

        public bool IsAdditiveNumber(string num)
        {
            var n = num.Length;
            if (n < 3)
            {
                return false;
            }
            for (var i = 1; i <= n / 2; i++)
            {
                if (num[0] == '0' && i >= 2)
                {
                    continue;
                }
                for (var j = 1; n - i - j >= System.Math.Max(i, j); j++)
                {
                    if (num[i] == '0' && j >= 2)
                    {
                        continue;
                    }
                    long pre = 0;
                    var k = 0;
                    while (k < i)
                    {
                        pre = pre * 10 + num[k++] - '0';
                    }
                    long cur = 0;
                    while (k < i + j)
                    {
                        cur = cur * 10 + num[k++] - '0';
                    }
                    var flag = true;
                    while (k < n)
                    {
                        if (num[k] == '0' && pre + cur != 0)
                        {
                            flag = false;
                            break;
                        }
                        long next = num[k++] - '0';
                        while (next < pre + cur && k < n)
                        {
                            next = next * 10 + num[k++] - '0';
                        }
                        if (next != pre + cur)
                        {
                            flag = false;
                            break;
                        }
                        pre = cur;
                        cur = next;
                    }
                    if (!flag)
                    {
                        continue;
                    }
                    return true;
                }
            }
            return false;
        }



    }
}
