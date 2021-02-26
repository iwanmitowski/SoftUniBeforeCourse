using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Logger
{
    class LogFile : IFile
    {
        public string Path { get; } = "LogFile.txt";

        public ulong Size => GetFileSize();

        public string Write(string message,ILayout layout, ReportLevel reportLevel,DateTime date)
        {
            return layout.Format(message, date, reportLevel);
        }

        private ulong GetFileSize()
        {
            var text = File.ReadAllText(this.Path);

            ulong size = (ulong)text.ToCharArray().Where(x => char.IsLetter(x)).Sum(x=>x);
            return size;
        }
    }
}
