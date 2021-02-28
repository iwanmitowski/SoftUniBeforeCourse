using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    class Spy
    {
        public string AnalyzeAcessModifiers(string classToInvestigate)
        {
            Type classType = Type.GetType(classToInvestigate);
            
            StringBuilder sb = new StringBuilder();
            FieldInfo[] fieldInfo = classType.GetFields(BindingFlags.Instance|BindingFlags.Public|BindingFlags.Static);
            MethodInfo[] gettersInfo = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] settersInfo = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var item in fieldInfo)
            {
                sb.AppendLine($"{item.Name} must be private!");
            }

            foreach (var item in gettersInfo.Where(m=>m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{item.Name} have to be public!");
            }

            foreach (var item in settersInfo.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{item.Name} have to be private!");
            }
            return sb.ToString().Trim() ;
        }
    }
}
