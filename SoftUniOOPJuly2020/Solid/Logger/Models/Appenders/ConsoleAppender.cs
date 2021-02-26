using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    class ConsoleAppender : Appender
    {
        int messagesAppended;
        public ConsoleAppender(ILayout layout,ReportLevel reportLevel) : base(layout, reportLevel)
        {
        }

        public override void Append(string message, ReportLevel reportLevel, DateTime date)
        {
            if (this.ReportLevel <= reportLevel)
            {
                Console.WriteLine(Layout.Format(message, date, reportLevel));
                messagesAppended++;

            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString()}, Messages appended: {this.messagesAppended}"; ;
        }
    }
}
