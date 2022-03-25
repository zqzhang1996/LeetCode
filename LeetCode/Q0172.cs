using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q0172
{
    public class Solution
    {
        public int TrailingZeroes(int n)
        {
            return n / 5 + n / 5 / 5 + n / 5 / 5 / 5 + n / 5 / 5 / 5 / 5 + n / 5 / 5 / 5 / 5 / 5;
        }
    }
}
