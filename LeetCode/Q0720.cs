using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q0720
{
    public class Solution
    {
        public string LongestWord(string[] words)
        {
            Array.Sort(words);
            HashSet<string> dic = new HashSet<string> { "" };
            string result = "";
            foreach(string word in words)
            {
                if(dic.Contains(word.Substring(0, word.Length - 1)))
                {
                    dic.Add(word);
                    if(word.Length > result.Length)
                    {
                        result = word;
                    }
                }
            }
            return result;
        }
    }
}
