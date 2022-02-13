using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q0077
{
    public class Solution
    {
        int maxNum;
        int combinationLength;
        IList<IList<int>> result;

        public IList<IList<int>> Combine(int n, int k)
        {
            maxNum = n;
            combinationLength = k;
            result = new List<IList<int>>();
            AddCombination(0, 0, 0);
            return result;
        }

        void AddCombination(int num, int mark, int markCount)
        {
            if (markCount == combinationLength)
            {
                List<int> list = new List<int>();
                for (int i = 0; i < num; i++)
                {
                    if (((mark >> i) & 1) == 1)
                    {
                        list.Add(num - i);
                    }
                }
                result.Add(list);
                return;
            }

            num++;
            mark <<= 1;
            if (maxNum - num + markCount >= combinationLength)
            {
                AddCombination(num, mark, markCount);
            }
            mark |= 1;
            markCount++;
            if (maxNum - num + markCount >= combinationLength)
            {
                AddCombination(num, mark, markCount);
            }
        }
    }
}
