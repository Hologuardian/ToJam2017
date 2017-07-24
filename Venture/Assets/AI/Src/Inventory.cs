//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using UnityEngine;

//[Serializable]
//public class InventoryItem
//{
//    public Resource resource;
//    public float volume;
//}

//[Serializable]
//public class Inventory
//{
//    private Dictionary<string, Resource> inventory = new Dictionary<string, Resource>();

//    public InventoryItem[] inventoryDisplay;

//    private float totalMass = 0;
//    private float totalVolume = 0;
//    public float maxVolume = 0;
//    public float transferVolume = 100;

//    public void Start()
//    {
//        for (int i = 0; i < Resources.Length; i++)
//        {
//            inventory.Add(Resources[i].Name, new Resource() { Name = Resources[i].Name, Density = Resources[i].Density, Mass = Resources[i].Mass, MolarMass = Resources[i].MolarMass, Value = Resources[i].Value, Volume = 0.0f });
//        }
//    }

//    public bool AddItem(Resource item)
//    {
//        if (totalVolume + item.Volume <= maxVolume)
//        {
//            if (inventory.ContainsKey(item.Name))
//                inventory[item.Name].Volume += item.Volume;
//            else
//                inventory.Add(item.Name, item);

//            return true;
//        }
//        return false;
//    }

//    public void RemoveItem(Resource item)
//    {
//        if (inventory.ContainsKey(item.Name))
//            inventory[item.Name].Volume -= item.Volume;
//    }

//    public Resource this[int index]
//    {
//        get
//        {
//            return inventory[inventory.Keys.ElementAt(index)];
//        }
//        set
//        {
//            inventory[inventory.Keys.ElementAt(index)] = value;
//        }
//    }

//    public Resource this[string key]
//    {
//        get
//        {
//            return inventory[key];
//        }
//        set
//        {
//            inventory[key] = value;
//        }
//    }

//    public int Length()
//    {
//        return inventory.Count;
//    }

//    public bool IsFull()
//    {
//        totalVolume = 0;
//        for (int i = 0; i < inventory.Count; i++)
//        {
//            Resource res = this[i];
//            if (res.Volume > 0)
//            {
//                totalMass += inventory[res.Name].Mass;
//                totalVolume += inventory[res.Name].Volume;
//            }
//        }

//        if (totalVolume >= maxVolume)
//        {
//            return true;
//        }
//        else
//        {
//            return false;
//        }
//    }

//    public bool IsEmpty()
//    {
//        if (inventory.Count <= 0)
//        {
//            return true;
//        }
//        for (int i = 0; i < inventory.Count; i++)
//        {
//            if (this[i].Volume > 0)
//            {
//                return true;
//            }
//        }
//        return false;
//    }

//    public bool DoesContain(Resource item)
//    {
//        if (inventory.ContainsKey(item.Name))
//        {
//            return inventory[item.Name].Volume > 0;
//        }

//        return false;
//    }
    
//    public void UpdateDisplay()
//    {
//        int index = 0;

//        if (inventoryDisplay.Length < 1)
//        {
//            inventoryDisplay = new InventoryItem[inventory.Count];
//            index = 0;
//            foreach (KeyValuePair<string, Resource> pair in inventory)
//            {
//                inventoryDisplay[index] = new InventoryItem() { resource = pair.Value, volume = pair.Value.Volume };
//                index++;
//            }
//        }

//        index = 0;
//        foreach(KeyValuePair<string, Resource> pair in inventory)
//        {
//            if (inventoryDisplay[index].resource.Volume != inventoryDisplay[index].volume)
//                inventoryDisplay[index].resource.Volume = inventoryDisplay[index].volume;

//            index++;
//        }
//    }
//}

