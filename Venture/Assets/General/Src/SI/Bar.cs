using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public class Bar : SIUnit
    {
        public override string Name()
        { return "bar"; }

        public override string Symbol()
        { return "bar"; }

        public static implicit operator Bar(float f)
        { return new Bar() { Value = f }; }

        public static implicit operator Bar(Pascal pa)
        { return new Bar() { Value = pa / 100000 }; }

        public static implicit operator Pascal(Bar bar)
        { return new Pascal() { Value = bar * 100000 }; }
    }
}
