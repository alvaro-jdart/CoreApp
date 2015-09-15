using Jdart.CoreApp.Dependency;
using Jdart.CoreApp.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jdart.CoreApp
{
    public class AppConfigurationInfo : IAppConfigurationInfo
    {
        internal AppConfigurationInfo() { }

        public DependencyResolver DependencyResolver { get; internal set; }

        public IAppLogger Logger { get; internal set; }

        public Action<Exception> HandleError { get; internal set; }
    }
}
