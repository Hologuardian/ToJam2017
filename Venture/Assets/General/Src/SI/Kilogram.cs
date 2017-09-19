using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.SI
{
    public struct Kilogram : ISIUnit
    {
        public float value;

        public Kilogram(float f)
        { value = f; }

        public string Name()
        { return Literals.SI.Name.Kilogram; }

        public string Symbol()
        { return Literals.SI.Symbol.Kilogram; }

        public float Value()
        { return value; }

        public void Value(float f)
        { value = f; }

        public static implicit operator Kilogram(float f)
        { return new Kilogram(f); }

        public static implicit operator Kilogram(Gram g)
        { return new Kilogram(g.value / 1000.0f); }

        public static implicit operator Gram(Kilogram kg)
        { return new Gram(kg.value * 1000.0f); }

        public static KilogramPerMetre3 operator /(Kilogram kg, Metre3 m)
        { return new KilogramPerMetre3(kg.value / m.value); }
    }
}
