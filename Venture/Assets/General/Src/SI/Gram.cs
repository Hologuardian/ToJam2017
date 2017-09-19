using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.SI
{
    public struct Gram : ISIUnit
    {
        public float value;

        public Gram(float f)
        { value = f; }

        public string Name()
        { return Literals.SI.Name.Gram; }

        public string Symbol()
        { return Literals.SI.Symbol.Gram; }

        public float Value()
        { return value; }

        public void Value(float f)
        { value = f; }

        public static Gram operator +(Gram a, Gram b)
        { return new Gram(a.value + b.value); }

        public static Gram operator -(Gram a, Gram b)
        { return new Gram(a.value - b.value); }

        public static implicit operator Gram(float f)
        { return new Gram(f); }

        public static explicit operator float(Gram g)
        { return g.value; }

        public static explicit operator string(Gram g)
        { return SIUnit.ToString(g); }
    }
}
