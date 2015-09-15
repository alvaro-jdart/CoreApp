using Jdart.CoreApp.Dependency;
using Jdart.CoreApp.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jdart.CoreApp
{
    public class AppConfig : IAppConfig
    {
        internal AppConfig() { }

        public IDependencyResolver DependencyResolver { get; internal set; }

        public IAppLogger Logger { get; internal set; }
    }
}
