using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    interface IAppenderFactory
    {
        IAppender GetAppender(string appenderType, string layoutType, string reportLevel);
    }
}
