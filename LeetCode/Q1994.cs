using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1994
{
    public class Solution
    {
        readonly int[] marks = new int[] { 0,
            0, 1, 2, -1, 4,
            3, 8, -1, -1, 5,
            16, -1, 32, 9, 6,
            -1, 64, -1, 128, -1,
            10, 17, 256, -1, -1,
            33, -1, -1, 512, 7, };

        public int NumberOfGoodSubsets(int[] nums)
        {
            //// 这里打表了
            //marks = new int[31];
            //int[] primes = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
            //for (int i = 1; i < 31; i++)
            //{
            //    int tmp = 0;
            //    for (int j = 0; j < primes.Length; j++)
            //    {
            //        if (i % primes[j] == 0)
            //        {
            //            if (i / primes[j] % primes[j] == 0)
            //            {
            //                tmp = -1;
            //                break;
            //            }
            //            else
            //            {
            //                tmp |= 1 << j;
            //            }
            //        }
            //    }
            //    marks[i] = tmp;
            //}
            frequencies = new int[31];
            foreach (int num in nums)
            {
                frequencies[num]++;
            }
            return (int)(NumberOfGoodSubsetsHelper(0, 1, 0) % 1000000007);
        }

        int[] frequencies;
        long NumberOfGoodSubsetsHelper(int mark, int num, long result)
        {
            // 终止条件
            if (mark == 0b1111111111) return result % 1000000007;
            if (num == 31)
            {
                if (mark == 0) return 0;
                return result % 1000000007;
            }
            // 1可以取多个
            if(num == 1 && frequencies[num] != 0)
            {
                result = 1;
                while(frequencies[num] != 0)
                {
                    if(frequencies[num] > 32)
                    {
                        result = (result << 32) % 1000000007;
                        frequencies[num] -= 32;
                    }
                    else
                    {
                        result = (result << frequencies[num]) % 1000000007;
                        frequencies[num] = 0;
                    }
                }
                return NumberOfGoodSubsetsHelper(mark, num + 1, result);
            }
            // num不能取||与已取的冲突||num计数为0
            if (marks[num] == -1 || (mark & marks[num]) != 0 || frequencies[num] == 0)
            {
                return NumberOfGoodSubsetsHelper(mark, num + 1, result);
            }
            // 分支
            return (NumberOfGoodSubsetsHelper(mark | marks[num], num + 1, result == 0 ? frequencies[num] : (result * frequencies[num]) % 1000000007) +
                NumberOfGoodSubsetsHelper(mark, num + 1, result)) % 1000000007;
        }
    }
}
