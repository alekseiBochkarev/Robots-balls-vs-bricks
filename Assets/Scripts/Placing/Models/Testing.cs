using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour
{
    private Grid grid;    
    
    private void Start()
    {
        grid = new Grid(3, 4, 1f, new Vector3(-2.832f, 2.664f));
    }

    private void Update () {
        if (Input.GetMouseButtonDown(0)) {
            grid.SetValue(UtilsClass.GetMouseWorldPosition(), 56);
        }
    }

}
