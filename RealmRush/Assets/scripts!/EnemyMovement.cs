using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 1f;
    [SerializeField] GameObject suicide;
    void Start()
    {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(PrintAllWayPoints(path));
    }

    IEnumerator PrintAllWayPoints(List<Waypoint> path)
    {
        foreach (Waypoint wayPoints in path)
        {
            transform.position = wayPoints.transform.position;
            yield return new WaitForSeconds(movementSpeed);
        }
        var shipsuicide = Instantiate(suicide, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(shipsuicide.gameObject, 1f);
    }
}
