using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1001
{
    public class Tset
    {
        public void Test()
        {
            //5
            //[[0, 0],[4,4]]
            //[[1,1],[1,0]]
            int n = 5;
            int[][] lamps = new int[2][] { new int[] { 0, 0, }, new int[] { 0, 4 } };
            int[][] queries = new int[3][] { new int[] { 0, 4 }, new int[] { 0, 1 }, new int[] { 1, 4 } };

            //10
            //[[3, 9],[3,6],[8,3],[5,3],[8,1],[1,3],[5,9],[4,2]]
            //[[1,9],[4,9],[7,1],[6,9]]
            //int n = 10;
            //int[][] lamps = new int[8][] { new int[] { 3, 9 }, new int[] { 3, 6 }, new int[] { 8, 3 }, new int[] { 5, 3 }, new int[] { 8, 1 }, new int[] { 1, 3 }, new int[] { 5, 9 }, new int[] { 4, 2 }, };
            //int[][] queries = new int[4][] { new int[] { 1, 9 }, new int[] { 4, 9 }, new int[] { 7, 1 }, new int[] { 6, 9 }, };

            int[] ans = new Q1001.Solution().GridIllumination(n, lamps, queries);
            string str = "[";
            foreach (int i in ans)
            {
                str += i + ", ";
            }
            str += "]";
            Console.WriteLine(str);
        }
    }
    public class Solution
    {
        public int[] GridIllumination(int n, int[][] lamps, int[][] queries)
        {
            int[] ans = new int[queries.Length];

            //点灯
            Lamp[] lampList = new Lamp[lamps.Length];
            for (int i = 0; i < lamps.Length; i++)
            {
                lampList[i] = new Lamp(lamps[i]);
            }
            Array.Sort(lampList);
            Lamp tmpLamp = null;
            for (int i = 0; i < lampList.Length; i++)
            {
                if(lampList[i] != null)
                {
                    if (lampList[i].CompareTo(tmpLamp) !=0)
                    {
                        tmpLamp = lampList[i];
                    }
                    else
                    {
                        lampList[i] = null;
                    }
                }
            }
            Array.Sort(lampList);
            
            //统计亮度
            Light[][] lightList = new Light[4][] {
                new Light[lamps.Length],
                new Light[lamps.Length],
                new Light[lamps.Length],
                new Light[lamps.Length],
            };
            for (int i = 0; i < lamps.Length; i++)
            {
                if (lampList[i] != null)
                {
                    lightList[0][i] = new Light(lampList[i].row);
                    lightList[1][i] = new Light(lampList[i].col);
                    lightList[2][i] = new Light(lampList[i].row + lampList[i].col);
                    lightList[3][i] = new Light(lampList[i].row - lampList[i].col);
                }
            }
            Array.Sort(lightList[0]);
            Array.Sort(lightList[1]);
            Array.Sort(lightList[2]);
            Array.Sort(lightList[3]);
            for(int i = 0; i < 4; i++)
            {
                int tmpIndex = -1;
                Light tmpLight = null;
                for (int j = 0; j < lamps.Length; j++)
                {
                    if(lightList[i][j] != null)
                    {
                        Console.WriteLine(i);
                        Console.WriteLine(j);
                        Console.WriteLine(lightList[i][j] != null);
                        Console.WriteLine(lightList[i][j].index);
                        Console.WriteLine(lightList[i][j].count);
                        if(lightList[i][j].CompareTo(tmpLight) != 0)
                        {
                            tmpLight = lightList[i][j];
                            tmpIndex = j;
                        }
                        else
                        {
                            lightList[i][j] = null;
                            lightList[i][tmpIndex].count++;
                        }
                    }
                }
            }
            Array.Sort(lightList[0]);
            Array.Sort(lightList[1]);
            Array.Sort(lightList[2]);
            Array.Sort(lightList[3]);

            for(int i = 0; i < queries.Length; i++)
            {
                //检查
                ans[i] = IsIlluminated(ref lightList,queries[i]);
                //关灯
                for(int j = 0; j < 3; j++)
                {
                    for(int k = 0;k<3; k++)
                    {
                        CloseLamp(ref lampList, ref lightList, new Lamp(new int[] { queries[i][0] - 1 + j, queries[i][1] - 1 + k }));
                    }
                }
            }

            return ans;
        }

        //检查
        static int IsIlluminated(ref Light[][] lightList, int[] query)
        {
            int i = Array.BinarySearch(lightList[0], new Light(query[0]));
            if (i >= 0)
            {
                if (lightList[0][i].count != 0)
                {
                    return 1;
                }
            }
            i = Array.BinarySearch(lightList[1], new Light(query[1]));
            if (i >= 0)
            {
                if (lightList[1][i].count != 0)
                {
                    return 1;
                }
            }
            i = Array.BinarySearch(lightList[2], new Light(query[0] + query[1]));
            if (i >= 0)
            {
                if (lightList[2][i].count != 0)
                {
                    return 1;
                }
            }
            i = Array.BinarySearch(lightList[3], new Light(query[0] - query[1]));
            if (i >= 0)
            {
                if (lightList[3][i].count != 0)
                {
                    return 1;
                }
            }
            return 0;
        }

        //关灯
        static void CloseLamp(ref Lamp[] lampList, ref Light[][] lightList, Lamp lamp)
        {

            int i = Array.BinarySearch(lampList, lamp);
            if (i < 0)
            {
                return;
            }
            else
            {
                if (lampList[i].isOn)
                {
                    lampList[i].isOn = false;
                    int index;
                    lightList[0][Array.BinarySearch(lightList[0], new Light(lampList[i].row))].count--;
                    lightList[1][Array.BinarySearch(lightList[1], new Light(lampList[i].col))].count--;
                    lightList[2][Array.BinarySearch(lightList[2], new Light(lampList[i].row + lampList[i].col))].count--;
                    lightList[3][Array.BinarySearch(lightList[3], new Light(lampList[i].row - lampList[i].col))].count--;
                }
            }
        }
    }

    class Lamp : IComparable<Lamp>
    {
        public int row;
        public int col;
        public bool isOn;

        public Lamp(int[] lamp)
        {
            row = lamp[0];
            col = lamp[1];
            isOn = true;
        }

        public int CompareTo(Lamp? other)
        {
            if (this == null) return -1;
            if (other == null) return 1;
            if (row - other.row != 0)
            {
                return row - other.row;
            }
            else
            {
                return col - other.col;
            }
        }
    }

    class Light : IComparable<Light>
    {
        public int index;
        public int count;

        public Light(int lamp)
        {
            index = lamp;
            count = 1;
        }

        public int CompareTo(Light? other)
        {
            if (this == null) return -1;
            if (other == null) return 1;
            return index - other.index;
        }
    }
}
