using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q0599
{
    public class Solution
    {
        public string[] FindRestaurant(string[] list1, string[] list2)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();
            for(int i = 0; i < list1.Length; i++)
            {
                map[list1[i]] = i;
            }
            List<string> result = new List<string>();
            int min = int.MaxValue;
            for(int i = 0; i < list2.Length; i++)
            {
                if (map.ContainsKey(list2[i]))
                {
                    if(min == i + map[list2[i]])
                    {
                        result.Add(list2[i]);
                    }
                    else if(min > i + map[list2[i]])
                    {
                        min = i + map[list2[i]];
                        result.Clear();
                        result.Add(list2[i]);
                    }
                }
            }
            return result.ToArray();
        }
    }
}
