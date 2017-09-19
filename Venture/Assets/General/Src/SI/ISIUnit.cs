using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.General.SI
{
    public interface ISIUnit
    {
        string Name();

        string Symbol();

        float Value();

        void Value(float f);
    }
}
