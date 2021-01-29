using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject pathPrefab;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int numberOfEnemies;

    public List<Transform> GetWaypoints()
    {
        var waypointsToAdd = new List<Transform>();
        foreach (Transform waypointTransform in pathPrefab.transform)
        {
            waypointsToAdd.Add(waypointTransform);
        }
        Debug.Log("Test");

        return waypointsToAdd;
    }

}
