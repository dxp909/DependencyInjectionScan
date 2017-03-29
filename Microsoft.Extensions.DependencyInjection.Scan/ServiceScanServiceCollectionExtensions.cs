using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection.Scan
{
    public static class ServiceScanServiceCollectionExtensions
    {
        private static void AddScanCore(IServiceCollection services)
        {
            services.TryAddEnumerable(ServiceDescriptor.Transient<IServiceRegisteDescriptorProvider, DefaultServiceRegisterDescriptorProvider>());
            services.TryAddTransient<IServiceRegisteDescriptorCollectionProvider, ServiceRegisteDescriptorCollectionProvider>();
            
        }
        public static IServiceCollection AddScanServices(this IServiceCollection services)
        {
            return AddScanServices(services,null);
        }

        public static IServiceCollection AddScanServices(this IServiceCollection services,Action<ServiceScanOptions> options)
        {
            AddScanCore(services);
            if (options!=null)
            {
                ServiceScanOptions option = new ServiceScanOptions();
                options(option);
                foreach (var item in option.DescriptorProviderTypes)
                {
                    services.TryAddEnumerable(ServiceDescriptor.Transient(typeof(IServiceRegisteDescriptorProvider), item));
                }
            }

            IServiceRegisteDescriptorCollectionProvider provider = GetServiceFromCollection<IServiceRegisteDescriptorCollectionProvider>(services);
            ServiceRegisteDescriptorCollection collection = provider.ServiceRegisteDescriptors;
            foreach (var item in collection.Items)
            {
                ServiceRegister.Registe(item);
            }

            return services;
        }

        private static T GetServiceFromCollection<T>(this IServiceCollection services)
        {
            return (T)services
                .FirstOrDefault(d => d.ServiceType == typeof(T))
                ?.ImplementationInstance;
        }
    }
}
