using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public struct GramPerMole : ISIUnit
    {
        public float value;

        public GramPerMole(float f)
        { value = f; }

        public ISIUnit[] Decompose()
        { return new ISIUnit[] { new Gram(value), new Mole(1.0f) }; }

        public string Name()
        { return Literals.SI.Name.GramPerMole; }

        public string Symbol()
        { return Literals.SI.Symbol.GramPerMole; }

        public float Value()
        { return value; }

        public void Value(float f)
        { value = f; }

        public static Gram operator *(GramPerMole molar, Mole mol)
        { return new Gram(molar.value * mol.value); }

        public static Mole operator /(GramPerMole molar, Gram g)
        { return new Mole(molar.value / g.value); }

        public static implicit operator GramPerMole(float f)
        { return new GramPerMole(f); }
    }
}
