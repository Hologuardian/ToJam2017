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
            FindEdge(rayHit.collider.gameObject);
        }

    }
    void FindEdge(GameObject obj) {
        //transform.LookAt(new Vector3(obj.transform.position.x + obj.transform.localScale.x / 2));
    }
}
