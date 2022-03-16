using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1333
{
    public class Solution
    {
        public IList<int> FilterRestaurants(int[][] restaurants, int veganFriendly, int maxPrice, int maxDistance)
        {
            IList<int> result = new List<int>();
            var temp = restaurants.OrderBy(x => (((long)x[1] << 32) + x[0]) * -1);
            foreach (int[] restaurant in temp)
            {
                if (veganFriendly - restaurant[2] != 1)
                {
                    if (maxPrice >= restaurant[3])
                    {
                        if (maxDistance >= restaurant[4])
                        {
                            result.Add(restaurant[0]);
                        }
                    }
                }
            }
            return result;
        }
    }
}
