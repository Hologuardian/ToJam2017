using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public class KilogramMole : SIUnit
    {
        public override string Name()
        { return Literals.SI.Name.KilogramMole; }

        public override string Symbol()
        { return Literals.SI.Symbol.KilogramMole; }

        public static Kilogram operator *(KilogramMole molar, Mole mol)
        { return new Kilogram() { Value = molar * mol }; }

        public static implicit operator KilogramMole(float f)
        { return new KilogramMole() { Value = f }; }
    }
}
