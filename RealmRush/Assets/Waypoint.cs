﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Color exploredColor;
    public bool isExplored = false;
    public Waypoint exploredFrom;
    Vector2Int gridPos;
    const int gridSize = 10;
    private void Update()
    {
        if (isExplored)
        {
            exploredColor = Color.white;
            exploredFrom.SetTopColor(exploredColor);
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
    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
}
