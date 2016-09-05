/**
 * @param {number} x
 * @param {number} y
 * @param {number} z
 * @return {boolean}
 */
var canMeasureWater = function(x, y, z) {
    m = Math.max(x, y);
    n = Math.min(x, y);
    if(m === 0 || n === 0)
    {
        return z == m || z === 0;
    }
    var f = true
    while(f)
    {
        f = false;
        while(m-n>0)
        {
            m -= n;
            f = true;
        }
        while(n-m>0)
        {
            n -= m;
            f = true;
        }
    }
    return z <= x+y && z%n===0;
};