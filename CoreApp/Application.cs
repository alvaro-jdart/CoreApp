using Jdart.CoreApp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jdart.CoreApp
{
    public class Application<TContainer> : Application<TContainer, TContainer>
    {
        public Application(AppOptions<TContainer> options) : base(options.ToCommonOptions())
        { }
    }
}
