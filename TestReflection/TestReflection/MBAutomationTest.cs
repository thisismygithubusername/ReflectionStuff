using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestReflection
{
    public class MbAutomationTest
    {
        public MbAutomationTest()
        {
        }

        public MbAutomationTest(MemberInfo member)
        {
            ConvertFromMember(member);
        }

        private void ConvertFromMember(MemberInfo member)
        {
            
        }
        public string Name { get; set; }

        public string Class { get; set; }

        public string Folder { get; set; }

        public string CustomAttributes { get; set; }

        public string Namespace { get; set; }

        public string Assembly { get; set; }

        public string FullName { get; set; }

    }
}
