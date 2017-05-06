using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class Inventory
{
    public Resource[] stats_editor = {
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
            Name = "Ammonia",
            Value = 3.01f,
            Density = 670.8f }, //1000bar
        new Resource() {
            Name = "Nitric Acid",
            Value = 1.9f,
            Density = 1519.3f },
        new Resource() {
            Name = "Ammonium Nitrate",
            Value = 7.28f,
            Density = 1739.93f},
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
            Name = "Carbon",
            Value = 2.75f,
            Density = 2260 },
        new Resource() {
            Name = "Acanthite Ore", //Silver Sulfide
            Value = 0.0f,
            Density = 7234.0f },
        new Resource() {
            Name = "Barite Ore",
            Value = 4500.0f,
            Density = 0 },
        new Resource() {
            Name = "Bauxite Ore",
            Value = 1281.0f,
            Density = 0 },
        new Resource() {
            Name = "Beryl Ore",
            Value = 0.0f,
            Density = 0 },
        new Resource() {
            Name = "Bornite Ore",
            Value = 0.0f,
            Density = 0 },
        new Resource() {
            Name = "Cassiterite Ore",
            Value = 0.0f,
            Density = 0 },
        new Resource() {
            Name = "Chalcopyrite Ore",
            Value = 0.0f,
            Density = 0 },
        new Resource() {
            Name = "Chromite Ore",
            Value = 0.0f,
            Density = 0 },
        new Resource() {
            Name = "Cinnabar Ore",
            Value = 0.0f,
            Density = 0 },
        new Resource() {
            Name = "Cobaltite Ore",
            Value = 0.0f,
            Density = 0 },
        new Resource() {
            Name = "Coltan Ore",
            Value = 0.0f,
            Density = 0 },
        new Resource() {
            Name = "Dolomite Ore",
            Value = 0.0f,
            Density = 0 },
        new Resource() {
            Name = "Galena Ore",
            Value = 0.0f,
            Density = 7500.0f },
        new Resource() {
            Name = "Native Gold Ore",
            Value = 0.0f,
            Density = 0 },
        new Resource() {
            Name = "Hematite Ore",
            Value = 0.0f,
            Density = 5150.0f },
        new Resource() {
            Name = "Ilmenite Ore",
            Value = 0.0f,
            Density = 2307.0f },
        new Resource() {
            Name = "Magnetite Ore",
            Value = 0.0f,
            Density = 4000.0f },
        new Resource() {
            Name = "Malachite Ore",
            Value = 0.0f,
            Density = 0 },
        new Resource() {
            Name = "Molybdenite Ore",
            Value = 0.0f,
            Density = 1600.0f },
        new Resource() {
            Name = "Pentlandite Ore",
            Value = 0.0f,
            Density = 0 },
        new Resource() {
            Name = "Pyrolusite Ore",
            Value = 0.0f,
            Density = 0 },
        new Resource() {
            Name = "Scheelite Ore",
            Value = 0.0f,
            Density = 0 },
        new Resource() {
            Name = "Sperrylite Ore",
            Value = 0.0f,
            Density = 0 },
        new Resource() {
            Name = "Sphalerite Ore",
            Value = 0.0f,
            Density = 0 },
        new Resource() {
            Name = "Uraninite Ore",
            Value = 0.0f,
            Density = 0 },
        new Resource() {
            Name = "Wolframite Ore",
            Value = 0.0f,
            Density = 0 },
        new Resource() {
            Name = "Silica",
            Value = 0.0f,
            Density = 0 },
        new Resource() {
            Name = "Silicon",
            Value = 0.0f,
            Density = 0 },
        new Resource() {
            Name = "Iron",
            Value = 0.0f,
            Density = 0 },
        new Resource() {
            Name = "Nickle",
            Value = 0.0f,
            Density = 0 },
        new Resource() {
            Name = "Cobalt",
            Value = 0.0f,
            Density = 0 },
        new Resource() {
            Name = "Ruthenium",
            Value = 0.0f,
            Density = 0 },
        new Resource() {
            Name = "Rhodium",
            Value = 0.0f,
            Density = 0 },
        new Resource() {
            Name = "Palladium",
            Value = 0.0f,
            Density = 0 },
        new Resource() {
            Name = "Osmium",
            Value = 0.0f,
            Density = 0 },
        new Resource() {
            Name = "Iridium",
            Value = 0.0f,
            Density = 0 },
        new Resource() {
            Name = "Platinum",
            Value = 0.0f,
            Density = 0 },
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

