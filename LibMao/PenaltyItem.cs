using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mao
{
    public class PenaltyItem
    {
        public PenaltyItem(string reason, Card penalty)
        {
            Reason = reason;
            Penalty = penalty;
        }

        public string Reason;
        public Card Penalty;
    }
}
