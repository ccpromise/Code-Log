import sys;

def fibonacci(n):
	a = 0;
	b = 1;
	i = 0;
	while(i<n):
		yield a;
		a = b;
		b = a+b;
		i+=1;
	return;

# lambda
sum = lambda x, y : x+y
sum(1,2)

# fibonacci
def f(n):
	a = 0
	b = 1
	count = 0
	while(count<n):
		print(b)
		a = b
		b = a+b
	
	
#f = fibonacci(10);
#while True:
##	try:
#		print(next(f),end=" ")
#	except StopIteration:
#		sys.exit()
#input("enter to quit");