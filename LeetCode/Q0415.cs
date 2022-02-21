using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q0415
{
    public class Solution
    {
        public string AddStrings(string num1, string num2)
        {
            int tmp;
            int isCarried = 0;
            char[] result = new char[Math.Max(num1.Length, num2.Length)];
            for (int i = 0; i < Math.Min(num1.Length, num2.Length); i++)
            {
                tmp = num1[num1.Length - i - 1] + num2[num2.Length - i - 1] - '0' - '0' + isCarried;
                isCarried = tmp / 10;
                result[result.Length - i - 1] = (char)((tmp % 10) + '0');
            }
            if(num1.Length < num2.Length)
            {
                for (int i = num1.Length; i < num2.Length; i++)
                {
                    tmp = num2[num2.Length - i - 1] - '0' + isCarried;
                    isCarried = tmp / 10;
                    result[result.Length - i - 1] = (char)((tmp % 10) + '0');
                }
            }
            if (num2.Length < num1.Length)
            {
                for (int i = num2.Length; i < num1.Length; i++)
                {
                    tmp = num1[num1.Length - i - 1] - '0' + isCarried;
                    isCarried = tmp / 10;
                    result[result.Length - i - 1] = (char)((tmp % 10) + '0');
                }
            }
            if (isCarried == 1) return '1' + new string(result);
            return new string(result);
        }
    }
}
