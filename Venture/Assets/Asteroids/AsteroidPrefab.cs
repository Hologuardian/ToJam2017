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
                transform.localScale *= 0.25f;
                break;
            case Size.Small:
                transform.localScale *= 0.5f;
                break;
            case Size.Medium:
                transform.localScale *= 0.75f;
                break;
            case Size.Large:
                transform.localScale *= 1f;
                break;
            case Size.Huge:
                transform.localScale *= 1.5f;
                break;
        }
        inventory.maxVolume = Mathf.Pow(10, (int)asteroidSize);
        while (!inventory.IsFull()) {
            Resource tempResource = Inventory.Resources[Random.Range(77, 109)];
            if (inventory.DoesContain(tempResource))
            {
                inventory[tempResource.Name].Mass += tempResource.Mass;
            }
            else {
                inventory.AddItem(tempResource);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Mine(Inventory inventory) {

    }

}
