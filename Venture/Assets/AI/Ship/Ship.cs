using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ship : MonoBehaviour
{
    public Blackboard general = new Blackboard();
    public Inventory inventory = new Inventory();
    public GameObject Model;
    public Station station;
    public AsteroidBelt asteroidBelt;
    public Transform rawgoal, goal;
    bool isInitialize = false;

    public NavMeshAgent navMeshAgent;

    void Start()
    {

    }

    void Initialize()
    {
        isInitialize = true;
        rawgoal = goal = asteroidBelt.roids[Random.Range(0, asteroidBelt.roids.Count - 1)].transform;
    }

    // Use this for initialization
    public void Launch(Specialisations specialisation)
    {

    }

    void Tick() {

        if (Vector3.Distance(transform.position, goal.position) < 1)
        {
            switch (goal.GetComponent<AsteroidPrefab>().Mine(inventory)) {
                case 1:
                    rawgoal = goal = asteroidBelt.roids[Random.Range(0, asteroidBelt.roids.Count - 1)].transform;
                    break;
                case 2:
                    rawgoal.position = goal.position = (transform.position - station.transform.position).normalized * station.dockingPerimeter;
                    break;

            }
        }
    }
    void Update()
    {
       
        if (!isInitialize)
        {
            Initialize();
        }
        navMeshAgent.destination = goal.position;

    }

}
