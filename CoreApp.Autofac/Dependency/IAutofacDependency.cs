using Autofac;
using Jdart.CoreApp.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jdart.CoreApp.Autofac.Dependency
{
    public interface IAutofacDependency : IDependency<ContainerBuilder>
    {
    }
}
