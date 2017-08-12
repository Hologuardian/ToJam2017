﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public class Joule : SIUnit
    {
        public override string Name()
        { return Literals.SI.Name.Joule; }

        public override string Symbol()
        { return Literals.SI.Symbol.Joule; }

        public static implicit operator Joule(float f)
        { return new Joule() { Value = f }; }

        public static implicit operator Joule(WattHour wh)
        { return new Joule() { Value = wh / 3600.0f }; }
    }
}