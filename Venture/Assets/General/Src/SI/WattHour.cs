using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public class WattHour : SIUnit
    {
        public Watt watt;
        public Hour hour;

        public override string Name()
        {
            return "watthour";
        }

        public override string Symbol()
        {
            return "Wh";
        }

        public override SIUnit[] Decompose()
        {
            return new SIUnit[] { watt, hour };
        }

        public static WattHour operator *(WattHour a, WattHour b)
        {
            return new WattHour()
            {
                watt = new Watt() { Value = a.watt * b.watt },
                hour = new Hour() { Value = a.hour * b.hour },
                Value = a.Value * b.Value };
        }

        public static implicit operator Watt(WattHour Wh)
        {
            return Wh.watt;
        }

        public static implicit operator Hour(WattHour Wh)
        {
            return Wh.hour;
        }
    }
}
