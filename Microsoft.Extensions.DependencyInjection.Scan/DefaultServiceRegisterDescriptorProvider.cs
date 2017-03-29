using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection.Scan
{
    
    public class DefaultServiceRegisterDescriptorProvider : IServiceRegisteDescriptorProvider
    {
        public void OnProvidersExecuted(ServiceRegisteDescriptorProviderContext context)
        {
        }
        /// <summary>
        /// 使用反射从程序集中获取所有包含ServiceRegisteDescriptor特性的接口定义
        /// </summary>
        /// <param name="context"></param>
        public void OnProvidersExecuting(ServiceRegisteDescriptorProviderContext context)
        {
            
        }

        public class AssemblyDiscovery
        {

        }
    }
}
