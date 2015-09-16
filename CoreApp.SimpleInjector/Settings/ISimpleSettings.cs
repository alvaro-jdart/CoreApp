using Jdart.CoreApp.Settings;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jdart.CoreApp.SimpleInjector.Settings
{
    public interface ISimpleSettings : ISettings<Container>
    {
    }
}
