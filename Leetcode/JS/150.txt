/**
 * @param {string[]} tokens
 * @return {number}
 */
// Solution150
var evalRPN = function(tokens) {
    var s = [];
    
    for(var t of tokens)
    {
        if(t==="+"||t==="-"||t=="*"||t=="/")
        {
            var a = s.pop();
            var b = s.pop();
            
            if(t==="+")
            {
                s.push(a+b);
            }
            else if(t==="-")
            {
                s.push(b-a);
            }
            else if(t==="/")
            {
                if(b/a < 0)
                {
                    s.push(Math.ceil(b/a));
                }
                else
                {
                    s.push(Math.floor(b/a));
                }
            }
            else
            {
                s.push(a*b);
            }
        }
        else
        {
            s.push(Number(t));
        }
    }
    return s[0];
};