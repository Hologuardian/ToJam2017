using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OldStation
{
    [System.Serializable]
    public class Hardpoint : MonoBehaviour
    {
        public Color colourDefault = Color.clear;
        public Color colourSelected = Color.green;
        public Color colourSelectable = Color.blue;
        public Color colourFocused = Color.red;
        public Color colourFocusable = Color.green;
        public Color colourAttach = Color.green;
        public Color colourInvalid = Color.red;

        public UnityEngine.UI.Image gizmo;

        public StationModule self;
        public Hardpoint attach;
        public StationModule attachment;

        [Range(0, 10000)]
        public float detachForce = 1000;

        public bool isSelected = false;
        public bool isFocused = false;
        public bool focusable = false;

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

            if (attachment)
            {
                gizmo.color = colourDefault;
            }
            else if (isSelected)
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
            else if (focusable || (self.station.moduleSelected && !attachment))
            {
                gizmo.color = colourFocusable;
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

        public Hardpoint QueryHardpoint()
        {
            RaycastHit[] hits = Physics.SphereCastAll(transform.position, 0.1f, Vector3.zero, 0, LayerMask.GetMask(Consts.Station.Hardpoints));

            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.gameObject != gameObject)
                    return hit.collider.gameObject.GetComponent<Hardpoint>();
            }

            return null;
        }

        /// <summary>
        /// Attaches the attachment hardpoint to this hardpoint
        /// </summary>
        public void Attach(Hardpoint attach)
        {
            this.attach = attach;
            attach.attach = this;
            attach.attachment = self;
            attachment = attach.self;

            Quaternion rotation = Quaternion.FromToRotation(attach.transform.forward, -transform.forward);

            attach.self.transform.Rotate(rotation.eulerAngles);// Quaternion.FromToRotation(attach.self.transform.forward, transform.forward);
                                                               // The attachment hardpoint module needs to be put offset from this hardpoint by the distance to the hardpoint we are attaching
            attach.self.transform.position = transform.position + (attach.self.transform.position - attach.transform.position);
        }

        public void Detach(Hardpoint detach)
        {
            attach = null;
            detach.attach = null;
            detach.attachment = null;
            attachment = null;

            //(detach.self.general[Consts.General.Rigidbody].Value as Rigidbody).AddForce(transform.forward * detachForce);
        }

        public bool HasAttachment()
        {
            return attachment;
        }

        public void Focus()
        {
            if (!attachment)
            {
                if (focusable || self.station.moduleSelected)
                {
                    isFocused = true;
                    self.station.hardpointHover = this;
                }

                focusable = true;
            }
        }

        public void Defocus()
        {
            if (!attachment)
            {
                if (focusable || self.station.moduleSelected)
                {
                    self.station.hardpointHover = null;
                    isFocused = false;
                }

                focusable = false;
            }
        }

        public void Select()
        {
            Debug.Log("Select: " + this.name);
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
            Debug.Log("Deselect: " + this.name);
            self.Deselect();
            isSelected = false;
            self.station.hardpointSelected = null;
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
            Select();
        }

        void OnMouseDrag()
        {

        }

        void OnMouseUp()
        {
            if (self.station.hardpointSelected && self.station.hardpointHover)
            {
                if (self.station.hardpointSelected.self != self.station.hardpointHover.self)
                {
                    self.station.hardpointHover.Attach(self.station.hardpointSelected);
                    //Deselect();
                }
            }

            Deselect();
        }
    }
}