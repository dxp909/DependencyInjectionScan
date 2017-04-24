using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection.Scan
{
    
    public class DefaultServiceRegisterDescriptorProvider : IServiceRegisterDescriptorProvider
    {
        public void OnProvidersExecuted(ServiceRegisterDescriptorProviderContext context)
        {
        }
        /// <summary>
        /// 使用反射从程序集中获取所有包含ServiceRegisteDescriptor特性的接口定义
        /// </summary>
        /// <param name="context"></param>
        public void OnProvidersExecuting(ServiceRegisterDescriptorProviderContext context)
        {
            Assembly[] assemblys = AssemblyDiscovery.Discovery();
            IEnumerable<Type> types = assemblys.SelectMany(m => m.GetTypes().Where(t => t.GetTypeInfo().GetCustomAttributes().Any(a => a.GetType() == typeof(ServiceRegisterDescriptorAttribute)))).ToList();
            foreach (var type in types)
            {
                TypeInfo typeInfo = type.GetTypeInfo();
                ServiceRegisterDescriptorAttribute attr = type.GetTypeInfo().GetCustomAttributes().FirstOrDefault(m => m.GetType() == typeof(ServiceRegisterDescriptorAttribute)) as ServiceRegisterDescriptorAttribute;

                if (typeInfo.IsGenericTypeDefinition && attr.GenericType == null)
                {
                    throw new NotSupportedException(nameof(attr));
                }

                Type[] impTypes = null;
                if ((typeInfo.IsInterface || typeInfo.IsAbstract) && attr.Imp == null)
                {
                    //从程序集中获取所有实现了该服务端类
                    if (typeInfo.IsGenericTypeDefinition && typeInfo.IsInterface)
                    {
                        impTypes = assemblys.SelectMany(m => m.GetTypes().Where(t => t.GetTypeInfo().IsClass && !t.GetTypeInfo().IsAbstract && t.GetTypeInfo().GetInterfaces().Any(i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == type))).ToArray();
                    }
                    else
                    {
                        if (typeInfo.IsInterface)
                        {
                            impTypes = assemblys.SelectMany(m => m.GetTypes().Where(t => t.GetTypeInfo().IsClass && !t.GetTypeInfo().IsAbstract && t.GetTypeInfo().GetInterfaces().Any(i => i == type))).ToArray();
                        }
                        else
                        {
                            impTypes = assemblys.SelectMany(m => m.GetTypes().Where(t => t.GetTypeInfo().IsClass && !t.GetTypeInfo().IsAbstract && t.GetTypeInfo().IsSubclassOf(type))).ToArray();
                        }
                    }
                }
                else if (attr.Imp!=null)
                {
                    impTypes = new Type[1] { attr.Imp };
                }
                else
                {
                    impTypes = new Type[1] { type };
                }

                foreach (var imp in impTypes)
                {
                    ServiceRegisterDescriptor d=new ServiceRegisterDescriptor
                    {
                        AllowMultipleImp = attr.AllowMultipleImp,
                        Imp = imp,
                        ServiceType = type,
                        LifeTime = attr.LifeTime
                    };

                    if (typeInfo.IsGenericType)
                    {
                        d.GenericParameterTypes = assemblys.SelectMany(m => m.GetTypes().Where(t => !t.GetTypeInfo().IsAbstract && (t.GetTypeInfo().IsSubclassOf(attr.GenericType) || t == attr.GenericType))).ToArray();
                    }
                    context.Results.Add(d);
                }
            }
        }

        public int Order
        {
            get { return 0; }
        }
    }
}
