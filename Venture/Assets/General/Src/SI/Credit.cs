using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.Src.SI
{
    public class Credit : SIUnit
    {
        public override string Name()
        {
            return Literals.SI.Name.Credit;
        }

        public override string Symbol()
        {
            return Literals.SI.Symbol.Credit;
        }
    }
}
