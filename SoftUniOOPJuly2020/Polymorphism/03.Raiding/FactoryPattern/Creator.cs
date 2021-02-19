using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
   abstract class Creator
    {
        public abstract BaseHero FactoryMethod(string type, string name);
    }
}
