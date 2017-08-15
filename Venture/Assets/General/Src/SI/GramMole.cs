using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public class GramMole : SIUnit
    {
        public override string Name()
        { return Literals.SI.Name.GramMole; }

        public override string Symbol()
        { return Literals.SI.Symbol.GramMole; }

        public static Gram operator *(GramMole molar, Mole mol)
        { return new Gram() { Value = molar * mol }; }

        public static implicit operator GramMole(float f)
        { return new GramMole() { Value = f }; }
    }
}
