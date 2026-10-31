using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints; // GameObject Is an Array Meaning It Contains Multiple Variables
    int currentWaypointIndex = 0;

    [SerializeField] float speed = 1f;



    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < .1f) // Checks how Far We Are From Currently Active Waypoint If We Touch It We Move To The Next One Vice Versa
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }


        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime); // Caluclates New Position And We Move To Next Active Waypoint
        
    }
}