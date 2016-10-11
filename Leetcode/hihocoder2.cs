 static int main(string[] args)
        {
            var n = Convert.ToInt32(Console.ReadLine());
            var str = Console.ReadLine();
            var m = Convert.ToInt32(Console.ReadLine());
            var constraints = new HashSet<char>[256];
            while (m > 0)
            {
                var s = Console.ReadLine();
                if (constraints[s[0]] == null)
                {
                    constraints[s[0]] = new HashSet<char>();
                }
                if (constraints[s[1]] == null)
                {
                    constraints[s[1]] = new HashSet<char>();
                }
                constraints[s[0]].Add(s[1]);
                constraints[s[1]].Add(s[0]);
                m--;
            }
            Console.WriteLine(helper(str, constraints));
            return 0;
        }

        private static int helper(string str, HashSet<char>[] constraints)
        {
            int ret = Int32.MaxValue;
            helper(str, 0, 0, "", constraints, ref ret);
            return ret;
        }

        private static void helper(string str, int i, int deletation, string cur, HashSet<char>[] constraints, ref int globalmin)
        {

            if (i == str.Count())
            {
                globalmin = Math.Min(globalmin, deletation);
                return;
             }
            if (cur.Count() == 0 || constraints[str[i]] == null || !constraints[str[i]].Contains(cur.Last()))
            {
                cur += str[i];
                helper(str, i + 1, deletation, cur, constraints, ref globalmin);
            }
            else
            {
                helper(str, i + 1, deletation + 1, cur, constraints, ref globalmin);//delete the second one
                cur = cur.Substring(0, cur.Count() - 1);
                helper(str, i, deletation + 1, cur, constraints, ref globalmin);//delete the first one
            }
        }