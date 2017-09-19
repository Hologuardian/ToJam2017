using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Systems
{
    public static class Systems
    {
        public static Dictionary<Type, Dictionary<Guid, IState>> states = new Dictionary<Type, Dictionary<Guid, IState>>();

        public static bool SystemRegistered(Type t)
        {
            return states.ContainsKey(t);
        }
        public static void RegisterSystem(Type t, Dictionary<Guid, IState> state)
        {
            states.Add(t, state);
        }
    }
}
