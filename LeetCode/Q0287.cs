using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q0287
{
    public class Solution
    {
        public int FindDuplicate(int[] nums)
        {
            int fast = 0, slow = 0;
            while (true)
            {
                fast = nums[nums[fast]];
                slow = nums[slow];
                if(fast == slow)
                {
                    fast = 0;
                    while (true)
                    {
                        fast = nums[fast];
                        slow = nums[slow];
                        if (fast == slow) return fast;
                    }
                }
            }
        }
    }
}
