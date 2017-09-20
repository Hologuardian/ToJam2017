using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.SI
{
    public struct Joule : ISIUnit
    {
        public float value;

        public Joule(float f)
        { value = f; }

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

        public static Joule operator /(Joule j, float f)
        { return new Joule(j.value / f); }

        public static Pascal operator /(Joule j, Metre3 m3)
        { return new Pascal(j.value / m3.value); }

        public static explicit operator float(Joule j)
        { return j.value; }

        public static explicit operator string(Joule j)
        { return SIUnit.ToString(j); }
    }
}
