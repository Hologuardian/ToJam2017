using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.SI
{
    public struct KilogramPerMetre3 : ISIUnit
    {
        public float value;

        public KilogramPerMetre3(float f)
        { value = f; }

        public string Name()
        { return Literals.SI.Name.KilogramPerMetre3; }

        public string Symbol()
        { return Literals.SI.Symbol.KilogramPerMetre3; }

        public float Value()
        { return value; }

        public void Value(float f)
        { value = f; }

        public static Kilogram operator *(KilogramPerMetre3 Kgm3, Metre3 m3)
        { return new Kilogram(Kgm3.value * m3.value); }

        public static Kilogram operator *(Metre3 m3, KilogramPerMetre3 Kgm3)
        { return new Kilogram(Kgm3.value * m3.value); }

        public static Metre3 operator *(Kilogram Kg, KilogramPerMetre3 Kgm3)
        { return new Metre3(Kg.value * Kgm3.value); }

        public static implicit operator KilogramPerMetre3(float f)
        { return new KilogramPerMetre3(f); }

        public static explicit operator float(KilogramPerMetre3 Kgm3)
        { return Kgm3.value; }

        public static explicit operator string(KilogramPerMetre3 Kgm3)
        { return SIUnit.ToString(Kgm3); }
    }
}
