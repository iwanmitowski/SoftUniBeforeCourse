using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
   abstract class Appender : IAppender
    {
        protected Appender(ILayout layout,ReportLevel reportLevel)
        {
            Layout = layout;
            ReportLevel = reportLevel;
        }
        public ReportLevel ReportLevel { get; set; }
        public ILayout Layout { get; private set; }
        
        public abstract void Append(string message, ReportLevel reportLevel, DateTime date);
        
    }
}
