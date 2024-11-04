using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountNUnitTest.Exceptions
{
    internal class NoSuchAccountExistException : Exception
    {
        public NoSuchAccountExistException(string message) : base(message) { }
    }
}
