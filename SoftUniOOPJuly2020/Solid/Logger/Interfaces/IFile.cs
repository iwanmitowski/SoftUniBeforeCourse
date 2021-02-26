using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    interface IFile
    {
        string Path { get; }
        ulong Size { get; }
        string Write(string message,ILayout layout, ReportLevel reportLevel,DateTime date);
    }
}
