using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AppDomainToolkit;

namespace TestReflection.AssemblyLoading
{
    public class SimpleAssemblyLoader
    {


        public IAppDomainContext DomainContext { get; set; }

        public object GetLoadedAssembly(string path)
        {
            var context = AppDomainContext.Create();
            var prevNumofAssemblies = context.LoadedAssemblies.Count();

            var dir = new FileInfo(new Uri(path).AbsolutePath).DirectoryName;

            context.RemoteResolver.AddProbePath(dir);

            var assemblies = context.LoadAssemblyWithReferences(AppDomainToolkit.LoadMethod.LoadFrom, path);
            Console.WriteLine(assemblies.First().FullName);
            return assemblies.First();
        }
    }
}
