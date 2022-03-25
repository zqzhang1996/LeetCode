using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2038
{
    public class Solution
    {
        public bool WinnerOfGame(string colors)
        {
            int a = 0, b = 0;
            for (int i = 2; i < colors.Length; i++)
            {
                if(colors[i] == 'A')
                {
                    if (colors[i - 1] == 'A' && colors[i - 2] == 'A') a++;
                } 
                else if (colors[i - 1] == 'B' && colors[i - 2] == 'B') b++;
            }
            return a > b;
        }
    }
}
