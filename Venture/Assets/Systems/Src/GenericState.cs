using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Systems
{
    public struct GenericState : IState
    {
        public object[] parameters;

        public GenericState(object[] parameters)
        { this.parameters = parameters; }

        public object[] Parameters()
        { return parameters; }

        public static implicit operator GenericState(object[] parameters)
        { return new GenericState(parameters); }
    }
}
