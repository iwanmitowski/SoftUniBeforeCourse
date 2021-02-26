using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    class XmlLayout : ILayout
    {
        public string Format(string message, DateTime date, ReportLevel reportLevel)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<log>");
            sb.AppendLine($"   <date>{date}</date>");
            sb.AppendLine($"   <level>{reportLevel}</level>");
            sb.AppendLine($"   <message>{message}</message>");
            sb.AppendLine("</log>");

            return sb.ToString().Trim();

        }
    }
}
