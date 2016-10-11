
public int MininumDeletion(string str, bool[,] constraints){
	var N = str.Count();
	var dp = new int[N]; // dp[i]: the minimum deletion if the subsequence ending with str[i]
	for(var i = 0; i < N; i++) dp[i] = 0;
	
	for(var i = 0; i < N; i++){
		var min = Int32.MaxValue;
		for(var j = 0; j < i; j++){
			if(!constraints[str[i], str[j]])
				min = Math.Min(min, dp[j])
		}	
		dp[i] = Math.Min(i, ret);
		for(var j = 0; j < i; j++)
			dp[j]++;
	}
	var ret = Int32.MaxValue;
	foreach(var x in dp) ret = Math.Min(x, ret);
	return ret == Int32.MaxValue ? 0 : ret;
}

public int MinimumDeletion(string str, bool[,] constraints){
	var N = str.Count();
	var dp = new int[26]; / // dp[i]: the minimum deletion if the subsequence ending with str[i], optimal
	for(var i = 0; i < 26; i++) dp[i] = 0;
	
	for(var i = 0; i < N; i++){
		var min = Int32.MaxValue;
		for(var j = 0; j < 26; j++){
			if(dp[j] != -1 && !constraints[str[i]-'a', j]){
				min = Math.Min(min, dp[j]);
			}
		}
		dp[str[i]-'a'] = Math.Min(min, ret);
		for(var j = 0; j < 26; j++){
			if(j != str[i]-'a') dp[j]++;
		}
	}
	var ret = Int32.MaxValue;
	foreach(var x in dp){
		if(x != -1) ret = Math.Min(ret, x);
	}
	return ret == Int32.MaxValue ? 0 : ret;
}

public int MinimumDeletion(string str, bool[,] constraints){
	var N = str.Count();
	var dp = new int[26];// dp[i]: the longest subsequence ending with i+'a'
	var ret = 0;
	for(var i = 0; i < N; i++){
		var max = 1;
		for(var j = 0; j < 26; j++){
			if(!constraints[str[i]-'a', j]){
				max = Math.Max(dp[j]+1, max);
			}
		}
		dp[str[i]-'a'] = max;
		ret = Math.Max(ret, dp[str[i]-'a']);
	}
	return N - ret;
}

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