using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Systems.Src
{
    public interface ISystem
    {
        State Update(State state);
    }
}
