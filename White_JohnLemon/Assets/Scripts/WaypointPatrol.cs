using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    public Transform player;
    public Transform Intruder;
    
    int m_CurrentWaypointIndex;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        float farPoint = 0f; //variable for storing fathest waypoint from player
        Vector3 target = Vector3.zero;
        RaycastHit hit;
        Vector3 rayDirection = player.position - Intruder.position;
        if (Physics.Raycast(transform.position, rayDirection, out hit))  //makes it so intruder won't move unless spotted by player
        {
            if (hit.transform == player)
            {
                foreach (Transform point in waypoints)
                {
                    float playerDistance = Vector3.Distance(player.position, point.position);

                    if (playerDistance > farPoint)
                    {
                        farPoint = playerDistance;
                        target = point.position;
                    }


                }
                navMeshAgent.SetDestination(target);
            }
           else
           {
                // there is something obstructing the view
           }
        }
        

        // if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        //{
        //  m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
        //navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        //   }
    }
}
