using System;

namespace Microsoft.Extensions.DependencyInjection.Scan
{
    /// <summary>
    /// 服务注册描述特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Interface,AllowMultiple =true,Inherited =false)]
    public class ServiceRegisteDescriptorAttribute:Attribute
    {
        public ServiceRegisteDescriptorAttribute(ServiceLifetime lifetime)
        {
            LifeTime = lifetime;
        }
        public ServiceLifetime LifeTime { get; }
        public bool AllowMultipleImp { get; set; }
        public Type Imp { get; set; }
        public Type GenericType { get; set; }
    }
}
