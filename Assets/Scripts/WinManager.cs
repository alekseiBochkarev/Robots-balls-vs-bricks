using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    private int maxSpawn = 20;
    public int GetMaxSpawn
    {
        get
        {
            return maxSpawn;
        }
    }

    public void CheckIfWin ()
    {
        if (ScoreManager.Instance.m_LevelOfFinalBrick == GetMaxSpawn)
        {
            GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");
            if (bricks.Length == 0)
            {
                LevelManager.Instance.m_LevelState = LevelManager.LevelState.WIN;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
