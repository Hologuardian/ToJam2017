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
    public Color colourAttach = Color.green;
    public Color colourInvalid = Color.red;

    public UnityEngine.UI.Image gizmo;

    public StationModule self;
    public StationModule attachment;

    [Range (0,10000)]
    public float detachForce = 1000;

    public bool isSelected = false;
    public bool isFocused = false;

    public bool isInitialised = false;

    private void Start()
    {

    }

    void Initialise()
    {
        if (!isInitialised)
        {
            gizmo = (Blackboard.Global[Consts.Globals.UIInterface].Value as UIInterface).GenerateWidget(UIInterface.Widget.Hardpoint).GetComponent<UnityEngine.UI.Image>();
            isInitialised = true;
        }
    }

    private void Update()
    {
        Initialise();

        if (isSelected)
        {
            gizmo.color = colourSelected;
        }
        else if (isFocused)
        {
            if (self.station.hardpointSelected)
            {
                if (self.station.hardpointSelected.self != self)
                    gizmo.color = colourAttach;
                else
                    gizmo.color = colourInvalid;
            }
            else
                gizmo.color = colourFocused;
        }
        else if (self.station.hardpointSelected)
        {
            gizmo.color = colourSelectable;
        }
        else
        {
            gizmo.color = colourDefault;
        }

        if (Camera.current)
            gizmo.rectTransform.position = Camera.current.WorldToScreenPoint(transform.position);
    }

    /// <summary>
    /// Attaches the attachment hardpoint to this hardpoint
    /// </summary>
    public void Attach(Hardpoint attach)
    {
        attach.attachment = self;
        attachment = attach.self;

        // The attachment hardpoint module needs to be put offset from this hardpoint by the distance to the hardpoint we are attaching
        attach.self.transform.position = transform.position + (transform.position - self.transform.position);

        attach.self.transform.rotation = Quaternion.FromToRotation(attach.self.transform.forward, (transform.position - attach.self.transform.position));
    }

    public void Detach(Hardpoint detach)
    {
        detach.attachment = null;
        attachment = null;

        (detach.self.general[Consts.General.Rigidbody].Value as Rigidbody).AddForce(transform.forward * detachForce);
    }

    public bool HasAttachment()
    {
        return attachment;
    }

    public void Select()
    {
        // This means that this is the first hard point to be selected
        // And as such it will be the module being detached and moved
        if (!self.station.hardpointSelected)
        {
            self.Select();
            isSelected = true;
            self.station.hardpointSelected = this;
        }
        // This means that this is the second hard point to be selected
        // This hardpoint is the hardpoint the first selected one will now move to
        else
        {
            if (self.station.hardpointSelected.self != self)
            {
                self.Move(self.station.hardpointSelected, this);
                //Attach(self.station.hardpointSelected);
            }
        }
    }

    public void Deselect()
    {
        self.Deselect();
        isSelected = false;
        self.station.hardpointSelected = null;
    }

    // When the mouse enters a hardpoint collision zone
    void OnMouseEnter()
    {
        isFocused = true;
        self.station.hardpointHover = this;
    }

    void OnMouseOver()
    {
        
    }

    void OnMouseExit()
    {
        self.station.hardpointHover = null;
        isFocused = false;
    }

    void OnMouseDown()
    {
        Select();
    }

    void OnMouseDrag()
    {

    }

    void OnMouseUp()
    {
        Debug.Log("Mouse released on: " + this.name);

        if (self.station.hardpointSelected && self.station.hardpointHover)
        {
            if (self.station.hardpointSelected.self != self.station.hardpointHover)
            {
                self.station.hardpointHover.Attach(self.station.hardpointSelected);
                Deselect();
            }
        }
        else
        {
            Deselect();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // We have collided with a hardpoint
        if (other.gameObject.tag == Consts.Station.Hardpoints)
        {
            self.Couple(this, other.gameObject.GetComponent<Hardpoint>());
            //Attach(other.gameObject.GetComponent<Hardpoint>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // We have stopped colliding with a hardpoint, decouple
        if (other.gameObject.tag == Consts.Station.Hardpoints)
        {
            self.Decouple(this, other.gameObject.GetComponent<Hardpoint>());
            //Detach(other.gameObject.GetComponent<Hardpoint>());
        }
    }
}