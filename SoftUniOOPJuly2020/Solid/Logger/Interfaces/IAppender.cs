using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    interface IAppender
    {
        ILayout Layout { get; }
        ReportLevel ReportLevel { get; set; }
        
        void Append(string message, ReportLevel reportLevel, DateTime date);
    }
}
