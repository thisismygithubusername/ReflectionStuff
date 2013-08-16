using System;
using System.Collections.Generic;
using System.IO;
using MbUnit.Framework;
using Xunit;

namespace TestReflection.Tests
{
    public class ReflectionTests
    {
        [Test]
        public static void BestTest()
        {
            var tests = GetTests.BuildTestPackage(DefaultAssemblies.TestAssemPath, ExtractionMethod.MonoCecil);
            foreach (var ass in AppDomain.CurrentDomain.GetAssemblies())
            {
                Console.WriteLine(ass);
            }

            foreach (var testy in tests.AutomationTests)
            {
                Console.WriteLine(testy.Name);
            }
        }
    }
}
