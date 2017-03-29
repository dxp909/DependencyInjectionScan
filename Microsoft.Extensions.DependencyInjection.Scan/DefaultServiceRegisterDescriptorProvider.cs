﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            Assembly[] assemblys = AssemblyDiscovery.Discovery();
            IEnumerable<Type> types = assemblys.SelectMany(m => m.GetTypes().Where(t => t.GetTypeInfo().GetCustomAttributes().Any(a => a.GetType() == typeof(ServiceRegisteDescriptorAttribute))));
            foreach (var type in types)
            {
                TypeInfo typeInfo = type.GetTypeInfo();
                ServiceRegisteDescriptorAttribute attr = type.GetTypeInfo().GetCustomAttributes().FirstOrDefault(m => m.GetType() == typeof(ServiceRegisteDescriptorAttribute)) as ServiceRegisteDescriptorAttribute;

                if (typeInfo.IsGenericType && !typeInfo.ContainsGenericParameters && attr.GenericType == null)
                {
                    throw new NotSupportedException(nameof(attr));
                }

                Type[] impTypes = null;
                if ((typeInfo.IsInterface || typeInfo.IsAbstract) && attr.Imp == null)
                {
                    //从程序集中获取所有实现了该服务端类
                    impTypes = assemblys.SelectMany(m => m.GetTypes().Where(t => t.GetTypeInfo().BaseType == type)).ToArray();
                }
                else
                {
                    impTypes = new Type[1] { type };
                }

                foreach (var imp in impTypes)
                {
                    ServiceRegisteDescriptor d=new ServiceRegisteDescriptor
                    {
                        AllowMultipleImp = attr.AllowMultipleImp,
                        Imp = imp,
                        ServiceType = type,
                        LifeTime = attr.LifeTime
                    };

                    if (typeInfo.IsGenericType && !typeInfo.ContainsGenericParameters)
                    {
                        d.GenericParameterTypes = assemblys.SelectMany(m => m.GetTypes().Where(t => !t.GetTypeInfo().IsAbstract && (t.GetTypeInfo().BaseType == attr.GenericType || t == attr.GenericType))).ToArray();
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
