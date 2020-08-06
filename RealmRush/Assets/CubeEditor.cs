using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;
    void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }
    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(waypoint.getGridPos().x,0f , waypoint.getGridPos().y);
    }

    private void UpdateLabel()
    {
        int gridSize = waypoint.GetGridSize();
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string labelText = waypoint.getGridPos().x / gridSize + "," + waypoint.getGridPos().y / gridSize;
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
