using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection.Scan
{
    /// <summary>
    /// 服务注册
    /// </summary>
    public class ServiceRegister
    {
        public static void Registe(IServiceCollection services,ServiceRegisteDescriptor descriptor)
        {
            switch (descriptor.LifeTime)
            {
                case ServiceLifetime.Singleton:

                    break;
                case ServiceLifetime.Scoped:
                    break;
                case ServiceLifetime.Transient:
                    break;
                default:
                    break;
            }
        }
    }
}
