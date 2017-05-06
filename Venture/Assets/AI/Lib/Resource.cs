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
        this.volume = 0;
        this.density = 0;
        this.value = 0;
    }
    public Resource(string Name, float Volume, float Mass, float Density, float Value)
    {
        this.Name = Name;
        this.volume = Volume;
        this.density = Density;
        this.value = Value;
    }
    public Resource(Resource resource)
    {
        this.Name = resource.Name;
        this.volume = resource.Volume;
        this.density = resource.Density;
        this.value = resource.Value;
    }

    public string Name;

    public float Volume
    {
        get { return volume; }
        set { this.volume = value; }
    }
    public float Mass
    {
        get { return Volume * Density; }
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
        get { return value * Volume; }
    }

    private float volume;
    private float density;
    private float value;
}
