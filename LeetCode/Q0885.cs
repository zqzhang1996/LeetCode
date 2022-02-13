using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q0885
{
    public class Solution
    {
        public int[][] SpiralMatrixIII(int rows, int cols, int rStart, int cStart)
        {
            int[][] ans = new int[rows * cols][];
            int rowPos = rStart, colPos = cStart;
            int rowVector = 0, colVector = 1;
            int index = 0;
            int step = 2;
            while (index < rows * cols)
            {
                for (int j = 0; j < step / 2; j++)
                {
                    if (0 <= rowPos && rowPos < rows && 0 <= colPos && colPos < cols)
                    {
                        ans[index] = new int[2] { rowPos, colPos };
                        index++;
                    }
                    rowPos += rowVector;
                    colPos += colVector;
                }
                step++;
                colVector = rowVector ^ colVector;
                rowVector = rowVector ^ colVector;
                colVector = (rowVector ^ colVector) * -1;
            }
            return ans;
        }
    }
}
