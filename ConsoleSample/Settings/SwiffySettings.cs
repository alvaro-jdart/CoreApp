using Jdart.CoreApp.SimpleInjector.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using Jdart.Swiffy;

namespace Jdart.ConsoleSample.Settings
{
    public class SwiffySettings : ISimpleDependency
    {
        public void Register(Container container)
        {
            container.RegisterSingleton(() => new SwiffyClient(new SwiffyOptions { MillisecondsTimeout = 200000 }));
        }
    }
}
