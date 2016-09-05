// JavaScript source code

var Queue = function () {
    this.queue = [];
};

Queue.prototype.push = function (x) {
    this.queue.push(x);
};

Queue.prototype.pop = function () {
    this.queue.shift();
};

Queue.prototype.peek = function () {
    return this.queue[0];
};

Queue.prototype.size = function () {
    return this.queue.length;
};

Queue.prototype.empty = function () {
    return this.queue.length == 0;
};