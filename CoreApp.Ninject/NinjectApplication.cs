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
    public class NinjectApplication : Application<IKernel>
    {
        public NinjectApplication(IAppLogger logger) : base(new NinjectOptions(logger))
        { }
    }
}
