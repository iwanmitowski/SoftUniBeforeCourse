using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger
{
    class AppenderFile : Appender
    {
        int messagesAppended;

        public AppenderFile(ILayout layout,IFile file,ReportLevel reportLevel) : base(layout,reportLevel)
        {
            this.File = file;
            this.ReportLevel = ReportLevel;
        }
        public IFile File { get; private set; }
        public override void Append(string message, ReportLevel reportLevel, DateTime date)
        {
            if (this.ReportLevel<=reportLevel)
            {
                string formatedMessage = this.File.Write(message,this.Layout, this.ReportLevel,date);
                messagesAppended++;

                System.IO.File.AppendAllText(this.File.Path, formatedMessage);//WriteAllText
            }
            
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString()}, Messages appended: {this.messagesAppended}, File size {this.File.Size}";
        }
    }
}

        