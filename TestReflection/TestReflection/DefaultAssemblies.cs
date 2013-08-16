using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestReflection
{
    public class DefaultAssemblies
    {
        private static string _relativePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public static readonly string Assemblylocationz =
            _relativePath + "\\Debug\\MBRegressionLibrary.Tests.dll";

        public static readonly string AssemblyMarshalPath =
            _relativePath + "\\lib\\DynamicAssemblyLoader.dll";

        public static readonly string TestAssemPath =
            _relativePath + "\\lib\\TestLibrary.dll";

        public static readonly string AssemblyLoader =
            "DynamicAssemblyLoader.dll";
    }
}
