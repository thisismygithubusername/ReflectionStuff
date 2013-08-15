using System;

namespace TestReflection.AssemblyLoading
{
    public class DefaultAssemblies
    {
        private static string _relativePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public static readonly string Assemblylocationz =
            _relativePath + "\\Debug\\MBRegressionLibrary.Tests.dll";
        // @"GitHub\mbregressiontests\CSharp\Regression.Tests\bin\Debug\Regression.Tests.dll");
        //public static string Assemblylocationz =
        //    "C:\\Users\\DaKastserMeister/Documents/GitHub/mbregressiontests/CSharp/Regression.Tests/bin/Debug/Regression.Tests.dll";

    }
}
