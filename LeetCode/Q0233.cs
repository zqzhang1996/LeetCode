using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q0233
{
    public class Solution
    {
        public int CountDigitOne(int n)
        {
            int result = 0;
            int digit = 1;
            while (n >= digit)
            {
                if (n / digit % 10 == 0)
                {
                    result += n / digit / 10 * digit;
                }
                else if(n / digit % 10 == 1)
                {
                    result += n / digit / 10 * digit + n % digit + 1;
                }
                else
                {
                    result += n / digit / 10 * digit + digit;
                }
                digit *= 10;
            }
            return result;
        }
    }
}
