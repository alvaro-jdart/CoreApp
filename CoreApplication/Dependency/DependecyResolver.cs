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
    public class DependencyResolver
    {
        private readonly Func<Type,object> _getService;
        private readonly Func<Type, IEnumerable<object>> _getServices;

        public DependencyResolver(Func<Type, object> getService, Func<Type, IEnumerable<object>> getServices)
        {
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

        /// <summary>
        /// Получить сервиса
        /// </summary>
        /// <param name="type">Тип сервиса</param>
        /// <returns>Сервис</returns>
        public object GetService(Type type)
        {
            return _getService(type);
        }

        /// <summary>
        /// Получить сервисы
        /// </summary>
        /// <typeparam name="T">Тип сервиса</typeparam>
        /// <returns>Коллекция сервисов</returns>
        public IEnumerable<T> GetServices<T>()
        {
            return GetServices(typeof(T)).Cast<T>();
        }

        /// <summary>
        /// Получить сервисы
        /// </summary>
        /// <param name="type">Тип сервиса</param>
        /// <returns>Коллекция сервисов</returns>
        public IEnumerable<object> GetServices(Type type)
        {
            return _getServices(type);
        }
    }
}
