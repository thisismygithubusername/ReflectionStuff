using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AppDomainToolkit;
using MbUnit.Framework;
using TestReflection.AssemblyLoading;
using LoadMethod = AppDomainToolkit.LoadMethod;

namespace TestReflection.Tests
{
    public class ReflectionTests
    {

        [Test]
        public static void TestAgain()
        {
            var context = AppDomainContext.Create();
            var dir = new FileInfo(new Uri(DefaultAssemblies.Assemblylocationz).AbsolutePath).DirectoryName;
            context.RemoteResolver.AddProbePath(dir);
            var assemblies = context.LoadAssemblyWithReferences(AppDomainToolkit.LoadMethod.LoadFrom, DefaultAssemblies.Assemblylocationz);
            var loaded = assemblies.First();
            Console.WriteLine(loaded.FullName);
            //context.AssemblyImporter = new AssemblyLoader("");
           // assembly.CodeBase;
        }

        [Test]
        public static void TestasdaAgain()
        {
           
            var assemblyLoader = AppDomainContext.Create();
            var assemblies = assemblyLoader.LoadAssemblyWithReferences(LoadMethod.LoadFrom, DefaultAssemblies.Assemblylocationz);
            //var assem = assemblyLoader.GetAssemblies().First();
        }

        [Test]
        public void initSetup()
        {
            var resolver = new PathBasedAssemblyResolver();
            resolver.AddProbePath(DefaultAssemblies.Assemblylocationz);

            var appDomain = AppDomainContext.Create();
            appDomain.Domain.AssemblyResolve += resolver.Resolve;
            appDomain.LoadAssembly(LoadMethod.LoadFile, DefaultAssemblies.Assemblylocationz);
           /* var aseemblyproxy =
                (AssemblyProxyWrapper)
                appDomain.Domain.CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly(), "AssemblyProxyWrapper", );
            foreach (var assembly1 in assembly)
            {
                Console.WriteLine(assembly1.FullName);
            }
            * */
            Console.WriteLine();
        }
    }
}
