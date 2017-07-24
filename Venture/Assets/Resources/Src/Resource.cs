using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Resources
{
    [Serializable]
    public class Resource
    {
        public static Resource Find(string name)
        {
            return Resources.First(x => x.Name == name);
        }

        public static Resource[] Resources = {
        #region Elements
        new Resource() {
            Name = Consts.Hydrogen,
            Value = 1.0f,
            MolarMass = 1.008f,
            Density = 107.7f }, //5000bar
        new Resource() { Name = Consts.Helium,
            Value = 2.0f,
            MolarMass = 4.003f,
            Density = 177.1f }, //2000bar
        new Resource() {
            Name = Consts.Oxygen,
            Value = 0.1f,
            MolarMass = 16.00f,
            Density = 573.6f }, // 500bar
        new Resource() {
            Name = Consts.Nitrogen,
            Value = 0.01f,
            MolarMass = 14.01f,
            Density = 420.2f }, // 500bar
        new Resource() {
            Name = Consts.Carbon,
            Value = 2.75f,
            MolarMass = 12.01f,
            Density = 2260 },
        new Resource() {
            Name = Consts.Silicon,
            Value = 0.0f,
            MolarMass = 32.06f,
            Density = 2330.0f },
        new Resource() {
            Name = Consts.Iron,
            Value = 0.0f,
            MolarMass = 55.85f,
            Density = 7874.0f },
        new Resource() {
            Name = Consts.Nickel,
            Value = 0.0f,
            MolarMass = 58.69f,
            Density = 8908.0f },
        new Resource() {
            Name = Consts.Cobalt,
            Value = 0.0f,
            MolarMass = 58.93f,
            Density = 8900.0f },
        new Resource() {
            Name = Consts.Ruthenium,
            Value = 0.0f,
            MolarMass = 101.07f,
            Density = 12370.0f },
        new Resource() {
            Name = Consts.Rhodium,
            Value = 0.0f,
            MolarMass = 102.90f,
            Density = 12450.0f },
        new Resource() {
            Name = Consts.Palladium,
            Value = 0.0f,
            MolarMass = 106.42f,
            Density = 12020.0f },
        new Resource() {
            Name = Consts.Tellurium,
            Value = 0.0f,
            MolarMass = 127.60f,
            Density = 0.0f },
        new Resource() {
            Name = Consts.Bismuth,
            Value = 0.0f,
            MolarMass = 208.98f,
            Density = 0.0f },
        new Resource() {
            Name = Consts.Osmium,
            Value = 0.0f,
            MolarMass = 190.23f,
            Density = 22590.0f },
        new Resource() {
            Name = Consts.Iridium,
            Value = 0.0f,
            MolarMass = 192.21f,
            Density = 22560.0f },
        new Resource() {
            Name = Consts.Platinum,
            Value = 0.0f,
            MolarMass = 195.08f,
            Density = 21450.0f },
        new Resource() {
            Name = Consts.Aluminum,
            Value = 0.0f,
            MolarMass = 26.98f,
            Density = 2700.0f },
        new Resource() {
            Name = Consts.Copper,
            Value = 0.0f,
            MolarMass = 63.546f,
            Density = 8960.0f },
        new Resource() {
            Name = Consts.Lead,
            Value = 0.0f,
            MolarMass = 207.2f,
            Density = 11340.0f },
        new Resource() {
            Name = Consts.Magnesium,
            Value = 0.0f,
            MolarMass = 24.305f,
            Density = 1738.0f },
        new Resource() {
            Name = Consts.Manganese,
            Value = 0.0f,
            MolarMass = 54.938f,
            Density = 1738.0f },
        new Resource() {
            Name = Consts.Tungsten,
            Value = 0.0f,
            MolarMass = 183.84f,
            Density = 19250.0f },
        new Resource() {
            Name = Consts.Thallium,
            Value = 0.0f,
            MolarMass = 204.38f,
            Density = 11850.0f },
        new Resource() {
            Name = Consts.Sulfur,
            Value = 0.0f,
            MolarMass = 32.06f,
            Density = 1960.0f },
        new Resource() {
            Name = Consts.Tin,
            Value = 0.0f,
            MolarMass = 118.71f,
            Density = 7310.0f },
        new Resource() {
            Name = Consts.Uranium,
            Value = 0.0f,
            MolarMass = 238,
            Density = 7310.0f },
        new Resource() {
            Name = Consts.Chromium,
            Value = 0.0f,
            MolarMass = 51.99f,
            Density = 7190.0f },
        new Resource() {
            Name = Consts.Beryllium,
            Value = 0.0f,
            MolarMass = 9.012f,
            Density = 0 },
        new Resource() {
            Name = Consts.Molybdenum,
            Value = 0.0f,
            Density = 1848.0f },
        new Resource() {
            Name = Consts.Gold,
            Value = 0.0f,
            MolarMass = 196.967f,
            Density = 19300.0f },
        new Resource() {
            Name = Consts.Calcium,
            Value = 0.0f,
            MolarMass = 40.078f,
            Density = 1550.0f },
        new Resource() {
            Name = Consts.Arsenic,
            Value = 0.0f,
            MolarMass = 74.92f,
            Density = 5727.0f },
        new Resource() {
            Name = Consts.Antimony,
            Value = 0.0f,
            MolarMass = 121.76f,
            Density = 6697.0f },
        new Resource() {
            Name = Consts.Chlorine,
            Value = 0.0f,
            MolarMass = 35.45f,
            Density = 1577.0f }, //200bar
        new Resource() {
            Name = Consts.Mercury,
            Value = 0.0f,
            MolarMass = 200.59f,
            Density = 13534.0f },
        new Resource() {
            Name = Consts.Gallium,
            Value = 0.0f,
            MolarMass = 69.72f,
            Density = 5904.0f },
        new Resource() {
            Name = Consts.Germanium,
            Value = 0.0f,
            MolarMass = 4.003f,
            Density = 72.63f },
        new Resource() {
            Name = Consts.Titanium,
            Value = 0.0f,
            MolarMass = 47.9f,
            Density = 4507.0f },
        new Resource() {
            Name = Consts.Zinc,
            Value = 0.0f,
            MolarMass = 65.39f,
            Density = 7140.0f },
        #endregion
        #region Acids
        new Resource() {
            Name = Consts.Nitric_Acid,
            Value = 1.9f,
            MolarMass = 63.0128f,
            Density = 1519.3f },
        new Resource() {
            Name = Consts.Sodium_Hydroxide,
            Value = 0.0f,
            MolarMass = 39.997f,
            Density = 2130.0f },
        #endregion
        #region Compounds
        new Resource() {
            Name = Consts.Water,
            Value = 6.93f,
            MolarMass = 18.015f,
            Density = 1000.0f },
        new Resource() {
            Name = Consts.Ammonia,
            Value = 3.01f,
            MolarMass = 17.03f,
            Density = 670.8f }, //1000bar
        new Resource() {
            Name = Consts.Ammonium_Nitrate,
            Value = 7.28f,
            MolarMass = 80.043f,
            Density = 1739.93f},
        new Resource() {
            Name = Consts.Alumina,
            Value = 0.0f,
            MolarMass = 101.961f,
            Density = 0.0f },
        new Resource() {
            Name = Consts.Silica,
            Value = 0.0f,
            MolarMass = 60.084f,
            Density = 2634.0f },
        new Resource() {
            Name = Consts.Titania,
            Value = 0.0f,
            MolarMass = 79.866f,
            Density = 4260.0f },
        new Resource() {
            Name = Consts.Calcia,
            Value = 0.0f,
            MolarMass = 56.077f,
            Density = 3300.0f },
        new Resource() {
            Name = Consts.Ferrochrome,
            Value = 0.0f,
            MolarMass = 107.84f,
            Density = 4007.0f },
        new Resource() {
            Name = Consts.Ferrotitanium,
            Value = 0.0f,
            MolarMass = 151.579f,
            Density = 2850f },
        new Resource() {
            Name = Consts.Magnesia,
            Value = 0.0f,
            MolarMass = 40.304f,
            Density = 3580.0f },
        new Resource() {
            Name = Consts.Manganese_Carbonate,
            Value = 0.0f,
            MolarMass = 114.947f,
            Density = 3120.0f },
        new Resource() {
            Name = Consts.Manganese_Nitrate,
            Value = 0.0f,
            MolarMass = 178.948f,
            Density = 1536.0f },
        new Resource() {
            Name = Consts.Sulfur_Dioxide,
            Value = 0.0f,
            MolarMass = 64.064f,
            Density = 1460.0f }, //500bar
        new Resource() {
            Name = Consts.Iron3_Oxide,
            Value = 0.0f,
            MolarMass = 55.85f,
            Density = 5260.0f },
        new Resource() {
            Name = Consts.Titanium_Tetrachloride,
            Value = 0.0f,
            MolarMass = 189.68f,
            Density = 1730.0f },
        new Resource() {
            Name = Consts.Magnisum_Chloride,
            Value = 0.0f,
            MolarMass = 35.453f,
            Density = 2320.0f },
        new Resource() {
            Name = Consts.Molybdate,
            Value = 0.0f,
            MolarMass = 159.9f,
            Density = 4240.0f },
        new Resource() {
            Name = Consts.Gallium_Arsenide,
            Value = 0.0f,
            MolarMass = 144.64f,
            Density = 4240.0f },
        new Resource() {
            Name = Consts.Silicon_Germanium,
            Value = 0.0f,
            MolarMass = 100.7f,
            Density = 4240.0f },
        #endregion
        #region Complex Materials
        new Resource() {
            Name = Consts.Tungsten_Carbide,
            Value = 0.0f,
            MolarMass = 195.85f,
            Density = 15600.0f },
        new Resource() {
            Name = Consts.Coloured_Glass,
            Value = 0.0f,
            Density = 0.0f },
        new Resource() {
            Name = Consts.Clear_Glass,
            Value = 0.0f,
            Density = 0.0f },
        new Resource() {
            Name = Consts.Steel,
            Value = 0.0f,
            Density = 7859.0f },
        new Resource() {
            Name = Consts.Monocrystalline_Silicon,
            Value = 0.0f,
            MolarMass = 0f,
            Density = 7859.0f },
        #endregion
        #region Goods
        new Resource() {
            Name = Consts.Soil,
            Value = 12.0f,
            Density = 1083.3f },
        new Resource() {
            Name = Consts.Seeds,
            Value = 50.0f,
            Density = 504.65f },
        new Resource() {
            Name = Consts.Food,
            Value = 176.39f,
            Density = 780.0f },
        new Resource() {
            Name = Consts.Stainless_Steel,
            Value = 0.0f,
            MolarMass = 0f,
            Density = 7863.0f },
        new Resource() {
            Name = Consts.Tantalum_Capacitor_Anode,
            Value = 0.0f,
            Density = 0.0f },
        new Resource() {
            Name = Consts.Tantalum_Capacitor_Cathode,
            Value = 0.0f,
            Density = 0.0f },
        new Resource() {
            Name = Consts.Tantalum_Capacitor,
            Value = 0.0f,
            Density = 0.0f },
        new Resource() {
            Name = Consts.Printed_Circuit_Board,
            Value = 0.0f,
            Density = 0.0f },
        new Resource() {
            Name = Consts.Transistor,
            Value = 0.0f,
            Density = 0.0f },
        new Resource() {
            Name = Consts.Semiconductor,
            Value = 0.0f,
            Density = 0.0f },
        new Resource() {
            Name = Consts.Integrated_Circuit,
            Value = 0.0f,
            Density = 0.0f },
        #endregion
        #region Ores
        new Resource() {
            Name = Consts.Barite,
            Value = 0,
            MolarMass = 233.39f,
            Density = 4500.0f },
        new Resource() {
            Name = Consts.Bauxite,
            Value = 0,
            MolarMass = 137.99f,
            Density = 1281.0f },
        new Resource() {
            Name = Consts.Beryl,
            Value = 0.0f,
            MolarMass = 0f,
            Density = 2765.0f },
        new Resource() {
            Name = Consts.Bornite,
            Value = 0.0f,
            MolarMass = 537.5f,
            Density = 5100.0f },
        new Resource() {
            Name = Consts.Cassiterite,
            Value = 0.0f,
            MolarMass = 150.71f,
            Density = 6900.0f },
        new Resource() {
            Name = Consts.Chalcopyrite,
            Value = 0.0f,
            MolarMass = 183.53f,
            Density = 4200.0f },
        new Resource() {
            Name = Consts.Chromite,
            Value = 0.0f,
            MolarMass = 223.84f,
            Density = 4795.0f },
        new Resource() {
            Name = Consts.Cinnabar,
            Value = 0.0f,
            MolarMass = 232.66f,
            Density = 8100.0f },
        new Resource() {
            Name = Consts.Cobaltite,
            Value = 0.0f,
            MolarMass = 165.92f,
            Density = 6330.0f },
        new Resource() {
            Name = Consts.Coltan,
            Value = 0.0f,
            MolarMass = 513.74f,
            Density = 6700.0f },
        new Resource() {
            Name = Consts.Dolomite,
            Value = 0.0f,
            MolarMass = 184.40f,
            Density = 2850.0f },
        new Resource() {
            Name = Consts.Galena,
            Value = 0.0f,
            MolarMass = 239.27f,
            Density = 7500.0f },
        new Resource() {
            Name = Consts.Hematite,
            Value = 0.0f,
            MolarMass = 159.69f,
            Density = 5150.0f },
        new Resource() {
            Name = Consts.Ilmenite,
            Value = 0.0f,
            MolarMass = 151.73f,
            Density = 2307.0f },
        new Resource() {
            Name = Consts.Magnetite,
            Value = 0.0f,
            MolarMass = 231.54f,
            Density = 5175.0f },
        new Resource() {
            Name = Consts.Malachite,
            Value = 0.0f,
            MolarMass = 221.12f,
            Density = 4000.0f },
        new Resource() {
            Name = Consts.Molybdenite,
            Value = 0.0f,
            MolarMass = 160.07f,
            Density = 1600.0f },
        new Resource() {
            Name = Consts.Pentlandite,
            Value = 0.0f,
            MolarMass = 771.94f,
            Density = 4800.0f },
        new Resource() {
            Name = Consts.Periclase,
            Value = 0.0f,
            MolarMass = 40.30f,
            Density = 3785.0f },
        new Resource() {
            Name = Consts.Pyrolusite,
            Value = 0.0f,
            MolarMass = 86.94f,
            Density = 4730.0f },
        new Resource() {
            Name = Consts.Rhodochrosite,
            Value = 0.0f,
            MolarMass = 114.95f,
            Density = 3690.0f },
        new Resource() {
            Name = Consts.Sperrylite,
            Value = 0.0f,
            MolarMass = 344.92f,
            Density = 10580.0f },
        new Resource() {
            Name = Consts.Sphalerite,
            Value = 0.0f,
            MolarMass = 96.98f,
            Density = 4050.0f },
        new Resource() {
            Name = Consts.Cooperite,
            Value = 0.0f,
            MolarMass = 186.91f,
            Density = 9500.0f },
        new Resource() {
            Name = Consts.Laurite,
            Value = 0.0f,
            MolarMass = 165.20f,
            Density = 6990.0f },
        new Resource() {
            Name = Consts.Merenskyite,
            Value = 0.0f,
            MolarMass = 386.76f,
            Density = 9140.0f },
        new Resource() {
            Name = Consts.Sudburyite,
            Value = 0.0f,
            MolarMass = 0f,
            Density = 9000.0f },
        new Resource() {
            Name = Consts.Omeiite,
            Value = 0.0f,
            MolarMass = 216.24f,
            Density = 11200.0f },
        new Resource() {
            Name = Consts.Niggliite,
            Value = 0.0f,
            MolarMass = 313.79f,
            Density = 13440.0f },
        new Resource() {
            Name = Consts.Thorianite,
            Value = 0.0f,
            MolarMass = 264.04f,
            Density = 10000.0f },
        new Resource() {
            Name = Consts.Uraninite,
            Value = 0.0f,
            MolarMass = 270.03f,
            Density = 8725.0f },
        new Resource() {
            Name = Consts.Wolframite,
            Value = 0.0f,
            MolarMass = 303.24f,
            Density = 7300.0f }
        #endregion
        };

        public Resource()
        {
            this.Name = "";
            this.volume = 0;
            this.Density = 0;
            this.value = 0;
            this.MolarMass = 0.0f;
        }
        public Resource(string Name, float Volume, float Mass, float Density, float Value, float MolarMass)
        {
            this.Name = Name;
            this.volume = Volume;
            this.Density = Density;
            this.value = Value;
            this.MolarMass = MolarMass;
        }
        public Resource(Resource resource)
        {
            this.Name = resource.Name;
            this.volume = resource.Volume;
            this.Density = resource.Density;
            this.value = resource.Value;
            this.MolarMass = resource.MolarMass;
        }

        public Resource Mols(int mols)
        {
            Mass = MolarMass * 0.001f * mols;
            return this;
        }

        public Resource PercentMass(float Mass, float percent)
        {
            this.Mass = Mass * percent;
            return this;
        }

        public string Name;

        /// <summary>
        /// How much of a thing we have
        /// </summary>
        public float Volume
        {
            get { return volume; }
            set { this.volume = value; }
        }

        /// <summary>
        /// How much this stack weighs
        /// </summary>
        public float Mass
        {
            get { return Volume * Density; }
            set { Volume = value / Density; }
        }
        /// <summary>
        /// How dense this item is
        /// </summary>
        public float Density
        {
            get { return density; }
            set { density = value; }
        }
        /// <summary>
        /// How much each m3 of this item is worth
        /// </summary>
        public float Value
        {
            get { return value; }
            set { this.value = value; }
        }
        /// <summary>
        /// How much one Mol of this item weighs, used for chemistry equations
        /// </summary>
        public float MolarMass
        {
            get { return molarMass; }
            set { this.molarMass = value; }
        }
        /// <summary>
        /// How much this stack is worth
        /// </summary>
        public float GrossValue
        {
            get { return value * Volume; }
        }

        [SerializeField]
        private float volume;
        [SerializeField]
        private float density;
        [SerializeField]
        private float value;
        [SerializeField]
        private float molarMass;
    }
}