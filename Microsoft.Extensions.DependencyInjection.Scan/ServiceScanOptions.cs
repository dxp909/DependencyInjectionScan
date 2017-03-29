using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection.Scan
{
    public class ServiceScanOptions
    {
        public IList<Type> DescriptorProviderTypes { get; } = new List<Type>();
    }
}
