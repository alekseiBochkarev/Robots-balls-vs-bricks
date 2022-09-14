using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelConfig : MonoBehaviour
{
    [SerializeField] private int gridWidth;
    [SerializeField] private int gridHeight;
    [SerializeField] private float cellSize;
    [SerializeField] private Vector3 originPosition;
    public Grid grid;
     
    void Awake()
    {
        grid = new Grid(gridWidth, gridHeight, cellSize, originPosition);
    }

    
}
