using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1832
{
    public class Solution
    {
        public bool CheckIfPangram(string sentence)
        {
            //67108863
            int mark = 0;
            foreach (char c in sentence)
            {
                mark |= 1 << (c - 'a');
            }
            return mark == 67108863;

        }
    }
}
