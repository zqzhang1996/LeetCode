using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1605
{
    public class Solution
    {
        public int[][] RestoreMatrix(int[] rowSum, int[] colSum)
        {
            int[][] result = new int[rowSum.Length][];
            int col = 0;
            for(int row = 0; row < rowSum.Length; row++)
            {
                int[] tmp = new int[colSum.Length];
                while(rowSum[row] != 0)
                {
                    tmp[col] = Math.Min(rowSum[row], colSum[col]);
                    rowSum[row] -= tmp[col];
                    colSum[col] -= tmp[col];
                    if(colSum[col] == 0)
                    {
                        col++;
                    }
                }
                result[row] = tmp;
            }
            return result;
        }
    }
}
