using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class Inventory
{
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

    public Recipe[] RecipeList = {
        #region Ore Reprocessing
        #region Bauxite Reprocess
        new Recipe() {
            ingredients = new List<Resource>()
            {
            new Resource(GetResource(Consts.Bauxite)) { Volume = 100.0f },
            new Resource(GetResource(Consts.Sodium_Hydroxide)) { Volume = 200.0f }
            },
            products = new List<Resource>()
            {
            new Resource(GetResource(Consts.Aluminum)).PercentMass(new Resource(GetResource(Consts.Bauxite)) { Volume = 100.0f }.Mass, 55.0f),
            new Resource(GetResource(Consts.Iron3_Oxide)).PercentMass(new Resource(GetResource(Consts.Bauxite)) { Volume = 100.0f }.Mass, 15.0f),
            new Resource(GetResource(Consts.Alumina)).PercentMass(new Resource(GetResource(Consts.Bauxite)) { Volume = 100.0f }.Mass, 10.0f),
            new Resource(GetResource(Consts.Titania)).PercentMass(new Resource(GetResource(Consts.Bauxite)) { Volume = 100.0f }.Mass, 3.0f),
            new Resource(GetResource(Consts.Calcia)).PercentMass(new Resource(GetResource(Consts.Bauxite)) { Volume = 100.0f }.Mass, 4.9f),
            new Resource(GetResource(Consts.Silica)).PercentMass(new Resource(GetResource(Consts.Bauxite)) { Volume = 100.0f }.Mass, 12.0f),
            new Resource(GetResource(Consts.Gallium)).PercentMass(new Resource(GetResource(Consts.Bauxite)) { Volume = 100.0f }.Mass, 0.1f),
            new Resource(GetResource(Consts.Sodium_Hydroxide)) { Volume = 200.0f }
            },
            time = 85,
            type = Recipe.RecipeType.Reprocess,
            Name = "Bauxite Reprocess"
        },
        #endregion
        #region Bornite Reprocess
        new Recipe() {
            ingredients = new List<Resource>()
            {
            new Resource(GetResource(Consts.Bornite)) { Volume = 100.0f }
            },
            products = new List<Resource>()
            {
            new Resource(GetResource(Consts.Iron)).PercentMass(new Resource(GetResource(Consts.Bornite)) { Volume = 100.0f }.Mass, 11.13f),
            new Resource(GetResource(Consts.Copper)).PercentMass(new Resource(GetResource(Consts.Bornite)) { Volume = 100.0f }.Mass, 63.31f),
            new Resource(GetResource(Consts.Sulfur)).PercentMass(new Resource(GetResource(Consts.Bornite)) { Volume = 100.0f }.Mass, 25.56f)
            },
            time = 85,
            type = Recipe.RecipeType.Reprocess,
            Name = "Bornite Reprocess"
        },
        #endregion
        #region Cassiterite Reprocess
        new Recipe() {
            ingredients = new List<Resource>()
            {
            new Resource(GetResource(Consts.Cassiterite)) { Volume = 100.0f }
            },
            products = new List<Resource>()
            {
            new Resource(GetResource(Consts.Tin)).PercentMass(new Resource(GetResource(Consts.Cassiterite)) { Volume = 100.0f }.Mass, 78.77f),
            new Resource(GetResource(Consts.Oxygen)).PercentMass(new Resource(GetResource(Consts.Cassiterite)) { Volume = 100.0f }.Mass, 21.23f)
            },
            time = 85,
            type = Recipe.RecipeType.Reprocess,
            Name = "Cassiterite Reprocess"
        },
        #endregion
        #region Chalcopyrite Reprocess
        new Recipe() {
            ingredients = new List<Resource>()
            {
            new Resource(GetResource(Consts.Chalcopyrite)) { Volume = 100.0f }
            },
            products = new List<Resource>()
            {
            new Resource(GetResource(Consts.Copper)).PercentMass(new Resource(GetResource(Consts.Chalcopyrite)) { Volume = 100.0f }.Mass, 66.66f),
            new Resource(GetResource(Consts.Sulfur)).PercentMass(new Resource(GetResource(Consts.Chalcopyrite)) { Volume = 100.0f }.Mass, 33.33f)
            },
            time = 85,
            type = Recipe.RecipeType.Reprocess,
            Name = "Chalcopyrite Reprocess"
        },
        #endregion
        #region Cinnabar Reprocess
        new Recipe() {
            ingredients = new List<Resource>()
            {
            new Resource(GetResource(Consts.Cinnabar)) { Volume = 100.0f }
            },
            products = new List<Resource>()
            {
            new Resource(GetResource(Consts.Mercury)).PercentMass(new Resource(GetResource(Consts.Cinnabar)) { Volume = 100.0f }.Mass, 86.22f),
            new Resource(GetResource(Consts.Sulfur)).PercentMass(new Resource(GetResource(Consts.Cinnabar)) { Volume = 100.0f }.Mass, 17.78f)
            },
            time = 85,
            type = Recipe.RecipeType.Reprocess,
            Name = "Cinnabar Reprocess"
        },
        #endregion
        #region Cobaltite Reprocess
        new Recipe() {
            ingredients = new List<Resource>()
            {
            new Resource(GetResource(Consts.Cobaltite)) { Volume = 100.0f }
            },
            products = new List<Resource>()
            {
            new Resource(GetResource(Consts.Cobalt)).PercentMass(new Resource(GetResource(Consts.Cobaltite)) { Volume = 100.0f }.Mass, 35.52f),
            new Resource(GetResource(Consts.Arsenic)).PercentMass(new Resource(GetResource(Consts.Cobaltite)) { Volume = 100.0f }.Mass, 45.16f),
            new Resource(GetResource(Consts.Sulfur)).PercentMass(new Resource(GetResource(Consts.Cobaltite)) { Volume = 100.0f }.Mass, 19.33f)
            },
            time = 85,
            type = Recipe.RecipeType.Reprocess,
            Name = "Cobaltite Reprocess"
        },
        #endregion
        #region Rhodochrosite Reprocess
        new Recipe() {
            ingredients = new List<Resource>()
            {
            new Resource(GetResource(Consts.Rhodochrosite)) { Volume = 100.0f }
            },
            products = new List<Resource>()
            {
            new Resource(GetResource(Consts.Manganese_Carbonate)).PercentMass(new Resource(GetResource(Consts.Rhodochrosite)) { Volume = 100.0f }.Mass, 58.24f),
            new Resource(GetResource(Consts.Oxygen)).PercentMass(new Resource(GetResource(Consts.Rhodochrosite)) { Volume = 100.0f }.Mass, 41.76f)
            },
            time = 85,
            type = Recipe.RecipeType.Reprocess,
            Name = "Rhodochrosite Reprocess"
        },
        #endregion
        #region Galena Reprocess
        new Recipe() {
            ingredients = new List<Resource>()
            {
            new Resource(GetResource(Consts.Galena)).Mols(1000000),
            new Resource(GetResource(Consts.Oxygen)).Mols(1000000)
            },
            products = new List<Resource>()
            {
            new Resource(GetResource(Consts.Lead)).Mols(1000000),
            new Resource(GetResource(Consts.Oxygen)).Mols(1000000),
            new Resource(GetResource(Consts.Sulfur_Dioxide)).Mols(1000000)
            },
            time = 85,
            type = Recipe.RecipeType.Reprocess,
            Name = "Galena Reprocess"
        },
        #endregion
        #region Magnetite Reprocess
        new Recipe() {
            ingredients = new List<Resource>()
            {
            new Resource(GetResource(Consts.Magnetite)) { Volume = 100.0f }
            },
            products = new List<Resource>()
            {
            new Resource(GetResource(Consts.Iron)).PercentMass(new Resource(GetResource(Consts.Magnetite)) { Volume = 100.0f }.Mass, 72.36f),
            new Resource(GetResource(Consts.Oxygen)).PercentMass(new Resource(GetResource(Consts.Magnetite)) { Volume = 100.0f }.Mass, 27.64f)
            },
            time = 85,
            type = Recipe.RecipeType.Reprocess,
            Name = "Magnetite Reprocess"
        },
        #endregion
        #region Malachite Reprocess
        new Recipe() {
            ingredients = new List<Resource>()
            {
            new Resource(GetResource(Consts.Malachite)) { Volume = 100.0f }
            },
            products = new List<Resource>()
            {
            new Resource(GetResource(Consts.Copper)).PercentMass(new Resource(GetResource(Consts.Malachite)) { Volume = 100.0f }.Mass, 57.48f),
            new Resource(GetResource(Consts.Hydrogen)).PercentMass(new Resource(GetResource(Consts.Malachite)) { Volume = 100.0f }.Mass, 0.91f),
            new Resource(GetResource(Consts.Carbon)).PercentMass(new Resource(GetResource(Consts.Malachite)) { Volume = 100.0f }.Mass, 5.43f),
            new Resource(GetResource(Consts.Oxygen)).PercentMass(new Resource(GetResource(Consts.Malachite)) { Volume = 100.0f }.Mass, 36.18f)
            },
            time = 85,
            type = Recipe.RecipeType.Reprocess,
            Name = "Malachite Reprocess"
        },
        #endregion
        #region Pyrolusite Reprocess
        new Recipe() {
            ingredients = new List<Resource>()
            {
            new Resource(GetResource(Consts.Pyrolusite)) { Volume = 100.0f }
            },
            products = new List<Resource>()
            {
            new Resource(GetResource(Consts.Copper)).PercentMass(new Resource(GetResource(Consts.Pyrolusite)) { Volume = 100.0f }.Mass, 63.19f),
            new Resource(GetResource(Consts.Hydrogen)).PercentMass(new Resource(GetResource(Consts.Pyrolusite)) { Volume = 100.0f }.Mass, 36.81f)
            },
            time = 85,
            powerCost = 500.0f,
            type = Recipe.RecipeType.Reprocess,
            Name = "Pyrolusite Reprocess"
        },
        #endregion
        #region Sperrylite Reprocess
        new Recipe() {
            ingredients = new List<Resource>()
            {
            new Resource(GetResource(Consts.Sperrylite)) { Volume = 1.0f }
            },
            products = new List<Resource>()
            {
            new Resource(GetResource(Consts.Arsenic)).PercentMass(new Resource(GetResource(Consts.Sperrylite)) { Volume = 1.0f }.Mass, 44.44f),
            new Resource(GetResource(Consts.Platinum)).PercentMass(new Resource(GetResource(Consts.Sperrylite)) { Volume = 1.0f }.Mass, 56.56f)
            },
            time = 85,
            type = Recipe.RecipeType.Reprocess,
            Name = "Sperrylite Reprocess"
        },
        #endregion
        #region Cooperite Reprocess
        new Recipe() {
            ingredients = new List<Resource>()
            {
            new Resource(GetResource(Consts.Cooperite)) { Volume = 1.0f }
            },
            products = new List<Resource>()
            {
            new Resource(GetResource(Consts.Nickel)).PercentMass(new Resource(GetResource(Consts.Cooperite)) { Volume = 1.0f }.Mass, 3.14f),
            new Resource(GetResource(Consts.Palladium)).PercentMass(new Resource(GetResource(Consts.Cooperite)) { Volume = 1.0f }.Mass, 17.08f),
            new Resource(GetResource(Consts.Platinum)).PercentMass(new Resource(GetResource(Consts.Cooperite)) { Volume = 1.0f }.Mass, 62.62f),
            new Resource(GetResource(Consts.Sulfur)).PercentMass(new Resource(GetResource(Consts.Cooperite)) { Volume = 1.0f }.Mass, 17.16f)
            },
            time = 85,
            type = Recipe.RecipeType.Reprocess,
            Name = "Cooperite Reprocess"
        },
        #endregion
        #region Laurite Reprocess
        new Recipe() {
            ingredients = new List<Resource>()
            {
            new Resource(GetResource(Consts.Laurite)) { Volume = 1.0f }
            },
            products = new List<Resource>()
            {
            new Resource(GetResource(Consts.Ruthenium)).PercentMass(new Resource(GetResource(Consts.Laurite)) { Volume = 1.0f }.Mass, 61.18f),
            new Resource(GetResource(Consts.Sulfur)).PercentMass(new Resource(GetResource(Consts.Laurite)) { Volume = 1.0f }.Mass, 38.82f)
            },
            time = 85,
            type = Recipe.RecipeType.Reprocess,
            Name = "Laurite Reprocess"
        },
        #endregion
        #region Merenskyite Reprocess
        new Recipe() {
            ingredients = new List<Resource>()
            {
            new Resource(GetResource(Consts.Merenskyite)) { Volume = 1.0f }
            },
            products = new List<Resource>()
            {
            new Resource(GetResource(Consts.Bismuth)).PercentMass(new Resource(GetResource(Consts.Merenskyite)) { Volume = 1.0f }.Mass, 10.81f),
            new Resource(GetResource(Consts.Tellurium)).PercentMass(new Resource(GetResource(Consts.Merenskyite)) { Volume = 1.0f }.Mass, 59.38f),
            new Resource(GetResource(Consts.Palladium)).PercentMass(new Resource(GetResource(Consts.Merenskyite)) { Volume = 1.0f }.Mass, 24.76f),
            new Resource(GetResource(Consts.Platinum)).PercentMass(new Resource(GetResource(Consts.Merenskyite)) { Volume = 1.0f }.Mass, 5.04f)
            },
            time = 85,
            type = Recipe.RecipeType.Reprocess,
            Name = "Merenskyite Reprocess"
        },
        #endregion
        #region Sudburyite Reprocess
        new Recipe() {
            ingredients = new List<Resource>()
            {
            new Resource(GetResource(Consts.Sudburyite)) { Volume = 1.0f }
            },
            products = new List<Resource>()
            {
            new Resource(GetResource(Consts.Nickel)).PercentMass(new Resource(GetResource(Consts.Sudburyite)) { Volume = 1.0f }.Mass, 6.79f),
            new Resource(GetResource(Consts.Antimony)).PercentMass(new Resource(GetResource(Consts.Sudburyite)) { Volume = 1.0f }.Mass, 56.30f),
            new Resource(GetResource(Consts.Palladium)).PercentMass(new Resource(GetResource(Consts.Sudburyite)) { Volume = 1.0f }.Mass, 36.91f)
            },
            time = 85,
            type = Recipe.RecipeType.Reprocess,
            Name = "Sudburyite Reprocess"
        },
        #endregion
        #region Omeiite Reprocess
        new Recipe() {
            ingredients = new List<Resource>()
            {
            new Resource(GetResource(Consts.Omeiite)) { Volume = 1.0f }
            },
            products = new List<Resource>()
            {
            new Resource(GetResource(Consts.Arsenic)).PercentMass(new Resource(GetResource(Consts.Omeiite)) { Volume = 1.0f }.Mass, 47.16f),
            new Resource(GetResource(Consts.Osmium)).PercentMass(new Resource(GetResource(Consts.Omeiite)) { Volume = 1.0f }.Mass, 44.89f),
            new Resource(GetResource(Consts.Ruthenium)).PercentMass(new Resource(GetResource(Consts.Omeiite)) { Volume = 1.0f }.Mass, 7.95f)
            },
            time = 85,
            type = Recipe.RecipeType.Reprocess,
            Name = "Omeiite Reprocess"
        },
        #endregion
        #region Niggliite Reprocess
        new Recipe() {
            ingredients = new List<Resource>()
            {
            new Resource(GetResource(Consts.Niggliite)) { Volume = 1.0f }
            },
            products = new List<Resource>()
            {
            new Resource(GetResource(Consts.Tin)).PercentMass(new Resource(GetResource(Consts.Niggliite)) { Volume = 1.0f }.Mass, 37.83f),
            new Resource(GetResource(Consts.Platinum)).PercentMass(new Resource(GetResource(Consts.Niggliite)) { Volume = 1.0f }.Mass, 62.17f)
            },
            time = 85,
            type = Recipe.RecipeType.Reprocess,
            Name = "Niggliite Reprocess"
        },
        #endregion
        #region Sphalerite Reprocess
        new Recipe() {
            ingredients = new List<Resource>()
            {
            new Resource(GetResource(Consts.Sphalerite)) { Volume = 1.0f }
            },
            products = new List<Resource>()
            {
            new Resource(GetResource(Consts.Zinc)).PercentMass(new Resource(GetResource(Consts.Sphalerite)) { Volume = 1.0f }.Mass, 64.06f),
            new Resource(GetResource(Consts.Iron)).PercentMass(new Resource(GetResource(Consts.Sphalerite)) { Volume = 1.0f }.Mass, 2.88f),
            new Resource(GetResource(Consts.Sulfur)).PercentMass(new Resource(GetResource(Consts.Sphalerite)) { Volume = 1.0f }.Mass, 32.06f),
            new Resource(GetResource(Consts.Gallium)).PercentMass(new Resource(GetResource(Consts.Sphalerite)) { Volume = 1.0f }.Mass, 0.1f),
            new Resource(GetResource(Consts.Germanium)).PercentMass(new Resource(GetResource(Consts.Sphalerite)) { Volume = 1.0f }.Mass, 0.3f)
            },
            time = 85,
            type = Recipe.RecipeType.Reprocess,
            Name = "Sphalerite Reprocess"
        },
        #endregion
        #region Wolframite Reprocess
        new Recipe() {
            ingredients = new List<Resource>()
            {
            new Resource(GetResource(Consts.Wolframite)) { Volume = 100.0f }
            },
            products = new List<Resource>()
            {
            new Resource(GetResource(Consts.Manganese)).PercentMass(new Resource(GetResource(Consts.Wolframite)) { Volume = 100.0f }.Mass, 9.06f),
            new Resource(GetResource(Consts.Iron)).PercentMass(new Resource(GetResource(Consts.Wolframite)) { Volume = 100.0f }.Mass, 9.21f),
            new Resource(GetResource(Consts.Tungsten)).PercentMass(new Resource(GetResource(Consts.Wolframite)) { Volume = 100.0f }.Mass, 60.63f),
            new Resource(GetResource(Consts.Oxygen)).PercentMass(new Resource(GetResource(Consts.Wolframite)) { Volume = 100.0f }.Mass, 21.10f)
            },
            time = 85,
            type = Recipe.RecipeType.Reprocess,
            Name = "Wolframite Reprocess"
        },
        #endregion
        #endregion
        #region Reactions
        #region Hydrogen Fusion Reaction
        new Recipe() {
            ingredients = new List<Resource>()
            {
            new Resource(GetResource(Consts.Hydrogen)).Mols(600)
            },
            products = new List<Resource>()
            {
            new Resource(GetResource(Consts.Helium)).Mols(100),
            new Resource(GetResource(Consts.Hydrogen)).Mols(200)
            },
            time = 1,
            powerCost = -25000.0f,
            type = Recipe.RecipeType.Reaction,
            Name = "Hydrogen Fusion Reaction"
        },
        #endregion
        #region Hydrogen Oxygen Electolysis Reaction
        new Recipe() {
            ingredients = new List<Resource>()
            {
            new Resource(GetResource(Consts.Water)).Mols(1000000),
            new Resource(GetResource(Consts.Pentlandite)).Mols(1000000)
            },
            products = new List<Resource>()
            {
            new Resource(GetResource(Consts.Hydrogen)).Mols(2000000),
            new Resource(GetResource(Consts.Oxygen)).Mols(1000000),
            new Resource(GetResource(Consts.Pentlandite)).Mols(1000000)
            },
            time = 12,
            powerCost = 200.0f,
            type = Recipe.RecipeType.Reaction,
            Name = "Hydrogen Oxygen Electolysis Reaction"
        },
        #endregion
        #region Hydrogen Oxygen Combustion Reaction
        new Recipe() {
            ingredients = new List<Resource>()
            {
            new Resource(GetResource(Consts.Hydrogen)).Mols(2000000),
            new Resource(GetResource(Consts.Oxygen)).Mols(2000000)
            },
            products = new List<Resource>()
            {
            new Resource(GetResource(Consts.Water)).Mols(2000000),
            new Resource(GetResource(Consts.Oxygen)).Mols(1000000)
            },
            time = 12,
            powerCost = -200.0f,
            type = Recipe.RecipeType.Reaction,
            Name = "Hydrogen Oxygen Combustion Reaction"
        },
        #endregion
        #region Ammonia Reaction
        new Recipe() {
            ingredients = new List<Resource>()
            {
            new Resource(GetResource(Consts.Nitrogen)).Mols(1000000),
            new Resource(GetResource(Consts.Hydrogen)).Mols(3000000),
            new Resource(GetResource(Consts.Magnetite)).Mols(1000000)
            },
            products = new List<Resource>()
            {
            new Resource(GetResource(Consts.Ammonia)).Mols(1000000),
            new Resource(GetResource(Consts.Magnetite)).Mols(1000000)
            },
            time = 1,
            powerCost = 0.0f,
            type = Recipe.RecipeType.Reaction,
            Name = "Ammonia Reaction"
        },
        #endregion
        #region Nitric Acid Reaction
        new Recipe() {
            ingredients = new List<Resource>()
            {
            new Resource(GetResource(Consts.Nitrogen)).Mols(1000000),
            new Resource(GetResource(Consts.Hydrogen)).Mols(1000000),
            new Resource(GetResource(Consts.Oxygen)).Mols(3000000)
            },
            products = new List<Resource>()
            {
            new Resource(GetResource(Consts.Nitric_Acid)).Mols(1000000),
            },
            time = 3,
            powerCost = 0.0f,
            type = Recipe.RecipeType.Reaction,
            Name = "Nitric Acid Reaction"
        },
        #endregion
        #region Ammonium Nitrate Reaction
        new Recipe() {
            ingredients = new List<Resource>()
            {
            new Resource(GetResource(Consts.Ammonia)).Mols(1000000),
            new Resource(GetResource(Consts.Nitric_Acid)).Mols(1000000),
            },
            products = new List<Resource>()
            {
            new Resource(GetResource(Consts.Ammonium_Nitrate)).Mols(1000000)
            },
            time = 1,
            powerCost = 0.0f,
            type = Recipe.RecipeType.Reaction,
            Name = "Ammonium Nitrate Reaction"
        },
        #endregion
        #endregion
        #region Manufacturing
        #region Tungsten Carbide Synthesis
        new Recipe() {
            ingredients = new List<Resource>()
            {
            new Resource(GetResource(Consts.Tungsten)).Mols(1000000),
            new Resource(GetResource(Consts.Carbon)).Mols(1000000),
            },
            products = new List<Resource>()
            {
            new Resource(GetResource(Consts.Tungsten_Carbide)).Mols(1000000)
            },
            time = 1,
            powerCost = 250.0f,
            type = Recipe.RecipeType.Factory,
            Name = "Tungsten Carbide Synthesis"
        },
        #endregion
        #region Titanium Tetrachloride Synthesis
        new Recipe() {
            ingredients = new List<Resource>()
            {
            new Resource(GetResource(Consts.Ilmenite)).Mols(1000000),
            new Resource(GetResource(Consts.Chlorine)).Mols(4000000),
            },
            products = new List<Resource>()
            {
            new Resource(GetResource(Consts.Titanium_Tetrachloride)).Mols(1000000),
            new Resource(GetResource(Consts.Iron)).PercentMass(new Resource(GetResource(Consts.Ilmenite)).Mols(1000000).Mass, 36.81f),
            new Resource(GetResource(Consts.Oxygen)).PercentMass(new Resource(GetResource(Consts.Ilmenite)).Mols(1000000).Mass, 31.63f)
            },
            time = 1,
            powerCost = 0.0f,
            type = Recipe.RecipeType.Factory,
            Name = "Titanium Tetrachloride Synthesis"
        },
        #endregion
        #region Titanium Tetrachloride Processing
        new Recipe() {
            ingredients = new List<Resource>()
            {
            new Resource(GetResource(Consts.Titanium_Tetrachloride)).Mols(1000000),
            new Resource(GetResource(Consts.Magnesium)).Mols(2000000)
            },
            products = new List<Resource>()
            {
            new Resource(GetResource(Consts.Titanium)).Mols(1000000),
            new Resource(GetResource(Consts.Magnisum_Chloride)).Mols(2000000)
            },
            time = 1,
            powerCost = 0.0f,
            type = Recipe.RecipeType.Factory,
            Name = "Titanium Tetrachloride Processing"
        },
        #endregion
        #region Ferrotitanium Synthesis
        new Recipe() {
            ingredients = new List<Resource>()
            {
            new Resource(GetResource(Consts.Iron)).Mols(200000),
            new Resource(GetResource(Consts.Titanium)).Mols(750000),
            new Resource(GetResource(Consts.Carbon)).Mols(50000)
            },
            products = new List<Resource>()
            {
            new Resource(GetResource(Consts.Ferrotitanium)).Mols(1000000)
            },
            time = 1,
            powerCost = 0.0f,
            type = Recipe.RecipeType.Factory,
            Name = "Ferrotitanium Synthesis"
        },
        #endregion
        #endregion
        #region Farming
        #region Food
        new Recipe() {
            ingredients = new List<Resource>()
            {
            new Resource(GetResource(Consts.Seeds)) { Volume = 100 },
            new Resource(GetResource(Consts.Ammonium_Nitrate)) { Volume = 5 }
            },
            products = new List<Resource>()
            {
            new Resource(GetResource(Consts.Food)) { Volume = 100 }
            },
            time = 300,
            type = Recipe.RecipeType.Reaction,
            Name = "Farm Food"
        },
        #endregion
        #endregion
    };



    private List<Resource> inventory = new List<Resource>();

    private float totalMass = 0;
    private float totalVolume = 0;
    public float maxVolume = 0;
    public float transferVolume = 100;

    public void Start()
    {
        for (int i = 0; i < Inventory.Resources.Length; i++)
        {
            inventory.Add(Resources[i]);
        }
    }

    public static Resource GetResource(string name)
    {
        return Resources.First(x => x.Name == name);
    }

    public bool AddItem(Resource item)
    {
        if(totalVolume + item.Volume <= maxVolume)
        {
            int index = inventory.FindIndex(x => x.Name == item.Name);
            if (index >= 0)
                inventory[index].Volume += item.Volume;
            inventory[index] = item;
            return true;
        }
        return false;
    }

    public Resource RemoveItem(Resource item)
    {
        int index = inventory.FindIndex(x => x.Name == item.Name);

        if (index >= 0)
        {
            if (inventory[index].Volume >= item.Volume)
            {
                inventory[index].Volume -= item.Volume;
                return item;
            }
            else
            {
                Resource res = inventory[index];
                inventory[index].Volume = 0;
                return res;
            }
        }
        return null;
    }

    public void Add(int key, Resource stat)
    {
        inventory.Insert(key, stat);
    }

    public void Remove(int key)
    {
        inventory.RemoveAt(key);
    }

    public Resource this[int key]
    {
        get
        {
            return inventory[key];
        }
        set
        {
            inventory[key] = value;
        }
    }
    public int Length()
    {
        return inventory.Count;
    }
}

