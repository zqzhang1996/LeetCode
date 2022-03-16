using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q0526
{
    public class Solution
    {
        // 可以打表{0,1,2,3,8,10,36,41,132,250,700,750,4010,4237,10680,24679}
        public int CountArrangement(int n)
        {
            max = n;
            marks = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (i % j == 0 || j % i == 0)
                    {
                        marks[i] |= 1 << j;
                    }
                }
            }
            CountArrangementHelper(0, 1);
            return result;
        }
        int max;
        int[] marks;
        int result;
        void CountArrangementHelper(int mark, int num)
        {
            if (num > max)
            {
                result++;
                return;
            }
            for (int i = 1; i <= max; i++)
            {
                if ((marks[num] & (1 << i)) != 0 && (mark & (1 << i)) == 0)
                {
                    CountArrangementHelper(mark | (1 << i), num + 1);
                }
            }
        }
    }
}
