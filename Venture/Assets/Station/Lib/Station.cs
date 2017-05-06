using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    public static class Literals
    {
        public const string Inventory = "Inventory";
        public const string Modules = "Modules";
        public const string DockingBays = "DockingBays";
    }

    public Blackboard general = new Blackboard();
    public Inventory inventory = new Inventory();

    public List<StationModule> modulesAll = new List<StationModule>();
    public List<DockingModule> dockingBays = new List<DockingModule>();
    public List<ReactorModule> reactorCores = new List<ReactorModule>();

    public float credits;

    public Hardpoint hardpointSelected = null;

    // Use this for initialization
    void Start()
    {
        general.Add(Literals.Inventory, new BlackboardValue() { Name = Literals.Inventory, Value = inventory });
        inventory.Start();

        general.Add(Literals.Modules, new BlackboardValue() { Name = Literals.Modules, Value = modulesAll});
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Tick()
    {

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
