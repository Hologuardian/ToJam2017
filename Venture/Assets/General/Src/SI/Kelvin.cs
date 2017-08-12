using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public class Kelvin : SIUnit
    {
        public override string Name()
        { return Literals.SI.Name.Kelvin; }

        public override string Symbol()
        { return Literals.SI.Symbol.Kelvin; }

        public static implicit operator Kelvin(float f)
        { return new Kelvin() { Value = f }; }

        public static implicit operator Kelvin(Celsius c)
        { return new Kelvin() { Value = c + 273.15f }; }
    }
}
