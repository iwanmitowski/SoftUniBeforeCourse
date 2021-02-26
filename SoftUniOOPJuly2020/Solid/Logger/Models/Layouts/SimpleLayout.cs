using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    class SimpleLayout : ILayout
    {
        public string Format(string message,DateTime date,ReportLevel reportLevel)
        {
            return $"{date} - {reportLevel} - {message}";
        }
    }
}
