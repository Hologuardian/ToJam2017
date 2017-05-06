using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {
    public Blackboard general = new Blackboard();
    public Inventory inventory = new Inventory();
    Specialisations shipsSpecialisation = new Specialisations();
    public bool arrived= false;
    public Thruster[] thrusters;
    public List<int>
        backThrusters, frontThrusters, upThrusters, downThrusters, leftThrusters, rightThrusters,
        turnLeftThrusters, turnRightThrusters, turnUpThrusters, turnDownThrusters;


    public Rigidbody rigidbody;

    Vector3 start;
    public Transform goal, target;
    public float fuel, currentVel, desiredVel, stoppingDistance, dist; 

    void Start() {
        start = transform.position;
        target = goal;
        target.position = new Vector3(target.position.x, target.position.y, target.position.z - (target.localScale.z*2));


        for (int i = 0; i < thrusters.Length; i++) {
            if (thrusters[i].isABackThruster) {
                backThrusters.Add(i);
            }
            else if (thrusters[i].isAFrontThruster) {
                frontThrusters.Add(i);
            }
            else if (thrusters[i].isAUpThruster) {
                upThrusters.Add(i);
            }
            else if (thrusters[i].isADownThruster) {
                downThrusters.Add(i);
            }
            else if (thrusters[i].isALeftThruster) {
                leftThrusters.Add(i);
            }
            else if (thrusters[i].isARightThruster) {
                rightThrusters.Add(i);
            }

            if (thrusters[i].isATurnLeftThruster) {
                turnLeftThrusters.Add(i);
            }
            else if (thrusters[i].isATurnRightThruster) {
                turnRightThrusters.Add(i);
            }
            else if (thrusters[i].isATurnUpThruster) {
                turnUpThrusters.Add(i);
            }
            else if (thrusters[i].isATurnDownThruster) {
                turnDownThrusters.Add(i);
            }
        }
    }
    
    // Use this for initialization
    public void Launch(Specialisations specialisation) {
        
    }

// Update is called once per frame
void FixedUpdate () {
        transform.LookAt(target);
        dist = Vector3.Distance(transform.position, target.position);
        currentVel = rigidbody.velocity.z;
        if (dist > 3 && !arrived)
        {
            if (dist > Vector3.Distance((target.position / 2), target.position))
            {
                Forward();
            }
            else if (dist < (Vector3.Distance(start, target.position) / 2))
            {
                if (rigidbody.velocity.z < 0.5) {
                    Forward();
                    print(dist);
                }
                else
                {
                    Back();
                }
            }
            if (dist < 4) {
                rigidbody.velocity = Vector3.zero;
                arrived = true;
            }
        }
        if (arrived) {
            rigidbody.velocity = Vector3.zero;
        }
	}
    void Forward() {
        for (int i = 0; i < backThrusters.Count; i++)
        {
            thrusters[backThrusters[i]].Thrust();
        }
    }
    void Back() {
        
        for (int i = 0; i < frontThrusters.Count; i++)
        {
            thrusters[frontThrusters[i]].Thrust();
        }
    }
    void turnRight() { }
    void turnLeft() {
        for (int i = 0; i < turnLeftThrusters.Count; i++) {
            thrusters[turnLeftThrusters[i]].Thrust();
        }
    }

}
