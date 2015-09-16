using Jdart.CoreApp.Dependency;
using Jdart.CoreApp.Init;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jdart.CoreApp.Settings
{
    public interface ISettings<TContainer> : IDependency<TContainer>, IInit
    {
    }
}
