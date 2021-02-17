using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    class InvalidCorpsException : Exception
    {
        public InvalidCorpsException()
            : base()
        {

        }

        public InvalidCorpsException(string message)
            :base(message)
        {

        }
    }
}
