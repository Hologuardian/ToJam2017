using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public class Watt : SIUnit
    {
        public override string Name()
        {
            return "watt";
        }

        public override string Symbol()
        {
            return "W";
        }

        public static SIUnit operator *(Watt w, Hour h)
        {
            return new WattHour() { Value = w * h, watt = w, hour = h };
        }

        public static SIUnit operator *(Watt w, Second s)
        {
            return new WattHour() { Value = w * (Hour)s, watt = w, hour = (Hour)s };
        }

        public static SIUnit operator /(Watt w, Hour h)
        {
            return new WattHour() { Value = w / h, watt = w, hour = h };
        }

        public static SIUnit operator /(Watt w, Second s)
        {
            return new WattHour() { Value = w / (Hour)s, watt = w, hour = (Hour)s };
        }
    }
}
