using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fields)
        {
            Type typeClass = Type.GetType(className);
            FieldInfo[] classFields = typeClass.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
            object classInstance = Activator.CreateInstance(typeClass, new object[] {});
            StringBuilder txt = new StringBuilder();
            txt.AppendLine($"Class under investigation: {className}");

            foreach (var field in classFields.Where(f => fields.Contains(f.Name)))
            {
                txt.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return txt.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder txt = new StringBuilder();
            Type typeClass = Type.GetType(className);
            FieldInfo[] classFields = typeClass.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            MethodInfo[] classSetters = typeClass.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            MethodInfo[] classGetters = typeClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach(FieldInfo field in classFields)
            {
                txt.AppendLine($"{field.Name} must be private!");
            }

            foreach (MethodInfo method in classGetters.Where(m => m.Name.StartsWith("get")))
            {
                txt.AppendLine($"{method.Name} have to be public!");
            }

            foreach (MethodInfo method in classSetters.Where(m => m.Name.StartsWith("set")))
            {
                txt.AppendLine($"{method.Name} have to be private!");
            }

            return txt.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);
            StringBuilder txt = new StringBuilder();
            MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            txt.AppendLine($"All Private Methods of Class: {className}");
            txt.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach(var method in privateMethods)
            {
                txt.AppendLine(method.Name);
            }

            return txt.ToString().Trim();
        }
    }
}
