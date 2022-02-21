using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q0838
{
    public class Solution
    {
        public string PushDominoes(string dominoes)
        {
            char[] result = dominoes.ToCharArray();
            int left = 0;
            char leftStatus = result[0];
            for(int right = 1; right < dominoes.Length; right++)
            {
                if(result[right] == 'L')
                {
                    if(leftStatus == 'R')
                    {
                        for(int j = 1; j < (right - left + 1) / 2; j++)
                        {
                            result[left + j] = 'R';
                            result[right - j] = 'L';
                        }
                    }
                    else
                    {
                        for (int i = left + 1; i < right; i++)
                        {
                            result[i] = 'L';
                        }
                    }
                    left = right;
                    leftStatus = result[left];
                }
                else if(result[right] == 'R')
                {
                    if(leftStatus == 'R')
                    {
                        for(int i = left + 1; i < right; i++)
                        {
                            result[i] = 'R';
                        }
                    }
                    left = right;
                    leftStatus = result[left];
                }
            }
            if(left != dominoes.Length - 1 && leftStatus == 'R')
            {
                for(int i = left + 1; i < dominoes.Length; i++)
                {
                    result[i] = 'R';
                }
            }
            return new string(result);
        }
    }
}
