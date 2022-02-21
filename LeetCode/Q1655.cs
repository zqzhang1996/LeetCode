using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1655
{
    public class Solution
    {
        public bool CanDistribute(int[] nums, int[] quantity)
        {
            // 统计频率
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (!dic.ContainsKey(num)) { dic[num] = 1; }
                else { dic[num]++; }
            }
            var frequencies = dic.Values.ToList();

            // 频率和小于订单和，则必定不满足
            int remain = frequencies.Sum() - quantity.Sum();
            if (remain < 0) return false;

            frequencies.Sort(comparer);
            int quantityLength = quantity.Length;
            for (int i = 0; i < quantity.Length; i++)
            {
                int k = frequencies.BinarySearch(quantity[i], comparer);
                // 移除完全匹配的对
                if (k >= 0)
                {
                    frequencies.RemoveAt(k);
                    quantity[i] = 0;
                    quantityLength--;
                }
                // 任意请求大于最大频率则必定不满足
                else if (~k == 0) return false;
            }
            // 请求清空则必定满足
            if (quantityLength == 0) return true;

            // 大到小排序
            newFrequencies = frequencies.ToArray();
            newQuantity = new int[quantityLength];
            Array.Sort(quantity, comparer);
            for (int i = 0; i < quantityLength; i++)
            {
                newQuantity[i] = quantity[i];
            }

            // 动态规划
            return Match(0, 0, new int[2] { 0, remain }, newFrequencies[0]);
        }

        IComparer<int> comparer = new ReverserComparer();
        int[] newFrequencies;
        int[] newQuantity;
        bool Match(int f, int q, int[] mark, int remain)
        {
            // 分配完成则返回true
            if (mark[0] == ((1 << newQuantity.Length) - 1)) return true;
            // 分配未完成且越界则返回false
            if (f == newFrequencies.Length) return false;
            if (q == newQuantity.Length) return false;

            if ((mark[0] & (1 << q)) == 0)
            {
                // 未使用才做判断是否填
                if (newQuantity[q] == remain)
                {
                    // 刚好填满第f个频率，分支f+1
                    if (Match(f + 1, 0, new int[2] { mark[0] | (1 << q), mark[1] },
                        f + 1 == newFrequencies.Length ? 0 : newFrequencies[f + 1])) return true;
                }
                else if (newQuantity[q] < remain)
                {
                    // 能填但不填，查找空隙是否能继续填
                    int k = Array.BinarySearch(newQuantity, q + 1, newQuantity.Length - q - 1, remain, comparer);
                    if (~k != newQuantity.Length)
                    {
                        // 可以继续填，分支k
                        if (k < 0) k = ~k;
                        if (Match(f, k, mark, remain)) return true;
                    }
                    // 能填但填不满，查找空隙是否能继续填
                    k = Array.BinarySearch(newQuantity, q + 1, newQuantity.Length - q - 1, remain - newQuantity[q], comparer);
                    if (~k != newQuantity.Length)
                    {
                        // 可以继续填，分支k
                        if (k < 0) k = ~k;
                        if (Match(f, k, new int[2] { mark[0] | (1 << q), mark[1] }, remain - newQuantity[q])) return true;
                    }
                    else
                    {
                        // 不能继续填
                        if (remain - newQuantity[q] <= mark[1])
                        {
                            // 余量足够则分支f+1
                            if (Match(f + 1, 0, new int[2] { mark[0] | (1 << q), mark[1] - remain + newQuantity[q] },
                                f + 1 == newFrequencies.Length ? 0 : newFrequencies[f + 1])) return true;
                        }
                    }
                }
                else
                {
                    // 不能填
                    if (remain <= mark[1])
                    {
                        // 余量足够则分支f+1
                        if ((f + 1 == newFrequencies.Length ? 0 : newFrequencies[f + 1]) >= newQuantity[q])
                        {
                            if (Match(f + 1, 0, new int[2] { mark[0], mark[1] - remain },
                                f + 1 == newFrequencies.Length ? 0 : newFrequencies[f + 1])) return true;
                        }
                    }
                }
            }
            else
            {
                // 已使用则找下一个未使用，找不到则终止
                for (int i = q + 1; i < newQuantity.Length; i++)
                {
                    if ((mark[0] & (1 << i)) == 0)
                    {
                        if (Match(f, i, mark, remain)) return true;
                        break;
                    }
                }

            }
            return false;
        }
    }

    class ReverserComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y - x;
        }
    }
}
