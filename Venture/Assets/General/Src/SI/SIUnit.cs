using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.General.Src.SI
{
    #region Factors
    public enum Factor
    {
        yocto = -24,
        zepto = -21,
        atto = -18,
        femto = -15,
        pico = -12,
        nano = -9,
        micro = -6,
        milli = -3,
        centi = -2,
        deci = -1,
        none = 0,
        deca = 1,
        hecto = 2,
        kilo = 3,
        mega = 6,
        giga = 9,
        tera = 12,
        peta = 15,
        exa = 18,
        zetta = 21,
        yotta = 24
    };
    #endregion

    public abstract class SIUnit
    {
        public abstract string Name();
        public abstract string Symbol();
        public float Value { get; set; }

        public virtual SIUnit[] Decompose()
        {
            return new SIUnit[] { this };
        }

        public int GetFactor()
        {
            if (Value != 0)
                return Mathf.FloorToInt(Mathf.Log10(Value));
            else
                return 0;
        }

        public float FactorValue()
        {
            return Value * Mathf.Pow(10, GetFactor());
        }

        #region Symbols
        public string PrefixSymbol()
        {
            int factorInt = GetFactor();

            if (factorInt <= (int)Factor.yocto)
            {
                return "y";
            }
            else if (factorInt <= (int)Factor.zepto)
            {
                return "z";
            }
            else if (factorInt <= (int)Factor.atto)
            {
                return "a";
            }
            else if (factorInt <= (int)Factor.femto)
            {
                return "f";
            }
            else if (factorInt <= (int)Factor.pico)
            {
                return "p";
            }
            else if (factorInt <= (int)Factor.nano)
            {
                return "n";
            }
            else if (factorInt <= (int)Factor.micro)
            {
                return "μ";
            }
            else if (factorInt <= (int)Factor.milli)
            {
                return "m";
            }
            else if (factorInt <= (int)Factor.centi)
            {
                return "c";
            }
            else if (factorInt <= (int)Factor.deci)
            {
                return "d";
            }
            else if (factorInt <= (int)Factor.none)
            {
                return "";
            }
            else if (factorInt <= (int)Factor.deca)
            {
                return "da";
            }
            else if (factorInt <= (int)Factor.hecto)
            {
                return "h";
            }
            else if (factorInt <= (int)Factor.kilo)
            {
                return "k";
            }
            else if (factorInt <= (int)Factor.mega)
            {
                return "M";
            }
            else if (factorInt <= (int)Factor.giga)
            {
                return "G";
            }
            else if (factorInt <= (int)Factor.tera)
            {
                return "T";
            }
            else if (factorInt <= (int)Factor.peta)
            {
                return "P";
            }
            else if (factorInt <= (int)Factor.exa)
            {
                return "E";
            }
            else if (factorInt <= (int)Factor.zetta)
            {
                return "Z";
            }
            else if (factorInt <= (int)Factor.yotta)
            {
                return "Y";
            }

            return "";
        }
        #endregion

        public static implicit operator float(SIUnit unit)
        {
            return unit.Value;
        }

        public static implicit operator string(SIUnit unit)
        {
            return unit.FactorValue() + unit.PrefixSymbol() + unit.Symbol();
        }
    }
}
