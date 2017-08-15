using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Engine.Src;

namespace Assets.Systems.Src.Connection
{
    /// <summary>
    /// IConnections is the interface responsible for defining the behaviour of all connectable objects, such that they can form connections between each other in a map like data structure.
    /// </summary>
    public interface IConnections : ISubsystem<ConnectionsState>
    {
        
    }
}
