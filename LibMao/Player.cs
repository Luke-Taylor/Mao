using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMao
{
    public class Player
    {
        public String Name;
        public List<Card> Hand;
        public int Score;

        public Player(String name, int score = 0)
        {
            Name = name;
            Score = score;
        }

        public void giveCard(Card c)
        {
            Hand.Add(c);
        }
    }
}
