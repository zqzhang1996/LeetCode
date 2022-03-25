using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1311
{
    public class Solution
    {
        public IList<string> WatchedVideosByFriends(IList<IList<string>> watchedVideos, int[][] friends, int id, int level)
        {
            HashSet<int> friendList = new HashSet<int> { id };
            HashSet<int> newFriendList = friends[id].ToHashSet();
            for(int i = 0; i < level; i++)
            {
                HashSet<int> tmp = new HashSet<int>();
                friendList = friendList.Union(newFriendList).ToHashSet();
                foreach(int j in friendList)
                {
                    foreach(int k in friends[j])
                    {
                        if (!friendList.Contains(k))
                        {
                            tmp.Add(k);
                        }
                    }
                }
                newFriendList = tmp;
            }
            Dictionary<string,int> map = new Dictionary<string,int>();
            foreach(int i in newFriendList)
            {
                foreach(string j in watchedVideos[i])
                {
                    if (!map.ContainsKey(j)) map[j] = 1;
                    else map[j]++;
                }
            }
            SortedList<int, SortedSet<string>> resultMap = new SortedList<int, SortedSet<string>>();
            foreach(var kvp in map)
            {
                if (!resultMap.ContainsKey(kvp.Value)) resultMap.Add(kvp.Value, new SortedSet<string> { kvp.Key });
                else resultMap[kvp.Value].Add(kvp.Key);
            }
            IList<string> result = new List<string>();
            foreach (var kvp in resultMap)
            {
                foreach (string j in kvp.Value)
                {
                    result.Add(j);
                }
            }
            return result;
        }
    }
}
