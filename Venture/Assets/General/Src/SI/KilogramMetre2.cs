using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.SI
{
    public struct KilogramMetre2 : ISIUnit
    {
        public float value;

        public KilogramMetre2(float f)
        { value = f; }

        public string Name()
        { return Literals.SI.Name.KilogramMetre2; }

        public string Symbol()
        { return Literals.SI.Symbol.KilogramMetre2; }

        public float Value()
        { return value; }

        public void Value(float f)
        { value = f; }
    }
}
