using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1509
{
    public class Solution
    {
        public int MinDifference(int[] nums)
        {
            if (nums.Length < 5) return 0;
            Array.Sort(nums);
            return Math.Min(    Math.Min(   nums[nums.Length - 1] - nums[3], 
                                            nums[nums.Length - 2] - nums[2]), 
                                Math.Min(   nums[nums.Length - 3] - nums[1], 
                                            nums[nums.Length - 4] - nums[0]));
        }
    }
}
