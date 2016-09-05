// JavaScript source code

var pascalTriangle = function (k) {
    var ret = [];
    var lastRow = [1];

    if(k<0)
    {
        return ret;
    }
    for(var i = 1;i<=k;i++)
    {
        var newRow = [];
        for(var j = 0; j<=i;j++)
        {
            if(j==0||j==i)
            {
                newRow.push(1);
            }
            else {
                newRow.push(lastRow[j - 1] + lastRow[j]);
            }
        }
        lastRow = newRow;
    }
    return lastRow;
}