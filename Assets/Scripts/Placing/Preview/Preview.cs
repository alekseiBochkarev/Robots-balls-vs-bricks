using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Preview : MonoBehaviour
{
    [SerializeField] private Placable Placable;

    public Vector2Int Size;
    private Vector2Int currentGridPose;

    private bool isPlacingAvailable;
    private bool isMoving;

    protected SpriteRenderer MainRenderer;
    private Color green;
    private Color red;

    private void Awake()
    {
        MainRenderer = GetComponentInChildren<SpriteRenderer>();
        green = new Color(0, 1f, .3f, .8f);
        red = new Color(1, .2f, .2f, .8f);
    }

    public void OnDrag()
    {
        isMoving = true;
    }

    public void StopDrag()
    {
        isMoving = false;
    }

    public void SetCurrentMousePosition(Vector2 position, Vector2Int GridPose, Func<Boolean> isBuildAvailable)
    {
        if (isMoving)
        {
            transform.position = position;
            currentGridPose = GridPose;
            SetBuildAvailable(isBuildAvailable());
        }
    }

    public void SetSpawnPosition(Vector2Int GridPose)
    {
        currentGridPose = GridPose;
    }

    public Placable InstantiateHere()
    {
        if (isPlacingAvailable)
        {
            Vector2Int size = GetSize();

            Cell[] placeInGrid = new Cell[size.x * size.y];
            int index = 0;

            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    placeInGrid[index++] = new Cell(currentGridPose.x + x, currentGridPose.y + y);
                }
            }

            Placable placable = InitPlacable(placeInGrid);
            Destroy(gameObject);
            return placable;
        }

        return null;
    }

    private Placable InitPlacable(Cell[] placeInGrid)
    {
        Placable placable = Instantiate(Placable, transform.position, Quaternion.identity);
        placable.GridPlace = new GridPlace(placeInGrid);
        return placable;
    }

    public void SetBuildAvailable(bool available)
    {
        isPlacingAvailable = available;
        MainRenderer.material.color = available ? green : red;
    }

    public bool IsBuildAvailable()
    {
        return isPlacingAvailable;
    }

    public virtual Vector2Int GetSize()
    {
        return Size;
    }
}
