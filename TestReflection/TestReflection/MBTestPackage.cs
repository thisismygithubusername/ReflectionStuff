using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil;

namespace TestReflection
{
    public class MbTestPackage
    {
        public MbTestPackage(IEnumerable<MethodInfo> methods )
        {
            AutomationTests = new List<MbAutomationTest>();
            foreach (var method in methods)
            {
                AutomationTests.Add(new MbAutomationTest(method));
            }
        }

        public MbTestPackage(IEnumerable<MethodDefinition> methods)
        {
            AutomationTests = new List<MbAutomationTest>();
            foreach (var method in methods)
            {
                AutomationTests.Add(new MbAutomationTest(method));
            }
        }

        public List<MbAutomationTest> AutomationTests
        {
            get; set;
        }
        
    }
}
