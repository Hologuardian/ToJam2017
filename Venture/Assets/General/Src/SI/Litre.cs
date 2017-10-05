using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.SI
{
    public struct Litre : ISIUnit
    {
        private float value;

        public Litre(float f)
        { value = f; }
        
        public string Name()
        { return Literals.SI.Name.Litre; }

        public string Symbol()
        { return Literals.SI.Symbol.Litre; }

        public float Value()
        { return value; }

        public void Value(float f)
        { value = f; }

        public static implicit operator Metre3(Litre L)
        { return new Metre3(L.value * 0.001f); }

        public static implicit operator Litre(Metre3 m3)
        { return new Litre(m3.value * 1000.0f); }

        public static explicit operator float(Litre L)
        { return L.value; }

        public static implicit operator string(Litre L)
        { return SIUnit.ToString(L); }
    }
}
