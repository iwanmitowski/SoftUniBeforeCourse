﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    interface ILogFileFactory
    {
        IFile GetLogFile();
    }
}
