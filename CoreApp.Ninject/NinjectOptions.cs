using Jdart.CoreApp;
using Jdart.CoreApp.Log;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jdart.CoreApp.Ninject
{
    internal class NinjectOptions : AppOptions<IKernel>
    {
        public NinjectOptions(IAppLogger logger)
        {
            var container = new StandardKernel();

            DependencyContainer = container;
            GetServiceFunc = t => container.Get(t);
            GetAllServicesFunc = t => container.GetAll(t);
            Logger = logger;
        }
    }
}
