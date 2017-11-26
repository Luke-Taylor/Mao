using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMao
{
    public class Mao
    {
        public List<Player> Players;

        private List<Deck> cards;

        public Mao()
        {
            Players = new List<Player>();
        }

        public void AddPlayer(String name)
        {
            Players.Add(new Player(name));
        }
    }
}
