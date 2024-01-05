using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INIMIGO : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 2f;
    public float stoppingDistance = 0.1f;

    private int currentWaypointIndex = 0;

    void Update()
    {
        if (waypoints.Length == 0)
            return;

        MoveTowardsWaypoint();
    }

    void MoveTowardsWaypoint()
    {
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, step);
        if (Vector2.Distance(transform.position, targetWaypoint.position) < stoppingDistance)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex == waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
    }
}


