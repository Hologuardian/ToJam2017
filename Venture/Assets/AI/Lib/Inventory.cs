using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class Inventory
{
    public Resource[] stats_editor = {
        new Resource() { Name = "Hydrogen", Value = 1.0f, Density = 0.1077f }, //5000bar
        new Resource() { Name = "Helium", Value = 2.0f, Density = 0.1771f }, //2000bar
        new Resource() { Name = "Oxygen", Value = 0.1f, Density = 0.5736f }, // 500bar
        new Resource() { Name = "Nitrogen", Value = 0.0f, Density = 0 },
        new Resource() { Name = "Water", Value = 0.0f, Density = 0 },
        new Resource() { Name = "Ammonia", Value = 0.0f, Density = 0 },
        new Resource() { Name = "Nitric Acid", Value = 0.0f, Density = 0 },
        new Resource() { Name = "Ammonium Nitrate", Value = 0.0f, Density = 0 },
        new Resource() { Name = "Soil", Value = 0.0f, Density = 0 },
        new Resource() { Name = "Seeds", Value = 0.0f, Density = 0 },
        new Resource() { Name = "Food", Value = 0.0f, Density = 0 },
        new Resource() { Name = "Carbon", Value = 0.0f, Density = 0 },
        new Resource() { Name = "Silica", Value = 0.0f, Density = 0 },
        new Resource() { Name = "Silicon", Value = 0.0f, Density = 0 },
        new Resource() { Name = "Carbonaceous Ore", Value = 0.0f, Density = 0 },
        new Resource() { Name = "Silacious Ore", Value = 0.0f, Density = 0 },
        new Resource() { Name = "Metallic Ore", Value = 0.0f, Density = 0 },
        new Resource() { Name = "Iron", Value = 0.0f, Density = 0 },
        new Resource() { Name = "Nickle", Value = 0.0f, Density = 0 },
        new Resource() { Name = "Cobalt", Value = 0.0f, Density = 0 },
        new Resource() { Name = "Precious Metal", Value = 0.0f, Density = 0 },
        new Resource() { Name = "Ruthenium", Value = 0.0f, Density = 0 },
        new Resource() { Name = "Rhodium", Value = 0.0f, Density = 0 },
        new Resource() { Name = "Palladium", Value = 0.0f, Density = 0 },
        new Resource() { Name = "Osmium", Value = 0.0f, Density = 0 },
        new Resource() { Name = "Iridium", Value = 0.0f, Density = 0 },
        new Resource() { Name = "Platinum", Value = 0.0f, Density = 0 },
    };

    private Dictionary<string, Resource> inventory = new Dictionary<string, Resource>();

    public void Start()
    {
        foreach(Resource stat in stats_editor)
        {
            inventory.Add(stat.Name, stat);
        }
    }

    public bool ContainsKey(string key)
    {
        return inventory.ContainsKey(key);
    }

    public void Add(string key, Resource stat)
    {
        inventory.Add(key, stat);
    }

    public bool Remove(string key)
    {
        return inventory.Remove(key);
    }

    public Resource this[string key]
    {
        get
        {
            if (inventory.ContainsKey(key))
            {
                return inventory[key];
            }
            else
            {
                return null;
            }
        }
        set
        {
            if (inventory.ContainsKey(key))
            {
                inventory[key] = value;
            }
            else
            {
                inventory.Add(key, value);
            }
        }
    }
    public int Length()
    {
        return inventory.Keys.Count;
    }
}

