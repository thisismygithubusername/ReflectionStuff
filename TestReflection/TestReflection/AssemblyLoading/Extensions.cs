using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestReflection.AssemblyLoading
{
    public static class Extensions
    {
        public static bool CheckSame(this string str, string other)
        {
            if (str.Contains("Test"))
            {
                Console.WriteLine("Attr: " + str);
            }
            return str.Equals(other);
        }
    }
}
