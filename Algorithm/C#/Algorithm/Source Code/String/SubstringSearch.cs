public class Solution{
    public static R = 256;
    public int ContainsSubStr1(string s, string sub){
        var n = s.Count();
        var m = sub.Count();
        if(m > n) return -1;

        var i = 0;
        while(i < n-m+1){
            var j = 0;
            while(j < m && s[i+j] == sub[j]){
                j++;
            }
            if(j == m){
                return i;
            }
        }
        return -1;
    }

    public int ContainsSubStr2(string s, string sub){
        var n = s.Count();
        var m = sub.Count();
        if(m > n) return -1;

        var state = new int[R,m];
        state[sub[0],0] = 1;
        x = 0; // the fisrt restart state should be state[][0]
        for(var i = 1; i < m; i++){
            for(var j = 0; j < R; j++){
                state[j,i] = state[j,x];
            }
            state[CharToIndex(sub[i]), i] = i+1;
            x = state[CharToIndex(sub[i]), x]; 
            // the next restart state should be in current restart state, if you enter sub[i], what the next state is.
        }
    }

    public int ContainsSubStr3(string s, string sub){
        var n = s.Count();
        var m = sub.Count();
        if(m > n) return -1;

        var dic = new Dictionary<char, int>();
        for(var i = 0; i < m; i++){
            if(!dic.ContainsKey(sub[i])){
                dic.Add(sub[i], i);
            }
            sub[i] = i;
        }
        var right = m-1;
        while(right < n){
            var j = m-1;
            while(j >= 0 && sub[j] == s[right-(m-1-j)]){
                j--;
            }
            if(j == -1) return right-m-1;
            if(!dic.ContainsKey(s[right-(m-1-j)])) right += m;
            else{
                var skip = j - s[right-(m-1-j)];
                skip = Math.Max(skip, 1);
                right += skip;
            }
        }
        return -1;
    }

    private int CharToIndex(char c){
        return -1;
    }
}