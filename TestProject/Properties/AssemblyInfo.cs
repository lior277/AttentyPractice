using NUnit.Framework;
using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("TestProject")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("TestProject")]
[assembly: AssemblyCopyright("Copyright ©  2019")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: ComVisible(false)]

[assembly: Guid("615d274f-9e39-43ca-acf8-68baa55e389a")]

// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly : Parallelizable(ParallelScope.Children)]
[assembly : LevelOfParallelism(2)]
