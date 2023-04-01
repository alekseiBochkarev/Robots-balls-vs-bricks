using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell 
{
    public float centerX;
    public float centerY;
    public bool IsOccupied;

    public GridCell(float x, float y, bool isOccupied)
    {
        this.centerX = x;
        this.centerY = y;
        this.IsOccupied = isOccupied;
    }
}
