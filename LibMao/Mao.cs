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

        private List<IRule> rules;

        private List<Card> cards;

        public Mao()
        {
            Players = new List<Player>();
            DiscardPile = new List<Card>();
            cards = new List<Card>();
            cards.AddRange(new Deck().Cards);
            rules = new List<IRule>();
            rules.Add(new BaseRule());
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
                    Players[i].giveCard(DrawCard());
                }
            }

            ActiveCard = DrawCard();
        }

        public Card DrawCard()
        {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

        public List<PenaltyItem> PlayCard(Card c)
        {
            List<PenaltyItem> penalty = new List<PenaltyItem>();

            foreach (var rule in rules)
            {
                var response = rule.Evaluate(ActiveCard, c);
                if (response.Response == RuleResponse.ResponseType.Illegal)
                {
                    penalty.Add(new PenaltyItem(response.Message,DrawCard()));
                }
            }

            DiscardPile.Add(ActiveCard);
            if(cards.Count == 0)
            {
                DiscardPile.Reverse();
                cards = DiscardPile;
                DiscardPile.Clear();
            }
            ActiveCard = c;

            return penalty;
        }
    }
}
