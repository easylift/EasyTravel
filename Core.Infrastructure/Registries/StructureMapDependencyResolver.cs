using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using StructureMap;

namespace Core.Infrastructure.Registries
{
    public class StructureMapDependencyResolver : IDependencyResolver
    {
        private readonly Func<IContainer> _factory;

        public StructureMapDependencyResolver(Func<IContainer> factory)
        {
            _factory = factory;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType==null) return null;
            var factory = _factory();
            return serviceType.IsAbstract || serviceType.IsInterface
                ? factory.TryGetInstance(serviceType)
                : factory.GetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _factory().GetAllInstances(serviceType).Cast<object>();
        }

        public IDependencyScope BeginScope()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
