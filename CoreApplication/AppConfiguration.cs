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
    public class AppConfiguration<TContainer> : IAppConfiguration<TContainer>
    {
        private Action<Exception, IAppLogger, DependencyResolver> _errorHandler = (e, logger, resolver) => { };

        private Lazy<IAppConfigurationInfo> _resultInfo;
        private readonly IAppLogger _logger;
        private readonly TContainer _container;
        private readonly DependencyResolver _dependencyResolver;
        private readonly Action<TContainer> _verify;

        public AppConfiguration(TContainer container, Func<Type, object> getService, Func<Type, IEnumerable<object>> getServices, IAppLogger logger = null, Action<TContainer> verify = null)
        {
            _logger = logger ?? new EmptyLogger();
            _container = container;
            _dependencyResolver = new DependencyResolver(getService, getServices);
            _resultInfo = new Lazy<IAppConfigurationInfo>(Initialize);
            _verify = verify ?? (c => { });
        }

        public DependencyConfigCollection<TContainer> DependencyConfigs { get; } = new DependencyConfigCollection<TContainer>();
        public InitServiceCollection InitServices { get; } = new InitServiceCollection();

        public IAppConfigurationInfo Build()
        {
            return _resultInfo.Value;
        }

        public void SetErrorHandler(Action<Exception, IAppLogger, DependencyResolver> handler)
        {
            _errorHandler = handler;
        }

        public IAppConfiguration<TContainer> SetSettings<T>(T settingsService) where T : ISettingsService<TContainer>
        {
            DependencyConfigs.SetDependencies<T>(settingsService);
            InitServices.SetInit<T>(settingsService);

            return this;
        }

        public IAppConfiguration<TContainer> RemoveSettings<T>() where T : ISettingsService<TContainer>
        {
            DependencyConfigs.RemoveDependencies<T>();
            InitServices.RemoveInit<T>();

            return this;
        }

        private IAppConfigurationInfo Initialize()
        {
            #region Dependency(Регистрируем зависимости)

            try
            {
                foreach (var dependencyAction in DependencyConfigs)
                {
                    dependencyAction(_container);
                }

                _verify(_container);
            }
            catch (Exception e)
            {
                _logger.Error(new Exception("Ошибка в регистрации зависимостей", e));
                throw e;
            }

            #endregion

            #region Init Services(Инициализируем)

            try
            {
                foreach (var initAction in InitServices)
                {
                    initAction(_dependencyResolver);
                }
            }
            catch (Exception e)
            {
                _logger.Error(new Exception("Ошибка в инициализации сервисов", e));
                throw e;
            }

            #endregion

            return new AppConfigurationInfo
            {
                DependencyResolver = _dependencyResolver,
                Logger = _logger,
                HandleError = (e) =>
                {
                    _errorHandler(e, _logger, _dependencyResolver);
                }
            };
        }
    }
}
