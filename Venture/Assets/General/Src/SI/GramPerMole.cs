using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public class GramPerMole : SIUnit
    {
        public override string Name()
        { return Literals.SI.Name.GramPerMole; }

        public override string Symbol()
        { return Literals.SI.Symbol.GramPerMole; }

        public static Gram operator *(GramPerMole molar, Mole mol)
        { return new Gram() { Value = molar * mol }; }

        public static Mole operator /(GramPerMole molar, Gram g)
        { return new Mole() { Value = molar / g }; }

        public static implicit operator GramPerMole(float f)
        { return new GramPerMole() { Value = f }; }
    }
}
