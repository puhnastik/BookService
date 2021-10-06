using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Castle.Windsor;

namespace BookService.IoC
{
    public class WindsorDependencyResolver : IDependencyResolver
    {
        private readonly IWindsorContainer _container;

        public WindsorDependencyResolver(IWindsorContainer container)
        {
            if (null == container)
            {
                throw new ArgumentNullException("container");
            }

            _container = container;
        }

        public object GetService(Type serviceType)
        {
            return _container.Kernel.HasComponent(serviceType) ? _container.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.ResolveAll(serviceType).Cast<object>().ToArray();
        }

        public IDependencyScope BeginScope()
        {
            return new ReleasingDependencyScope(this, _container.Release);
        }

        public void Dispose()
        {
        }
    }

    internal class ReleasingDependencyScope : IDependencyScope
    {
        private readonly IDependencyScope _scope;
        private readonly Action<object> _release;
        private readonly List<object> _instances;

        public ReleasingDependencyScope(IDependencyScope scope, Action<object> release)
        {
            if (null == scope)
            {
                throw new ArgumentNullException("scope");
            }

            if (null == release)
            {
                throw new ArgumentNullException("release");
            }

            _scope = scope;
            _release = release;
            _instances = new List<object>();
        }

        public object GetService(Type t)
        {
            object service = _scope.GetService(t);
            AddToScope(service);

            return service;
        }

        public IEnumerable<object> GetServices(Type t)
        {
            var services = _scope.GetServices(t);
            AddToScope(services);

            return services;
        }

        public void Dispose()
        {
            foreach (object instance in _instances)
            {
                _release(instance);
            }

            _instances.Clear();
        }

        private void AddToScope(params object[] services)
        {
            if (services.Any())
            {
                _instances.AddRange(services);
            }
        }

    }

}