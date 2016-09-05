def moveZeroes(nums):
	i = 0
	for j in range(len(nums)):
		if(nums[j] != 0):
			nums[i] = nums[j]
			i += 1
	while i < len(nums):
		nums[i] = 0
		i+=1

l = [1,0,2,3,0]
moveZeroes(l)
print(l)