using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    interface ILayoutFactory
    {
        ILayout GetLayout(string type);
    }
}
