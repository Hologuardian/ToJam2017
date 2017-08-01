using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public class Hour : SIUnit
    {
        public override string Name()
        { return "hour"; }

        public override string Symbol()
        { return "h"; }

        public static implicit operator Second(Hour h)
        { return new Second() { Value = h * 360.0f }; }

        public static implicit operator Hour(float f)
        { return new Hour() { Value = f }; }
    }
}
