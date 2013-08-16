using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil;

namespace TestReflection
{
    public class MbAutomationTest
    {
        public MbAutomationTest(MethodInfo method)
        {
            Name = method.Name;
            Class = method.ReflectedType.Name;
            Namespace = method.ReflectedType.FullName.Replace("." + Class, String.Empty);
            Binary = method.Module.Name;
            Folder = Namespace.Replace(Binary.Replace("dll", String.Empty), String.Empty);
            //CustomAttributes = method.CustomAttributes.ToList();
        }

        public MbAutomationTest(MethodDefinition method)
        {
            Name = method.Name;
            Class = method.DeclaringType.Name;
            Namespace = method.DeclaringType.FullName.Replace("." + Class, String.Empty);
            Binary = method.Module.Name;
            Folder = Namespace.Replace(Binary.Replace("dll", String.Empty), String.Empty);
            CustomAttributes = method.CustomAttributes.ToList();
        }

        public string Binary
        {
            get; set;
        }

        public string Class
        {
            get; set;
        }

        public List<CustomAttribute> CustomAttributes
        {
            get; set;
        } 

        public string Folder
        {
            get; set;
        } 

        public string FullName
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string Namespace
        {
            get; set;
        }


    }

    public class CustomAttributeInfo : ICustomAttribute 
    {
        public CustomAttributeInfo(CustomAttributeData data)
        {
             
        }

        public CustomAttributeInfo(CustomAttribute attribute)
        {

        }
    }
}
