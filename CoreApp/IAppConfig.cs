using Jdart.CoreApp.Dependency;
using Jdart.CoreApp.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jdart.CoreApp
{
    public interface IAppConfig
    {
        IDependencyResolver DependencyResolver { get; }

        IAppLogger Logger { get; }
    }
}
