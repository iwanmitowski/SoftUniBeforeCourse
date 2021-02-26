using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    class AppenderFactory : IAppenderFactory
    {
        public IAppender GetAppender(string appenderType, string layoutType, string reportLevel)
        {
            LayoutFactory layoutFactory = new LayoutFactory();
            ErrorFactory errorFactory = new ErrorFactory();
            LogFileFactory logFileFactory = new LogFileFactory();


            ILayout layout = layoutFactory.GetLayout(layoutType);
            ReportLevel error = errorFactory.GetError(reportLevel);
            IFile file = logFileFactory.GetLogFile();


            switch (appenderType)
            {
                case "ConsoleAppender":
                    return new ConsoleAppender(layout,error);
                case "FileAppender":
                    return new AppenderFile(layout,file,error);
                default:
                    throw new ArgumentException("Invalid AppenderType");
            }
        }
    }
}
