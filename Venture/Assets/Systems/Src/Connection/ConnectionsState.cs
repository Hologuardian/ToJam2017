using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Systems.Src.Connection
{
    public class ConnectionsState
    {
        private List<IConnections> connections = new List<IConnections>();
        public List<IConnections> Connections
        {
            get
            {
                return connections;
            }
            set
            {
                connections = value;
            }
        }
    }
}
