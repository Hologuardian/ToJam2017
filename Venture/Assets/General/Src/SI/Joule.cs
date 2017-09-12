using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public struct Joule : ISIUnit
    {
        public float value;

        public Joule(float f)
        { value = f; }

        public ISIUnit[] Decompose()
        { return new ISIUnit[] { this }; }

        public string Name()
        { return Literals.SI.Name.Joule; }

        public string Symbol()
        { return Literals.SI.Symbol.Joule; }

        public float Value()
        { return value; }

        public void Value(float f)
        { value = f; }

        public static implicit operator Joule(float f)
        { return new Joule(f); }

        public static implicit operator Joule(WattHour Wh)
        { return new Joule(Wh.value / 3600.0f); }

        public static explicit operator float(Joule j)
        { return j.value; }

        public static implicit operator string(Joule j)
        { return SIUnit.ToString(j); }
    }
}
