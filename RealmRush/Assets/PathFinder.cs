using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>(); 
    Waypoint searchCenter;
    public List<Waypoint> path = new List<Waypoint>(); // todo make private!
    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    bool isRunning = true;
    void Start()
    {
        LoadBlocks();
        SetStartAndEndColor();
        BreadthFirstSearch();
    }
    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            HalfIfEndFound();
            ExploreNeighbours();
        }
        print("finish?");
    }

    private void HalfIfEndFound()
    {
        if (searchCenter == endWaypoint)
        {
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning) { return; }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = searchCenter.getGridPos() + direction;
            try
            {
                QueueNewNeighbours(neighbourCoordinates);
            }
            catch
            {
                //bitch!!! IM DOING NOTHING SO SUCK MY FUCKING DICK YOOOO MR.WHITE LETS SELL SOME METH MR WHITE BITCH!
            }
        }
    }
    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = grid[neighbourCoordinates];
        if (neighbour.isExplored || queue.Contains(neighbour))
        { 
            //do nothing 
        }
        else
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
        }
    }
    private void SetStartAndEndColor()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
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
            }
        }
    }
}
