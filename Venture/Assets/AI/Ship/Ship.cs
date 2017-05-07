using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ship : MonoBehaviour
{
    public Blackboard general = new Blackboard();
    public Inventory inventory = new Inventory();
    public GameObject Model;
    public AsteroidBelt asteroidBelt;
    public Vector3 rawgoal,goal;
    bool isInitialize = false;

    public NavMeshAgent navMeshAgent;

    void Start()
    {

    }

    void Initialize()
    {
        isInitialize = true;
        rawgoal = goal = asteroidBelt.roids[Random.Range(0, asteroidBelt.roids.Count - 1)].transform.position;
        goal.y = 0;
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
       
        if (!isInitialize)
        {
            Initialize();
        }
        navMeshAgent.destination = goal;
        Model.transform.position = new Vector3(transform.position.x,
            Mathf.Lerp(Model.transform.position.y, rawgoal.y,Vector3.Distance(Model.transform.position.normalized,rawgoal.normalized)), 
            transform.position.z);

    }

}
