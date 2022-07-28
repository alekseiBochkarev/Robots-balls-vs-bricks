using System.Collections.Generic;
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

    [Header("Bricks Row")]
    public List<BricksRow> m_BricksRow;
    [Header("Win Manager")]
    public WinManager winManager;

    private void Awake()
    {
        Instance = this;

        m_BricksRow = new List<BricksRow>();
        winManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<WinManager>();

        // generate rows of bricks on the scene
        for (int i = 0; i < m_SpawningRows; i++)
        {
            m_BricksRow.Add(Instantiate(m_BricksRowPrefab, transform.parent, false));
            m_BricksRow[m_BricksRow.Count - 1].transform.localPosition = new Vector3(0, m_SpawningTopPosition, 0);
            m_BricksRow[m_BricksRow.Count - 1].gameObject.SetActive(false);
        }
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
        for (int i = 0; i < m_BricksRow.Count; i++)
        {
            if (!m_BricksRow[i].gameObject.activeInHierarchy)
            {
                //Debug.Log("SpawnNewBricks m_BricksRow " + i + "set active true");
                CreateBrickRow();
                m_BricksRow[i].gameObject.SetActive(true);
                break;
            }
        }
    }

    private void CreateBrickRow()
    {
        int numberOfScoreBallInRow = Random.Range(0, maxObjectsInRow);
        CreateObject(scoreBallPrefab, numberOfScoreBallInRow);
        bool createMagicBall = CreateMagicBall();
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
            if (IfCreateBrick())
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
        Instantiate(prefab, new Vector3(getPositionX(numberInRow), 1.66f, 0), new Quaternion(0, 180, 0, 1));
    }

    private float getPositionX (int number)
    {
        return -2.34f + number * 0.94f;
    }

    private bool CreateMagicBall ()
    {
        //30% chanse
        return Random.Range(0, 3) == 1 ? true : false;
    }

    private bool IfCreateBrick ()
    {
        return Random.Range(0, 2) == 1 ? true : false;
    }

    public void MoveDownBricksRows()
    {
        for (int i = 0; i < m_BricksRow.Count; i++)
            if (m_BricksRow[i].gameObject.activeInHierarchy)
                m_BricksRow[i].MoveDown(m_SpawningDistance);
    }

    void Update()
    {
        winManager.CheckIfWin();
    }
}