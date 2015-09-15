using Jdart.CoreApp.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jdart.CoreApp.Init
{
    /// <summary>
    /// Сервис инициализации
    /// </summary>
    public interface IInitService
    {
        /// <summary>
        /// Инициализировать
        /// </summary>
        /// <param name="resolver">Менеджер сервисов</param>
        void Init(DependencyResolver resolver);
    }
}
