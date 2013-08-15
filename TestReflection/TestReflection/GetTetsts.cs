using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MbUnit.Framework;
using TestReflection.AssemblyLoading;

namespace TestReflection
{
    public class GetTests
    {
        public static string GallioTestAnnotation = "TestAttribute";

        public static MbTestPackage All(Assembly cybertronAssembly)
        {
            return new MbTestPackage(GetMethodsWithAttribute(cybertronAssembly.GetTypes(), GallioTestAnnotation));
        }

        private static IEnumerable<MethodInfo> GetMethodsWithAttribute(IEnumerable<Type> types, string desiredAttribute)
        {
            return (from type in types
                    from method in type.GetMethods()
                    let customAttributes = method.CustomAttributes
                    where customAttributes.Any(attribute => attribute.AttributeType.Name.Equals(desiredAttribute))
                    select method).ToList();
        }

    }
}
