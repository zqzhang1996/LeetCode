using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q0806
{
    public class Solution
    {
        public int[] NumberOfLines(int[] widths, string s)
        {
            int length = 0;
            int row = 1;
            foreach(char c in s)
            {
                length += widths[c - 'a'];
                if(length > 100)
                {
                    row++;
                    length = widths[c - 'a'];
                }
            }
            return new int[2] { row, length };
        }
    }
}
