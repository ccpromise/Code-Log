var rectArea = function(A, B, C, D, E, F, G, H) {
	if (E >= C || A >= G || B >= H || F >= D)
	{
		return 0;
	}
	var w = findIter(A, C, E, G);
	var h = findIter(B, D, F, H);
	return w * h;
};

var findIter = function(a, b, c, d) {
	if(a <= c && b >= d)
	{
		return d - c;
	}
	if(a >= c && b <= d)
	{
		return b - a;
	}
	if(b >= c && b <= d)
	{
		return b - c;
	}
	if(a >= c && a <= d)
	{
		return a - c;
	}
};