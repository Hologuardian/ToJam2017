using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public struct Bar : ISIUnit
    {
        public float value;

        public Bar(float f)
        { value = f; }

        public string Name()
        { return Literals.SI.Name.Bar; }

        public string Symbol()
        { return Literals.SI.Symbol.Bar; }

        public float Value()
        { return value; }

        public void Value(float f)
        { value = f; }

        public ISIUnit[] Decompose()
        {//TODO SIUnit Bar Decompose()
            return new ISIUnit[] { this };
        }

        public static implicit operator Bar(float f)
        { return new Bar(f); }

        public static implicit operator Bar(Pascal pa)
        { return new Bar(pa.value / 100000); }

        public static implicit operator Pascal(Bar bar)
        { return new Pascal(bar.value * 100000); }

        public static explicit operator float(Bar bar)
        { return bar.value; }

        public static implicit operator string(Bar bar)
        { return SIUnit.ToString(bar); }
    }
}
