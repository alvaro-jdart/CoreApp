using Jdart.CoreApp.Dependency;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jdart.CoreApp.Ninject
{
    public static class DependencyResolverExtensions
    {
        public static IKernel GetNinjectContainer(this IDependencyResolver resolver)
        {
            var typedResolver = resolver as DependencyResolver<IKernel>;

            return typedResolver != null ? typedResolver.GetTypedContainer() : (IKernel)resolver.GetContainer();
        }
    }
}
