using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestReflection
{
    public class MbTestPackage
    {
        public MbTestPackage(IEnumerable<MemberInfo> members )
        {
            ConverMembersIntoTests(members);
        }

        public MbTestPackage()
        {
            //Init();
        }

        public List<MbAutomationTest> AutomationTests { get; set; }

        private  void ConverMembersIntoTests(IEnumerable<MemberInfo> members)
        {
            foreach (var memberInfo in members)
            {
                AutomationTests.Add(new MbAutomationTest(memberInfo));
            }
        }
    }
}
