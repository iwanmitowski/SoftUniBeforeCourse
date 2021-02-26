using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    class LogFileFactory : ILogFileFactory
    {
        public IFile GetLogFile() => new LogFile();
        
    }
}
