
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q0954
{
    public class Solution
    {
        public bool CanReorderDoubled(int[] arr)
        {
            if (arr.Length == 0) return true;
            SortedList<int, int> nums = new SortedList<int, int>();
            foreach (int i in arr)
            {
                if (!nums.ContainsKey(i))
                {
                    nums.Add(i, 1);
                }
                else
                {
                    nums[i]++;
                }
            }
            while(nums.Count > 0)
            {
                var kvp = nums.ElementAt(0);
                if (kvp.Key < 0)
                {
                    if (kvp.Key % 2 != 0) return false;
                    if (!nums.ContainsKey(kvp.Key / 2)) return false;
                    if (nums[kvp.Key / 2] < kvp.Value) return false;
                    nums.Remove(kvp.Key);
                    nums[kvp.Key / 2] -= kvp.Value;
                    if(nums[kvp.Key / 2] == 0)
                    {
                        nums.Remove(kvp.Key / 2);
                    }
                }
                else if (kvp.Key == 0)
                {
                    if(nums[0] % 2 != 0)
                    {
                        return false;
                    }
                    else
                    {
                        nums.Remove(0);
                    }
                }
                else
                {
                    if (!nums.ContainsKey(kvp.Key * 2)) return false;
                    if (nums[kvp.Key * 2] < kvp.Value) return false;
                    nums.Remove(kvp.Key);
                    nums[kvp.Key * 2] -= kvp.Value;
                    if (nums[kvp.Key * 2] == 0)
                    {
                        nums.Remove(kvp.Key * 2);
                    }
                }
            }
            return true;
        }
    }
}
