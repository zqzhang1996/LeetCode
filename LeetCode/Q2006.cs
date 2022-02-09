using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2006
{
    public class Solution
    {
        public int CountKDifference(int[] nums, int k)
        {
            int[] numList = new int[101];
            foreach(int num in nums)
            {
                numList[num]++;
            }
            int result = 0;
            for(int i = 1; i < 101 - k; i++)
            {
                result += numList[i] * numList[i + k];
            }
            return result;
        }
    }
}
