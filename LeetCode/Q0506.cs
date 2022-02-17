using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q0506
{
    public class Solution
    {
        public string[] FindRelativeRanks(int[] score)
        {
            var list = new SortedList<int, int>();
            for (int i = 0; i < score.Length; i++)
            {
                list.Add(score[i], i);
            }
            var result = new string[score.Length];
            int j = score.Length;
            foreach (var s in list)
            {
                switch (j)
                {
                    case 1:
                        result[s.Value] = "Gold Medal";
                        break;
                    case 2:
                        result[s.Value] = "Silver Medal";
                        break;
                    case 3:
                        result[s.Value] = "Bronze Medal";
                        break;
                    default:
                        result[s.Value] = (j).ToString();
                        break;
                }
                j--;
            }
            return result;
        }
    }
}
