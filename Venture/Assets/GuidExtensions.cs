using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Systems;
using Assets.Systems.Atmosphere;
using Assets.Systems.Connection;
using Assets.Systems.Electricity;
using Assets.Systems.Pressure;

public static class GuidExtensions
{
    public static TState State<TState> (this Guid guid) where TState : IState
    {
        // Do a look up on the guid in the system in question (defined by T).
        return (TState)Systems.states[typeof(TState)][guid];
    }
}
