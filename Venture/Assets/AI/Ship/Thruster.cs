using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour {
    public float thrust;
    public Ship ship;
    public void Thrust()
    {
           ship.rigidbody.AddForceAtPosition(transform.forward * thrust, transform.position);
    }
}
