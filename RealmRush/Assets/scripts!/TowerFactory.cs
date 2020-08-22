using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [Range(1,10)]
    [SerializeField] int towerLimit = 3;
    [SerializeField] Transform towerParentTransform;
    Queue<Tower> towers = new Queue<Tower>();
    public void AddTower(Waypoint baseWaypoint)
    {
        if (towers.Count < towerLimit)
        {
            InstantiateTower(baseWaypoint);
        }
        else
        {
            MoveExistTower(baseWaypoint);
        }
    }
    private void MoveExistTower(Waypoint newBaseWaypoint)
    {
        var oldTower = towers.Dequeue();
        oldTower.baseWaypoint.isPlaceable = true;
        newBaseWaypoint.isPlaceable = false;
        oldTower.baseWaypoint = newBaseWaypoint;
        oldTower.transform.position = newBaseWaypoint.transform.position;
        towers.Enqueue(oldTower);
    }

    private void InstantiateTower(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParentTransform;
        towers.Enqueue(newTower);
        newTower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;
    }
}   
