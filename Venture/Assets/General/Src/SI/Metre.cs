using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public class Metre : SIUnit
    {
        public override string Name()
        { return Literals.SI.Name.Metre; }

        public override string Symbol()
        { return Literals.SI.Symbol.Metre; }

        public static implicit operator Metre(float f)
        { return new Metre() { Value = f }; }
    }
}
