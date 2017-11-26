using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mao
{
    public class Mao
    {
        public List<Player> Players;
        public List<Card> DiscardPile;
        public Card ActiveCard;

        private List<Card> cards;

        public Mao()
        {
            Players = new List<Player>();
            DiscardPile = new List<Card>();
            cards = new List<Card>();
            cards.AddRange(new Deck().Cards);
        }

        public void AddPlayer(String name)
        {
            Players.Add(new Player(name));
            if(Players.Count % 3 == 0)
            {
                cards.AddRange(new Deck().Cards);
            }
        }

        public void Deal()
        {
            Deck.Shuffle(cards);

            for(int i = 0; i < Players.Count; i++)
            {
                for(int c = 0; c < 7; c++)
                {
                    Card card = cards[0];
                    cards.RemoveAt(0);
                    Players[i].giveCard(card);
                }
            }

            ActiveCard = cards[0];
            cards.RemoveAt(0);
        }

        public void PlayCard(Card c)
        {
            DiscardPile.Add(ActiveCard);
            if(cards.Count == 0)
            {
                DiscardPile.Reverse();
                cards = DiscardPile;
                DiscardPile.Clear();
            }
            ActiveCard = c;
        }
    }
}
