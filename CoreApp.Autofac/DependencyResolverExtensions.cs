using Autofac;
using Jdart.CoreApp.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jdart.CoreApp.Autofac
{
    public static class DependencyResolverExtensions
    {
        public static IContainer GetAutofacContainer(this IDependencyResolver resolver)
        {
            var typedResolver = resolver as DependencyResolver<IContainer>;

            return typedResolver != null ? typedResolver.GetTypedContainer() : (IContainer)resolver.GetContainer();
        }
    }
}
