using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    class LayoutFactory : ILayoutFactory
    {
        public ILayout GetLayout(string type)
        {
            switch (type)
            {
                case "XmlLayout":
                    return new XmlLayout();
                case "SimpleLayout":
                    return new SimpleLayout();

                default:
                    throw new ArgumentException("Invalid Layout");
                   
            }
        }
    }
}
