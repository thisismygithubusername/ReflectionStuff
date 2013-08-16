using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil;
using Mono.Cecil.Rocks;

namespace TestReflection
{
    public enum ExtractionMethod
    {
        Reflection,

        MonoCecil
    }

    public class GetTests
    {
        public static string GallioTestAnnotation = "FactAttribute";

        public static MbTestPackage BuildTestPackage(string cybertronAssembly, ExtractionMethod method)
        {
            switch (method)
            {
                case ExtractionMethod.Reflection:
                    return new MbTestPackage(GetMethodsWithAttribute(Assembly.LoadFrom(cybertronAssembly).GetTypes(), GallioTestAnnotation));
                case ExtractionMethod.MonoCecil:
                    return new MbTestPackage(GetMethodsWithAttribute(ModuleDefinition.ReadModule(cybertronAssembly).GetTypes(), GallioTestAnnotation));
                default:
                    throw new NotSupportedException("The target load method isn't supported!");
            }
        }

        private static IEnumerable<MethodInfo> GetMethodsWithAttribute(IEnumerable<Type> types, string desiredAttribute)
        {
            return (from type in types
                    from method in type.GetMethods()
                    let customAttributes = method.CustomAttributes
                    where customAttributes.Any(attribute => attribute.AttributeType.Name.Equals(desiredAttribute))
                    select method).ToList();
        }

        private static IEnumerable<MethodDefinition> GetMethodsWithAttribute(IEnumerable<TypeDefinition> types, string desiredAttribute)
        {
            return (from type in types
                    from method in type.GetMethods()
                    let customAttributes = method.CustomAttributes
                    where customAttributes.Any(attribute => attribute.AttributeType.Name.Equals(desiredAttribute))
                    select method).ToList(); 
        }

    }
}
