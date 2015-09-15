using Jdart.CoreApp.Dependency;
using Jdart.CoreApp.Init;
using Jdart.CoreApp.Log;
using Jdart.CoreApp.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jdart.CoreApp
{
    /// <summary>
    /// Строитель конфигурации приложения
    /// </summary>
    public interface IAppConfiguration<TContainer>
    {
        /// <summary>
        /// Задать функцию обработки глобальных ошибок
        /// </summary>
        /// <param name="handler">Обработчик</param>
        void SetErrorHandler(Action<Exception, IAppLogger, DependencyResolver> handler);

        /// <summary>
        /// Добавить сервис модульных настроек(зависимости + инициализация)
        /// </summary>
        /// <typeparam name="T">Тип сервиса</typeparam>
        /// <param name="settingsService">Сервис</param>
        IAppConfiguration<TContainer> SetSettings<T>(T settingsService) where T : ISettingsService<TContainer>;

        /// <summary>
        /// Удалить сервис модульных настроек
        /// </summary>
        /// <typeparam name="T">Тип сервиса</typeparam>
        IAppConfiguration<TContainer> RemoveSettings<T>() where T : ISettingsService<TContainer>;

        /// <summary>
        /// "Собрать" конфигурацию(зарегистрировать зависимости + проинициализировать модули).
        /// Создание конфигурации выполняется один раз, каждый повторный вызов возвратит результат первого построения.
        /// </summary>
        /// <returns>Информация о сконфигурированном приложении</returns>
        IAppConfigurationInfo Build();
    }
}
