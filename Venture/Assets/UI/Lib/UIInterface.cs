using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class MouseClick
{
    public float startTime = 0;
    public Vector3 startPosition = Vector3.zero;
}

public class UIInterface : MonoBehaviour
{
    public GameObject widgetHardpoint;

    new public Camera camera;
    public Canvas canvas;
    //public 
    public RectTransform panelWorld;
    public MouseClick click;

    void Start()
    {
        Blackboard.Global.Add(Consts.Globals.UIInterface, new BlackboardValue() { Name = Consts.Globals.UIInterface, Value = this });
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Right here we need to make sure that whatever was clicked on finds out about it.
            click = new MouseClick() { startTime = Time.time, startPosition = Input.mousePosition };

            // If I haven't hit UI, I should look into the world
            //if ()
            //    Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            //
            //    RaycastHit hit;
            //
            //    if (Physics.Raycast(ray, out hit))
            //    {
            //        Debug.Log(hit);
            //    }
            //}
        }
        else if (Input.GetMouseButton(0))
        {
            // This is a constant click
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // Right here we need to make sure that whatever was clicked stops thinking it is the center of the universe
            click = null;
        }
    }

    public enum Widget { Hardpoint };

    public GameObject GenerateWidget(Widget widget)
    {
        switch (widget)
        {
            case Widget.Hardpoint:
                return Instantiate(widgetHardpoint, panelWorld, false);
        }

        return null;
    }
}
