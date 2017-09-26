using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Systems
{
    public interface ISystem
    {
        /// <summary>
        /// Creates a state handler for the specified target Guid.
        /// </summary>
        /// <param name="target">The target Guid to create a handler for.</param>
        void Handle(Guid target);
        /// <summary>
        /// Updates all handled states of this system.
        /// </summary>
        void Update();
        /// <summary>
        /// Updates the specified handler, and returns the most up to date state.
        /// </summary>
        /// <param name="handler">The handler to update.</param>
        /// <returns>The most recent state of the handler.</returns>
        IState Update(StateHandler handler);
        /// <summary>
        /// Returns the most recent state of a specified target.
        /// </summary>
        /// <param name="target">The target to query the most recent state of.</param>
        /// <returns>The most recent state of the specified target.</returns>
        IState State(Guid target);
        /// <summary>
        /// Moves all states from memory to storage for a given handler.
        /// </summary>
        /// <param name="handler">The handler to dump to storage.</param>
        void Dump(StateHandler handler);
    }
}
