using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.SI
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

        public static implicit operator Mole(float f)
        { return new Mole(f); }

        public static Mole operator *(Mole mol, float f)
        { return new Mole(mol.value * f); }

        public static GramPerMole operator /(Gram g, Mole mol)
        { return new GramPerMole(g.value / mol.value); }

        public static MoleKelvin operator *(Mole mol, Kelvin K)
        { return new MoleKelvin(mol.value * K.value); }

        public static Mole operator +(Mole molA, Mole molB)
        { return new Mole(molA.value + molB.value); }

        public static Mole operator -(Mole molA, Mole molB)
        { return new Mole(molA.value - molB.value); }

        public static explicit operator float(Mole mol)
        { return mol.value; }

        public static explicit operator string(Mole mol)
        { return SIUnit.ToString(mol); }
    }
}
