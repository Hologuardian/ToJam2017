using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.SI
{
    public struct Second : ISIUnit
    {
        public float value;

        public Second(float f)
        { value = f; }

        public string Name()
        { return Literals.SI.Name.Second; }

        public string Symbol()
        { return Literals.SI.Symbol.Second; }

        public float Value()
        { return value; }

        public void Value(float f)
        { value = f; }

        public static implicit operator Hour(Second s)
        { return new Hour(s.value / 3600.0f); }

        public static implicit operator Second(float f)
        { return new Second(f); }

        public static explicit operator float(Second s)
        { return s.value; }

        public static explicit operator string(Second s)
        { return SIUnit.ToString(s); }
    }
}
