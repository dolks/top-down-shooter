using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject pathPrefab;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float timeBetweenSpawns = 0.5f;

    public List<Transform> GetWaypoints()
    {
        var waypointsToAdd = new List<Transform>();
        foreach (Transform waypointTransform in pathPrefab.transform)
        {
            waypointsToAdd.Add(waypointTransform);
        }

        return waypointsToAdd;
    }

    public GameObject GetEnemyPrefab() { return enemyPrefab; }

    public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }

    public float GetNumberOfEnemies() { return numberOfEnemies; }

    public float GetMoveSpeed() { return moveSpeed; }

}
