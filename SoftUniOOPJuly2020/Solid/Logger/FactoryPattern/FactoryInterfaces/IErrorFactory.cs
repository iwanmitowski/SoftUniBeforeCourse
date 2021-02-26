using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    interface IErrorFactory
    {
        ReportLevel GetError(string error);
    }
}
