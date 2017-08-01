using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public class Mole : SIUnit
    {
        public override string Name()
        { return "mole"; }

        public override string Symbol()
        { return "mol"; }

        public static implicit operator Mole(float f)
        { return new Mole() { Value = f }; }
    }
}
