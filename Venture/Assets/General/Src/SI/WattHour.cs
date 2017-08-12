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
    public class WattHour : SIUnit
    {
        public override string Name()
        { return Literals.SI.Name.WattHour; }

        public override string Symbol()
        { return Literals.SI.Symbol.WattHour; }

        public static WattHour operator +(WattHour a, WattHour b)
        { return new WattHour() { Value = a + b }; }

        public static WattHour operator -(WattHour a, WattHour b)
        { return new WattHour() { Value = a - b }; }

        public static WattHour operator *(WattHour a, float f)
        { return new WattHour() { Value = a * f }; }

        public static WattHour operator /(WattHour a, float f)
        { return new WattHour() { Value = a / f }; }

        public static Watt operator /(WattHour Wh, Hour h)
        { return new Watt() { Value = Wh / h }; }

        public static implicit operator WattHour(float f)
        { return new WattHour { Value = f }; }

        public static implicit operator WattHour(Joule j)
        { return new WattHour { Value = j * 3600.0f }; }
    }
}
