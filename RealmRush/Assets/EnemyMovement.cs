using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;
    void Start()
    {
        StartCoroutine(PrintAllWayPoints());
    }

     IEnumerator PrintAllWayPoints()
    {
        print("Starting patrol... ");
        foreach (Waypoint wayPoints in path)
        {
            transform.position = wayPoints.transform.position;
            print("visiting block: " + wayPoints);
            yield return new WaitForSeconds(1f);
        }
        print("Ending Patrol");
    }
}
