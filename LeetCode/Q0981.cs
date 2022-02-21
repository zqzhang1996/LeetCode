using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q0981
{
    public class TimeMap
    {
        public TimeMap()
        {

        }

        Dictionary<string, List<string>> valueList = new Dictionary<string, List<string>>();
        Dictionary<string,List<int>> timestampList = new Dictionary<string, List<int>>();

        public void Set(string key, string value, int timestamp)
        {
            if (!valueList.ContainsKey(key))
            {
                valueList[key] = new List<string> { value };
                timestampList[key] = new List<int> { timestamp };
            }
            else
            {
                valueList[key].Add(value);
                timestampList[key].Add(timestamp);
            }
        }

        public string Get(string key, int timestamp)
        {
            if (!valueList.ContainsKey(key)) return "";
            int index = (timestampList[key].BinarySearch(timestamp));
            if(index >= 0) return valueList[key][index];
            if(~index == 0) return "";
            return valueList[key].ElementAt(~index - 1);
        }
    }

    /**
     * Your TimeMap object will be instantiated and called as such:
     * TimeMap obj = new TimeMap();
     * obj.Set(key,value,timestamp);
     * string param_2 = obj.Get(key,timestamp);
     */
}
