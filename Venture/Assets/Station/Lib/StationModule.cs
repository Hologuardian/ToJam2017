﻿using System.Collections;
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

    public float speed = 10.0f;

    public bool isTransitioning = false;

    public Quaternion rotationStart = new Quaternion();
    public Quaternion rotationEnd = new Quaternion();

    public Vector3 positionStart = new Vector3();
    public Vector3 positionEnd = new Vector3();

    public bool isSelected = false;
    private float deselectCooldown = 0;

    public SphereCollider clickArea;

    // Use this for initialization
    void Start()
    {
        clickArea = GetComponent<SphereCollider>();
        general.Add(Literals.Inventory, new BlackboardValue() { Name = Literals.Inventory, Value = inventory });
        //inventory.
        general.Add(Literals.Hardpoints, new BlackboardValue() { Name = Literals.Hardpoints, Value = hardpoints });
        //general.Add(Consts.General.Rigidbody, new BlackboardValue() { Name = Consts.General.Rigidbody, Value = GetComponent<Rigidbody>() });

        //Select();
    }

    // Update is called once per frame
    void Update()
    {
        if (station.moduleSelected)
            clickArea.enabled = false;
        else
            clickArea.enabled = true;

        if (isTransitioning)
        {
            // This is the fun part
            // We want to isolate the axis that we are shortest on, and move on that one until we can't then move on the next shortest until we can't, then the final one.
            // If at any stage we fail to be able to do any motion, the module defaults to moving aways from the core on the longest axis it can move on.

            Vector3 delta = positionEnd - positionStart;

            float min = Mathf.Min(Mathf.Min(delta.x, delta.y), delta.z);

            if (delta.x == min)
            {
                if (CanMoveAlongAxis(new Vector3(1,0,0)))
                {

                }
            }
        }
    }

    public bool CanMoveAlongAxis(Vector3 axis)
    {
        return false;
    }

    public void Tick()
    {
        // Station modules want to use the default inventory transferVolume amount to shift an equal distribution of surplus resources, to adjacent deficits, or from adjacent surpluses.
        // In every case the amount taken from or given to the adjacent module will always be limited to less than half the amount the module has
        // This will eventually saturate the entire station with an even amount of all surpluses.
        // In the event that a module has no amount of a resource, and an adjacent module is found to have a deficit, this module adds half of that deficit to its own, 
        // This value is limited to the value of the greatest adjacent deficit.

        Inventory[] adjacentInventories = GetAdjacentInventories();

        Inventory[] cloneInventories = new Inventory[adjacentInventories.Length];
        // Iterate through the resources
        for(int i = 0; i < inventory.Length(); i++)
        {
            // Determine if this module has a surplus, nothing, or a deficit
            if (inventory[i].Volume > 0)
            {
                // If this module has a surplus it should immediately attempt to share this surplus with those around it, if they have less than it
                for(int j = 0; j < adjacentInventories.Length; j++)
                {
                    // If the adjacent inventory has a surplus as well
                    if (adjacentInventories[j][i].Volume > 0)
                    {
                        // If they have less than us we should give them half the difference, so we have the same amount, ideally, but we have to later distribute the volume transfer more evenly
                        if (adjacentInventories[j][i].Volume < inventory[i].Volume)
                        {
                            cloneInventories[j][i].Volume = (inventory[i].Volume - adjacentInventories[j][i].Volume) / 2;
                        }
                        // This module does nothing in any other case, as the other module will handle the transfer
                    }
                    // If the adjacent inventory has none
                    else if (adjacentInventories[j][i].Volume == 0)
                    {
                        // Immediately attempt to give them half your inventory
                        cloneInventories[j][i].Volume = inventory[i].Volume / 2.0f;
                    }
                    // If the adjacent inventory has a deficit
                    else
                    {
                        // If they have a deficit for something this module should immediately attempt to send as much of it as possible.
                        cloneInventories[j][i].Volume = inventory[i].Volume;
                    }
                }
            }
            else if (inventory[i].Volume == 0)
            {
                // If this module has none, it should attempt to look for deficits to inherit
                for (int j = 0; j < adjacentInventories.Length; j++)
                {
                    // If the adjacent inventory has a deficit
                    if (adjacentInventories[j][i].Volume < 0)
                    {
                        inventory[i].Volume = Mathf.Max(inventory[i].Volume + adjacentInventories[j][i].Volume / 2.0f, adjacentInventories[j][i].Volume);
                    }
                }
            }
            else
            {
                // If this module is in a deficit state it is passive at least in regards to this resource
            }
        }

        if (cloneInventories.Length > 0)
        {
            List<float> desiredDistributionVolumes = new List<float>();
            // First lets get all the desired distribution volumes in total that would like to be in transit from this module this tick
            foreach (Inventory desiredDistribution in cloneInventories)
            {
                float desiredDistributionVolume = 0;

                for (int i = 0; i < desiredDistribution.Length(); i++)
                {
                    Resource res = desiredDistribution[i];

                    if (res.Volume > 0)
                    {
                        desiredDistributionVolume += desiredDistribution[res.Name].Volume;
                    }
                }

                desiredDistributionVolumes.Add(desiredDistributionVolume);
            }

            // Next we need to evenly distribute the total transferVolume across all transfer inventories
            // The easiest way of doing this is allowing the first transfer inventory to use its fraction of the transfer volume, or exhaust the transfer inventory first, 
            // Then the left over transfer volume is left for the others to split
            float transferPer = inventory.transferVolume / cloneInventories.Length;
            float alotment = transferPer;
            int index = 0;
            while (alotment > 0 && !cloneInventories[index].IsEmpty())
            {
                for (int i = 0; i < Inventory.Resources.Length; i++)
                {
                    // The logic I think will work here best is calculate the percent of the total desired transfer that this resource is, and 
                    float totalDesiredTransfer = cloneInventories[index][Inventory.Resources[i].Name].Volume / desiredDistributionVolumes[index];
                    float currentDesiredTransfer = alotment * totalDesiredTransfer;
                    if (cloneInventories[index][Inventory.Resources[i].Name].Volume < currentDesiredTransfer)
                    {
                        alotment -= cloneInventories[index][Inventory.Resources[i].Name].Volume;
                        adjacentInventories[index][Inventory.Resources[i].Name].Volume += cloneInventories[index][Inventory.Resources[i].Name].Volume;
                    }
                    else
                    {
                        alotment -= currentDesiredTransfer;
                        adjacentInventories[index][Inventory.Resources[i].Name].Volume += currentDesiredTransfer;
                    }
                }
            }
        }
    }

    public Inventory[] GetAdjacentInventories()
    {
        List<Inventory> inv = new List<Inventory>();
        foreach(Hardpoint hardpoint in hardpoints)
        {
            if (hardpoint.attachment)
                inv.Add(hardpoint.attachment.general[Literals.Inventory].Value as Inventory);
        }
        return inv.ToArray();
    }

    public void Couple(Hardpoint self, Hardpoint other)
    {
        self.Attach(other.gameObject.GetComponent<Hardpoint>());
    }

    public void Decouple(Hardpoint self, Hardpoint other)
    {
        self.Detach(other.gameObject.GetComponent<Hardpoint>());
    }

    public void Move(Hardpoint self, Hardpoint goal)
    {
        positionStart = transform.position;
        rotationStart = transform.rotation;
        positionEnd = transform.position + (self.transform.position - transform.position);
        rotationEnd = Quaternion.FromToRotation(goal.self.transform.forward, (transform.position - goal.self.transform.position));
        isTransitioning = true;
    }

    public void Focus()
    {
        Debug.Log("Focus: " + name);

        foreach (Hardpoint hardpoint in hardpoints)
        {
            hardpoint.focusable = true;
        }
    }

    public void Defocus()
    {
        Debug.Log("Defocus: " + name);

        foreach (Hardpoint hardpoint in hardpoints)
        {
            hardpoint.focusable = false;
        }
    }

    /// <summary>
    /// Sets this module and all its hard points to the selected state, which makes all hardpoints enter isFocused state
    /// </summary>
    public void Select()
    {
        Debug.Log("Select: " + name);

        isSelected = true;

        clickArea.enabled = false;

        if (station.moduleSelected)
            if (station.moduleSelected != this)
                station.moduleSelected.Deselect();

        station.moduleSelected = this;

        //deselectCooldown = Consts.Station.StationModuleDeselectCooldown;
    }

    public void Deselect()
    {
        Debug.Log("Deselect: " + name);

        //if (deselectCooldown <= 0)
        //{
            isSelected = false;


        clickArea.enabled = true;
        station.moduleSelected = null;
        //}
    }

    // When the mouse enters a hardpoint collision zone
    void OnMouseEnter()
    {
        Focus();
    }

    void OnMouseOver()
    {

    }

    void OnMouseExit()
    {
        Defocus();
    }

    void OnMouseDown()
    {
        if (station.moduleSelected != this)
        {
            Select();
        }
        else
        {
            Deselect();
        }
    }

    void OnMouseDrag()
    {

    }

    void OnMouseUp()
    {
        
    }
}
