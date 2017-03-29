using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection.Scan
{
    public interface IServiceRegisteDescriptorCollectionProvider
    {
        ServiceRegisteDescriptorCollection ServiceRegisteDescriptors { get; }
    }
}
