using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum Size {
    /// <summary>
    /// Tiny is the first sizing of game elements with an expected long axis on simple stations at 108m, and is comparable to the ISS in size.
    /// Accommodation of ~8
    /// Dimensions of 4x4x4m
    /// </summary>
    Tiny = 1,
    /// <summary>
    /// Small is the second sizing of game elements  with an expected long axis on simple stations at 400m.
    /// Accommodation of ~64
    /// Dimensions of 16x16x16m
    /// </summary>
    Small = 2,
    /// <summary>
    /// Medium is the third sizing of game elements with an expected long axis on simple stations at 1.6km.
    /// Accommodation of ~512
    /// Dimensions of 64x64x64m
    /// </summary>
    Medium = 3,
    /// <summary>
    /// Large is the fourth sizing of game elements with an expected long axis on simple stations at 6.4km.
    /// Accommodation of ~4096
    /// Dimensions of 256x256x256m
    /// </summary>
    Large = 4,
    /// <summary>
    /// Huge is the final sizing of game elements with an expected long axis on simple stations at 25.6km.
    /// Accommodation of ~32768
    /// Dimensions of 1024x1024x1024m
    /// </summary>
    Huge = 5};
    
public static class Consts
{
    public const string Hydrogen = "Hydrogen";
    public const string Helium = "Helium";
    public const string Oxygen = "Oxygen";
    public const string Nitrogen = "Nitrogen";
    public const string Carbon = "Carbon";
    public const string Silicon = "Silicon";
    public const string Iron = "Iron";
    public const string Nickel = "Nickel";
    public const string Cobalt = "Cobalt";
    public const string Ruthenium = "Ruthenium";
    public const string Rhodium = "Rhodium";
    public const string Palladium = "Palladium";
    public const string Tellurium = "Tellurium";
    public const string Bismuth = "Bismuth";
    public const string Osmium = "Osmium";
    public const string Iridium = "Iridium";
    public const string Platinum = "Platinum";
    public const string Aluminum = "Aluminum";
    public const string Copper = "Copper";
    public const string Lead = "Lead";
    public const string Magnesium = "Magnesium";
    public const string Manganese = "Manganese";
    public const string Tungsten = "Tungsten";
    public const string Thallium = "Thallium";
    public const string Sulfur = "Sulfur";
    public const string Tin = "Tin";
    public const string Uranium = "Uranium";
    public const string Chromium = "Chromium";
    public const string Beryllium = "Beryllium";
    public const string Molybdenum = "Molybdenum";
    public const string Gold = "Gold";
    public const string Calcium = "Calcium";
    public const string Arsenic = "Arsenic";
    public const string Antimony = "Antimony";
    public const string Chlorine = "Chlorine";
    public const string Mercury = "Mercury";
    public const string Gallium = "Gallium";
    public const string Germanium = "Germanium";
    public const string Titanium = "Titanium";
    public const string Zinc = "Zinc";

    public const string Nitric_Acid = "Nitric Acid";
    public const string Sodium_Hydroxide = "Sodium Hydroxide";

    public const string Water = "Water";
    public const string Ammonia = "Ammonia";
    public const string Ammonium_Nitrate = "Ammonium Nitrate";
    public const string Alumina = "Alumina";
    public const string Silica = "Silica";
    public const string Titania = "Titania";
    public const string Calcia = "Calcia";
    public const string Ferrochrome = "Ferrochrome";
    public const string Ferrotitanium = "Ferrotitanium";
    public const string Magnesia = "Magnesia";
    public const string Manganese_Carbonate = "Manganese Carbonate";
    public const string Manganese_Nitrate = "Manganese Nitrate";
    public const string Sulfur_Dioxide = "Sulfur Dioxide";
    public const string Iron3_Oxide = "Iron(III) Oxide";
    public const string Titanium_Tetrachloride = "Titanium Tetrachloride";
    public const string Magnisum_Chloride = "Magnisum Chloride";
    public const string Molybdate = "Molybdate";
    public const string Gallium_Arsenide = "Gallium Arsenide";
    public const string Silicon_Germanium = "Silicon-Germanium";

    public const string Tungsten_Carbide = "Tungsten Carbide";
    public const string Coloured_Glass = "Coloured Glass";
    public const string Clear_Glass = "Clear Glass";
    public const string Steel = "Steel";
    public const string Monocrystalline_Silicon = "Monocrystalline Silicon";

    public const string Soil = "Soil";
    public const string Seeds = "Seeds";
    public const string Food = "Food";
    public const string Stainless_Steel = "Stainless Steel";
    public const string Tantalum_Capacitor_Anode = "Tantalum Capacitor Anode";
    public const string Tantalum_Capacitor_Cathode = "Tantalum Capacitor Cathode";
    public const string Tantalum_Capacitor = "Tantalum Capacitor";
    public const string Printed_Circuit_Board = "Printed Circuit Board";
    public const string Transistor = "Transistor";
    public const string Semiconductor = "Semiconductor";
    public const string Integrated_Circuit = "Integrated Circuit";

    public const string Barite = "Barite";
    public const string Bauxite = "Bauxite";
    public const string Beryl = "Beryl";
    public const string Bornite = "Bornite";
    public const string Cassiterite = "Cassiterite";
    public const string Chalcopyrite = "Chalcopyrite";
    public const string Chromite = "Chromite";
    public const string Cinnabar = "Cinnabar";
    public const string Cobaltite = "Cobaltite";
    public const string Coltan = "Coltan";
    public const string Dolomite = "Dolomite";
    public const string Galena = "Galena";
    public const string Hematite = "Hematite";
    public const string Ilmenite = "Ilmenite";
    public const string Magnetite = "Magnetite";
    public const string Malachite = "Malachite";
    public const string Molybdenite = "Molybdenite";
    public const string Pentlandite = "Pentlandite";
    public const string Periclase = "Periclase";
    public const string Pyrolusite = "Pyrolusite";
    public const string Rhodochrosite = "Rhodochrosite";
    public const string Sperrylite = "Sperrylite";
    public const string Sphalerite = "Sphalerite";
    public const string Cooperite = "Cooperite";
    public const string Laurite = "Laurite";
    public const string Merenskyite = "Merenskyite";
    public const string Sudburyite = "Sudburyite";
    public const string Omeiite = "Omeiite";
    public const string Niggliite = "Niggliite";
    public const string Thorianite = "Thorianite";
    public const string Uraninite = "Uraninite";
    public const string Wolframite = "Wolframite";

    //Agent
    public static class Agent
    {
        public const string
            Name = "Name",
            Specialisation = "Specialisation",
            CostPerMonth = "CostPerMonth",
            Employees = "Employees",
            EmployeesEfficiencyMax = "EmployeesEfficiencyMax",
            EmployeesEfficiencyMin = "EmployeesEfficiencyMin",
            EmployeesEfficiencyMean = "EmployeesEfficiencyMean",
            EmployeesEfficiencyMedian = "EmployeesEfficiencyMedian",
            EmployeesEfficiencyMode = "EmployeesEfficiencyMode";
    }
    //Employee
    public static class Employee
    {
        public const string
            Name = "Name",
            LastName = "Last Name",
            ParentAgent = "ParentAgent",
            Specialisation = "Specialisation",
            Age = "Age",
            Gender = "Gender",
            Height = "Height",
            Efficiency = "Efficiency",
            HungerMax = "HungerMax",
            Hunger = "Hunger",
            Happynes = "Happynes",
            HappynesGoal = "HappynesGoal";
    }

    ///////////////////////////////////////////////////////////////////////////////
    //      GLOBALS
    public static class Globals
    {
        public const string UIInterface = "UIInterface";
    }

    ///////////////////////////////////////////////////////////////////////////////
    //      STATION
    public static class Station
    {
        public const float StationModuleDeselectCooldown = 0.1f;
        public const string Hardpoints = "Hardpoints";
    }

    ///////////////////////////////////////////////////////////////////////////////
    //      GENERAL
    public static class General
    {
        public const string Rigidbody = "Rigidbody";
    }
}
