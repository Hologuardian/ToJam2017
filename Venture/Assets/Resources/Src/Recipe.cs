using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.General.Src.SI;

namespace Assets.Resources.Src
{
    [Serializable]
    public class Recipe
    {


        public Recipe[] RecipeList = {
        #region Ore Reprocessing
        #region Bauxite Reprocess
        new Recipe() {
            ingredients = new List<Resource>()
            {
            new Resource(Resource.Find(Consts.Bauxite)) { Volume = 100.0f },
            new Resource(Resource.Find(Consts.Sodium_Hydroxide)) { Volume = 200.0f }
            },
            products = new List<Resource>()
            {
            new Resource(Resource.Find(Consts.Aluminum)).PercentMass(new Resource(Resource.Find(Consts.Bauxite)) { Volume = 100.0f }.Mass, 55.0f),
            new Resource(Resource.Find(Consts.Iron3_Oxide)).PercentMass(new Resource(Resource.Find(Consts.Bauxite)) { Volume = 100.0f }.Mass, 15.0f),
            new Resource(Resource.Find(Consts.Alumina)).PercentMass(new Resource(Resource.Find(Consts.Bauxite)) { Volume = 100.0f }.Mass, 10.0f),
            new Resource(Resource.Find(Consts.Titania)).PercentMass(new Resource(Resource.Find(Consts.Bauxite)) { Volume = 100.0f }.Mass, 3.0f),
            new Resource(Resource.Find(Consts.Calcia)).PercentMass(new Resource(Resource.Find(Consts.Bauxite)) { Volume = 100.0f }.Mass, 4.9f),
            new Resource(Resource.Find(Consts.Silica)).PercentMass(new Resource(Resource.Find(Consts.Bauxite)) { Volume = 100.0f }.Mass, 12.0f),
            new Resource(Resource.Find(Consts.Gallium)).PercentMass(new Resource(Resource.Find(Consts.Bauxite)) { Volume = 100.0f }.Mass, 0.1f),
            new Resource(Resource.Find(Consts.Sodium_Hydroxide)) { Volume = 200.0f }
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
            new Resource(Resource.Find(Consts.Bornite)) { Volume = 100.0f }
            },
            products = new List<Resource>()
            {
            new Resource(Resource.Find(Consts.Iron)).PercentMass(new Resource(Resource.Find(Consts.Bornite)) { Volume = 100.0f }.Mass, 11.13f),
            new Resource(Resource.Find(Consts.Copper)).PercentMass(new Resource(Resource.Find(Consts.Bornite)) { Volume = 100.0f }.Mass, 63.31f),
            new Resource(Resource.Find(Consts.Sulfur)).PercentMass(new Resource(Resource.Find(Consts.Bornite)) { Volume = 100.0f }.Mass, 25.56f)
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
            new Resource(Resource.Find(Consts.Cassiterite)) { Volume = 100.0f }
            },
            products = new List<Resource>()
            {
            new Resource(Resource.Find(Consts.Tin)).PercentMass(new Resource(Resource.Find(Consts.Cassiterite)) { Volume = 100.0f }.Mass, 78.77f),
            new Resource(Resource.Find(Consts.Oxygen)).PercentMass(new Resource(Resource.Find(Consts.Cassiterite)) { Volume = 100.0f }.Mass, 21.23f)
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
            new Resource(Resource.Find(Consts.Chalcopyrite)) { Volume = 100.0f }
            },
            products = new List<Resource>()
            {
            new Resource(Resource.Find(Consts.Copper)).PercentMass(new Resource(Resource.Find(Consts.Chalcopyrite)) { Volume = 100.0f }.Mass, 66.66f),
            new Resource(Resource.Find(Consts.Sulfur)).PercentMass(new Resource(Resource.Find(Consts.Chalcopyrite)) { Volume = 100.0f }.Mass, 33.33f)
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
            new Resource(Resource.Find(Consts.Cinnabar)) { Volume = 100.0f }
            },
            products = new List<Resource>()
            {
            new Resource(Resource.Find(Consts.Mercury)).PercentMass(new Resource(Resource.Find(Consts.Cinnabar)) { Volume = 100.0f }.Mass, 86.22f),
            new Resource(Resource.Find(Consts.Sulfur)).PercentMass(new Resource(Resource.Find(Consts.Cinnabar)) { Volume = 100.0f }.Mass, 17.78f)
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
            new Resource(Resource.Find(Consts.Cobaltite)) { Volume = 100.0f }
            },
            products = new List<Resource>()
            {
            new Resource(Resource.Find(Consts.Cobalt)).PercentMass(new Resource(Resource.Find(Consts.Cobaltite)) { Volume = 100.0f }.Mass, 35.52f),
            new Resource(Resource.Find(Consts.Arsenic)).PercentMass(new Resource(Resource.Find(Consts.Cobaltite)) { Volume = 100.0f }.Mass, 45.16f),
            new Resource(Resource.Find(Consts.Sulfur)).PercentMass(new Resource(Resource.Find(Consts.Cobaltite)) { Volume = 100.0f }.Mass, 19.33f)
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
            new Resource(Resource.Find(Consts.Rhodochrosite)) { Volume = 100.0f }
            },
            products = new List<Resource>()
            {
            new Resource(Resource.Find(Consts.Manganese_Carbonate)).PercentMass(new Resource(Resource.Find(Consts.Rhodochrosite)) { Volume = 100.0f }.Mass, 58.24f),
            new Resource(Resource.Find(Consts.Oxygen)).PercentMass(new Resource(Resource.Find(Consts.Rhodochrosite)) { Volume = 100.0f }.Mass, 41.76f)
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
            new Resource(Resource.Find(Consts.Galena)).Mols(1000000),
            new Resource(Resource.Find(Consts.Oxygen)).Mols(1000000)
            },
            products = new List<Resource>()
            {
            new Resource(Resource.Find(Consts.Lead)).Mols(1000000),
            new Resource(Resource.Find(Consts.Oxygen)).Mols(1000000),
            new Resource(Resource.Find(Consts.Sulfur_Dioxide)).Mols(1000000)
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
            new Resource(Resource.Find(Consts.Magnetite)) { Volume = 100.0f }
            },
            products = new List<Resource>()
            {
            new Resource(Resource.Find(Consts.Iron)).PercentMass(new Resource(Resource.Find(Consts.Magnetite)) { Volume = 100.0f }.Mass, 72.36f),
            new Resource(Resource.Find(Consts.Oxygen)).PercentMass(new Resource(Resource.Find(Consts.Magnetite)) { Volume = 100.0f }.Mass, 27.64f)
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
            new Resource(Resource.Find(Consts.Malachite)) { Volume = 100.0f }
            },
            products = new List<Resource>()
            {
            new Resource(Resource.Find(Consts.Copper)).PercentMass(new Resource(Resource.Find(Consts.Malachite)) { Volume = 100.0f }.Mass, 57.48f),
            new Resource(Resource.Find(Consts.Hydrogen)).PercentMass(new Resource(Resource.Find(Consts.Malachite)) { Volume = 100.0f }.Mass, 0.91f),
            new Resource(Resource.Find(Consts.Carbon)).PercentMass(new Resource(Resource.Find(Consts.Malachite)) { Volume = 100.0f }.Mass, 5.43f),
            new Resource(Resource.Find(Consts.Oxygen)).PercentMass(new Resource(Resource.Find(Consts.Malachite)) { Volume = 100.0f }.Mass, 36.18f)
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
            new Resource(Resource.Find(Consts.Pyrolusite)) { Volume = 100.0f }
            },
            products = new List<Resource>()
            {
            new Resource(Resource.Find(Consts.Copper)).PercentMass(new Resource(Resource.Find(Consts.Pyrolusite)) { Volume = 100.0f }.Mass, 63.19f),
            new Resource(Resource.Find(Consts.Hydrogen)).PercentMass(new Resource(Resource.Find(Consts.Pyrolusite)) { Volume = 100.0f }.Mass, 36.81f)
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
            new Resource(Resource.Find(Consts.Sperrylite)) { Volume = 1.0f }
            },
            products = new List<Resource>()
            {
            new Resource(Resource.Find(Consts.Arsenic)).PercentMass(new Resource(Resource.Find(Consts.Sperrylite)) { Volume = 1.0f }.Mass, 44.44f),
            new Resource(Resource.Find(Consts.Platinum)).PercentMass(new Resource(Resource.Find(Consts.Sperrylite)) { Volume = 1.0f }.Mass, 56.56f)
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
            new Resource(Resource.Find(Consts.Cooperite)) { Volume = 1.0f }
            },
            products = new List<Resource>()
            {
            new Resource(Resource.Find(Consts.Nickel)).PercentMass(new Resource(Resource.Find(Consts.Cooperite)) { Volume = 1.0f }.Mass, 3.14f),
            new Resource(Resource.Find(Consts.Palladium)).PercentMass(new Resource(Resource.Find(Consts.Cooperite)) { Volume = 1.0f }.Mass, 17.08f),
            new Resource(Resource.Find(Consts.Platinum)).PercentMass(new Resource(Resource.Find(Consts.Cooperite)) { Volume = 1.0f }.Mass, 62.62f),
            new Resource(Resource.Find(Consts.Sulfur)).PercentMass(new Resource(Resource.Find(Consts.Cooperite)) { Volume = 1.0f }.Mass, 17.16f)
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
            new Resource(Resource.Find(Consts.Laurite)) { Volume = 1.0f }
            },
            products = new List<Resource>()
            {
            new Resource(Resource.Find(Consts.Ruthenium)).PercentMass(new Resource(Resource.Find(Consts.Laurite)) { Volume = 1.0f }.Mass, 61.18f),
            new Resource(Resource.Find(Consts.Sulfur)).PercentMass(new Resource(Resource.Find(Consts.Laurite)) { Volume = 1.0f }.Mass, 38.82f)
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
            new Resource(Resource.Find(Consts.Merenskyite)) { Volume = 1.0f }
            },
            products = new List<Resource>()
            {
            new Resource(Resource.Find(Consts.Bismuth)).PercentMass(new Resource(Resource.Find(Consts.Merenskyite)) { Volume = 1.0f }.Mass, 10.81f),
            new Resource(Resource.Find(Consts.Tellurium)).PercentMass(new Resource(Resource.Find(Consts.Merenskyite)) { Volume = 1.0f }.Mass, 59.38f),
            new Resource(Resource.Find(Consts.Palladium)).PercentMass(new Resource(Resource.Find(Consts.Merenskyite)) { Volume = 1.0f }.Mass, 24.76f),
            new Resource(Resource.Find(Consts.Platinum)).PercentMass(new Resource(Resource.Find(Consts.Merenskyite)) { Volume = 1.0f }.Mass, 5.04f)
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
            new Resource(Resource.Find(Consts.Sudburyite)) { Volume = 1.0f }
            },
            products = new List<Resource>()
            {
            new Resource(Resource.Find(Consts.Nickel)).PercentMass(new Resource(Resource.Find(Consts.Sudburyite)) { Volume = 1.0f }.Mass, 6.79f),
            new Resource(Resource.Find(Consts.Antimony)).PercentMass(new Resource(Resource.Find(Consts.Sudburyite)) { Volume = 1.0f }.Mass, 56.30f),
            new Resource(Resource.Find(Consts.Palladium)).PercentMass(new Resource(Resource.Find(Consts.Sudburyite)) { Volume = 1.0f }.Mass, 36.91f)
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
            new Resource(Resource.Find(Consts.Omeiite)) { Volume = 1.0f }
            },
            products = new List<Resource>()
            {
            new Resource(Resource.Find(Consts.Arsenic)).PercentMass(new Resource(Resource.Find(Consts.Omeiite)) { Volume = 1.0f }.Mass, 47.16f),
            new Resource(Resource.Find(Consts.Osmium)).PercentMass(new Resource(Resource.Find(Consts.Omeiite)) { Volume = 1.0f }.Mass, 44.89f),
            new Resource(Resource.Find(Consts.Ruthenium)).PercentMass(new Resource(Resource.Find(Consts.Omeiite)) { Volume = 1.0f }.Mass, 7.95f)
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
            new Resource(Resource.Find(Consts.Niggliite)) { Volume = 1.0f }
            },
            products = new List<Resource>()
            {
            new Resource(Resource.Find(Consts.Tin)).PercentMass(new Resource(Resource.Find(Consts.Niggliite)) { Volume = 1.0f }.Mass, 37.83f),
            new Resource(Resource.Find(Consts.Platinum)).PercentMass(new Resource(Resource.Find(Consts.Niggliite)) { Volume = 1.0f }.Mass, 62.17f)
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
            new Resource(Resource.Find(Consts.Sphalerite)) { Volume = 1.0f }
            },
            products = new List<Resource>()
            {
            new Resource(Resource.Find(Consts.Zinc)).PercentMass(new Resource(Resource.Find(Consts.Sphalerite)) { Volume = 1.0f }.Mass, 64.06f),
            new Resource(Resource.Find(Consts.Iron)).PercentMass(new Resource(Resource.Find(Consts.Sphalerite)) { Volume = 1.0f }.Mass, 2.88f),
            new Resource(Resource.Find(Consts.Sulfur)).PercentMass(new Resource(Resource.Find(Consts.Sphalerite)) { Volume = 1.0f }.Mass, 32.06f),
            new Resource(Resource.Find(Consts.Gallium)).PercentMass(new Resource(Resource.Find(Consts.Sphalerite)) { Volume = 1.0f }.Mass, 0.1f),
            new Resource(Resource.Find(Consts.Germanium)).PercentMass(new Resource(Resource.Find(Consts.Sphalerite)) { Volume = 1.0f }.Mass, 0.3f)
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
            new Resource(Resource.Find(Consts.Wolframite)) { Volume = 100.0f }
            },
            products = new List<Resource>()
            {
            new Resource(Resource.Find(Consts.Manganese)).PercentMass(new Resource(Resource.Find(Consts.Wolframite)) { Volume = 100.0f }.Mass, 9.06f),
            new Resource(Resource.Find(Consts.Iron)).PercentMass(new Resource(Resource.Find(Consts.Wolframite)) { Volume = 100.0f }.Mass, 9.21f),
            new Resource(Resource.Find(Consts.Tungsten)).PercentMass(new Resource(Resource.Find(Consts.Wolframite)) { Volume = 100.0f }.Mass, 60.63f),
            new Resource(Resource.Find(Consts.Oxygen)).PercentMass(new Resource(Resource.Find(Consts.Wolframite)) { Volume = 100.0f }.Mass, 21.10f)
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
            new Resource(Resource.Find(Consts.Hydrogen)).Mols(600)
            },
            products = new List<Resource>()
            {
            new Resource(Resource.Find(Consts.Helium)).Mols(100),
            new Resource(Resource.Find(Consts.Hydrogen)).Mols(200)
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
            new Resource(Resource.Find(Consts.Water)).Mols(1000000),
            new Resource(Resource.Find(Consts.Pentlandite)).Mols(1000000)
            },
            products = new List<Resource>()
            {
            new Resource(Resource.Find(Consts.Hydrogen)).Mols(2000000),
            new Resource(Resource.Find(Consts.Oxygen)).Mols(1000000),
            new Resource(Resource.Find(Consts.Pentlandite)).Mols(1000000)
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
            new Resource(Resource.Find(Consts.Hydrogen)).Mols(2000000),
            new Resource(Resource.Find(Consts.Oxygen)).Mols(2000000)
            },
            products = new List<Resource>()
            {
            new Resource(Resource.Find(Consts.Water)).Mols(2000000),
            new Resource(Resource.Find(Consts.Oxygen)).Mols(1000000)
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
            new Resource(Resource.Find(Consts.Nitrogen)).Mols(1000000),
            new Resource(Resource.Find(Consts.Hydrogen)).Mols(3000000),
            new Resource(Resource.Find(Consts.Magnetite)).Mols(1000000)
            },
            products = new List<Resource>()
            {
            new Resource(Resource.Find(Consts.Ammonia)).Mols(1000000),
            new Resource(Resource.Find(Consts.Magnetite)).Mols(1000000)
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
            new Resource(Resource.Find(Consts.Nitrogen)).Mols(1000000),
            new Resource(Resource.Find(Consts.Hydrogen)).Mols(1000000),
            new Resource(Resource.Find(Consts.Oxygen)).Mols(3000000)
            },
            products = new List<Resource>()
            {
            new Resource(Resource.Find(Consts.Nitric_Acid)).Mols(1000000),
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
            new Resource(Resource.Find(Consts.Ammonia)).Mols(1000000),
            new Resource(Resource.Find(Consts.Nitric_Acid)).Mols(1000000),
            },
            products = new List<Resource>()
            {
            new Resource(Resource.Find(Consts.Ammonium_Nitrate)).Mols(1000000)
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
            new Resource(Resource.Find(Consts.Tungsten)).Mols(1000000),
            new Resource(Resource.Find(Consts.Carbon)).Mols(1000000),
            },
            products = new List<Resource>()
            {
            new Resource(Resource.Find(Consts.Tungsten_Carbide)).Mols(1000000)
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
            new Resource(Resource.Find(Consts.Ilmenite)).Mols(1000000),
            new Resource(Resource.Find(Consts.Chlorine)).Mols(4000000),
            },
            products = new List<Resource>()
            {
            new Resource(Resource.Find(Consts.Titanium_Tetrachloride)).Mols(1000000),
            new Resource(Resource.Find(Consts.Iron)).PercentMass(new Resource(Resource.Find(Consts.Ilmenite)).Mols(1000000).Mass, 36.81f),
            new Resource(Resource.Find(Consts.Oxygen)).PercentMass(new Resource(Resource.Find(Consts.Ilmenite)).Mols(1000000).Mass, 31.63f)
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
            new Resource(Resource.Find(Consts.Titanium_Tetrachloride)).Mols(1000000),
            new Resource(Resource.Find(Consts.Magnesium)).Mols(2000000)
            },
            products = new List<Resource>()
            {
            new Resource(Resource.Find(Consts.Titanium)).Mols(1000000),
            new Resource(Resource.Find(Consts.Magnesium_Chloride)).Mols(2000000)
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
            new Resource(Resource.Find(Consts.Iron)).Mols(200000),
            new Resource(Resource.Find(Consts.Titanium)).Mols(750000),
            new Resource(Resource.Find(Consts.Carbon)).Mols(50000)
            },
            products = new List<Resource>()
            {
            new Resource(Resource.Find(Consts.Ferrotitanium)).Mols(1000000)
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
            new Resource(Resource.Find(Consts.Seeds)) { Volume = 100 },
            new Resource(Resource.Find(Consts.Ammonium_Nitrate)) { Volume = 5 }
            },
            products = new List<Resource>()
            {
            new Resource(Resource.Find(Consts.Food)) { Volume = 100 }
            },
            time = 300,
            type = Recipe.RecipeType.Reaction,
            Name = "Farm Food"
        },
        #endregion
        #endregion
    };

        public enum RecipeType
        {
            None,
            Reaction,
            Factory,
            Reprocess,
            Farming
        }

        public Recipe()
        {
            ingredients = new List<Resource>();
            products = new List<Resource>();
            time = 1;
            powerCost = 0;
            type = RecipeType.None;
            Name = "";
        }

        public Recipe(List<Resource> ingredients, List<Resource> products, int time, float powerCost, RecipeType type)
        {
            if (ingredients == null)
                ingredients = new List<Resource>();
            if (products == null)
                products = new List<Resource>();

            this.ingredients = ingredients;
            this.products = products;
            this.time = time;
            this.powerCost = powerCost;
            this.type = type;
            Name = "";
        }

        public string Name;
        public List<Resource> ingredients;
        public List<Resource> products;
        public int time;
        public float powerCost;
        public RecipeType type;
    }
}