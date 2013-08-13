using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MbUnit.Framework;

namespace TestReflection
{
    public static class GetTests
    {
        public static string GallioTestAnnotation = "Test";
        private static string RelativePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        private static readonly string Assemblylocationz =
            "C:\\Users\\DaKastserMeister\\Documents" + "\\GitHub\\mbregressiontests\\CSharp\\Regression.Tests\\bin\\Debug\\Regression.Tests.dll";
                        // @"GitHub\mbregressiontests\CSharp\Regression.Tests\bin\Debug\Regression.Tests.dll");
        //public static string Assemblylocationz =
         //    "C:\\Users\\DaKastserMeister/Documents/GitHub/mbregressiontests/CSharp/Regression.Tests/bin/Debug/Regression.Tests.dll";

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
            var tests = GetMethodsWithAttributeNameFromTypes(GetAssembly(assemblyLocation).GetTypes(), GallioTestAnnotation);
            return new MbTestPackage(tests);
        }
        [Test]
        public static void TestThisThing()
        {
            var package = ByAllTests(Assemblylocationz);
            
        }
        private static IEnumerable<MemberInfo> GetMethodsWithAttributeNameFromTypes(IEnumerable<Type> types, string attrName)
        {
            return (from type in types from memberInfo in type.GetMembers() where memberInfo.Name.Equals(attrName) select memberInfo).ToList();
        }

        //unused
        private static List<MemberInfo> DoMoreShit(IEnumerable<MemberInfo> methods )
        {
            return methods.Where(memberInfo => memberInfo.Name.Equals(GallioTestAnnotation)).ToList();
        }

        //unused
        private static List<MemberInfo> DoShit(IEnumerable<Type> Types)
        {
            var list = new List<MemberInfo>();
            foreach (var type in Types)
            {
                var members = type.GetMembers();
                foreach (var memberInfo in members)
                {
                    if (memberInfo.Name.Equals(GallioTestAnnotation))
                    {
                        list.Add(memberInfo);
                    }
                }
            }
            return list;
        }

        private static Assembly GetAssembly(string assemblyLocation)
        {
            return Assembly.LoadFile(assemblyLocation);
        }

    }
}
