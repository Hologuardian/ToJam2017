using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public class Second : SIUnit
    {
        public override string Name()
        { return Literals.SI.Name.Second; }

        public override string Symbol()
        { return Literals.SI.Symbol.Second; }

        public static implicit operator Hour(Second s)
        { return new Hour() { Value = s / 3600.0f }; }

        public static implicit operator Second(float f)
        { return new Second() { Value = f }; }
    }
}
