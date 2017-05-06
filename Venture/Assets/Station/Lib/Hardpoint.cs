using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Hardpoint : MonoBehaviour
{
    public StationModule self;
    public StationModule attachment;

    private void Start()
    {
        //Attach();
    }

    private void Update()
    {

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
}