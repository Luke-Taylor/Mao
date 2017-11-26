using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMao
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

        public void Shuffle()
        {
            Random r = new Random();
            for(int i = Cards.Count - 1; i > 0; i--)
            {
                int target = r.Next(i + 1);
                Card tmp = Cards[i];
                Cards[i] = Cards[target];
                Cards[target] = tmp;
            }
        }
    }
}
