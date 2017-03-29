using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection.Scan
{
    public class ServiceRegisteDescriptorCollectionProvider : IServiceRegisteDescriptorCollectionProvider
    {
        private readonly IServiceRegisteDescriptorProvider[] _serviceRegisteDescriptorProviders;
        private ServiceRegisteDescriptorCollection _collection;

        public ServiceRegisteDescriptorCollectionProvider(
           IEnumerable<IServiceRegisteDescriptorProvider> serviceRegisteDescriptorProviders)
        {
            _serviceRegisteDescriptorProviders = serviceRegisteDescriptorProviders.ToArray();
        }

        private void UpdateCollection()
        {
            var context = new ServiceRegisteDescriptorProviderContext();

            for (var i = 0; i < _serviceRegisteDescriptorProviders.Length; i++)
            {
                _serviceRegisteDescriptorProviders[i].OnProvidersExecuting(context);
            }

            for (var i = _serviceRegisteDescriptorProviders.Length - 1; i >= 0; i--)
            {
                _serviceRegisteDescriptorProviders[i].OnProvidersExecuted(context);
            }

            _collection = new ServiceRegisteDescriptorCollection(
                new ReadOnlyCollection<ServiceRegisteDescriptor>(context.Results));
        }
        public ServiceRegisteDescriptorCollection ServiceRegisteDescriptors
        {
            get
            {
                if (_collection == null)
                {
                    UpdateCollection();
                }

                return _collection;
            }
        }
    }
}
