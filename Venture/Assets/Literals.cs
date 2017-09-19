using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    public class Literals
    {
        public class States
        {
            public static string Generic = "genericState";
        }

        public class Tasks
        {
            public static string UpdateModule = "updateModule";
        }

        public class SI
        {
            public class Name
            {
                public static string Atmosphere = "atmosphere";
                public static string Bar = "bar";
                public static string Celsius = "celsius";
                public static string Credit = "credit";
                public static string Gram = "gram";
                public static string GramPerMole = "molar mass";
                public static string Hour = "hour";
                public static string Joule = "joule";
                public static string JoulePerMole = Joule + " per " + Mole;
                public static string JoulePerMoleKelvin = Joule + " per " + Mole + " " + Kelvin;
                public static string Kelvin = "kelvin";
                public static string Kilogram = "kilogram";
                public static string KilogramMetre2 = Kilogram + " " + Metre2;
                public static string KilogramPerMetre2 = Kilogram + " per " + Metre2;
                public static string KilogramPerMetre3 = Kilogram + " per " + Metre3;
                public static string Metre = "metre";
                public static string Metre2 = "metre squared";
                public static string Metre3 = "metre cubed";
                public static string Mole = "mole";
                public static string MoleKelvin = Mole + " " + Kelvin;
                public static string Pascal = "pascal";
                public static string Second = "second";
                public static string Watt = "watt";
                public static string WattHour = Watt + Hour;
                public static string WattSecond = Watt + Second;
            }

            public class Symbol
            {
                public static string Atmosphere = "atm";
                public static string Bar = "bar";
                public static string Celsius = "°C";
                public static string Credit = "$";
                public static string Gram = "g";
                public static string GramPerMole = "M";
                public static string Hour = "h";
                public static string Joule = "J";
                public static string JoulePerMole = Joule + "/" + Mole;
                public static string JoulePerMoleKelvin = Joule + " / " + Mole + Kelvin;
                public static string Kelvin = "K";
                public static string Kilogram = "Kg";
                public static string KilogramMetre2 = Kilogram + Metre2;
                public static string KilogramPerMetre2 = Kilogram + "/" + Metre2;
                public static string KilogramPerMetre3 = Kilogram + "/" + Metre3;
                public static string Metre = "m";
                public static string Metre2 = "m²";
                public static string Metre3 = "m³";
                public static string Mole = "mol";
                public static string MoleKelvin = Mole + Kelvin;
                public static string Pascal = "Pa";
                public static string Second = "s";
                public static string Watt = "W";
                public static string WattHour = Watt + Hour;
                public static string WattSecond = Watt + Second;

                public static string Yocto = "y";
                public static string Zepto = "z";
                public static string Atto = "a";
                public static string Femto = "f";
                public static string Pico = "p";
                public static string Nano = "n";
                public static string Micro = "μ";
                public static string Milli = "m";
                public static string Centi = "c";
                public static string Deci = "d";
                public static string Deca = "da";
                public static string Hecto = "h";
                public static string Kilo = "k";
                public static string Mega = "M";
                public static string Giga = "G";
                public static string Tera = "T";
                public static string Peta = "P";
                public static string Exa = "E";
                public static string Zetta = "Z";
                public static string Yotta = "Y";
            }
        }
    }
}
