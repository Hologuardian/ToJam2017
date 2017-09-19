using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.SI
{
    public struct Hour : ISIUnit
    {
        public float value;

        public Hour(float f)
        { value = f; }

        public string Name()
        { return Literals.SI.Name.Hour; }

        public string Symbol()
        { return Literals.SI.Symbol.Hour; }

        public float Value()
        { return value; }

        public void Value(float f)
        { value = f; }

        public static implicit operator Second(Hour h)
        { return new Second(h.value * 3600.0f); }

        public static implicit operator Hour(float f)
        { return new Hour(f); }

        public static explicit operator float(Hour h)
        { return h.value; }

        public static explicit operator string(Hour h)
        { return SIUnit.ToString(h); }
    }
}
