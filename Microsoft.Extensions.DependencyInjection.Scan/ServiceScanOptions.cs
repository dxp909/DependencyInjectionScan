using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection.Scan
{
    public class ServiceScanOptions
    {
        public IList<IServiceRegisteDescriptorProvider> DescriptorProviderTypes { get; } = new List<IServiceRegisteDescriptorProvider>();
    }
}
