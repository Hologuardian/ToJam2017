using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public class Gram : SIUnit
    {
        public override string Name()
        { return Literals.SI.Name.Gram; }

        public override string Symbol()
        { return Literals.SI.Symbol.Gram; }

        public static Gram operator +(Gram a, Gram b)
        { return new Gram() { Value = (float)a + (float)b }; }

        public static Gram operator -(Gram a, Gram b)
        { return new Gram() { Value = (float)a - (float)b }; }

        public static implicit operator Gram(float f)
        { return new Gram() { Value = f }; }
    }
}
