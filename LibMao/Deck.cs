using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mao
{
    public class Deck
    {
        public List<Card> Cards;

        public Deck()
        {
            Cards = new List<Card>();
            for(int i = 0; i < 4; i++)
            {
                for(int c = 1; c < 13; c++)
                {
                    Cards.Add(new Card((Suit)i,(CardValue)c));
                }
            }
        }

        public static void Shuffle(List<Card> cards)
        {
            Random r = new Random();
            for(int i = cards.Count - 1; i > 0; i--)
            {
                int target = r.Next(i + 1);
                Card tmp = cards[i];
                cards[i] = cards[target];
                cards[target] = tmp;
            }
        }
    }
}
