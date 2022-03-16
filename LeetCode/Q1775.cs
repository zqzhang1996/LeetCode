using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1775
{
    public class Solution
    {
        public int MinOperations(int[] nums1, int[] nums2)
        {
            int operationTime = 0;
            int sum1 = 0;
            int sum2 = 0;
            int[] frequency1 = new int[7];
            int[] frequency2 = new int[7];
            foreach (int i in nums1)
            {
                sum1 += i;
                frequency1[i]++;
            }
            foreach (int i in nums2)
            {
                sum2 += i;
                frequency2[i]++;
            }
            if (sum1 == sum2) return 0;
            if (sum1 < sum2)
            {
                for (int i = 1; i != 6; i++)
                {
                    if ((frequency1[i] + frequency2[7 - i]) * (6 - i) >= sum2 - sum1)
                    {
                        return operationTime + (sum2 - sum1 + (5 - i)) / (6 - i);
                    }
                    else
                    {
                        operationTime += frequency1[i] + frequency2[7 - i];
                        sum2 -= (frequency1[i] + frequency2[7 - i]) * (6 - i);
                    }
                }
            }
            else
            {
                for (int i = 1; i != 6; i++)
                {
                    if ((frequency2[i] + frequency1[7 - i]) * (6 - i) >= sum1 - sum2)
                    {
                        return operationTime + (sum1 - sum2 + (5 - i)) / (6 - i);
                    }
                    else
                    {
                        operationTime += frequency2[i] + frequency1[7 - i];
                        sum1 -= (frequency2[i] + frequency1[7 - i]) * (6 - i);
                    }
                }
            }
            return -1;
        }
    }
}
