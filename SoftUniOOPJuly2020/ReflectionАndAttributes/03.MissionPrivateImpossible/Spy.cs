using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    class Spy
    {
        public string RevealPrivateMethods(string classToInvestigate)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(classToInvestigate);

            MethodInfo[] allClassMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            sb.AppendLine($"All Private Methods of Class: {classType.Name}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");
            foreach (var m in allClassMethods)
            {
                sb.AppendLine($"{m.Name}");
            }
            return sb.ToString().Trim();
        }
    }
}
