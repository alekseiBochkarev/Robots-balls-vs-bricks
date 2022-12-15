using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public static BrickSpawner Instance;

    

    [Header("Spawning informations")]
   // [SerializeField] private int m_SpawningRows = 8;
   // public BricksRow m_BricksRowPrefab;
   // public float m_SpawningTopPosition = 2.88f;   // top position
    //public float m_SpawningDistance = 0.8f; // distance of rows
    public GameObject brickPrefab;
    public GameObject scoreBallPrefab;
    public GameObject magicBallPrefab;
    private int maxObjectsInRow;
    private LevelConfig m_levelConfig;
    [SerializeField] private bool allBricksMovedDown;
    [SerializeField] private bool allBricksMovedHorizontal;
    [SerializeField] private bool allObjectsCreated;

    private float vision;
    Collider2D[] colliders;

    [Header("Bricks Row")]
    //public List<BricksRow> m_BricksRow;
    [Header("Win Manager")]
    public WinManager winManager;

    private void Awake()
    {
        Instance = this;

        //m_BricksRow = new List<BricksRow>();
        winManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<WinManager>();
        m_levelConfig = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LevelConfig>();
        maxObjectsInRow = m_levelConfig.grid.GridWidth;

    }

    public bool AllBricksMovedDown
    {
        get
        {
            return allBricksMovedDown;
        }
    }

    public bool AllBricksMovedHorizontal
    {
        get
        {
            return allBricksMovedHorizontal;
        }
    }

    public bool AllObjectsCreated
    {
        get
        {
            return allObjectsCreated;
        }
    }

/*
    public void HideAllBricksRows()
    {
        for (int i = 0; i < m_BricksRow.Count; i++)
            m_BricksRow[i].gameObject.SetActive(false);
    }*/

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

    }

    private void CreateBrickRow()
    {
        allObjectsCreated = false;
        int numberOfScoreBallInRow = Random.Range(0, maxObjectsInRow);
        if (CheckIfICanCreateScoreBall()) {
            CreateObject(scoreBallPrefab, numberOfScoreBallInRow);
        }
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
        allObjectsCreated = true;
    }

    private void CreateObject(GameObject prefab, int numberInRow)
    {
        if (m_levelConfig.grid.GetValue(numberInRow, 0+1) == 0) {
            GameObject newObject = Instantiate(prefab, m_levelConfig.grid.GetWorldPosition(numberInRow, 0), new Quaternion(0, 180, 0, 1));
            newObject.transform.localScale *= m_levelConfig.ScaleCoefficient;
            newObject.GetComponentInChildren<MoveDownBehaviour>().MoveDown();
        }
       // Instantiate(prefab, new Vector3(getPositionX(numberInRow), 1.64f, 0), new Quaternion(0, 180, 0, 1)); 
    }

//check it should not be used now
    private float getPositionX (int number)
    {
        return -2.32f + number * 0.94f;
    }

    private bool CheckIfICanCreateScoreBall ()
    {
        //30% chanse
        return Random.Range(0, 3) == 1 ? true : false;
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
        //Debug.Log("MOVE DOWN BRICK ROWS");
        allBricksMovedDown = false;
        vision = 10f; //need to check maybe we should set more than 10
        colliders = Physics2D.OverlapCircleAll(transform.position, vision);
        for (int y = m_levelConfig.grid.GridHeight-1; y >= 0; y--) {
            for (int x = 0; x <= m_levelConfig.grid.GridWidth-1; x++) {
                
                    for (int i = 0; i < colliders.Length; i ++) {
                        if (colliders[i].gameObject == gameObject) continue;
                        if (colliders[i].gameObject.GetComponent<MoveDownBehaviour>() != null) {
                            //Debug.Log("component MOVEDOWNBEHAVIOUR not null");
                            if (colliders[i].gameObject.GetComponent<MoveDownBehaviour>().X == x && colliders[i].gameObject.GetComponent<MoveDownBehaviour>().Y == y) {
                                //Debug.Log("component MOVEDOWN concrete COLLIDER");
                                colliders[i].gameObject.GetComponent<MoveDownBehaviour>().MoveDown();
                            }
                        }
                    }
                
            }
        } 
        allBricksMovedDown = true;
    }

    public void MoveHorizontalBricksRows()
    {
        allBricksMovedHorizontal = false;
        vision = 10f; //need to check maybe we should set more than 10
        colliders = Physics2D.OverlapCircleAll(transform.position, vision);
        for (int y = m_levelConfig.grid.GridHeight-1; y >= 0; y--) {
            for (int x = 0; x <= m_levelConfig.grid.GridWidth-1; x ++) {
                
                    for (int i = 0; i < colliders.Length; i ++) {
                        if (colliders[i].gameObject == gameObject) continue;
                        if (colliders[i].gameObject.GetComponent<MoveDownBehaviour>() != null) {
                            if (colliders[i].gameObject.GetComponent<MoveDownBehaviour>().X == x && colliders[i].gameObject.GetComponent<MoveDownBehaviour>().Y == y) {
                                colliders[i].gameObject.GetComponent<MoveDownBehaviour>().MoveHorizontal();
                            }
                        }
                    }
                
            }
        }
        allBricksMovedHorizontal = true; 
    }

    void Update()
    {
        winManager.CheckIfWin();
    }
}