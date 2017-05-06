using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Hardpoint : MonoBehaviour
{
    public Color colourDefault = Color.clear;
    public Color colourSelected = Color.green;
    public Color colourSelectable = Color.blue;
    public Color colourFocused = Color.red;

    public SpriteRenderer gizmo;

    public StationModule self;
    public StationModule attachment;

    public bool isSelected = false;
    public bool isFocused = false;

    private void Start()
    {
        //Attach();
    }

    private void Update()
    {
        if (isSelected)
        {
            gizmo.color = colourSelected;
        }
        else if (self.station.hardpointSelected)
        {
            gizmo.color = colourSelectable;
        }
        else if (isFocused)
        {
            gizmo.color = colourFocused;
        }
        else
        {
            gizmo.color = colourDefault;
        }
    }

    /// <summary>
    /// Attaches the attachment hardpoint to this hardpoint
    /// </summary>
    public void Attach(Hardpoint attach)
    {
        attach.attachment = self;
        attachment = attach.self;

        Vector3 delta = self.transform.position - attach.transform.position;

        attach.transform.parent.position += delta;
    }

    public bool HasAttachment()
    {
        return attachment;
    }

    public void Select()
    {
        if (!self.station.hardpointSelected)
        {
            self.Select();
            isSelected = true;
            self.station.hardpointSelected = true;
        }
        else
        {

        }
    }
}