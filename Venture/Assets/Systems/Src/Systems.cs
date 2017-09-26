using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Systems
{
    /// <summary>
    /// Systems is the factory class that handles delivering the correct system based on the query state of the passed parameters.
    /// As such it is the abstaction responsible for dealing with passing information to or from pertinant systems as the need demands, based on state or system type.
    /// Systems register themselves with this factory to enable proper management of their state information through Guid extensions, and static factory methods.
    /// </summary>
    public static class Systems
    {
        /// <summary>
        /// Maps the type of state to an instance of an ISystem
        /// </summary>
        private static Dictionary<Type, ISystem> systemsCache = new Dictionary<Type, ISystem>();

        public static void RegisterSystem(Type type, ISystem system)
        {
            if (!systemsCache.ContainsKey(type))
                systemsCache.Add(type, system);
        }

        public static IState State(Guid target, Type state)
        {
            ISystem system;
            systemsCache.TryGetValue(state, out system);

            if (system == null)
                return new GenericState();
            else
            {
                IState stateToReturn = system.State(target);
                if (stateToReturn == null)
                    return new GenericState();
                else
                    return stateToReturn;
            }
        }
    }
}
