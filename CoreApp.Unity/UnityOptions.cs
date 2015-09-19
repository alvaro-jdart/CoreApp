using Jdart.CoreApp;
using Jdart.CoreApp.Log;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jdart.CoreApp.Unity
{
    internal class UnityOptions : AppOptions<IUnityContainer>
    {
        public UnityOptions(IAppLogger logger)
        {
            var container = new UnityContainer();

            DependencyContainer = container;
            GetServiceFunc = t => container.Resolve(t);
            GetAllServicesFunc = t => container.ResolveAll(t);
            Logger = logger;
        }
    }
}
