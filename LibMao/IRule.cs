using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mao
{
    
    public interface IRule
    {
        RuleResponse Evaluate(Card active, Card played);
    }
}
