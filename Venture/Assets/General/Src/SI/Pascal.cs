using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.SI
{
    public struct Pascal : ISIUnit
    {
        public float value;

        public Pascal(float f)
        { value = f; }

        public string Name()
        { return Literals.SI.Name.Pascal; }

        public string Symbol()
        { return Literals.SI.Symbol.Pascal; }

        public float Value()
        { return value; }

        public void Value(float f)
        { value = f; }

        public static implicit operator Pascal(float f)
        { return new Pascal(f); }

        public static explicit operator float(Pascal Pa)
        { return Pa.value; }

        public static explicit operator string(Pascal Pa)
        { return SIUnit.ToString(Pa); }

        public static Joule operator *(Pascal Pa, Metre3 m3)
        { return new Joule(Pa.value * m3.value); }
    }
}
