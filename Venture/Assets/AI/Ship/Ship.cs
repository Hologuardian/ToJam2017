using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {
    public Blackboard general = new Blackboard();
    public Inventory inventory = new Inventory();

    public Thruster[] backThrusters, frontThrusters, upThrusters, downThrusters;

    public Rigidbody rigidbody;

    public Vector3 goal, target;
    public float fuel, currentVel , desiredVel;
    
    // Use this for initialization
    public void Launch(Station station, Specialisations specialisation, Inventory inventory) {


    }


    

	// Update is called once per frame
	void FixedUpdate () {
        currentVel = rigidbody.velocity.z;
        if (currentVel < desiredVel)
        {
            foreach (Thruster thruster in downThrusters)
            {
                thruster.Thrust();
            }
        }
	}
}
