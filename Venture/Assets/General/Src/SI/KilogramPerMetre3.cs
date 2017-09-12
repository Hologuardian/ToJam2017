using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public struct KilogramPerMetre3 : ISIUnit
    {
        public float value;

        public KilogramPerMetre3(float f)
        { value = f; }

        public ISIUnit[] Decompose()
        { return new ISIUnit[] { new Kilogram(value), new Metre3(1.0f) }; }

        public string Name()
        { return Literals.SI.Name.KilogramPerMetre3; }

        public string Symbol()
        { return Literals.SI.Symbol.KilogramPerMetre3; }

        public float Value()
        { return value; }

        public void Value(float f)
        { value = f; }

        public static implicit operator KilogramPerMetre3(float f)
        { return new KilogramPerMetre3(f); }

        public static explicit operator float(KilogramPerMetre3 Kgm3)
        { return Kgm3.value; }

        public static implicit operator string(KilogramPerMetre3 Kgm3)
        { return SIUnit.ToString(Kgm3); }
    }
}
