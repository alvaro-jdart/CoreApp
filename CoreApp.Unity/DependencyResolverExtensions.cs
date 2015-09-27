using Jdart.CoreApp.Dependency;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jdart.CoreApp.Unity
{
    public static class DependencyResolverExtensions
    {
        public static IUnityContainer GetUnityContainer(this IDependencyResolver resolver)
        {
            var typedResolver = resolver as DependencyResolver<IUnityContainer>;

            return typedResolver != null ? typedResolver.GetTypedContainer() : (IUnityContainer)resolver.GetContainer();
        }
    }
}
