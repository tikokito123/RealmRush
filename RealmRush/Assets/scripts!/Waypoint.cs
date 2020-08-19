using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Color exploredColor;
    public bool isExplored = false;
    public Waypoint exploredFrom;
    Vector2Int gridPos;
    const int gridSize = 10;
    public bool isPlaceable = true;
    [SerializeField] Tower towerPrefab;
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isPlaceable)
            {
                print("you can't here!");
            }
            else
            {
                print("you cant put another than one towers in the same place!");
                Instantiate(towerPrefab, transform.position, Quaternion.identity);
                isPlaceable = false;
            }
        }
    }
    public int GetGridSize()
    {
        return gridSize;
    }
    public Vector2Int getGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
            );
    }
}
