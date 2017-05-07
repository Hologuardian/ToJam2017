using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Nav : MonoBehaviour {
    float waitTime = 0.05f;
    float currentTime;
    RaycastHit rayHit;
    // Use this for initialization
    void Start () {
        
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit rayHit = new RaycastHit();
        if (Physics.Raycast(new Vector3(transform.position.x + (transform.localScale.x/2), transform.position.y, transform.position.z), transform.forward, out rayHit, 100))
        {
            FindEdge();
        }
        else if (Physics.Raycast(transform.position, transform.forward, out rayHit, 100))
        {
            FindEdge();
        }
        else if (Physics.Raycast(new Vector3(transform.position.x - (transform.localScale.x / 2), transform.position.y, transform.position.z), transform.forward, out rayHit, 100))
        {
            FindEdge();
        }

    }
    void FindEdge() {
        transform.Rotate(new Vector3(0, 1, 0), 45 * Mathf.Deg2Rad);
    }
}
