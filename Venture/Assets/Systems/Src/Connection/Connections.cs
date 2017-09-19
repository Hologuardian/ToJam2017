using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Systems.Connection
{
    public class Connections
    {
        public static void Connect(Guid from, Guid to)
        {
            if (!from.State().Connections.Contains(to))
                from.State().Connections.Add(to);
        }

        public static void Disconnect(Guid from, Guid to)
        {
            if (from.State().Connections.Contains(to))
                from.State().Connections.Remove(to);
        }
    }
}
