using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class BlackboardValue
{
    public enum ValueType { Integer, Float, Double, Vector2, Vector3, Vector4, String, GameObject, Object };

    public string Name { get; set; }

    public ValueType Type { get; set; }

    protected object value;
    public virtual object Value
    {
        get
        {
            return value;
        }
        set
        {
            this.value = value;
            if (value.GetType() == typeof(int))
                Type = ValueType.Integer;
            else if (value.GetType() == typeof(float))
                Type = ValueType.Float;
            else if (value.GetType() == typeof(double))
                Type = ValueType.Double;
            else if (value.GetType() == typeof(Vector2))
                Type = ValueType.Vector2;
            else if (value.GetType() == typeof(Vector3))
                Type = ValueType.Vector3;
            else if (value.GetType() == typeof(Vector4))
                Type = ValueType.Vector4;
            else if (value.GetType() == typeof(string))
                Type = ValueType.String;
            else if (value.GetType() == typeof(GameObject))
                Type = ValueType.GameObject;
            else
                Type = ValueType.Object;
        }
    }
}