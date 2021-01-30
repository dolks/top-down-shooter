using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] WaveConfig waveConfig;
    [SerializeField] float hitpoints = 100;
    [SerializeField] float moveSpeed = 1f;

    List<Transform> waypoints;
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
        Debug.Log("waypoints:" + waypoints.Count);
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            Debug.Log("Getting target position" + targetPosition);
            var movementThisFrame = Time.deltaTime * moveSpeed;
            Debug.Log("Current position" + transform.position);
            transform.position = Vector2.MoveTowards(
                transform.position,
                targetPosition,
                movementThisFrame
            );
            Debug.Log("Transform pos after moving" + transform.position);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Debug.Log("Resetting to 0");
            waypointIndex = 0;
        }
    }

}
