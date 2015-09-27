using Jdart.CoreApp.Dependency;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jdart.CoreApp.SimpleInjector
{
    public static class DependencyResolverExtensions
    {
        public static Container GetSimpleContainer(this IDependencyResolver resolver)
        {
            var typedResolver = resolver as DependencyResolver<Container>;

            return typedResolver != null ? typedResolver.GetTypedContainer() : (Container)resolver.GetContainer();
        }
    }
}
