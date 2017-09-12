using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public struct Mole : ISIUnit
    {
        public float value;

        public Mole(float f)
        { value = f; }

        public string Name()
        { return Literals.SI.Name.Mole; }

        public string Symbol()
        { return Literals.SI.Symbol.Mole; }

        public float Value()
        { return value; }

        public void Value(float f)
        { value = f; }

        public ISIUnit[] Decompose()
        { return new ISIUnit[] { this }; }

        public static implicit operator Mole(float f)
        { return new Mole(f); }

        public static GramPerMole operator /(Kilogram kg, Mole mol)
        { return new GramPerMole(kg.value / mol.value); }

        public static explicit operator float(Mole mol)
        { return mol.value; }

        public static implicit operator string(Mole mol)
        { return SIUnit.ToString(mol); }
    }
}
