using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q0592
{
    public class Solution
    {
        public string FractionAddition(string expression)
        {
            int result = 0;
            bool isPlus = true;
            bool inNumerator = true;
            string numerator = "";
            string denominator = "";

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '+')
                {
                    result += (isPlus ? 1 : -1) * int.Parse(numerator) * 5 * 7 * 8 * 9 / int.Parse(denominator);
                    inNumerator = true;
                    isPlus = true;
                    numerator = "";
                    denominator = "";
                }
                else if (expression[i] == '-')
                {
                    if (i != 0)
                    result += (isPlus ? 1 : -1) * int.Parse(numerator) * 5 * 7 * 8 * 9 / int.Parse(denominator);
                    inNumerator = true;
                    isPlus = false;
                    numerator = "";
                    denominator = "";
                }
                else if (expression[i] == '/')
                {
                    inNumerator = false;
                }
                else if (inNumerator)
                {
                    numerator += expression[i];
                }
                else
                {
                    denominator += expression[i];
                }
            }
            result += (isPlus ? 1 : -1) * int.Parse(numerator) * 5 * 7 * 8 * 9 / int.Parse(denominator);

            int result1 = 5 * 7 * 8 * 9;
            for(int i = 10; i != 1; i--)
            {
                if(result % i == 0 && result1 % i == 0)
                {
                    result /= i;
                    result1 /= i;
                }
            }
            return result.ToString() + "/" + result1.ToString();
        }
    }
}
