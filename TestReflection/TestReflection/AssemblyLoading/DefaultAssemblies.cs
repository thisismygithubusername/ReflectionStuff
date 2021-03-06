﻿using System;

namespace TestReflection.AssemblyLoading
{
    public class DefaultAssemblies
    {
        private static string _relativePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public static readonly string Assemblylocationz =
            _relativePath + "\\Debug\\MBRegressionLibrary.Tests.dll";

        public static readonly string AssemblyMarshalPath =
            _relativePath + "\\lib\\DynamicAssemblyLoader.dll";

        public static readonly string AssemblyLoader =
            "DynamicAssemblyLoader.dll"; 
    }
}
