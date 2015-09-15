using Jdart.CoreApp.Dependency;
using Jdart.CoreApp.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jdart.CoreApp
{
    /// <summary>
    /// Информация о конфигурации
    /// </summary>
    public interface IAppConfigurationInfo
    {
        /// <summary>
        /// Менеджер сервисов
        /// </summary>
        DependencyResolver DependencyResolver { get; }

        /// <summary>
        /// Логгер
        /// </summary>
        IAppLogger Logger { get; }

        /// <summary>
        /// Обработчик ошибок
        /// </summary>
        Action<Exception> HandleError { get; }
    }
}
