using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1004
{
    public class Solution
    {
        public int LongestOnes(int[] nums, int k)
        {
            int max = 0;
            int numOfZero = 0;
            int left = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0) numOfZero++;
                while (numOfZero > k)
                {
                    if (nums[left] == 0) numOfZero--;
                    left++;
                }
                max = Math.Max(max, i - left + 1);
            }
            return max;
        }
    }
}
