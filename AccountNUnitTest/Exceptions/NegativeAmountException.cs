using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountNUnitTest.Exceptions
{
    internal class NegativeAmountException : Exception
    {
        public NegativeAmountException(string message) : base(message)
        {
            
        }
    }
}
