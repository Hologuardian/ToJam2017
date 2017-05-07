using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    public const float TICKRATE = 0.1f;

    public delegate void OnTick();

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
    public Hardpoint hardpointHover = null;

    /// <summary>
    /// This is the distance from the origin of the station that being within is considered 'docked'
    /// </summary>
    public float dockingPerimeter = 10;

    private float timeToTick = 0;
    private int tickCallbacksPerFrame = 0;
    private List<OnTick> tickCallbacks = new List<OnTick>();

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
        timeToTick += Time.deltaTime;

        if (timeToTick >= TICKRATE)
        {
            timeToTick -= TICKRATE;
            Tick();
        }

        if (tickCallbacks.Count > 0)
        {
            for (int i = 0; i < tickCallbacksPerFrame; i++)
            {
                tickCallbacks[0]();
                tickCallbacks.RemoveAt(0);
            }
        }
    }

    public void Tick()
    {
        // By default I am just gonna get tick to queue all the things that need to be updated
        tickCallbacks.Clear();

        // First lets get all the modules, and set off their ticks.
        // I will make module extensions (the actual module logic) give its station module the callback for it to call when it calls tick
        foreach (StationModule module in modulesAll)
        {
            tickCallbacks.Add(module.Tick);
        }

        // Second lets get all the ships, and set off their ticks.


        if (tickCallbacks.Count > 0)
            tickCallbacksPerFrame = Mathf.CeilToInt(0.1f / tickCallbacks.Count);
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

    public void Dock(Ship ship)
    {

    }
}
