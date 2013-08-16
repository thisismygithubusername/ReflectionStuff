using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestReflection.AssemblyLoading
{

    public class AssemblyProxy : MarshalByRefObject
    {
        public string AssmblyPath { get; set; }
        public Assembly GetAssembly()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomainAssemblyResolve;
            try
            {
                return Assembly.LoadFile(AssmblyPath);
            }
            catch (Exception)
            {
                return null;
                // throw new InvalidOperationException(ex);
            }
        }

        public Assembly CurrentDomainAssemblyResolve(object sender, ResolveEventArgs args)
        {
            Assembly[] currentAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            var resolutionPath = AssmblyPath;
            foreach (Assembly assembly in currentAssemblies)
            {
                if (assembly.FullName == args.Name)
                {
                    return assembly;
                }
            }

            return FindAssembliesInDirectory(args.Name, resolutionPath);
        }

        private static Assembly FindAssembliesInDirectory(string assemblyName, string directory)
        {
            foreach (string file in Directory.GetFiles(directory))
            {
                Assembly assembly;

                if (TryLoadAssemblyFromFile(file, assemblyName, out assembly))
                    return assembly;
            }

            return null;
        }

        private static bool TryLoadAssemblyFromFile(string file, string assemblyName, out Assembly assembly)
        {
            try
            {
                // Convert the filename into an absolute file name for 
                // use with LoadFile. 
                file = new FileInfo(file).FullName;

                if (AssemblyName.GetAssemblyName(file).FullName == assemblyName)
                {
                    assembly = Assembly.LoadFile(file);
                    return true;
                }
            }
            catch
            {
                /* Do Nothing */
            }
            assembly = null;
            return false;
        }
    }


}
