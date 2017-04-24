using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection.Scan
{
    /// <summary>
    /// 服务注册
    /// </summary>
    public class ServiceRegister
    {
        private static void RegisteItem(IServiceCollection services,ServiceLifetime lifeTime,Type serviceType,Type impType,bool allowMultipleImp)
        {
            ServiceDescriptor serviceDescriptor = null;
            switch (lifeTime)
            {
                case ServiceLifetime.Singleton:
                    serviceDescriptor = ServiceDescriptor.Singleton(serviceType, impType);
                    break;
                case ServiceLifetime.Scoped:
                    serviceDescriptor = ServiceDescriptor.Scoped(serviceType, impType);
                    break;
                case ServiceLifetime.Transient:
                    serviceDescriptor = ServiceDescriptor.Transient(serviceType, impType);
                    break;
            }
            if (allowMultipleImp)
            {
                services.TryAddEnumerable(serviceDescriptor);
            }
            else
            {
                services.TryAdd(serviceDescriptor);
            }
           
        }
        public static void Registe(IServiceCollection services,ServiceRegisterDescriptor descriptor)
        {
            //判断是否是泛型接口
            if (descriptor.ServiceType.GetTypeInfo().IsGenericType)
            {
                if (descriptor.GenericParameterTypes == null)
                {
                    throw new NullReferenceException(nameof(descriptor.GenericParameterTypes));
                }

                if (!descriptor.Imp.GetTypeInfo().IsGenericType)
                {
                    throw new NotSupportedException(nameof(descriptor.Imp));
                }

                foreach (var item in descriptor.GenericParameterTypes)
                {
                    RegisteItem(services,descriptor.LifeTime, descriptor.ServiceType.MakeGenericType(item), descriptor.Imp.MakeGenericType(item), descriptor.AllowMultipleImp);
                }
            }
            else
            {
                RegisteItem(services, descriptor.LifeTime, descriptor.ServiceType, descriptor.Imp,descriptor.AllowMultipleImp);
            }            
        }
    }
}
