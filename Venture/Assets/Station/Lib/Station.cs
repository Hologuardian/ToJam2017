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

    public List<Resource> GetDesiredResources()
    {
        List<Resource> resources = new List<Resource>();

        for (int i = 0; i < inventory.Length(); i++)
        {
            if (inventory[i].Amount < 0)
                resources.Add(inventory[i]);
        }

        return resources;
    }

    public List<Resource> GetSurplusResources()
    {
        List<Resource> resources = new List<Resource>();

        for (int i = 0; i < inventory.Length(); i++)
        {
            if (inventory[i].Amount > 0)
                resources.Add(inventory[i]);
        }

        return resources;
    }
}
