﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public class Celsius : SIUnit
    {
        public override string Name()
        { return Literals.SI.Name.Celsius; }

        public override string Symbol()
        { return Literals.SI.Symbol.Celsius; }

        public static implicit operator Celsius(float f)
        { return new Celsius() { Value = f }; }

        public static implicit operator Celsius(Kelvin k)
        { return new Celsius() { Value = k - 273.15f }; }
    }
}
