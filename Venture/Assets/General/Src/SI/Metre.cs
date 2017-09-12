using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public struct Metre : ISIUnit
    {
        public float value;

        public Metre(float f)
        { value = f; }

        public ISIUnit[] Decompose()
        { return new ISIUnit[] { this }; }

        public string Name()
        { return Literals.SI.Name.Metre; }

        public string Symbol()
        { return Literals.SI.Symbol.Metre; }

        public float Value()
        { return value; }

        public void Value(float f)
        { value = f; }

        public static implicit operator Metre(float f)
        { return new Metre(f); }

        public static explicit operator float(Metre m)
        { return m.value; }

        public static implicit operator string(Metre m)
        { return SIUnit.ToString(m); }
    }
}
