using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection.Scan
{
    public class ServiceRegisteDescriptorProviderContext
    {
        public IList<ServiceRegisteDescriptor> Results { get; } = new List<ServiceRegisteDescriptor>();
    }
}
