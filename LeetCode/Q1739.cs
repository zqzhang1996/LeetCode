using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1739
{
    public class Solution
    {
        public int MinimumBoxes(int n)
        {
            long i = (int)Math.Pow((long)n * 6, 1.0 / 3);
            if (i * (i + 1) * (i + 2) / 6 > n)
            {
                i--;
            }
            long j = (int)Math.Pow((n - (i * (i + 1) * (i + 2) / 6)) * 2, 1.0 / 2);
            if (i * (i + 1) * (i + 2) / 6 + (j * (j + 1) / 2) < n)
            {
                j++;
            }
            return (int)(i * (i + 1) / 2 + j);
        }
    }
}
