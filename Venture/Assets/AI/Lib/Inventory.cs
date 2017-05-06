using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class Inventory
{
    public ResourceSerialisable[] stats_editor = {
        new ResourceSerialisable() { name = "Hydrogen", valueFloat = 0.0f, type = BlackboardValue.ValueType.Float },
        new ResourceSerialisable() { name = "Helium", valueFloat = 0.0f, type = BlackboardValue.ValueType.Float },
        new ResourceSerialisable() { name = "Oxygen", valueFloat = 0.0f, type = BlackboardValue.ValueType.Float },
        new ResourceSerialisable() { name = "Nitrogen", valueFloat = 0.0f, type = BlackboardValue.ValueType.Float },
        new ResourceSerialisable() { name = "Water", valueFloat = 0.0f, type = BlackboardValue.ValueType.Float },
        new ResourceSerialisable() { name = "Ammonia", valueFloat = 0.0f, type = BlackboardValue.ValueType.Float },
        new ResourceSerialisable() { name = "Nitric Acid", valueFloat = 0.0f, type = BlackboardValue.ValueType.Float },
        new ResourceSerialisable() { name = "Ammonium Nitrate", valueFloat = 0.0f, type = BlackboardValue.ValueType.Float },
        new ResourceSerialisable() { name = "Soil", valueFloat = 0.0f, type = BlackboardValue.ValueType.Float },
        new ResourceSerialisable() { name = "Seeds", valueFloat = 0.0f, type = BlackboardValue.ValueType.Float },
        new ResourceSerialisable() { name = "Food", valueFloat = 0.0f, type = BlackboardValue.ValueType.Float },
        new ResourceSerialisable() { name = "Carbon", valueFloat = 0.0f, type = BlackboardValue.ValueType.Float },
        new ResourceSerialisable() { name = "Silica", valueFloat = 0.0f, type = BlackboardValue.ValueType.Float },
        new ResourceSerialisable() { name = "Silicon", valueFloat = 0.0f, type = BlackboardValue.ValueType.Float },
        new ResourceSerialisable() { name = "Carbonaceous Ore", valueFloat = 0.0f, type = BlackboardValue.ValueType.Float },
        new ResourceSerialisable() { name = "Silacious Ore", valueFloat = 0.0f, type = BlackboardValue.ValueType.Float },
        new ResourceSerialisable() { name = "Metallic Ore", valueFloat = 0.0f, type = BlackboardValue.ValueType.Float },
        new ResourceSerialisable() { name = "Iron", valueFloat = 0.0f, type = BlackboardValue.ValueType.Float },
        new ResourceSerialisable() { name = "Nickle", valueFloat = 0.0f, type = BlackboardValue.ValueType.Float },
        new ResourceSerialisable() { name = "Cobalt", valueFloat = 0.0f, type = BlackboardValue.ValueType.Float },
        new ResourceSerialisable() { name = "Precious Metal", valueFloat = 0.0f, type = BlackboardValue.ValueType.Float },
        new ResourceSerialisable() { name = "Ruthenium", valueFloat = 0.0f, type = BlackboardValue.ValueType.Float },
        new ResourceSerialisable() { name = "Rhodium", valueFloat = 0.0f, type = BlackboardValue.ValueType.Float },
        new ResourceSerialisable() { name = "Palladium", valueFloat = 0.0f, type = BlackboardValue.ValueType.Float },
        new ResourceSerialisable() { name = "Osmium", valueFloat = 0.0f, type = BlackboardValue.ValueType.Float },
        new ResourceSerialisable() { name = "Iridium", valueFloat = 0.0f, type = BlackboardValue.ValueType.Float },
        new ResourceSerialisable() { name = "Platinum", valueFloat = 0.0f, type = BlackboardValue.ValueType.Float },
    };

    private Blackboard inventory = new Blackboard();

    public void Start()
    {
        foreach(ResourceSerialisable stat in stats_editor)
        {
            inventory.Add(stat.name, stat.Dump());
        }
    }

    public bool ContainsKey(string key)
    {
        return inventory.ContainsKey(key);
    }

    public void Add(string key, BlackboardValue stat)
    {
        inventory.Add(key, stat);
    }

    public bool Remove(string key)
    {
        return inventory.Remove(key);
    }

    public BlackboardValue this[string key]
    {
        get
        {
            if (inventory.ContainsKey(key))
            {
                return inventory[key] as BlackboardValue;
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
                inventory[key].Value = value;
            }
            else
            {
                inventory.Add(key, value);
            }
        }
    }
}
