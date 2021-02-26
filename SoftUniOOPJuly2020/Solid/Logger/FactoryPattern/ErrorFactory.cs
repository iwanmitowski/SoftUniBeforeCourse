using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    class ErrorFactory : IErrorFactory
    {
        public ReportLevel GetError(string error)
        {
            switch (error.ToLower())
            {
                case "critical":
                    return ReportLevel.Critical;
                case "error":
                    return ReportLevel.Error;
                case "fatal":
                    return ReportLevel.Fatal;
                case "info":
                    return ReportLevel.Info;
                case "warning":
                    return ReportLevel.Warning;
                case "":
                    return ReportLevel.Info;//за да извърти всичките
                default:
                    throw new ArgumentNullException("Invalid error");
            }
        }
    }
}
