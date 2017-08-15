using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.General.Src.SI
{
    #region Factors
    /// <summary>
    /// https://en.wikipedia.org/wiki/Orders_of_magnitude_(energy)
    /// </summary>
    public enum Factor
    {
        /// <summary>
        /// The scale of a subatomic particle's mass.
        /// <para>https://en.wikipedia.org/wiki/Yocto-</para>
        /// </summary>
        yocto = -24,
        /// <summary>
        /// The scale of electric charge in a single electron.
        /// <para>As well zeptomoles measure hundreds of particles.</para>
        /// <para>https://en.wikipedia.org/wiki/Zepto-</para>
        /// </summary>
        zepto = -21,
        /// <summary>
        /// The weight of HIV-1 virus is measured as 1000ag.
        /// <para>https://en.wikipedia.org/wiki/Atto-</para>
        /// </summary>
        atto = -18,
        /// <summary>
        /// The weight of HIV-1 virus is measures as 1fg.
        /// <para>A proton has a diameter of about 1.6-1.7 femtometres.</para>
        /// <para>https://en.wikipedia.org/wiki/Femto-</para>
        /// </summary>
        femto = -15,
        /// <summary>
        /// The radius of atoms range from 25 picometres (hydrogen) to 260 picometers (caesium).
        /// <para>One picolight-year is about nine kilometres.</para>
        /// <para>https://en.wikipedia.org/wiki/Pico-</para>
        /// </summary>
        pico = -12,
        /// <summary>
        /// The scale of atoms, and computer circuitry.
        /// <para>https://en.wikipedia.org/wiki/Nano-</para>
        /// </summary>
        nano = -9,
        /// <summary>
        /// The scale of bacteria and cells.
        /// <para>https://en.wikipedia.org/wiki/Micro-</para>
        /// </summary>
        micro = -6,
        /// <summary>
        /// The scale of crystaline structures.
        /// <para>https://en.wikipedia.org/wiki/Milli-</para>
        /// </summary>
        milli = -3,
        /// <summary>
        /// https://en.wikipedia.org/wiki/Centi-
        /// </summary>
        centi = -2,
        /// <summary>
        /// https://en.wikipedia.org/wiki/Deci-
        /// </summary>
        deci = -1,
        /// <summary>
        /// 
        /// </summary>
        none = 0,
        /// <summary>
        /// https://en.wikipedia.org/wiki/Deca-
        /// </summary>
        deca = 1,
        /// <summary>
        /// https://en.wikipedia.org/wiki/Hecto-
        /// </summary>
        hecto = 2,
        /// <summary>
        /// https://en.wikipedia.org/wiki/Kilo-
        /// </summary>
        kilo = 3,
        /// <summary>
        /// https://en.wikipedia.org/wiki/Mega-
        /// </summary>
        mega = 6,
        /// <summary>
        /// Clock rate of a cpu 3GHz.
        /// <para>Bandwidth of a network link 1Gbit/s.</para>
        /// <para>https://en.wikipedia.org/wiki/Giga-</para>
        /// </summary>
        giga = 9,
        /// <summary>
        /// https://en.wikipedia.org/wiki/Tera-
        /// </summary>
        tera = 12,
        /// <summary>
        /// https://en.wikipedia.org/wiki/Peta-
        /// </summary>
        peta = 15,
        /// <summary>
        /// https://en.wikipedia.org/wiki/Exa-
        /// </summary>
        exa = 18,
        /// <summary>
        /// https://en.wikipedia.org/wiki/Zetta-
        /// </summary>
        zetta = 21,
        /// <summary>
        /// https://en.wikipedia.org/wiki/Yotta-
        /// </summary>
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
