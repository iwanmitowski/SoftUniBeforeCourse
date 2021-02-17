﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string lastName,int codeNumber) : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Code Number: {this.CodeNumber}");
            return sb.ToString().Trim();
        }
    }
}
