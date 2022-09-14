﻿using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public static BrickSpawner Instance;

    

    [Header("Spawning informations")]
    public int m_SpawningRows = 8;
    public BricksRow m_BricksRowPrefab;
    public float m_SpawningTopPosition = 2.88f;   // top position
    public float m_SpawningDistance = 0.8f; // distance of rows
    public GameObject brickPrefab;
    public GameObject scoreBallPrefab;
    public GameObject magicBallPrefab;
    public int maxObjectsInRow = 6;
    private Grid grid;
    private LevelConfig m_levelConfig;

    private float vision;
    Collider2D[] colliders;

    [Header("Bricks Row")]
    public List<BricksRow> m_BricksRow;
    [Header("Win Manager")]
    public WinManager winManager;

    private void Awake()
    {
        Instance = this;

        m_BricksRow = new List<BricksRow>();
        winManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<WinManager>();
        m_levelConfig = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LevelConfig>();
        grid = m_levelConfig.grid;
        maxObjectsInRow = grid.GridWidth-1;
        /*
        // generate rows of bricks on the scene
        for (int i = 0; i < m_SpawningRows; i++)
        {
            m_BricksRow.Add(Instantiate(m_BricksRowPrefab, transform.parent, false));
            m_BricksRow[m_BricksRow.Count - 1].transform.localPosition = new Vector3(0, m_SpawningTopPosition, 0);
            m_BricksRow[m_BricksRow.Count - 1].gameObject.SetActive(false);
        }
        */
    }


    public void HideAllBricksRows()
    {
        for (int i = 0; i < m_BricksRow.Count; i++)
            m_BricksRow[i].gameObject.SetActive(false);
    }

    public void SpawnNewBricks()
    {
        if (winManager != null)
        {
            if (winManager.GetMaxSpawn > ScoreManager.Instance.m_LevelOfFinalBrick)
            {
                SpawnBricks();
            } 
        } else
        {
            SpawnBricks();
        }
    }

    public void SpawnBricks ()
    {
        ScoreManager.Instance.m_LevelOfFinalBrick++;
        CreateBrickRow();
/*
        for (int i = 0; i < m_BricksRow.Count; i++)
        {
            if (!m_BricksRow[i].gameObject.activeInHierarchy)
            {
                //Debug.Log("SpawnNewBricks m_BricksRow " + i + "set active true");
                
                m_BricksRow[i].gameObject.SetActive(true);
                break;
            }
        }
*/
    }

    private void CreateBrickRow()
    {
        int numberOfScoreBallInRow = Random.Range(0, maxObjectsInRow);
        CreateObject(scoreBallPrefab, numberOfScoreBallInRow);
        bool createMagicBall = CheckIfICanCreateMagicBall();
        int numberOfMagicBallInRow = 0;
        if (createMagicBall)
        {
            numberOfMagicBallInRow = Random.Range(0, maxObjectsInRow);
            if (numberOfMagicBallInRow != numberOfScoreBallInRow)
            {
                CreateObject(magicBallPrefab, numberOfMagicBallInRow);
            }
        }
        for (int i = 0; i < maxObjectsInRow; i++)
        {
            if (CheckIfICanCreateBrick())
            {
                if (i != numberOfScoreBallInRow)
                {
                    if (!createMagicBall)
                    {
                        CreateObject(brickPrefab, i);
                    } else
                    {
                        if (i != numberOfMagicBallInRow)
                        {
                            CreateObject(brickPrefab, i);
                        }
                    }
                    
                }
            }
        }
    }

    private void CreateObject(GameObject prefab, int numberInRow)
    {
       Debug.Log("world pos " + grid.GetWorldPosition(numberInRow, 0));
       // Instantiate(prefab, new Vector3(getPositionX(numberInRow), 1.64f, 0), new Quaternion(0, 180, 0, 1));
       GameObject newObject = Instantiate(prefab, grid.GetWorldPosition(numberInRow, 0), new Quaternion(0, 180, 0, 1));
       newObject.GetComponent<MoveDownBehaviour>().MoveDown();
    }

    private float getPositionX (int number)
    {
        return -2.32f + number * 0.94f;
    }

    private bool CheckIfICanCreateMagicBall ()
    {
        //30% chanse
        return Random.Range(0, 3) == 1 ? true : false;
    }

    private bool CheckIfICanCreateBrick ()
    {
        return Random.Range(0, 2) == 1 ? true : false;
    }

    public void MoveDownBricksRows()
    {
        vision = 10f; //need to check maybe we should set more than 10
        colliders = Physics2D.OverlapCircleAll(transform.position, vision);
        for (int y = grid.GridHeight-1; y >= 0; y--) {
            for (int x = 0; x <= grid.GridWidth-1; x ++) {
                if (grid.GetValue(x, y)== 1) {
                    for (int i = 0; i < colliders.Length; i ++) {
                        if (colliders[i].gameObject == gameObject) continue;
                        if (colliders[i].gameObject.GetComponentInParent<MoveDownBehaviour>() != null) {
                            if (colliders[i].gameObject.GetComponentInParent<MoveDownBehaviour>().X == x && colliders[i].gameObject.GetComponentInParent<MoveDownBehaviour>().Y == y) {
                                colliders[i].gameObject.GetComponentInParent<MoveDownBehaviour>().MoveDown();
                            }
                        }
                    }
                }
            }
        } 
        /*
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject == gameObject) continue;
            if (colliders[i].gameObject.GetComponentInParent<MoveDownBehaviour>() != null)
            {
               colliders[i].gameObject.GetComponentInParent<MoveDownBehaviour>().MoveDown(m_SpawningDistance);
            }
        }
        */

        /*
        for (int i = 0; i < m_BricksRow.Count; i++)
            if (m_BricksRow[i].gameObject.activeInHierarchy)
                m_BricksRow[i].MoveDown(m_SpawningDistance);
        */
    }

    public void MoveHorizontalBricksRows()
    {
        vision = 10f; //need to check maybe we should set more than 10
        colliders = Physics2D.OverlapCircleAll(transform.position, vision);
        for (int y = grid.GridHeight-1; y >= 0; y--) {
            for (int x = 0; x <= grid.GridWidth-1; x ++) {
                if (grid.GetValue(x, y)== 1) {
                    for (int i = 0; i < colliders.Length; i ++) {
                        if (colliders[i].gameObject == gameObject) continue;
                        if (colliders[i].gameObject.GetComponentInParent<MoveDownBehaviour>() != null) {
                            if (colliders[i].gameObject.GetComponentInParent<MoveDownBehaviour>().X == x && colliders[i].gameObject.GetComponentInParent<MoveDownBehaviour>().Y == y) {
                                colliders[i].gameObject.GetComponentInParent<MoveDownBehaviour>().MoveHorizontal();
                            }
                        }
                    }
                }
            }
        } 
    }

    void Update()
    {
        winManager.CheckIfWin();
    }
}