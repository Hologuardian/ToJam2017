using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Systems.Src.Connection
{
    public class Connections
    {
        public static void Connect(IConnections from, IConnections to)
        {
            if (!from.State().Connections.Contains(to))
                from.State().Connections.Add(to);
        }

        public static void Disconnect(IConnections from, IConnections to)
        {
            if (from.State().Connections.Contains(to))
                from.State().Connections.Remove(to);
        }
    }
}
