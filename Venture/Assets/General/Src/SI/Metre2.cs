using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public struct Metre2 : ISIUnit
    {
        public float value;

        public Metre2(float f)
        { value = f; }

        public ISIUnit[] Decompose()
        { return new ISIUnit[] { this }; }

        public string Name()
        { return Literals.SI.Name.Metre2; }

        public string Symbol()
        { return Literals.SI.Symbol.Metre2; }

        public float Value()
        { return value; }

        public void Value(float f)
        { value = f; }

        public static implicit operator Metre2(float f)
        { return new Metre2(f); }

        public static explicit operator float(Metre2 m2)
        { return m2.value; }

        public static implicit operator string(Metre2 m2)
        { return SIUnit.ToString(m2); }
    }
}
