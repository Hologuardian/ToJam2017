using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public class Gram : SIUnit
    {
        public override string Name()
        { return "gram"; }

        public override string Symbol()
        { return "g"; }

        public static Gram operator +(Gram a, Gram b)
        { return new Gram() { Value = a + b }; }

        public static Gram operator -(Gram a, Gram b)
        { return new Gram() { Value = a - b }; }

        public static implicit operator Gram(float f)
        { return new Gram() { Value = f }; }
    }
}
