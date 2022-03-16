using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q0289
{
    public class Solution
    {
        public void GameOfLife(int[][] board)
        {
            int rowLength = board.Length;
            int colLength = board[0].Length;
            int temp;
            for (int row = 0; row < rowLength; row++)
            {
                for (int col = 0; col < colLength; col++)
                {
                    temp = 0;
                    for (int i = -1; i != 2; i++)
                    {
                        if (row + i == -1) continue;
                        if (row + i == rowLength) continue;
                        for (int j = -1; j != 2; j++)
                        {
                            if (col + j == -1) continue;
                            if (col + j == colLength) continue;
                            if (i == 0 && j == 0) continue;
                            temp += (board[row + i][col + j] & 1);
                        }
                    }
                    if (temp == 2)
                    {
                        board[row][col] *= 3;
                    }
                    else if (temp == 3)
                    {
                        board[row][col] += 2;
                    }
                }
            }
            for (int row = 0; row < rowLength; row++)
            {
                for (int col = 0; col < colLength; col++)
                {
                    board[row][col] >>= 1;
                }
            }
        }
    }
}
