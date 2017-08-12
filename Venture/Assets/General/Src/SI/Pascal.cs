using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public class Pascal : SIUnit
    {
        public override string Name()
        { return Literals.SI.Name.Pascal; }

        public override string Symbol()
        { return Literals.SI.Symbol.Pascal; }

        public static implicit operator Pascal(float f)
        { return new Pascal() { Value = f }; }
    }
}
