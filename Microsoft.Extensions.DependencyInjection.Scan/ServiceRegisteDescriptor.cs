using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection.Scan
{
    /// <summary>
    /// 服务注册描述信息
    /// </summary>
    public struct ServiceRegisteDescriptor
    {
        public Type ServiceType { get; }
        public ServiceLifetime LifeTime { get; }
        public bool AllowMultipleImp { get; set; }
        public Type Imp { get; set; }
        public Type GenericType { get; set; }
    }
}
