using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public class Atmosphere : SIUnit
    {
        public override string Name()
        { return Literals.SI.Name.Atmosphere; }

        public override string Symbol()
        { return Literals.SI.Symbol.Atmosphere; }

        public static implicit operator Atmosphere(float f)
        { return new Atmosphere() { Value = f }; }

        public static implicit operator Atmosphere(Pascal pa)
        { return new Atmosphere() { Value = pa / 101325.0f }; }

        public static implicit operator Atmosphere(Bar bar)
        { return new Atmosphere() { Value = bar / 1.01325f }; }

        public static implicit operator Pascal(Atmosphere atm)
        { return new Pascal() { Value = atm * 101325.0f }; }

        public static implicit operator Bar(Atmosphere atm)
        { return new Bar() { Value = atm * 1.01325f }; }
    }
}
