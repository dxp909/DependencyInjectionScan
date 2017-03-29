using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection.Scan
{
    /// <summary>
    /// 服务注册描述信息
    /// </summary>
    public class ServiceRegisteDescriptor
    {
        public Type ServiceType { get; set; }
        public ServiceLifetime LifeTime { get; set; }
        public bool AllowMultipleImp { get; set; }
        public Type Imp { get; set; }
        public Type[] GenericParameterTypes { get; set; }
    }
}
