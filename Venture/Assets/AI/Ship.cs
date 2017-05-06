using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {
    public Blackboard general = new Blackboard();
    public Inventory inventory = new Inventory();

    public Ship Factory() {
        Ship ship = new Ship();



        return ship;
    }

    // Use this for initialization
    public void Launch(Station station, Specialisations specialisation, Inventory inventory) {


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
