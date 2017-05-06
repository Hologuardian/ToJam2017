using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationModule : MonoBehaviour
{
    public static float TransferVolume = 100;
    
    public static class Literals
    {
        public const string Inventory = "Inventory";
        public const string Hardpoints = "Hardpoints";
    }

    public Blackboard general = new Blackboard();
    public Inventory inventory = new Inventory();

    public Station station;
    public Hardpoint[] hardpoints;

    public float transferVolume = TransferVolume;

    public bool isSelected = false;
    private bool lastSelected = false;

    // Use this for initialization
    void Start()
    {
        general.Add(Literals.Inventory, new BlackboardValue() { Name = Literals.Inventory, Value = inventory });
        //inventory.
        general.Add(Literals.Hardpoints, new BlackboardValue() { Name = Literals.Hardpoints, Value = hardpoints });

        Select();
    }

    // Update is called once per frame
    void Update()
    {
        if (lastSelected != isSelected)
        {
            if (isSelected)
                Select();
            else
                Deselect();

            lastSelected = isSelected;
        }
    }

    /// <summary>
    /// Sets this module and all its hard points to the selected state, which makes all hardpoints enter isFocused state
    /// </summary>
    public void Select()
    {
        isSelected = true;

        foreach(Hardpoint hardpoint in hardpoints)
        {
            hardpoint.isFocused = true;
        }
    }

    public void Deselect()
    {
        isSelected = false;

        foreach(Hardpoint hardpoint in hardpoints)
        {
            hardpoint.isFocused = false;
        }
    }
}
