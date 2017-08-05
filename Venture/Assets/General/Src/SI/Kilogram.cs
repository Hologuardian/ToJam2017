using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public class Kilogram : SIUnit
    {
        public override string Name()
        { return "kilogram"; }

        public override string Symbol()
        { return "kg"; }

        public static implicit operator Kilogram(float f)
        { return new Kilogram() { Value = f }; }

        public static implicit operator Kilogram(Gram g)
        { return new Kilogram() { Value = g.Value / 1000.0f }; }

        public static implicit operator Gram(Kilogram kg)
        { return new Gram() { Value = kg.Value * 1000.0f }; }

        public static KilogramMetre3 operator /(Kilogram kg, Metre3 m)
        { return new KilogramMetre3() { Value = kg / m }; }
    }
}
