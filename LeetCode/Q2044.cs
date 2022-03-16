using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2044
{
    public class Solution
    {
        public int CountMaxOrSubsets(int[] nums)
        {
            if (nums.Length == 1) return 1;
            int maxOr = 0;
            int result = 0;
            foreach (int num in nums)
            {
                maxOr |= num;
            }
            for(int i = (1 << nums.Length) - 1; i != 0; i--)
            {
                int temp = 0;
                for(int j = 0; j < nums.Length; j++)
                {
                    if((i & (1 << j)) != 0) temp |= nums[j];
                }
                if (temp == maxOr) result++;
            }
            return result;
        }
    }
}
