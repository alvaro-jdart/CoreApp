using Jdart.CoreApp.Dependency;
using Jdart.CoreApp.Init;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Jdart.CoreApp
{
    public class InitServiceCollection : IEnumerable<Action<DependencyResolver>>
    {
        private Dictionary<Type, IInitService> _initServices = new Dictionary<Type, IInitService>();
        private List<Action<DependencyResolver>> _initActions = new List<Action<DependencyResolver>>();

        public InitServiceCollection SetInit<T>(T initService) where T : IInitService
        {
            _initServices[typeof(T)] = initService;

            return this;
        }

        public void AddInit(Action<DependencyResolver> action)
        {
            _initActions.Add(action);
        }

        public void RemoveInit<T>() where T : IInitService
        {
            _initServices.Remove(typeof(T));
        }

        public IEnumerator<Action<DependencyResolver>> GetEnumerator()
        {
            var actions = _initActions.Concat(_initServices.Select(x => (Action<DependencyResolver>)x.Value.Init));

            return actions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
