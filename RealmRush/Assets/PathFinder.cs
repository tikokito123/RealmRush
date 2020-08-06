using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    void Start()
    {
        LoadBlocks();
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (var waypoint in waypoints)
        {
            if (grid.ContainsKey(waypoint.getGridPos()))
            {
                Debug.LogWarning("OverLapping Block!" + waypoint);
            }
            else
            {
                grid.Add(waypoint.getGridPos(), waypoint);
                waypoint.SetTopColor(Color.black);
            }
        }
        print(grid.Count + " blocks!");
    }
}
