using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jdart.CoreApp.Dependency
{
    /// <summary>
    /// Менеджер сервисов
    /// </summary>
    public class DependencyResolver<TResultContainer> : IDependencyResolver
    {
        private readonly TResultContainer _container;
        private readonly Func<Type,object> _getService;
        private readonly Func<Type, IEnumerable<object>> _getServices;

        public DependencyResolver(TResultContainer container, Func<TResultContainer, Func<Type, object>> getServiceFunc, Func<TResultContainer, Func<Type, IEnumerable<object>>> getAllServicesFunc)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));
            if (getServiceFunc == null) throw new ArgumentNullException(nameof(getServiceFunc));
            if (getAllServicesFunc == null) throw new ArgumentNullException(nameof(getAllServicesFunc));

            _container = container;
            _getService = getServiceFunc(container);
            _getServices = getAllServicesFunc(container);
        }

        /// <summary>
        /// Получить сервис
        /// </summary>
        /// <typeparam name="T">Тип сервиса</typeparam>
        /// <returns>Сервис</returns>
        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }

        public object GetService(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            return _getService(type);
        }

        public IEnumerable<T> GetServices<T>()
        {
            return GetServices(typeof(T)).Cast<T>();
        }

        public IEnumerable<object> GetServices(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            return _getServices(type);
        }

        public object GetContainer()
        {
            return _container;
        }

        public TResultContainer GetTypedContainer()
        {
            return _container;
        }
    }
}
