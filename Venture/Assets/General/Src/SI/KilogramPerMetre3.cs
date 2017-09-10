using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public class KilogramPerMetre3 : SIUnit
    {
        public override string Name()
        { return Literals.SI.Name.KilogramPerMetre3; }

        public override string Symbol()
        { return Literals.SI.Symbol.KilogramPerMetre3; }

        public static implicit operator KilogramPerMetre3(float f)
        { return new KilogramPerMetre3() { Value = f }; }
    }
}
