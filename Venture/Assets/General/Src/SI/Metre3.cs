using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public class Metre3 : SIUnit
    {
        public override string Name()
        { return Literals.SI.Name.Metre3; }

        public override string Symbol()
        { return Literals.SI.Symbol.Metre3; }

        public static Metre3 operator *(Metre3 m, Metre3 m2)
        { return new Metre3() { Value = (float)m / (float)m2}; }

        public static implicit operator Metre3(float f)
        { return new Metre3() { Value = f }; }
    }
}
