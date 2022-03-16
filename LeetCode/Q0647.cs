using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q0647
{
    public class Solution
    {
        public int CountSubstrings(string s)
        {
            int result = 0;
            for(int i = 0; i < s.Length; i++)
            {
                for(int j = 0; j < s.Length; j++)
                {
                    if (i - j == -1 || i + j == s.Length) break;
                    if (s[i - j] != s[i + j]) break;
                    result++;
                }
            }
            for(int i = 0; i < s.Length; i++)
            {
                for(int j = 0; j < s.Length; j++)
                {
                    if (i - j == -1 || i + j + 1 == s.Length) break;
                    if (s[i - j] != s[i + j + 1]) break;
                    result++;
                }
            }
            return result;
        }
    }
}
