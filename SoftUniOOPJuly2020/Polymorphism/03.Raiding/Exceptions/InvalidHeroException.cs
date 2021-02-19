using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    class InvalidHeroException : Exception
    {
        private const string IHEMessage = "Invalid hero!";
        public InvalidHeroException() : base(IHEMessage)
        {

        }
    }
}
