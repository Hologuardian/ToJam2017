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
                public static string Gram = "gram";
                public static string Hour = "hour";
                public static string Joule = "joule";
                public static string Kelvin = "kelvin";
                public static string Kilogram = "kilogram";
                public static string KilogramMetre2 = Kilogram + " per " + Metre2;
                public static string KilogramMetre3 = Kilogram + " per " + Metre3;
                public static string Metre = "metre";
                public static string Metre2 = "squared metre";
                public static string Metre3 = "cubed metre";
                public static string Mole = "mole";
                public static string KilogramMole = "molar mass";
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
                public static string Gram = "g";
                public static string Hour = "h";
                public static string Joule = "J";
                public static string Kelvin = "K";
                public static string Kilogram = "Kg";
                public static string KilogramMetre2 = Kilogram + "/" + Metre2;
                public static string KilogramMetre3 = Kilogram + "/" + Metre3;
                public static string Metre = "m";
                public static string Metre2 = "m²";
                public static string Metre3 = "m³";
                public static string KilogramMole = "M";
                public static string Mole = "mol";
                public static string Pascal = "Pa";
                public static string Second = "s";
                public static string Watt = "W";
                public static string WattHour = Watt + Hour;
                public static string WattSecond = Watt + Second;
            }
        }
    }
}
