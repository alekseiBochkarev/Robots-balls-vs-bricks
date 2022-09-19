using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Grid{

    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private int [,] gridArray;
    private TextMesh[,] debugTextArray;

    public Grid(int width, int height, float cellSize, Vector3 originPosition) {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;
        gridArray = new int[width, height];
        
        debugTextArray = new TextMesh[width, height]; 
        DebugDraw();
    }

    public void DebugDraw () {
        
        for (int x=0; x < gridArray.GetLength(0); x++) {
            for (int y = 0; y < gridArray.GetLength(1); y++) {
                //Debug.Log (x + ", " + y + ", " + cellSize + ", worldpos" + GetWorldPosition(x,y));
               debugTextArray[x, y] = UtilsClass.CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPosition(x, y) , 12, Color.black, TextAnchor.MiddleCenter);
              // Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.black, 100f);
              // Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1 , y), Color.black, 100f);
            }
        }
      //  Debug.DrawLine(GetWorldPosition(0 , height ), GetWorldPosition(width, height), Color.black, 100f);
       // Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.black, 100f);
    }

    public Vector3 GetWorldPosition(int x, int y) {
      //  return new Vector3(x-1/2, -y+1/2) * cellSize + originPosition;
      return new Vector3(x+.5f, -y-.5f) * cellSize + originPosition;
    }

    public void GetXY (Vector3 worldPosition, out int x, out int y) {
        x = Mathf.FloorToInt(((worldPosition - originPosition).x / cellSize) - .5f);
        y = Mathf.FloorToInt((-(worldPosition - originPosition).y / cellSize) - .5f);
    }

    public void SetValue(int x, int y, int value) {
        if (x>=0 && y >=0 && x < width && y < height) {
            gridArray[x, y] = value;
         //   debugTextArray[x, y].text = gridArray[x, y].ToString();
        }
    }

    public void SetValue(Vector3 worldPosition, int value) {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

    public int GetValue(int x, int y) {
        if (x>=0 && y >=0 && x < width && y < height) {
            return gridArray[x, y];
        }
        return -1;
    }

    public int GridWidth
    {
        get
        {
            return width;
        }
    }

    public int GridHeight
    {
        get
        {
            return height;
        }
    }
}
