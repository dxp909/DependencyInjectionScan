using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection.Scan
{
    public class AssemblyDiscovery
    {
        public static Assembly[] Discovery()
        {
           
            return DependencyContext.Default.RuntimeLibraries.SelectMany(l => l.GetDefaultAssemblyNames(DependencyContext.Default)).Select(Assembly.Load).ToArray();
        }
    }
}
