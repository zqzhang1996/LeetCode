using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1298
{
    public class Solution
    {
        public int MaxCandies(int[] status, int[] candies, int[][] keys, int[][] containedBoxes, int[] initialBoxes)
        {
            int result = 0;
            HashSet<int>[] boxList = new HashSet<int>[] { new HashSet<int>(initialBoxes), new HashSet<int>(), new HashSet<int>() };
            HashSet<int>[] keyList = new HashSet<int>[] { new HashSet<int>(), new HashSet<int>(), new HashSet<int>() };
            int i = 0;
            while (boxList[i].Count != 0 || keyList[i].Count != 0)
            {
                foreach (int box in boxList[i])
                {
                    if (status[box] == 1 || keyList[2].Contains(box))
                    {
                        result += candies[box];
                        foreach (int newKey in keys[box])
                        {
                            keyList[i ^ 1].Add(newKey);
                        }
                        foreach (int newBox in containedBoxes[box])
                        {
                            boxList[i ^ 1].Add(newBox);
                        }
                    }
                    else
                    {
                        boxList[2].Add(box);
                    }
                }
                boxList[i].Clear();
                foreach(int key in keyList[i])
                {
                    if (boxList[2].Contains(key))
                    {
                        boxList[2].Remove(key);
                        result += candies[key];
                        foreach (int newKey in keys[key])
                        {
                            keyList[i ^ 1].Add(newKey);
                        }
                        foreach (int newBox in containedBoxes[key])
                        {
                            boxList[i ^ 1].Add(newBox);
                        }
                    }
                    else
                    {
                        keyList[2].Add(key);
                    }
                }
                keyList[i].Clear();
                i ^= 1;
            }
            return result;
        }
    }
}
