using Jdart.CoreApp.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Jdart.CoreApp
{
    public class DependencyConfigCollection<TContainer> : IEnumerable<Action<TContainer>>
    {
        private Dictionary<Type, IDependencyConfig<TContainer>> _dependencyConfigs = new Dictionary<Type, IDependencyConfig<TContainer>>();
        private List<Action<TContainer>> _dependencyActions = new List<Action<TContainer>>();

        public DependencyConfigCollection<TContainer> SetDependencies<T>(T dependencyConfig) where T : IDependencyConfig<TContainer>
        {
            _dependencyConfigs[typeof(T)] = dependencyConfig;

            return this;
        }

        public DependencyConfigCollection<TContainer> AddDependencies(Action<TContainer> action)
        {
            _dependencyActions.Add(action);

            return this;
        }

        public DependencyConfigCollection<TContainer> RemoveDependencies<T>() where T : IDependencyConfig<TContainer>
        {
            _dependencyConfigs.Remove(typeof(T));

            return this;
        }

        public IEnumerator<Action<TContainer>> GetEnumerator()
        {
            var actions = _dependencyActions.Concat(_dependencyConfigs.Select(x => (Action<TContainer>)x.Value.Register));

            return actions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
