using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q0432
{
    public class AllOne
    {
        Dictionary<string, int> strCount;
        SortedDictionary<int, HashSet<string>> countStr;
        public AllOne()
        {
            strCount = new Dictionary<string, int>();
            countStr = new SortedDictionary<int, HashSet<string>>();
        }

        public void Inc(string key)
        {
            if (!strCount.ContainsKey(key))
            {
                strCount.Add(key, 1);
                if (!countStr.ContainsKey(1))
                {
                    countStr.Add(1, new HashSet<string>());
                }
                countStr[1].Add(key);
            }
            else
            {
                countStr[strCount[key]].Remove(key);
                if(countStr[strCount[key]].Count == 0)
                {
                    countStr.Remove(strCount[key]);
                }
                strCount[key]++;
                if (!countStr.ContainsKey(strCount[key]))
                {
                    countStr.Add(strCount[key], new HashSet<string>());
                }
                countStr[strCount[key]].Add(key);
            }
        }

        public void Dec(string key)
        {
            countStr[strCount[key]].Remove(key);
            if(countStr[strCount[key]].Count == 0)
            {
                countStr.Remove(strCount[key]);
            }
            strCount[key]--;
            if (strCount[key] == 0)
            {
                strCount.Remove(key);
            }
            else
            {
                if (!countStr.ContainsKey(strCount[key]))
                {
                    countStr.Add(strCount[key], new HashSet<string>());
                }
                countStr[strCount[key]].Add(key);
            }
        }

        public string GetMaxKey()
        {
            if (countStr.Count == 0) return "";
            return countStr.Last().Value.First();
        }

        public string GetMinKey()
        {
            if (countStr.Count == 0) return "";
            return countStr.First().Value.First();
        }
    }

    /**
     * Your AllOne object will be instantiated and called as such:
     * AllOne obj = new AllOne();
     * obj.Inc(key);
     * obj.Dec(key);
     * string param_3 = obj.GetMaxKey();
     * string param_4 = obj.GetMinKey();
     */
}
