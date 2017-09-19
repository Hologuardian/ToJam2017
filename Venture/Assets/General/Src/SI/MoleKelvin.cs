using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.SI
{
    public struct MoleKelvin : ISIUnit
    {
        public float value;

        public MoleKelvin(float f)
        { value = f; }

        public string Name()
        { return Literals.SI.Name.MoleKelvin; }

        public string Symbol()
        { return Literals.SI.Symbol.MoleKelvin; }

        public float Value()
        { return value; }

        public void Value(float f)
        { value = f; }

        public static explicit operator float(MoleKelvin molK)
        { return molK.value; }

        public static explicit operator string(MoleKelvin molK)
        { return SIUnit.ToString(molK); }
    }
}
