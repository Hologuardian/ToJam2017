using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Systems
{
    public delegate void Dump(StateHandler handler);

    public class StateHandler
    {
        public readonly Guid target;

        private IState[] states;
        private int index = 0;
        private Dump dump;

        public IState State
        {
            get
            {
                return states[index];
            }
        }

        /// <summary>
        /// Constructs an instance of a state handler
        /// </summary>
        /// <param name="target">The Guid of the target object who owns the states</param>
        /// <param name="dump">The delegate method to call whenever the total number of storable states is exceded</param>
        /// <param name="states">The number of states this handler will store before dumping them to storage (using the dump delegate)</param>
        public StateHandler(Guid target, Dump dump, int states)
        {
            this.target = target;
            this.states = new IState[states];
        }

        /// <summary>
        /// Updates the last state of this handler to the passed state, this will overwrite pre-existing states if the states array is already full
        /// </summary>
        /// <param name="state">The state to set to the most recent state of this handler</param>
        public void Update(IState state)
        {
            states[index] = state;
            index++;
            if (index >= states.Length)
            {
                index = 0;
                dump.Invoke(this);
            }
        }
    }
}
