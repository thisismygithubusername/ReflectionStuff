using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestReflection.AssemblyLoading
{
    public class AssemblyLoader
    {
        public AssemblyLoader()
        {
            Domain = AppDomain.CreateDomain("ReflectionEnvironment");
            LoadedAssemblies = new Dictionary<string, Assembly>();
        }

        public Dictionary<string, Assembly> LoadedAssemblies { get; set; } 

        private AppDomain Domain
        {
            get; set;
        }

        public int LoadCount
        {
            get { return LoadedAssemblies.Count; } 
        }

        public bool Full
        {
            get { return LoadedAssemblies.Count == 5; }
        }

        public bool LoadAssembly(string key, string assemblyPath)
        {
            try
            {
                Domain.Load(assemblyPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Data);
                return false;
            }
            LoadedAssemblies.Add(key, Domain.Load(assemblyPath));
            return true;
        }

        public void Release()
        {
            AppDomain.Unload(Domain);
            Domain = AppDomain.CreateDomain("NewReflectionEnvironment");
            LoadedAssemblies = new Dictionary<string, Assembly>();
        }
    }
}
