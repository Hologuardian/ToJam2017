using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {
    float angle = 0;
    float angularVelocity = 0;
    float radius= 0;
     
    // Use this for initialization
    void Start () {
       
        angle = Random.Range(0, Mathf.PI * 2);
        angularVelocity = Random.Range(0.0001f, 0.0025f);
        radius = Random.Range(250, 350);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
        transform.position = direction*radius;
        angle += angularVelocity * Time.deltaTime;
        if (angle > Mathf.PI*2) {
            angle = 0;
        }
	}
}
