using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q0593
{
    public class Solution
    {
        public bool ValidSquare(int[] p1, int[] p2, int[] p3, int[] p4)
        {
            HashSet<int> squaredDistance = new HashSet<int>();
            squaredDistance.Add(GetSquaredDistance(p1, p2));
            squaredDistance.Add(GetSquaredDistance(p1, p3));
            squaredDistance.Add(GetSquaredDistance(p1, p4));
            squaredDistance.Add(GetSquaredDistance(p2, p3));
            squaredDistance.Add(GetSquaredDistance(p2, p4));
            squaredDistance.Add(GetSquaredDistance(p3, p4));
            return squaredDistance.Count == 2 && !squaredDistance.Contains(0);
        }

        int GetSquaredDistance(int[] p1, int[] p2)
        {
            return (p1[0] - p2[0]) * (p1[0] - p2[0]) + (p1[1] - p2[1]) * (p1[1] - p2[1]);
        }
    }
}
