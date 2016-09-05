// JavaScript source code

var removeDuplicates = function (nums) {
    var i = 0;
    var j = 0;

    while(j<nums.length)
    {
        while(j<nums.length && nums[j]==nums[i])
        {
            j++;
        }
        if(j<nums.length)
        {
            i++;
            nums[i] = nums[j];
        }
    }
    return i + 1;
};