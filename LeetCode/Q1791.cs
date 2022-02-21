using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1791
{
    public class Solution
    {
        public int FindCenter(int[][] edges)
        {
            return edges[1].Contains(edges[0][0]) ? edges[0][0] : edges[0][1];
        }
    }
}
