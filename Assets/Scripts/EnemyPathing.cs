﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] WaveConfig waveConfig;
    List<Transform> waypoints;
    [SerializeField] float moveSpeed = 5f;
    int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = Time.deltaTime * moveSpeed;
            transform.position = Vector2.MoveTowards(
                transform.position,
                targetPosition,
                movementThisFrame
            );
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            waypointIndex = 0;
        }
    }

}
