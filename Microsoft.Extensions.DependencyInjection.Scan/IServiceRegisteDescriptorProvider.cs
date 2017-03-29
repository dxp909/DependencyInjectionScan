using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection.Scan
{
    /// <summary>
    /// serviceregistedescriptor获取接口，可以自定义，比如从配置文件获取映射信息等，系统默认提供从程序集解析
    /// </summary>
    public interface IServiceRegisteDescriptorProvider
    {
        void OnProvidersExecuting(ServiceRegisteDescriptorProviderContext context);
        void OnProvidersExecuted(ServiceRegisteDescriptorProviderContext context);
    }
}
