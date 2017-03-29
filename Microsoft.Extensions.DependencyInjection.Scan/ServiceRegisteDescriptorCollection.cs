using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection.Scan
{
    /// <summary>
    /// 服务注册描述信息集合
    /// </summary>
    public class ServiceRegisteDescriptorCollection
    {
        public ServiceRegisteDescriptorCollection(IReadOnlyList<ServiceRegisteDescriptor> items)
        {
            Items = items ?? throw new ArgumentNullException(nameof(items));
        }
        public IReadOnlyList<ServiceRegisteDescriptor> Items { get; private set; }
    }
}
