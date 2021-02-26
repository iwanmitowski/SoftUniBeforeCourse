using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    interface ILogger
    {
        IAppender Appender{get;}
        void Info(DateTime date,string message);
        void Warning(DateTime date, string message);
        void Error(DateTime date, string message);
        void Critical(DateTime date, string message);
        void Fatal(DateTime date, string message);
    }
}
