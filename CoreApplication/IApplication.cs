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
    public interface IApplication<TContainer>
    {
        IApplication<TContainer> SetDependency<T>(T dependency) where T : IDependency<TContainer>;

        IApplication<TContainer> RemoveDependency<T>() where T : IDependency<TContainer>;

        IApplication<TContainer> SetInit<T>(T init) where T : IInit;

        IApplication<TContainer> RemoveInit<T>() where T : IInit;

        IApplication<TContainer> SetSettings<T>(T settings) where T : ISettings<TContainer>;

        IApplication<TContainer> RemoveSettings<T>() where T : ISettings<TContainer>;

        IAppConfig Build();
    }
}
