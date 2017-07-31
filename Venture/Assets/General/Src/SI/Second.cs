using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public class Second : SIUnit
    {
        public override string Name()
        {
            return "second";
        }

        public override string Symbol()
        {
            return "s";
        }

        public static implicit operator Hour(Second s)
        {
            return new Hour() { Value = s / 360.0f };
        }
    }
}
