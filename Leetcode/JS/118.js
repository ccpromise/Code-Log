// JavaScript source code

// 118. Pascal's Triangle
var generate = function (numRows) {
    var ret = [];

    if(numRows<=0)
    {
        return ret;
    }
    var lastRow = [1];
    ret.push(lastRow);

    for(let i = 2; i<=numRows;i++)
    {
        var newRow = [1];

        for(let j = 0;j<lastRow.length-1;j++)
        {
            newRow.push(lastRow[j] + lastRow[j + 1]);
        }
        newRow.push(1);
        ret.push(newRow);
        lastRow = newRow;
    }
    return ret;
};

var generate = function (numRows) {
    var ret = [];

    if(numRows<=0)
    {
        return ret;
    }
    for(var i = 0; i<numRows;i++)
    {
        var row = [];

        for(var j = 0; j<=i;j++)
        {
            if(j==0||j==i)
            {
                row.push(1);
            }
            else
            {
                row.push(ret[i - 1][j - 1] + ret[i - 1][j]);
            }
        }
        ret.push(row);
    }
    return ret;
}
