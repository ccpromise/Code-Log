import sys
import t1

f = t1.fibonacci(10)
while True:
	try:
		print(next(f), end=" ")
	except StopIteration:
		break
print(sys.path)



def f(x):
	x+=1

def g(x):
	x = x+"hello"

def h(x):
	x = x.append([1,2,3])

x, y, z = 1, "s", [2,3,4]
f(x);g(y);h(z);
print(x);print(y);print(z);

input("enter to quit")