using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Resource
{
    public Resource()
    {
        this.Name = "";
        this.amount = 0;
        this.density = 0;
        this.value = 0;
    }
    public Resource(string Name, float Amount, float Mass, float Density, float Value)
    {
        this.Name = Name;
        this.amount = Amount;
        this.density = Density;
        this.value = Value;
    }
    public Resource(Resource resource)
    {
        this.Name = resource.Name;
        this.amount = resource.Amount;
        this.density = resource.Density;
        this.value = resource.Value;
    }

    public string Name;

    public float Amount
    {
        get { return amount; }
        set { this.amount = value; }
    }
    public float Mass
    {
        get { return Amount * Density; }
    }
    public float Density
    {
        get { return value; }
        set { this.value = value; }
    }
    public float Value
    {
        get { return value; }
        set { this.value = value; }
    }
    public float GrossValue
    {
        get { return value * Amount; }
    }

    private float amount;
    private float density;
    private float value;
}
