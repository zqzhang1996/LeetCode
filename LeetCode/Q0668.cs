using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q0668
{
    public class Solution
    {
        double[,,] chessboard;
        public double KnightProbability(int n, int k, int row, int column)
        {
            if (k == 0) return 1;
            chessboard = new double[(n + 1) / 2, (n + 1) / 2, 2];
            for (int i = 0; i < (n + 1) / 2; i++)
            {
                for (int j = 0; j < (n + 1) / 2; j++)
                {
                    chessboard[i, j, 0] = 1;
                }
            }
            for (int i = 1; i < k; i++)
            {
                int index = i % 2;
                for (int r = 0; r < (n + 1) / 2; r++)
                {
                    for (int c = 0; c < (n + 1) / 2; c++)
                    {
                        chessboard[r, c, index] = CalcProbability(n, i, r, c);
                    }
                }
            }
            return CalcProbability(n, k, row, column);
        }

        double CalcProbability(int n, int i, int row, int col)
        {
            i--;
            return (
                GetProbability(n, i, row + 1, col + 2) +
                GetProbability(n, i, row + 1, col - 2) +
                GetProbability(n, i, row + 2, col + 1) +
                GetProbability(n, i, row + 2, col - 1) +
                GetProbability(n, i, row - 1, col + 2) +
                GetProbability(n, i, row - 1, col - 2) +
                GetProbability(n, i, row - 2, col + 1) +
                GetProbability(n, i, row - 2, col - 1)) / 8;
        }

        double GetProbability(int n, int k, int row, int col)
        {
            if (row < 0 || col < 0 || row >= n || col >= n)
            {
                return 0;
            }
            if (row >= (n + 1) / 2)
            {
                row = n - row - 1;
            }
            if (col >= (n + 1) / 2)
            {
                col = n - col - 1;
            }
            return chessboard[row, col, k % 2];
        }
    }
}
