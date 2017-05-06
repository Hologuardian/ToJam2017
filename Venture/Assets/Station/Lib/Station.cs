using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    public Inventory inventory;

    // Use this for initialization
    void Start()
    {
        inventory.Start();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Resource GetMostDesiredResource()
    {
        int index = 0;
        float value = 0;

        for (int i = 0; i < inventory.Length(); i++)
        {
            if (inventory[i].Volume < value)
            {
                index = i;
                value = inventory[i].Volume;
            }
        }

        return inventory[index];
    }

    public List<Resource> GetDesiredResources()
    {
        List<Resource> resources = new List<Resource>();

        for (int i = 0; i < inventory.Length(); i++)
        {
            if (inventory[i].Volume < 0)
                resources.Add(inventory[i]);
        }

        return resources;
    }

    public List<Resource> GetSurplusResources()
    {
        List<Resource> resources = new List<Resource>();

        for (int i = 0; i < inventory.Length(); i++)
        {
            if (inventory[i].Volume > 0)
                resources.Add(inventory[i]);
        }

        return resources;
    }
}
