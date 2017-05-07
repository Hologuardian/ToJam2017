using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ship : MonoBehaviour
{
    public Blackboard general = new Blackboard();
    public Inventory inventory = new Inventory();
    public AsteroidBelt asteroidBelt;
    bool isInitialize = false;

    public NavMeshAgent navMeshAgent;

    void Start()
    {

    }

    void Initialize()
    {
        print("running");
        isInitialize = true;
        navMeshAgent.destination = asteroidBelt.roids[Random.Range(0, asteroidBelt.roids.Count - 1)].transform.position;
    }

    // Use this for initialization
    public void Launch(Specialisations specialisation)
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
    void Update()
    {
        navMeshAgent.destination = asteroidBelt.roids[Random.Range(0, asteroidBelt.roids.Count - 1)].transform.position;
        if (!isInitialize)
        {
            Initialize();
        }
    }

}
