/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCollider : MonoBehaviour
{
    private int x, y;
    private Grid grid;
    private LevelConfig m_levelConfig;

    private void Awake() {
        m_levelConfig = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LevelConfig>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Brick>() != null || collider.gameObject.GetComponent<ScoreBall>() != null)
        {
            m_levelConfig.grid.SetValue(x, y, 1);
          //  Debug.Log("GRID COLLIDER TRIGGER ENTER");
        } 
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.GetComponent<Brick>() != null || collider.gameObject.GetComponent<ScoreBall>() != null)
        {
            m_levelConfig.grid.SetValue(x, y, 0);
           // Debug.Log("GRID COLLIDER TRIGGER EXIT");
        } 
    }


    public int X
    {
        set
        {
            if(value >= 0)
                x = value;
        }
    }

    public int Y
    {
        set
        {
            if(value >= 0)
                y = value;
        }
    }


}
*/