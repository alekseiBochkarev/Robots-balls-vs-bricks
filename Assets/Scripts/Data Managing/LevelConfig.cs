using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class LevelConfig : MonoBehaviour
{
    [SerializeField] private int gridWidth;
    [SerializeField] private int gridHeight;
    private float cellSize;
    private float baseCellSize = 0.72f;
    private float scaleCoefficient;
    [SerializeField] private Vector3 originPosition;
    public Grid grid;
   // public GameObject gridColliderPrefab;
     
    void Awake()
    {
        gridHeight = gridWidth * 4 / 3 + 1;
        //Debug.Log("gridHeight " + gridHeight);
        scaleCoefficient = 6 / gridWidth;
        cellSize = baseCellSize * scaleCoefficient;
        grid = new Grid(gridWidth, gridHeight, cellSize, originPosition);
        //grid.SetValue(2,2,2); //- it's for test
        //grid.SetValue(1,1,1);
       /* for (int y = 0; y < grid.GridHeight; y++) {
            for (int x = 0; x < grid.GridWidth; x ++) {
                GameObject gridObj = Instantiate(gridColliderPrefab, grid.GetWorldPosition(x, y), new Quaternion(0, 180, 0, 1));
                gridObj.GetComponent<GridCollider>().X = x;
                gridObj.GetComponent<GridCollider>().Y = y;
            }
        }*/
    }

    public float ScaleCoefficient
    {
        get
        {
            return scaleCoefficient;
        }
    }


    
}
