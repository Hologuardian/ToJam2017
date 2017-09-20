using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.SI
{
    public struct GramPerMole : ISIUnit
    {
        public float value;

        public GramPerMole(float f)
        { value = f; }

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

        public static Mole operator *(GramPerMole molar, Metre3 m3)
        { return new Mole(molar.value * m3.value); }

        public static Mole operator /(GramPerMole molar, Gram g)
        { return new Mole(molar.value / g.value); }

        public static Gram operator /(Mole mol, GramPerMole gmol)
        { return new Gram(mol.value / gmol.value); }

        public static implicit operator GramPerMole(float f)
        { return new GramPerMole(f); }
    }
}
