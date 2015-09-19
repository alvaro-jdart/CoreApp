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
    public class UnityApplication : Application<IUnityContainer>
    {
        public UnityApplication(IAppLogger logger) : base(new UnityOptions(logger))
        { }
    }
}
