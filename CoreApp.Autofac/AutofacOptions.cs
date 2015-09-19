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
    internal class AutofacOptions : AppOptions<ContainerBuilder, IContainer>
    {
        public AutofacOptions(IAppLogger logger)
        {
            var builder = new ContainerBuilder();

            DependencyContainer = builder;
            GetServiceFunc = b => b.Resolve;
            GetAllServicesFunc = b =>
            {
                return t =>
                {
                    var enumerableServiceType = typeof(IEnumerable<>).MakeGenericType(t);
                    return (IEnumerable<object>)b.Resolve(enumerableServiceType);
                };
            };
            VerifyAction = b => b.Build();
            Logger = logger;
        }
    }
}
