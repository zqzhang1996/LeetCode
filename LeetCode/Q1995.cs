using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1995
{
    public class Solution
    {
        public int CountQuadruplets(int[] nums)
        {
            int ans = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            //int a = 0, b = 1, c = nums.Length - 2, d = nums.Length - 1;
            for (int c = nums.Length - 2; c > 2; c--)
            {
                for (int d = c + 1; d < nums.Length; d++)
                {
                    if (!map.ContainsKey(nums[d] - nums[c]))
                    {
                        map.Add(nums[d] - nums[c], 0);
                    }
                    map[nums[d] - nums[c]]++;
                }
                for (int a = 0; a < c - 1; a++)
                {
                    if (map.ContainsKey(nums[a] + nums[c - 1]))
                    {
                        ans += map[nums[a] + nums[c - 1]];
                    }
                }
            }
            return ans;
        }
    }
}
