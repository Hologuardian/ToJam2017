using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public class KilogramMetre3 : SIUnit
    {
        public override string Name()
        { return "kilogram per cubed metre"; }

        public override string Symbol()
        { return "kg/m³"; }

        public static implicit operator KilogramMetre3(float f)
        { return new KilogramMetre3() { Value = f }; }
    }
}
