using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q0542
{
    public class Solution
    {
        public int[][] UpdateMatrix(int[][] mat)
        {
            // 转换标记
            for(int x = 0; x < mat.Length; x++)
            {
                for(int y = 0; y < mat[x].Length; y++)
                {
                    mat[x][y] -= 2;
                }
            }
            // 处理数据
            for (int x = 0; x < mat.Length; x++)
            {
                for (int y = 0; y < mat[x].Length; y++)
                {
                    if(mat[x][y] == -2)
                    {
                        Updata(mat, x, y, 0);
                    }
                }
            }
            return mat;
        }
        void Updata(int[][] mat,int x, int y, int num)
        {
            if (mat[x][y] < 0)
            {
                // 未处理过，仅有-2和-1
                mat[x][y] = mat[x][y] == -2 ? 0 : num;
            }
            else
            {
                // 已处理过，新值更小则更新，新值更大则终止
                if (mat[x][y] > num)
                {
                    mat[x][y] = num;
                }
                else
                {
                    return;
                }
            }
            // 四面递归
            if (x != 0) Updata(mat, x - 1, y , mat[x][y] + 1);
            if (x != mat.Length - 1) Updata(mat, x + 1, y, mat[x][y] + 1);
            if (y != 0) Updata(mat, x, y - 1, mat[x][y] + 1);
            if (y != mat[0].Length - 1) Updata(mat, x, y + 1, mat[x][y] + 1);
        }
    }
}
