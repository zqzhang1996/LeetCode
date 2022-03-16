using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q0650
{
    public class Solution
    {
        public int MinSteps(int n)
        {
            int result = 0;
            int[] primes = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31 };
            for (int i = 0; i < 11; i++)
            {
                while (n % primes[i] == 0)
                {
                    n /= primes[i];
                    result += primes[i];
                }
            }
            if (n == 1) return result;
            return result + n;
        }
    }
}
