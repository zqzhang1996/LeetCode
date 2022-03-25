using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q0661
{
    public class Solution
    {
        public int[][] ImageSmoother(int[][] img)
        {
            int[][] result = new int[img.Length][];
            for(int i = 0; i < img.Length; i++)
            {
                result[i] = new int[img[i].Length];
                for (int j = 0; j < img[i].Length; j++)
                {
                    int numerator = 0;
                    int denominator = 0;
                    for (int m = -1; m != 2; m++)
                    {
                        if (i + m == -1 || i + m == img.Length) continue;
                        for (int n = -1; n != 2; n++)
                        {
                            if (j + n == -1 || j + n == img[i].Length) continue;
                            numerator += img[i + m][j + n];
                            denominator++;
                        }
                    }
                    result[i][j] = numerator / denominator;
                }
            }
            return result;
        }
    }
}
