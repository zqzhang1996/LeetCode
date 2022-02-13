using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q0946
{
    public class Solution
    {
        public bool ValidateStackSequences(int[] pushed, int[] popped)
        {
            int pushTimes = 0;
            int popTimes = 0;
            int[] stack = new int[pushed.Length];
            int i = -1;
            while(popTimes != pushed.Length)
            {
                if (i == -1 || stack[i] != popped[popTimes])
                {
                    if(pushTimes == pushed.Length) return false;
                    i++;
                    stack[i] = pushed[pushTimes];
                    pushTimes++;
                }
                if(stack[i] == popped[popTimes])
                {
                    i--;
                    popTimes++;
                }
            }
            return true;
        }
    }
}
