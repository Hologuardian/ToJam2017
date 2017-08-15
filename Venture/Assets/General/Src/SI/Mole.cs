using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public class Mole : SIUnit
    {
        public override string Name()
        { return Literals.SI.Name.Mole; }

        public override string Symbol()
        { return Literals.SI.Symbol.Mole; }

        public static implicit operator Mole(float f)
        { return new Mole() { Value = f }; }

        public static GramMole operator /(Kilogram kg, Mole mol)
        { return new GramMole() { Value = kg / mol }; }
    }
}
