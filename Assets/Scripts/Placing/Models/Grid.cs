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
    private float gridCenter = .5f;

    public Grid(int width, int height, float cellSize, Vector3 originPosition) {
        //Debug.Log("grid" + " " + width + " " + height + " " + cellSize + " " + originPosition);
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;
        gridArray = new int[width, height];
        
        debugTextArray = new TextMesh[width, height]; 
        DebugDraw();
    }

    public void DebugDraw () {
        
       /* for (int x=0; x < gridArray.GetLength(0); x++) {
            for (int y = 0; y < gridArray.GetLength(1); y++) {
                //Debug.Log (x + ", " + y + ", " + cellSize + ", worldpos" + GetWorldPosition(x,y));
               debugTextArray[x, y] = UtilsClass.CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPosition(x, y) , 12, Color.black, TextAnchor.MiddleCenter);
              // Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.black, 100f);
              // Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1 , y), Color.black, 100f);
            }
        }*/
      //  Debug.DrawLine(GetWorldPosition(0 , height ), GetWorldPosition(width, height), Color.black, 100f);
       // Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.black, 100f);
    }

    public Vector3 GetWorldPosition(int x, int y) {
      //  return new Vector3(x-1/2, -y+1/2) * cellSize + originPosition;
      return new Vector3(x+gridCenter, -(y+gridCenter)) * cellSize + originPosition;
    }

    public void GetXY (Vector3 worldPosition, out int x, out int y) {
        //x = Mathf.FloorToInt(((worldPosition.x  - originPosition.x ) / cellSize) - .5f );
        x = (int)Mathf.Round(((worldPosition.x  - originPosition.x ) / cellSize) - gridCenter );
        y = (int)Mathf.Round((-(worldPosition.y - originPosition.y ) / cellSize) - gridCenter );
        //int test = (int)Mathf.Round(-(0.144f-2.664f)/0.72f - 0.5f); 
       //Debug.Log("worldpos " + worldPosition + " x " + x + " y " + y + " originPos " + originPosition.y );
       //Debug.Log("test (int)(-(0.144f-2.664f)/0.72f - 0.5f) " + test);
    }

    public void SetValue(int x, int y, int value) {
        if (x>=0 && y >=0 && x < width && y < height) {
            gridArray[x, y] = value;
           // debugTextArray[x, y].text = gridArray[x, y].ToString();
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
