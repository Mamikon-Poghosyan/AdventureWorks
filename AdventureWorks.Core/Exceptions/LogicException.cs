using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks.Core.Exceptions
{
    public class LogicException : Exception
    {
        public LogicException(string message)
            : base(message)
        {
        }
    }
}
