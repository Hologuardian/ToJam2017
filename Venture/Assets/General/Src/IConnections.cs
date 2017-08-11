using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Engine.Src;

namespace Assets.General.Src
{
    /// <summary>
    /// IConnections is the interface responsible for defining the behaviour of all connectable objects, such that they can form connections between each other in a map like data structure.
    /// </summary>
    public interface IConnections
    {
        /// <summary>
        /// Returns a reference to this volatile object
        /// </summary>
        /// <returns>This volatile object</returns>
        VolatileObject Self();
        /// <summary>
        /// Returns the array of connections this IConnection is connected to.
        /// </summary>
        /// <returns>The array of connections this IConnection is connected to.</returns>
        IConnections[] Connections();
        /// <summary>
        /// Adds an IConnection to this IConnection as a connection.
        /// </summary>
        /// <param name="connection">The IConnection to add as a connectoon.</param>
        void Add(IConnections connection);
        /// <summary>
        /// Removes an IConnection from this IConnection.
        /// </summary>
        /// <param name="connection">The IConnection to remove.</param>
        void Remove(IConnections connection);
    }
}
