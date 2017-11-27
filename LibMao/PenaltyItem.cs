using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mao
{
    public class PenaltyItem
    {
        public PenaltyItem(string reason, Card penalty, RuleResponse.ResponseType response)
        {
            Reason = reason;
            Penalty = penalty;
            Response = response;
        }

        public string Reason;
        public Card Penalty;
        public RuleResponse.ResponseType Response;
    }
}
