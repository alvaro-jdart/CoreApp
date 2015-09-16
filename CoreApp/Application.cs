﻿using Jdart.CoreApp.Dependency;
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
    public class Application<TContainer> : IApplication<TContainer>
    {
        private Dictionary<Type, IDependency<TContainer>> _dependencies = new Dictionary<Type, IDependency<TContainer>>();
        private Dictionary<Type, IInit> _inits = new Dictionary<Type, IInit>();

        private Lazy<IAppConfig> _resultInfo;
        private readonly IAppLogger _logger;
        private readonly TContainer _container;
        private readonly IDependencyResolver _dependencyResolver;
        private readonly Action<TContainer> _verify;

        public Application(AppOptions<TContainer> options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            _logger = options.Logger ?? new EmptyLogger();
            _container = options.DependencyContainer;
            _dependencyResolver = new DependencyResolver(options.GetServiceFunc, options.GetAllServicesFunc);
            _verify = options.VerifyAction ?? (c => { });
            
            _resultInfo = new Lazy<IAppConfig>(Run);
        }

        #region Dependency

        public IApplication<TContainer> SetDependency<T>(T dependency) where T : IDependency<TContainer>
        {
            if (dependency == null) throw new ArgumentNullException(nameof(dependency));

            _dependencies[typeof(T)] = dependency;

            return this;
        }

        public IApplication<TContainer> RemoveDependency<T>() where T : IDependency<TContainer>
        {
            _inits.Remove(typeof(T));

            return this;
        }

        #endregion

        #region Init

        public IApplication<TContainer> SetInit<T>(T init) where T : IInit
        {
            if (init == null) throw new ArgumentNullException(nameof(init));

            _inits[typeof(T)] = init;

            return this;
        }

        public IApplication<TContainer> RemoveInit<T>() where T : IInit
        {
            _inits.Remove(typeof(T));

            return this;
        }

        #endregion

        #region Settings

        public IApplication<TContainer> SetSettings<T>(T settings) where T : ISettings<TContainer>
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            SetInit<T>(settings);
            SetDependency<T>(settings);

            return this;
        }

        public IApplication<TContainer> RemoveSettings<T>() where T : ISettings<TContainer>
        {
            RemoveDependency<T>();
            RemoveInit<T>();

            return this;
        }

        #endregion

        public virtual IAppConfig Build()
        {
            return _resultInfo.Value;
        }

        private IAppConfig Run()
        {
            #region Dependency

            try
            {
                foreach (var dependency in _dependencies)
                {
                    dependency.Value.Register(_container);
                }

                _verify(_container);
            }
            catch (Exception e)
            {
                _logger.Error(new Exception("Ошибка в регистрации зависимостей", e));
                throw e;
            }

            #endregion

            #region Init

            try
            {
                foreach (var init in _inits)
                {
                    init.Value.Init(_dependencyResolver);
                }
            }
            catch (Exception e)
            {
                _logger.Error(new Exception("Ошибка в инициализации сервисов", e));
                throw e;
            }

            #endregion

            return new AppConfig
            {
                DependencyResolver = _dependencyResolver,
                Logger = _logger
            };
        }
    }
}
