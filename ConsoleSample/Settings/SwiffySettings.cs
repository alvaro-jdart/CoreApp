using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using Jdart.Swiffy;
using Jdart.CoreApp.SimpleInjector.Settings;
using Jdart.CoreApp.Dependency;
using Jdart.CoreApp.SimpleInjector;

namespace Jdart.ConsoleSample.Settings
{
    public class SwiffySettings : ISimpleSettings
    {
        public void Init(IDependencyResolver resolver)
        {
            var container = resolver.GetSimpleContainer();
        }

        public void Register(Container container)
        {
            container.RegisterSingleton(() => new SwiffyClient(new SwiffyOptions { MillisecondsTimeout = 200000 }));
        }
    }
}
