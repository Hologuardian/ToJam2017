using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.SI
{
    public struct JoulePerMoleKelvin : ISIUnit
    {
        public float value;

        public JoulePerMoleKelvin(float f)
        { value = f; }

        public string Name()
        { return Literals.SI.Name.JoulePerMoleKelvin; }

        public string Symbol()
        { return Literals.SI.Symbol.JoulePerMoleKelvin; }

        public float Value()
        { return value; }

        public void Value(float f)
        { value = f; }

        public static explicit operator float(JoulePerMoleKelvin JmolK)
        { return JmolK.value; }

        public static explicit operator string(JoulePerMoleKelvin JmolK)
        { return SIUnit.ToString(JmolK); }
    }
}
