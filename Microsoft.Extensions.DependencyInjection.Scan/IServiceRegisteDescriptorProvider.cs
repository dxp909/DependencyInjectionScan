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
        /// <summary>
        /// 排序号，建议自定义的Provider，order从1开始，系统默认提供的Provider是0
        /// </summary>
        int Order { get; }
        /// <summary>
        /// 从特定目标获取服务注册描述信息，放到ServiceRegisteDescriptorProviderContext中
        /// </summary>
        /// <param name="context"></param>
        void OnProvidersExecuting(ServiceRegisteDescriptorProviderContext context);
        /// <summary>
        /// 在该方法中可以对收集好的ServiceRegisteDescriptor集合进行修改，比如删除，替换等
        /// </summary>
        /// <param name="context"></param>
        void OnProvidersExecuted(ServiceRegisteDescriptorProviderContext context);
    }
}
