using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    class InvalidInputException : Exception
    {
        public InvalidInputException()
        {
        }
        public InvalidInputException(string message)
            :base(message)
        {
        }
    }
}
