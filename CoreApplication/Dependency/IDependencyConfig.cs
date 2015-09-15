using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jdart.CoreApp.Dependency
{
    /// <summary>
    /// Сервис регистирации зависимостей
    /// </summary>
    public interface IDependencyConfig<TContainer>
    {
        /// <summary>
        /// Регистрировать зависимости
        /// </summary>
        /// <param name="container">Контейнер зависимостей</param>
        void Register(TContainer container);
    }
}
