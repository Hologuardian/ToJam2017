using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AsteroidPrefab : MonoBehaviour {
    public Size asteroidSize;
    public Inventory inventory;
    // Use this for initialization
    void Start () {
        inventory.Start();
        switch (asteroidSize) {
            case Size.Tiny:
                transform.localScale *= 1f;
                break;
            case Size.Small:
                transform.localScale *= 1.5f;
                break;
            case Size.Medium:
                transform.localScale *= 2f;
                break;
            case Size.Large:
                transform.localScale *= 2.5f;
                break;
            case Size.Huge:
                transform.localScale *= 3f;
                break;
        }

        //inventory.AddItem(Instantiate(Resource)
    }
	
	// Update is called once per frame
	void Update () {
		
	}


}
