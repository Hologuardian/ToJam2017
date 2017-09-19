using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.SI
{
    public struct Celsius : ISIUnit
    {
        public float value;

        public Celsius(float f)
        { value = f; }

        public string Name()
        { return Literals.SI.Name.Celsius; }

        public string Symbol()
        { return Literals.SI.Symbol.Celsius; }

        public float Value()
        { return value; }

        public void Value(float f)
        { value = f; }

        public static implicit operator Celsius(float f)
        { return new Celsius(f); }

        public static implicit operator Celsius(Kelvin K)
        { return new Celsius(K.value - 273.15f); }

        public static explicit operator float(Celsius c)
        { return c.value; }

        public static explicit operator string(Celsius c)
        { return SIUnit.ToString(c); }
    }
}
