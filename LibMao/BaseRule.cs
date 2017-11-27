namespace Mao
{
    public class BaseRule : IRule
    {
        public RuleResponse Evaluate(Card active, Card played)
        {
            RuleResponse response = new RuleResponse();

            if (active.Suit == played.Suit || active.Value == played.Value)
            {
                response.Response = RuleResponse.ResponseType.Legal;
                response.Message = "The move is legal";
            }
            else
            {
                response.Response = RuleResponse.ResponseType.Illegal;
                response.Message = "Incorrect play";
            }

            return response;
        }
    }
}