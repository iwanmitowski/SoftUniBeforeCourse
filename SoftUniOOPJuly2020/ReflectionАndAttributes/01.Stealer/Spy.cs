using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    class Spy
    {
        public string StealFieldInfo(string classToInvestigate, params string[] nameOfFields)
        {
            StringBuilder sb = new StringBuilder();


            Type classType = Type.GetType(classToInvestigate);

            FieldInfo[] fieldInfo = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

            Object classInstance = Activator.CreateInstance(classType);


            sb.AppendLine($"Class under investigation: {classToInvestigate}");

            foreach (FieldInfo fi in fieldInfo.Where(f => nameOfFields.Contains(f.Name)))
            {
                sb.AppendLine($"{fi.Name} = {fi.GetValue(classInstance)}");
            }
            return sb.ToString().Trim();
        }
    }
}
