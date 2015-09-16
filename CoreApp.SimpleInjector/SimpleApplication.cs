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
    public class SimpleApplication : Application<Container>
    {
        public SimpleApplication(IAppLogger logger) : base(new SimpleOptions(logger))
        { }
    }
}
