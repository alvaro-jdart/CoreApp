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
    public class DependencyResolver : IDependencyResolver
    {
        private readonly Func<Type,object> _getService;
        private readonly Func<Type, IEnumerable<object>> _getServices;

        public DependencyResolver(Func<Type, object> getService, Func<Type, IEnumerable<object>> getServices)
        {
            if (getService == null) throw new ArgumentNullException(nameof(getService));
            if (getServices == null) throw new ArgumentNullException(nameof(getServices));

            _getService = getService;
            _getServices = getServices;
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
    }
}
