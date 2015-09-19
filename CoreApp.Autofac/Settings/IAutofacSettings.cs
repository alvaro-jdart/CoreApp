using Autofac;
using Jdart.CoreApp.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jdart.CoreApp.Autofac.Settings
{
    public interface IAutofacSettings : ISettings<ContainerBuilder>
    {
    }
}
