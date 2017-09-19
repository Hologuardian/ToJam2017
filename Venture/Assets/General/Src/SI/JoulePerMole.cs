using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.SI
{
    public struct JoulePerMole : ISIUnit
    {
        public float value;

        public JoulePerMole(float f)
        { value = f; }

        public string Name()
        { return Literals.SI.Name.JoulePerMole; }

        public string Symbol()
        { return Literals.SI.Symbol.JoulePerMole; }

        public float Value()
        { return value; }

        public void Value(float f)
        { value = f; }

        public static explicit operator float(JoulePerMole jmol)
        { return jmol.value; }

        public static explicit operator string(JoulePerMole jmol)
        { return SIUnit.ToString(jmol); }

        public static implicit operator JoulePerMole(float f)
        { return new JoulePerMole(f); }
    }
}
