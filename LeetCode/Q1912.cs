using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1912
{
    public class MovieRentingSystem
    {
        /// <summary>
        /// shop movie price
        /// </summary>
        Dictionary<int, Dictionary<int, int>> priceList = new Dictionary<int, Dictionary<int, int>>();
        /// <summary>
        /// movie price shop
        /// </summary>
        Dictionary<int, SortedList<int, SortedSet<int>>> unrentedList = new Dictionary<int, SortedList<int, SortedSet<int>>>();
        /// <summary>
        /// price shop movie
        /// </summary>
        SortedList<int, SortedList<int, SortedSet<int>>> rentedList = new SortedList<int, SortedList<int, SortedSet<int>>>();

        public MovieRentingSystem(int n, int[][] entries)
        {
            foreach (var entry in entries)
            {
                // shop movie price
                if (!priceList.ContainsKey(entry[0]))
                {
                    priceList.Add(entry[0], new Dictionary<int,int>());
                }
                priceList[entry[0]][entry[1]] = entry[2];
                if (!unrentedList.ContainsKey(entry[1]))
                {
                    unrentedList.Add(entry[1], new SortedList<int, SortedSet<int>>());
                }
                if (!unrentedList[entry[1]].ContainsKey(entry[2]))
                {
                    unrentedList[entry[1]].Add(entry[2], new SortedSet<int>());
                }
                unrentedList[entry[1]][entry[2]].Add(entry[0]);
            }
        }

        public IList<int> Search(int movie)
        {
            IList<int> results = new List<int>();
            if(!unrentedList.ContainsKey(movie)) return results;
            foreach (var movieId in unrentedList[movie])
            {
                foreach(var shopId in movieId.Value)
                {
                    results.Add(shopId);
                    if(results.Count == 5) return results;
                }
            }
            return results;
        }

        public void Rent(int shop, int movie)
        {
            int price = priceList[shop][movie];
            unrentedList[movie][price].Remove(shop);
            if (!rentedList.ContainsKey(price))
            {
                rentedList.Add(price, new SortedList<int,SortedSet<int>>());
            }
            if (!rentedList[price].ContainsKey(shop))
            {
                rentedList[price].Add(shop, new SortedSet<int>());
            }
            rentedList[price][shop].Add(movie);
        }

        public void Drop(int shop, int movie)
        {
            int price = priceList[shop][movie];
            rentedList[price][shop].Remove(movie);
            unrentedList[movie][price].Add(shop);
        }

        public IList<IList<int>> Report()
        {
            IList<IList<int>> report = new List<IList<int>>();
            foreach(var price in rentedList)
            {
                foreach(var shopId in price.Value)
                {
                    foreach(var movieId in shopId.Value)
                    {
                        report.Add(new List<int>() { shopId.Key, movieId });
                        if(report.Count ==5) return report;
                    }
                }
            }
            return report;
        }
    }
}
