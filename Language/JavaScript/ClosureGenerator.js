// JavaScript source code
var sum = function (arr) {
    return arr.reduce(function (x, y) {
        return x + y;
    })
};
sum([1, 2, 3]);

// sum returns a function to f, the variable required to execuate this function will be kept by f. 
// So when you call f, f knows where to find the variables required for execuation.
var sum = function (arr) {
    return function () {
        return arr.reduce(function (x, y) {
            return x + y;
        })
    }
}
f = sum([1, 2, 3]);
f();

var f = function () {
    var arr = [];
    var i;
    for (i = 0; i < 3; i++) {
        arr[i] = function () {
            return i * i;
        }
    }
    return arr;
};
ret = f(); 
ret[0]();
ret[1]();
ret[2](); // all return 9

var f = function () {
    var arr = [];
    var i;
    for (i = 0; i < 3; i++) {
        arr[i] = (function (n) {
            return function () {
                return n * n;
            }
        })(i);
    }
    return arr;
}
var results = f();
results[0]();
results[1]();

var add = function () {
    var count = 0;
    return function () {
        count++;
        return count;
    }
}
f = add();
f();
f();

var createCounter = function (n) {
    n = n || 0;
    return {
        inc: function () {
            return n++;
        }
    }
}
var c1 = createCounter();
c1.inc();
c1.inc();
var c2 = createCounter();
c2.inc();
c2.inc();

var powN = function (n) {
    return function (x) {
        return pow(n, x);
    }
}
pow2 = powN(2);
pow3 = powN(3);
alert(pow2(3));
alert(pow3(2));

function* fib(n) {
    var a = 0;
    var b = 1;
    
    for(var i = 1;i<n;i++)
    {
        yield a;
        a = b;
        b = a+b;
    }
    return a;
}
var arr = fib(5);
arr.next();



