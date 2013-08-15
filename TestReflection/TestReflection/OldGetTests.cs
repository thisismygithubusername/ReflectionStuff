using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MbUnit.Framework;
using TestReflection.AssemblyLoading;


namespace TestReflection
{
    public static class OldGetTests
    {
        public static string GallioTestAnnotation = "TestAttribute";

        public static MbTestPackage ByFolders(string assemblyLocation, List<string> folders)
        {

            //Assembly.ReflectionOnlyLoad(assemblyLocation).
            return new MbTestPackage();
        }

        public static MbTestPackage ByNames(string assemblyLocation, List<string> names)
        {
            return new MbTestPackage();
        }

        public static MbTestPackage ByClassNames(string assemblyLocation, List<string> classNames)
        {
            return new MbTestPackage();
        }

        public static MbTestPackage ByCategories(string assemblyLocation, List<string> category)
        {
            return new MbTestPackage();
        }

        public static MbTestPackage ByCustomAtrributes(string assemblyLocation, List<string> customAttr)
        {
            return new MbTestPackage();
        }

        public static MbTestPackage ByGallioAttributes(string assemblyLocation, List<string> gallioAttr)
        {
            return new MbTestPackage();
        }

        public static MbTestPackage ByAllTests(string assemblyLocation)
        {
            //var tests = GetMethodsWithAttributeNameFromTypes(GetAssembly(assemblyLocation).GetTypes(), GallioTestAnnotation);
            var tests = DoShit(GetAssembly(assemblyLocation).GetTypes());
            return new MbTestPackage(tests);
        }
        [Test]
        public static void TestThisThing()
        {
            var package = ByAllTests(DefaultAssemblies.Assemblylocationz);
        }

        private static IEnumerable<MethodInfo> GetMethodsWithAttributeNameFromTypes(IEnumerable<Type> types, string attrName)
        {
            return (from type in types from memberInfo in type.GetMethods() where memberInfo.Name.Equals(attrName) select memberInfo).ToList();
        }

        //unused
        private static List<MemberInfo> DoMoreShit(IEnumerable<MemberInfo> methods)
        {
            return methods.Where(memberInfo => memberInfo.Name.Equals(GallioTestAnnotation)).ToList();
        }

        //unused
        private static List<MethodInfo> DoShit(IEnumerable<Type> Types)
        {
            var list = new List<MethodInfo>();
            foreach (var type in Types)
            {
                var members = type.GetMethods();
                foreach (var memberInfo in members)
                {
                    var customattrs = memberInfo.CustomAttributes;

                    if (ContainCustomAttr(customattrs, GallioTestAnnotation))
                    {
                        list.Add(memberInfo);
                    }
                }
            }
            return list;
        }

        private static bool ContainCustomAttr(IEnumerable<CustomAttributeData> attrs, string attr)
        {
            foreach (var att in attrs)
            {
                if (att.AttributeType.Name.CheckSame(attr))
                {
                    return true;
                }
            }
            return false;

        }

        private static Assembly GetAssembly(string assemblyLocation)
        {
            return Assembly.LoadFrom(assemblyLocation);
        }

    }
}

