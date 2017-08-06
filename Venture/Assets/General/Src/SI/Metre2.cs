using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public class Metre2 : SIUnit
    {
        public override string Name()
        { return "squared metre"; }

        public override string Symbol()
        { return "m²"; }

        public static implicit operator Metre2(float f)
        { return new Metre2() { Value = f }; }
    }
}
