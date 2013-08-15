using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AssemblyMarhsall;

namespace TestReflection.AssemblyLoading
{
    public class AssemblyLoader
    {
        public AssemblyLoader(string name)
        {

            Domain = AppDomain.CreateDomain(name);
            var assem = AssemblyName.GetAssemblyName(DefaultAssemblies.AssemblyMarshallDll);
            FullName = assem.FullName;
            Domain.Load(assem);
        }

        private string MarshallDirectory
        {
            get { return DefaultAssemblies.AssemblyMarshalPath; } 
        }
        public string FullName { get; set; }
        public Assembly LoadedAssembly { get; set; } 
    
        private AppDomain Domain
        {
            get; set;
        }

        public bool LoadAssembly(string assemblyPath)
        {
            var assemblyMarshall = (AssemblyMarshall)Domain.CreateInstanceFromAndUnwrap(DefaultAssemblies.AssemblyMarshallDll, "AssemblyMarhsall.AssemblyMarshall");
            assemblyMarshall.LoadDirectory = GenerateDirectoryPath(Assembly.GetExecutingAssembly().CodeBase);
            Domain.AssemblyResolve += assemblyMarshall.CurrentDomainAssemblyResolve;
            try
            {
                LoadedAssembly = Domain.Load(AssemblyName.GetAssemblyName(assemblyPath));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Data);
                return false;
            }
            return true;
        }

        private static string GenerateDirectoryPath(string assemblyPath)
        {
            var splitPath = assemblyPath.Split('/');
            var path = "";
            for (int i = 0; i < splitPath.Length - 1; i++)
            {
                path += splitPath[i] + "/";
            }
            return path;
        }


    }
}
