using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbUnit.Framework;
using TestReflection.AssemblyLoading;

namespace TestReflection.Tests
{
    public class ReflectionTests
    {
        [Test]
        public static void TestThisThing()
        {
            var assemblyLoader = new AssemblyLoader();
            assemblyLoader.LoadAssembly("Salon", DefaultAssemblies.Assemblylocationz);
            var package = GetTests.All(assemblyLoader.LoadedAssemblies["Salon"]);
            var methodinfo = package.AutomationTests.First();
            var method = methodinfo.Name;
        }
    }
}
