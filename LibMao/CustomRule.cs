using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mao
{
    public class CustomRule : IRule
    {
        private string _incorrectResponseMessage;
        private RuleResponse.ResponseType _correctResponse;
        private RuleResponse.ResponseType _incorrectResponse;

        public CustomRule(string incorrectMessage, RuleResponse.ResponseType correct,
            RuleResponse.ResponseType incorrect)
        {
            _incorrectResponseMessage = incorrectMessage;
            _correctResponse = correct;
            _incorrectResponse = incorrect;
        }


        public RuleResponse Evaluate(Card active, Card played)
        {
            var response = new RuleResponse();

            return response;
        }
    }
}
