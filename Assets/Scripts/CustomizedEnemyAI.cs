using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomizedEnemyAI : MonoBehaviour {

    public NavMeshAgent agent;
    public AIPlayerMovment character;
    public enum State
    {
        PATROL,
        CHASE
    }
    
    public State state;

    public GameObject[] waypoints;

    private int waypointInd = 0;

    public float patrolSpeed = 0.5f;

    public float chaseSpeed = 1f;

    public GameObject target;

    private bool alive;
 
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<AIPlayerMovment>();
        agent.updatePosition = true;
        agent.updateRotation = false;
        state = CustomizedEnemyAI.State.PATROL;
        alive = true;
        StartCoroutine("FSM");
    }

    IEnumerator FSM()
    {
        while (alive)
        {
            switch (state)
            {
                case State.PATROL:
                    Patrol();
                    break;
                case State.CHASE:
                    Chase();
                    break;
            }
            yield return null;
        }
    }

    void Patrol()
    {
        agent.speed = patrolSpeed;
        if (Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position) >= 2)
        {
            agent.SetDestination(waypoints[waypointInd].transform.position);
            //character.Move(agent.desiredVelocity, false, false);
            character.MoveForward();
        }
        else if (Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position) <= 2)
        {
            waypointInd += 1;

            if (waypointInd > waypoints.Length)
            {
                waypointInd = 0;
            }
        }
        else
        {
            character.Idle();
        }
    }

    void Chase()
    {
        agent.speed = chaseSpeed;
        agent.SetDestination(target.transform.position);
        character.MoveForward();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            state = CustomizedEnemyAI.State.CHASE;
            target = other.gameObject;

        }

    }
     

}
