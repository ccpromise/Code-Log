/**
 * @param {string} s
 * @return {string[]}
 */
var restoreIpAddresses = function(s) {
    var ret = [];
    var N = s.length;
    var i;
    
    for(i = 1; i<=3;i++)
    {
        var a = s.substr(0, i);
        if(N-i > 9) continue;
        if(N-i < 3) break;
        if(valid(a)===false) break;
        var j;
        for(j = 1; j<=3;j++)
        {
            var b = s.substr(i, j);
            if(N-i-j > 6) continue;
            if(N-i-j < 2) break;
            if(valid(b)===false) break;
            var k;
            for(k = 1; k<=3 && i+j+k < N;k++)
            {
                var c  =s.substr(i+j, k);
                var d = s.substr(i+j+k);
                if( valid(c) && valid(d))
                {
                    ret.push(a+"."+b+"."+c+"."+d);
                }
            }
        }
    }
    return ret;
};

var valid = function(s){
    if(Number(s) > 255 || (s[0]=='0' && s.length > 1))
    {
        return false;
    }
    return true;
}