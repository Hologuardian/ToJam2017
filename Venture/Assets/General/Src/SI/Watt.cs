using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.SI
{
    public struct Watt : ISIUnit
    {
        public float value;

        public Watt(float f)
        { value = f; }

        public string Name()
        { return Literals.SI.Name.Watt; }

        public string Symbol()
        { return Literals.SI.Symbol.Watt; }

        public float Value()
        { return value; }

        public void Value(float f)
        { value = f; }

        public static WattHour operator *(Watt w, Hour h)
        { return new WattHour(w.value * h.value); }

        public static Joule operator *(Watt w, Second s)
        { return new Joule(w.value * s.value); }

        public static implicit operator Watt(float f)
        { return new Watt(f); }

        public static explicit operator float(Watt w)
        { return w.value; }

        public static explicit operator string(Watt w)
        { return SIUnit.ToString(w); }
    }
}
