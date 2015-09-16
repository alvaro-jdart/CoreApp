using System;
using System.Collections.Generic;

namespace Jdart.CoreApp.Dependency
{
    public interface IDependencyResolver
    {
        object GetService(Type type);

        T GetService<T>();

        IEnumerable<object> GetServices(Type type);

        IEnumerable<T> GetServices<T>();
    }
}