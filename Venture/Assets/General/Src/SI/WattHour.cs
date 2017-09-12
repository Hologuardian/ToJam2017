using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    /// <summary>
    /// The WattHour symbol Wh is a derived SI unit formed when multiplying Watts by any measure of time
    /// The WattHour is always expressed in # of Watts per 1 hour.
    /// </summary>
    public struct WattHour : ISIUnit
    {
        public float value;

        public WattHour(float f)
        { value = f; }

        public string Name()
        { return Literals.SI.Name.WattHour; }

        public string Symbol()
        { return Literals.SI.Symbol.WattHour; }

        public float Value()
        { return value; }

        public void Value(float f)
        { value = f; }

        public ISIUnit[] Decompose()
        { return new ISIUnit[] { new Watt(value), new Hour(1.0f) }; }

        public static WattHour operator +(WattHour a, WattHour b)
        { return new WattHour((float)a + (float)b); }

        public static WattHour operator -(WattHour a, WattHour b)
        { return new WattHour((float)a - (float)b); }

        public static WattHour operator *(WattHour a, float f)
        { return new WattHour((float)a * f); }

        public static WattHour operator /(WattHour a, float f)
        { return new WattHour((float)a / f); }

        public static Watt operator /(WattHour Wh, Hour h)
        { return new Watt((float)Wh / (float)h); }

        public static implicit operator WattHour(float f)
        { return new WattHour(f); }

        public static implicit operator WattHour(Joule j)
        { return new WattHour((float)j * 3600.0f); }

        public static explicit operator float(WattHour Wh)
        { return Wh.value; }

        public static implicit operator string(WattHour Wh)
        { return ISIUnit.ToString(Wh); }
    }
}
