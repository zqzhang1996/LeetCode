using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q0950
{
    public class Solution
    {
        public int[] DeckRevealedIncreasing(int[] deck)
        {
            int[] result = new int[deck.Length];
            Array.Sort(deck);
            for (int i = 0; i < deck.Length; i++)
            {
                result[GetOriginIndex(deck.Length, i * 2)] = deck[i];
            }
            return result;
        }

        int GetOriginIndex(int deckLength, int inedx)
        {
            if (inedx < deckLength)
            {
                return inedx;
            }
            else
            {
                return GetOriginIndex(deckLength, (inedx - deckLength) * 2 + 1);
            }
        }
    }
}
