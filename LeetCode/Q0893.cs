using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q0893
{
    public class Solution
    {
        public int NumSpecialEquivGroups(string[] words)
        {
            HashSet<string> result = new HashSet<string>();
            foreach (string word in words)
            {
                List<char> even = new List<char>();
                List<char> odd = new List<char>();
                for (int i = 0; i < word.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        even.Add(word[i]);
                    }
                    else
                    {
                        odd.Add(word[i]);
                    }
                }
                even.Sort();
                odd.Sort();
                string newStr = new string(even.ToArray())+"-"+new string(odd.ToArray());
                if (result.Contains(newStr)) continue;
                result.Add(newStr);
            }
            return result.Count;
        }
    }
}
