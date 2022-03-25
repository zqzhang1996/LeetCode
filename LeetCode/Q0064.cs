using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q0064
{
    public class Solution
    {
        public int MinPathSum(int[][] grid)
        {
            for (int x = 0; x < grid.Length; x++)
            {
                for (int y = 0; y < grid[x].Length; y++)
                {
                    if(x == 0)
                    {
                        if (y != 0)
                        {
                            grid[x][y] += grid[x][y - 1];
                        }
                    }
                    else
                    {
                        if(y == 0)
                        {
                            grid[x][y] += grid[x - 1][y];
                        }
                        else
                        {
                            grid[x][y] += grid[x - 1][y] < grid[x][y - 1] ? grid[x - 1][y] : grid[x][y - 1];
                        }
                    }
                }
            }
            return grid[grid.Length - 1][grid[0].Length - 1];
        }
    }
}
