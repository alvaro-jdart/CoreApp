using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jdart.CoreApp.Dependency
{
    public interface IDependency<TContainer>
    {
        void Register(TContainer container);
    }
}
