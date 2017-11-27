using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mao
{
    public class RuleResponse
    {
        public ResponseType Response;
        public String Message;

        public enum ResponseType
        {
            Legal,
            Illegal,
            Reverse
        }
    }
}
