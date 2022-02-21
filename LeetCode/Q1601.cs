namespace Q1601
{
    public class Solution
    {
        public int MaximumRequests(int n, int[][] requests)
        {
            int maxCount = 0;
            for (int i = 1; i < (1 << requests.Length); i++)
            {
                int[] buildings = new int[n];
                int count = 0;
                for(int j = 0; j < requests.Length; j++)
                {
                    if((i & (1 << j)) != 0)
                    {
                        buildings[requests[j][0]]--;
                        buildings[requests[j][1]]++;
                        count++;
                    }
                }
                if(buildings.Min() == 0)
                {
                    maxCount = Math.Max(maxCount, count);
                }
            }
            return maxCount;
        }
    }
}
