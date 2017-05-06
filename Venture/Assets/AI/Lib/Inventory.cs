using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class Inventory
{
    public Resource[] BaseResources = {
        /*
         * BASE AND ORGANIC
         */
        new Resource() {
            Name = "Hydrogen",
            Value = 1.0f,
            Density = 107.7f }, //5000bar
        new Resource() { Name = "Helium",
            Value = 2.0f,
            Density = 177.1f }, //2000bar
        new Resource() {
            Name = "Oxygen",
            Value = 0.1f,
            Density = 573.6f }, // 500bar
        new Resource() {
            Name = "Nitrogen",
            Value = 0.01f,
            Density = 420.2f }, // 500bar
        new Resource() {
            Name = "Water",
            Value = 6.93f,
            Density = 1000.0f },
        new Resource() {
            Name = "Carbon",
            Value = 2.75f,
            Density = 2260 },
        new Resource() {
            Name = "Silicon",
            Value = 0.0f,
            Density = 2330.0f },
        new Resource() {
            Name = "Iron",
            Value = 0.0f,
            Density = 7874.0f },
        new Resource() {
            Name = "Nickle",
            Value = 0.0f,
            Density = 8908.0f },
        new Resource() {
            Name = "Cobalt",
            Value = 0.0f,
            Density = 8900.0f },
        new Resource() {
            Name = "Ruthenium",
            Value = 0.0f,
            Density = 12370.0f },
        new Resource() {
            Name = "Rhodium",
            Value = 0.0f,
            Density = 12450.0f },
        new Resource() {
            Name = "Palladium",
            Value = 0.0f,
            Density = 12020.0f },
        new Resource() {
            Name = "Tellurium",
            Value = 0.0f,
            Density = 0.0f },
        new Resource() {
            Name = "Bismuth",
            Value = 0.0f,
            Density = 0.0f },
        new Resource() {
            Name = "Osmium",
            Value = 0.0f,
            Density = 22590.0f },
        new Resource() {
            Name = "Iridium",
            Value = 0.0f,
            Density = 22560.0f },
        new Resource() {
            Name = "Platinum",
            Value = 0.0f,
            Density = 21450.0f },
        new Resource() {
            Name = "Aluminum",
            Value = 0.0f,
            Density = 2700.0f },
        new Resource() {
            Name = "Copper",
            Value = 0.0f,
            Density = 8960.0f },
        new Resource() {
            Name = "Lead",
            Value = 0.0f,
            Density = 11340.0f },
        new Resource() {
            Name = "Magnesium",
            Value = 0.0f,
            Density = 1738.0f },
        new Resource() {
            Name = "Tungsten",
            Value = 0.0f,
            Density = 19250.0f },
        new Resource() {
            Name = "Thallium",
            Value = 0.0f,
            Density = 11850.0f },
        new Resource() {
            Name = "Sulfur",
            Value = 0.0f,
            Density = 1960.0f },
        new Resource() {
            Name = "Tin",
            Value = 0.0f,
            Density = 7310.0f },
        new Resource() {
            Name = "Uranium",
            Value = 0.0f,
            Density = 7310.0f },
        new Resource() {
            Name = "Chromium",
            Value = 0.0f,
            Density = 7190.0f },
        new Resource() {
            Name = "Beryllium",
            Value = 0.0f,
            Density = 0 },
        new Resource() {
            Name = "Molybdenum",
            Value = 0.0f,
            Density = 1848.0f },
        new Resource() {
            Name = "Gold",
            Value = 0.0f,
            Density = 19300.0f },
        new Resource() {
            Name = "Calcium",
            Value = 0.0f,
            Density = 1550.0f },
        new Resource() {
            Name = "Arsenic",
            Value = 0.0f,
            Density = 5727.0f },
        new Resource() {
            Name = "Antimony",
            Value = 0.0f,
            Density = 6697.0f },
        new Resource() {
            Name = "Chlorine",
            Value = 0.0f,
            Density = 1577.0f }, //200bar
        new Resource() {
            Name = "Mercury",
            Value = 0.0f,
            Density = 13534.0f },
        new Resource() {
            Name = "Gallium",
            Value = 0.0f,
            Density = 5904.0f },
        /*
         * ACIDS
         */
        new Resource() {
            Name = "Nitric Acid",
            Value = 1.9f,
            Density = 1519.3f },
        new Resource() {
            Name = "Sodium Hydroxide",
            Value = 0.0f,
            Density = 2130.0f },
        /*
         * COMPOUNDS
         */
        new Resource() {
            Name = "Ammonia",
            Value = 3.01f,
            Density = 670.8f }, //1000bar
        new Resource() {
            Name = "Ammonium Nitrate",
            Value = 7.28f,
            Density = 1739.93f},
        new Resource() {
            Name = "Alumina",
            Value = 0.0f,
            Density = 0.0f },
        new Resource() {
            Name = "Silica",
            Value = 0.0f,
            Density = 2634.0f },
        new Resource() {
            Name = "Titania",
            Value = 0.0f,
            Density = 0.0f },
        new Resource() {
            Name = "Calcia",
            Value = 0.0f,
            Density = 0.0f },
        new Resource() {
            Name = "Ferrochrome",
            Value = 0.0f,
            Density = 0.0f },
        new Resource() {
            Name = "Ferrotitanium",
            Value = 0.0f,
            Density = 0.0f },
        new Resource() {
            Name = "Magnesia",
            Value = 0.0f,
            Density = 0.0f },
        new Resource() {
            Name = "Manganese Carbonate",
            Value = 0.0f,
            Density = 0.0f },
        new Resource() {
            Name = "Manganese Nitrate",
            Value = 0.0f,
            Density = 0.0f },
        new Resource() {
            Name = "Sulfur Dioxide",
            Value = 0.0f,
            Density = 0.0f },
        new Resource() {
            Name = "Iron(III) Oxide",
            Value = 0.0f,
            Density = 0.0f },
        new Resource() {
            Name = "Titanium Tetrachloride",
            Value = 0.0f,
            Density = 0.0f },
        new Resource() {
            Name = "Magnisum Chloride",
            Value = 0.0f,
            Density = 0.0f },
        new Resource() {
            Name = "Molybdate",
            Value = 0.0f,
            Density = 0.0f },
        new Resource() {
            Name = "Coloured Glass",
            Value = 0.0f,
            Density = 0.0f },
        /*
         * COMPLEX MATERIALS
         */
        new Resource() {
            Name = "Tungsten Carbide",
            Value = 0.0f,
            Density = 0.0f },
        new Resource() {
            Name = "Clear Glass",
            Value = 0.0f,
            Density = 0.0f },
        new Resource() {
            Name = "Steel",
            Value = 0.0f,
            Density = 0.0f },
        /*
         * GOODS
         */
        new Resource() {
            Name = "Soil",
            Value = 12.0f,
            Density = 1083.3f },
        new Resource() {
            Name = "Seeds",
            Value = 50.0f,
            Density = 504.65f },
        new Resource() {
            Name = "Food",
            Value = 176.39f,
            Density = 780.0f },
        new Resource() {
            Name = "Stainless Steel",
            Value = 0.0f,
            Density = 0.0f },
        new Resource() {
            Name = "Tantalum Capacitor Anode",
            Value = 0.0f,
            Density = 0.0f },
        new Resource() {
            Name = "Tantalum Capacitor Cathode",
            Value = 0.0f,
            Density = 0.0f },
        new Resource() {
            Name = "Tantalum Capacitor",
            Value = 0.0f,
            Density = 0.0f },
        new Resource() {
            Name = "Printed Circuit Board",
            Value = 0.0f,
            Density = 0.0f },
        new Resource() {
            Name = "Semiconductor",
            Value = 0.0f,
            Density = 0.0f },
        new Resource() {
            Name = "Integrated Circuit",
            Value = 0.0f,
            Density = 0.0f },
        /*
         * ORES
         */
        new Resource() {
            Name = "Acanthite",
            Value = 0.0f,
            Density = 7234.0f },
        new Resource() {
            Name = "Barite",
            Value = 0,
            Density = 4500.0f },
        new Resource() {
            Name = "Bauxite",
            Value = 0,
            Density = 1281.0f },
        new Resource() {
            Name = "Beryl",
            Value = 0.0f,
            Density = 2765.0f },
        new Resource() {
            Name = "Bornite",
            Value = 0.0f,
            Density = 5100.0f },
        new Resource() {
            Name = "Cassiterite",
            Value = 0.0f,
            Density = 6900.0f },
        new Resource() {
            Name = "Chalcopyrite",
            Value = 0.0f,
            Density = 4200.0f },
        new Resource() {
            Name = "Chromite",
            Value = 0.0f,
            Density = 4795.0f },
        new Resource() {
            Name = "Cinnabar",
            Value = 0.0f,
            Density = 8100.0f },
        new Resource() {
            Name = "Cobaltite",
            Value = 0.0f,
            Density = 6330.0f },
        new Resource() {
            Name = "Coltan",
            Value = 0.0f,
            Density = 6700.0f },
        new Resource() {
            Name = "Dolomite",
            Value = 0.0f,
            Density = 2850.0f },
        new Resource() {
            Name = "Galena",
            Value = 0.0f,
            Density = 7500.0f },
        new Resource() {
            Name = "Native Gold",
            Value = 0.0f,
            Density = 19320.0f },
        new Resource() {
            Name = "Hematite",
            Value = 0.0f,
            Density = 5150.0f },
        new Resource() {
            Name = "Ilmenite",
            Value = 0.0f,
            Density = 2307.0f },
        new Resource() {
            Name = "Magnetite",
            Value = 0.0f,
            Density = 5175.0f },
        new Resource() {
            Name = "Malachite",
            Value = 0.0f,
            Density = 4000.0f },
        new Resource() {
            Name = "Molybdenite",
            Value = 0.0f,
            Density = 1600.0f },
        new Resource() {
            Name = "Pentlandite",
            Value = 0.0f,
            Density = 4800.0f },
        new Resource() {
            Name = "Periclase",
            Value = 0.0f,
            Density = 3785.0f },
        new Resource() {
            Name = "Pyrolusite",
            Value = 0.0f,
            Density = 4730.0f },
        new Resource() {
            Name = "Rhodochrosite",
            Value = 0.0f,
            Density = 3690.0f },
        new Resource() {
            Name = "Sperrylite",
            Value = 0.0f,
            Density = 10580.0f },
        new Resource() {
            Name = "Sphalerite",
            Value = 0.0f,
            Density = 4050.0f },
        new Resource() {
            Name = "Cooperite",
            Value = 0.0f,
            Density = 9500.0f },
        new Resource() {
            Name = "Laurite",
            Value = 0.0f,
            Density = 6990.0f },
        new Resource() {
            Name = "Merenskyite",
            Value = 0.0f,
            Density = 9140.0f },
        new Resource() {
            Name = "Sudburyite",
            Value = 0.0f,
            Density = 9000.0f },
        new Resource() {
            Name = "Omeiite",
            Value = 0.0f,
            Density = 11200.0f },
        new Resource() {
            Name = "Niggliite",
            Value = 0.0f,
            Density = 13440.0f },
        new Resource() {
            Name = "Thorianite",
            Value = 0.0f,
            Density = 10000.0f },
        new Resource() {
            Name = "Uraninite",
            Value = 0.0f,
            Density = 8725.0f },
        new Resource() {
            Name = "Wolframite",
            Value = 0.0f,
            Density = 7300.0f }
    };

    public Resource[] OreResources = {
    };

    private List<Resource> inventory = new List<Resource>();

    public void Start()
    {
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

