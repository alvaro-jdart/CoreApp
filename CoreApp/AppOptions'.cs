using Jdart.CoreApp.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jdart.CoreApp
{
    public class AppOptions<TContainer, TResultContainer>
    {
        public TContainer DependencyContainer { get; set; }

        public Func<TResultContainer, Func<Type, object>> GetServiceFunc { get; set; }

        public Func<TResultContainer, Func<Type, IEnumerable<object>>> GetAllServicesFunc { get; set; }

        public Func<TContainer, TResultContainer> VerifyAction { get; set; }

        public IAppLogger Logger { get; set; }
    }
}
