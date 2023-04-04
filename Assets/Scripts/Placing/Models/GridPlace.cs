using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlace 
{
    private Cell[] place;

    public Cell[] Place { get => place; set => place = value; }

    public GridPlace(Cell[] place)
    {
        this.place = place;
    }
}
