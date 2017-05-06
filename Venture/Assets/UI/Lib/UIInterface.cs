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
    void Start()
    {
        Blackboard.Global.Add(Consts.Globals.UIInterface, new BlackboardValue() { Name = Consts.Globals.UIInterface, Value = this });
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {

        }
    }
}
