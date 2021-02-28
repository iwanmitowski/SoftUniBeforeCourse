using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    class Spy
    {
        public string CollectGettersAndSetters(string classToInvestigate)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(classToInvestigate);

            MethodInfo[] allTheMethods = classType.GetMethods();

            foreach (var method in allTheMethods.Where(m => m.Name.Contains("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (var method in allTheMethods.Where(m => m.Name.Contains("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.ReturnType}");
            }

            return sb.ToString().Trim();
        }
    }
}
