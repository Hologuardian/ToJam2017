using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.General.SI;

namespace Assets.Systems.Connection
{
    public struct ConnectionsState : IState
    {
        public List<Guid> connections;

        public object[] Parameters()
        {
            return new object[] { connections };
        }
    }
}
