using Autofac;
using Jdart.CoreApp;
using Jdart.CoreApp.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jdart.CoreApp.SimpleInjector
{
    public class AutofacApplication : Application<ContainerBuilder, IContainer>
    {
        public AutofacApplication(IAppLogger logger) : base(new AutofacOptions(logger))
        { }
    }
}
