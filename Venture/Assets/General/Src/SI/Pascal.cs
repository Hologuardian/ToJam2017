using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public class Pascal : SIUnit
    {
        public override string Name()
        { return "pascal"; }

        public override string Symbol()
        { return "Pa"; }

        public static implicit operator Pascal(float f)
        { return new Pascal() { Value = f }; }
    }
}
