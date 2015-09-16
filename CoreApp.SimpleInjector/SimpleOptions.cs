using Jdart.CoreApp;
using Jdart.CoreApp.Log;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jdart.CoreApp.SimpleInjector
{
    internal class SimpleOptions : AppOptions<Container>
    {
        public SimpleOptions(IAppLogger logger)
        {
            var container = new Container();

            DependencyContainer = container;
            GetServiceFunc = container.GetInstance;
            GetAllServicesFunc = container.GetAllInstances;
            VerifyAction = c => c.Verify();
            Logger = logger;
        }
    }
}
