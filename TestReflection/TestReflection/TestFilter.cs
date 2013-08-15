using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestReflection
{
    public class TestFilter
    {
        public TestFilter(List<MbAutomationTest> tests )
        {
            Tests = tests;
        }

        private List<MbAutomationTest> Tests { get; set; }

        public List<MbAutomationTest> ByFolder(string folder)
        {
            return new List<MbAutomationTest>();
        } 

        public List<MbAutomationTest> ByNames()
        {
            return new List<MbAutomationTest>();
        }  
    }
}
