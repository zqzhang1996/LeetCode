using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1344
{
    public class Solution
    {
        public double AngleClock(int hour, int minutes)
        {
            int tmp = Math.Abs(hour * 60 - minutes * 11);
            if (tmp > 360) tmp = 720 - tmp;
            return tmp / 2.0;
        }
    }
}
