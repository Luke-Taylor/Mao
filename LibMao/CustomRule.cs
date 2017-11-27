using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mao
{
    public class CustomRule : IRule
    {
        public enum MatchType
        {
            Suit,
            Card,
            Exact,
            Target
        }

        private string _incorrectResponseMessage;
        private RuleResponse.ResponseType _correctResponse;
        private RuleResponse.ResponseType _incorrectResponse;
        private MatchType _match;
        private Card _target;

        public CustomRule(string incorrectMessage, RuleResponse.ResponseType correct,
            RuleResponse.ResponseType incorrect, MatchType match, Card target = null)
        {
            _incorrectResponseMessage = incorrectMessage;
            _correctResponse = correct;
            _incorrectResponse = incorrect;
            _match = match;
            _target = target;
        }


        public RuleResponse Evaluate(Card current, Card played)
        {
            var response = new RuleResponse();
            var success = false;

            var active = (_target ?? current);

            switch (_match)
            {
                case MatchType.Suit:
                    if (active.Suit == played.Suit)
                    {
                        success = true;
                    }
                    break;
                case MatchType.Card:
                    if (active.Value == played.Value)
                    {
                        success = true;
                    }
                    break;
                case MatchType.Exact:
                    if (active.Suit == played.Suit || active.Value == played.Value)
                    {
                        success = true;
                    }
                    break;
                case MatchType.Target:
                    if (played == _target)
                    {
                        response.Response = _incorrectResponse;
                        response.Message = _incorrectResponseMessage;
                        return response;
                    }
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (success)
            {
                response.Message = "";
                response.Response = _correctResponse;
            }
            else
            {
                response.Message = _incorrectResponseMessage;
                response.Response = _incorrectResponse;
            }

            return response;
        }
    }
}
