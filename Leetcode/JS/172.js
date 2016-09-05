// JavaScript source code

var trailingZeros = function (n) {
    var ret = 0;

    while(n>=5)
    {
        ret += Math.floor(n / 5);
        n = Math.floor(n / 5);
    }
    return ret;
};