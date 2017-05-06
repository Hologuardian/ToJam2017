using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResourceSerialisable
{
    public string name;
    public BlackboardValue.ValueType type = BlackboardValue.ValueType.Integer;
    public int valueInt;
    public float valueFloat;
    public double valueDouble;
    public Vector2 valueVector2;
    public Vector3 valueVector3;
    public Vector4 valueVector4;
    public string valueString;
    public GameObject valueGameObject;

    public BlackboardValue Dump()
    {
        switch (type)
        {
            case BlackboardValue.ValueType.Integer:
                return new BlackboardValue() { Value = valueInt, Name = name };
            case BlackboardValue.ValueType.Float:
                return new BlackboardValue() { Value = valueFloat, Name = name };
            case BlackboardValue.ValueType.Double:
                return new BlackboardValue() { Value = valueDouble, Name = name };
            case BlackboardValue.ValueType.Vector2:
                return new BlackboardValue() { Value = valueVector2, Name = name };
            case BlackboardValue.ValueType.Vector3:
                return new BlackboardValue() { Value = valueVector3, Name = name };
            case BlackboardValue.ValueType.Vector4:
                return new BlackboardValue() { Value = valueVector4, Name = name };
            case BlackboardValue.ValueType.String:
                return new BlackboardValue() { Value = valueString, Name = name };
            case BlackboardValue.ValueType.GameObject:
                return new BlackboardValue() { Value = valueGameObject, Name = name };
            case BlackboardValue.ValueType.Object:
                return new BlackboardValue() { Value = valueGameObject, Name = name };
        }

        return null;
    }
}
