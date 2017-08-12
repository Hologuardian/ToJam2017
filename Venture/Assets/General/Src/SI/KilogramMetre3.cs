using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public class KilogramMetre3 : SIUnit
    {
        public override string Name()
        { return Literals.SI.Name.KilogramMetre3; }

        public override string Symbol()
        { return Literals.SI.Symbol.KilogramMetre3; }

        public static implicit operator KilogramMetre3(float f)
        { return new KilogramMetre3() { Value = f }; }
    }
}
