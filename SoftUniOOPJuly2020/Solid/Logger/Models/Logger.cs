using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    class Logger : ILogger
    {
        public Logger(IAppender appender)
        {
            Appender = appender;
        }

        public IAppender Appender { get; private set; }

        public override string ToString()
        {
            return $"{this.Appender}";
        }
        public void Critical(DateTime date, string message)
        {
            Appender.Append(message, ReportLevel.Critical, date);
        }

        public void Error(DateTime date, string message)
        {
            Appender.Append(message, ReportLevel.Error, date);

        }

        public void Fatal(DateTime date, string message)
        {
            Appender.Append(message, ReportLevel.Fatal, date);

        }

        public void Info(DateTime date, string message)
        {
            Appender.Append(message, ReportLevel.Info, date);

        }

        public void Warning(DateTime date, string message)
        {
            Appender.Append(message, ReportLevel.Warning, date);

        }
    }
}
