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
        { return "watthour"; }

        public override string Symbol()
        { return "Wh"; }

        public static WattHour operator +(WattHour a, WattHour b)
        { return new WattHour() { Value = a + b }; }

        public static WattHour operator -(WattHour a, WattHour b)
        { return new WattHour() { Value = a - b }; }

        public static Watt operator /(WattHour Wh, Hour h)
        { return new Watt() { Value = Wh / h }; }

        public static implicit operator WattHour(float f)
        { return new WattHour { Value = f }; }
    }
}
