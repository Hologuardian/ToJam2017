using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour {
    public float thrust;
    public Ship ship;
    public bool
        isABackThruster, isAFrontThruster, isAUpThruster, isADownThruster, isALeftThruster, isARightThruster,
        isATurnLeftThruster, isATurnRightThruster, isATurnUpThruster, isATurnDownThruster;
    public void Thrust()
    {
           ship.GetComponent<Rigidbody>().AddForceAtPosition(transform.forward * thrust, transform.position);
    }
}
