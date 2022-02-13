using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1487
{
    public class Solution
    {
        public string[] GetFolderNames(string[] names)
        {
            string[] ans = new string[names.Length];
            Dictionary<string,int> dic=new Dictionary<string,int>();
            for(int i = 0; i < names.Length; i++)
            {
                if (!dic.ContainsKey(names[i]))
                {
                    ans[i] = names[i];
                    dic.Add(names[i], 0);
                }
                else
                {
                    int k = dic[names[i]] + 1;
                    string newName = names[i] + '(' + k + ')';
                    while (dic.ContainsKey(newName))
                    {
                        k++;
                        newName = names[i] + '(' + k + ')';
                    }
                    dic[names[i]] = k;
                    ans[i] = newName;
                    dic.Add(newName, 0);
                }
            }
            return ans;
        }
    }
}
