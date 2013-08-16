using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestReflection.AppDomainLibrary
{
    public class LoadingMarshall : MarshalByRefObject
    {
        private readonly string _binaryPath;
        
        public LoadingMarshall(string binaryPath)
        {
            _binaryPath = binaryPath;
        }

        public Assembly LoadAssembly()
        {
            return LoadAssemblyAndDependencies();
        }

        private Assembly LoadAssemblyAndDependencies()
        {
            var desiredAssembly = AssemblyName.GetAssemblyName(_binaryPath);
            //AppDomain.CurrentDomain.AssemblyResolve = 
            return Assembly.GetExecutingAssembly();

        }

    }
}
