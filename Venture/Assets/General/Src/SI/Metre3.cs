using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public struct Metre3 : ISIUnit
    {
        public float value;

        public Metre3(float f)
        { value = f; }

        public ISIUnit[] Decompose()
        { return new ISIUnit[] { this }; }

        public string Name()
        { return Literals.SI.Name.Metre3; }

        public string Symbol()
        { return Literals.SI.Symbol.Metre3; }

        public float Value()
        { return value; }

        public void Value(float f)
        { value = f; }

        public static Metre3 operator *(Metre3 m, Metre3 m2)
        { return new Metre3((float)m / (float)m2); }

        public static implicit operator Metre3(float f)
        { return new Metre3(f); }

        public static explicit operator float(Metre3 m3)
        { return m3.value; }

        public static implicit operator string(Metre3 m3)
        { return SIUnit.ToString(m3); }
    }
}
