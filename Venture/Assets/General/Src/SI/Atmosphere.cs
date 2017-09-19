using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.SI
{
    public struct Atmosphere : ISIUnit
    {
        public float value;

        public Atmosphere(float f)
        { value = f; }

        public string Name()
        { return Literals.SI.Name.Atmosphere; }

        public string Symbol()
        { return Literals.SI.Symbol.Atmosphere; }

        public float Value()
        { return value; }

        public void Value(float f)
        { value = f; }

        public static implicit operator Atmosphere(float f)
        { return new Atmosphere(f); }

        public static implicit operator Atmosphere(Pascal pa)
        { return new Atmosphere(pa.value / 101325.0f); }

        public static implicit operator Atmosphere(Bar bar)
        { return new Atmosphere(bar.value / 1.01325f); }

        public static implicit operator Pascal(Atmosphere atm)
        { return new Pascal(atm.value * 101325.0f); }

        public static implicit operator Bar(Atmosphere atm)
        { return new Bar(atm.value * 1.01325f); }

        public static explicit operator float(Atmosphere atm)
        { return atm.value; }

        public static explicit operator string(Atmosphere atm)
        { return SIUnit.ToString(atm); }
    }
}
