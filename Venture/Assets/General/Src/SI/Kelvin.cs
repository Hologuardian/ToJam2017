using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.SI
{
    public struct Kelvin : ISIUnit
    {
        public float value;

        public Kelvin(float f)
        { value = f; }

        public string Name()
        { return Literals.SI.Name.Kelvin; }

        public string Symbol()
        { return Literals.SI.Symbol.Kelvin; }

        public float Value()
        { return value; }

        public void Value(float f)
        { value = f; }

        public static implicit operator Kelvin(float f)
        { return new Kelvin(f); }

        public static implicit operator Kelvin(Celsius c)
        { return new Kelvin((float)c + 273.15f); }

        public static explicit operator float(Kelvin K)
        { return K.value; }

        public static explicit operator string(Kelvin K)
        { return SIUnit.ToString(K); }
    }
}
