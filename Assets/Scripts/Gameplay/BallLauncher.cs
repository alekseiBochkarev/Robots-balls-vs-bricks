using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallLauncher : MonoBehaviour
{
    public static BallLauncher Instance;
    [SerializeField]
    private Vector3 m_StartPosition;
    private Vector3 m_EndPosition;
    private Vector3 m_WorldPosition;

    private Vector3 ballStartPostitionCoordinates = new Vector3(0, ballStartPositionCoordinatesY);
    public static float ballStartPositionCoordinatesY = -4.32f;

    private Vector3 m_Direction;
    private Balls m_BallsScript;

    private Vector3 m_DefaultStartPosition;
    [Header("For all bricks and scoreballs and magicballs")]
    private SpriteRenderer m_BallSprite;
    public bool colliderTriggered = false;

    public bool m_CanPlay = true;
    [SerializeField] private GameObject m_DeactivatableChildren;
    [Header("Bricks")]
    //public Brick[] bricks;
    Collider2D[] colliders;

    [Header("Linerenderer Colors")]
    public Color m_CorrectLineColor;    // it will be displayed for correct angles
    public Color m_WrongLineColor;      // it will be displayed for wrong angles

    [Header("Balls")]
    // public int m_BallsAmount;
    public int m_TempAmount = 0;  // for score balls
    public Text m_BallsText;
    //[SerializeField] private int m_StartingBallsPoolAmount = 10;
    // [SerializeField] private AbstractBall m_BallPrefab;
    // [SerializeField] private List<AbstractBall> m_Balls;

    [Header("UI Elements")]
    [SerializeField] private GameObject m_ReturnBallsButton;
    public GameObject topBorder;
    public GameObject leftBorder;
    public GameObject rightBorder;
    public GameObject bottomBorder;
    public GameObject ballStartPrefab;
    private GameObject ballStartPosition;

    private void Awake()
    {
        Instance = this;
        m_CanPlay = true;
        ballStartPosition = Instantiate(ballStartPrefab, ballStartPostitionCoordinates, new Quaternion(0, 180, 0, 1));
        ballStartPosition.transform.SetParent(this.transform.parent, false);
        m_BallSprite = ballStartPosition.GetComponent<SpriteRenderer>();
        m_DefaultStartPosition = transform.position;

        //m_BallsAmount = PlayerPrefs.GetInt("balls", 1);
        m_BallsScript = GetComponent<Balls>();
    }

    private void Start()
    {
        ShowBallsAmountOnHUD(); 
        m_ReturnBallsButton.SetActive(false);
    }

    public void ShowBallsAmountOnHUD()
    {
        m_BallsScript.SavePlayerBallsAmount();
        m_BallsText.text = "x" + m_BallsScript.PlayerBallsAmount.ToString();
    }
    
    public void ChangePositionAndSetTrue(Vector3 s_FirstCollisionPoint)
    {
        m_BallSprite.transform.position = s_FirstCollisionPoint;
        m_BallSprite.enabled = true;
    }

    private void Update()
    {
        if (LevelManager.Instance.m_LevelState == LevelManager.LevelState.GAMEOVER)
            return;

        if (!m_CanPlay)
            return;

        if(Time.timeScale != 0 && LevelManager.Instance.m_LevelState != LevelManager.LevelState.GAMEOVER)
            m_WorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.back * -10;

        
       /* if (Input.GetMouseButtonDown(0)
            && m_WorldPosition.x >= leftBorder.transform.position.x
            && m_WorldPosition.x <= rightBorder.transform.position.x
            && m_WorldPosition.y <= topBorder.transform.position.y
            && m_WorldPosition.y >= bottomBorder.transform.position.y)
            StartDrag(m_WorldPosition);
        else */
        if (Input.GetMouseButton(0)
            && m_WorldPosition.x >= leftBorder.transform.position.x
            && m_WorldPosition.x <= rightBorder.transform.position.x
            && m_WorldPosition.y <= topBorder.transform.position.y
            && m_WorldPosition.y >= bottomBorder.transform.position.y)
            ContinueDrag(m_WorldPosition);
        else if (Input.GetMouseButtonUp(0)
            && m_WorldPosition.x >= leftBorder.transform.position.x
            && m_WorldPosition.x <= rightBorder.transform.position.x
            && m_WorldPosition.y <= topBorder.transform.position.y
            && m_WorldPosition.y >= bottomBorder.transform.position.y)
            EndDrag();
    }

    private void StartDrag(Vector3 worldPosition)
    {
        GetComponent<AimLine>().AimLineDraw(ballStartPosition.transform.position, worldPosition);
        m_EndPosition = worldPosition;
        //m_StartPosition = worldPosition;
       // Debug.Log("startPosition " + m_StartPosition);
    }
    
    private void ContinueDrag(Vector3 worldPosition)
    {
        GetComponent<AimLine>().AimLineDraw(ballStartPosition.transform.position, worldPosition);
		m_EndPosition = worldPosition;
    }

    private void EndDrag()
    {
        if (m_StartPosition == m_EndPosition)
            return;
		GetComponent<AimLine>().RemoveDraw();
       // m_Direction = m_EndPosition - m_StartPosition;
        m_Direction = m_EndPosition - ballStartPosition.transform.position;
        m_CanPlay = false;
        StartCoroutine(StartShootingBalls());
    }
    
    public void OnMainMenuActions()
    {
        m_CanPlay = false;

        //check what it is!!!!!
        // m_BallsAmount = 1;
        ShowBallsAmountOnHUD();
        // m_BallsText.text = "x" + m_BallsAmount.ToString();

        m_BallSprite.enabled = true;
        m_DeactivatableChildren.SetActive(true);

        transform.position = m_DefaultStartPosition;
       // m_BallSprite.transform.position = m_DefaultStartPosition;

        ResetPositions();

        m_TempAmount = 0;
        EventManager.OnResetReturningBallsAmount();
        //AbstractBall.ResetReturningBallsAmount();

        m_ReturnBallsButton.SetActive(false);

        HideAllBalls();
    }

    public void ResetPositions()
    {
        m_StartPosition = Vector3.zero;
        m_EndPosition = Vector3.zero;
        m_WorldPosition = Vector3.zero;
    }

    private void HideAllBalls()
    {
        for (int i = 0; i < m_BallsScript.PlayerBalls.Count; i++)
        {
            m_BallsScript.PlayerBalls[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            m_BallsScript.PlayerBalls[i].Disable();
        }
    }

    IEnumerator StartShootingBalls()
    {
        m_BallSprite.enabled = false;

        int balls = m_BallsScript.PlayerBallsAmount;
        
        for (int i = 0; i < m_BallsScript.PlayerBallsAmount; i++)
        {
            if (m_CanPlay)
                break;
            if (m_BallsScript.PlayerBalls[i] != null)
            {
                m_BallsScript.PlayerBalls[i].transform.position = transform.position;
                m_BallsScript.PlayerBalls[i].GetReadyAndAddForce(m_Direction);

                balls--;
                m_BallsText.text = "x" + balls.ToString();   
            }
            yield return new WaitForSeconds(0.05f);
        }
        m_ReturnBallsButton.SetActive(true);
        if(balls <= 0)
            m_DeactivatableChildren.SetActive(false);
    }

    public void ActivateHUD()
    {
        m_BallsScript.IncreaseBallsAmountFromOutSide(m_TempAmount);
        m_BallsScript.SpawnNewBall(m_TempAmount, BallsTypeEnum.Ball);
       // m_BallsAmount += m_TempAmount;

        // avoiding more balls than final brick level - I SHOULD AVOID THIS. IF I will use extra balls. Bochkarev Aleksei
        /*
        if (m_BallsAmount > ScoreManager.Instance.m_LevelOfFinalBrick)
            m_BallsAmount = ScoreManager.Instance.m_LevelOfFinalBrick;
        */
        m_TempAmount = 0;

        m_BallsText.text = "x" + m_BallsScript.PlayerBallsAmount.ToString();
        m_DeactivatableChildren.SetActive(true);
        m_ReturnBallsButton.SetActive(false);
    }

    public void ReturnAllBallsToNewStartPosition()
    {
       // Debug.Log("ReturnAllBallsToNewStartPosition");
        if(AbstractBall.s_FirstCollisionPoint != Vector3.zero)
        {
            transform.position = AbstractBall.s_FirstCollisionPoint;
            AbstractBall.ResetFirstCollisionPoint();
        }

        for (int i = 0; i < m_BallsScript.PlayerBalls.Count; i++)
        {
            m_BallsScript.PlayerBalls[i].DisablePhysics();
            m_BallsScript.PlayerBalls[i].MoveTo(transform.position, iTween.EaseType.easeInOutQuart, (Vector2.Distance(transform.position, m_BallsScript.PlayerBalls[i].transform.position) / 6.0f), "Deactive");
        }

    }

    public void ReturnBallToStartPosition (AbstractBall ball) {
        if(AbstractBall.s_FirstCollisionPoint != Vector3.zero)
        {
            transform.position = AbstractBall.s_FirstCollisionPoint;
            //AbstractBall.ResetFirstCollisionPoint();
        }
            ball.Disable();
            ball.MoveToStartPosition(transform.position, iTween.EaseType.easeInOutQuart, (Vector2.Distance(transform.position, ball.transform.position) / 6.0f), "Deactive");
    }

    public void ContinuePlaying()
    {
       // Debug.Log("ContinuePlaying");
        
        if(AbstractBall.s_FirstCollisionPoint != Vector3.zero)
        {
            transform.position = AbstractBall.s_FirstCollisionPoint;
            AbstractBall.ResetFirstCollisionPoint();
        }
        ResetPositions();
        m_BallSprite.enabled = true;
        ActivateHUD();

        ScoreManager.Instance.UpdateScore();

        //BrickSpawner.Instance.MoveDownBricksRows();
        StartCoroutine(MoveBricksAndSpawnNewBricks());

        EventManager.OnAllBallsReturned();
        EventManager.OnResetReturningBallsAmount();
        //AbstractBall.ResetReturningBallsAmount();
        
        StartCoroutine(WaitAndCanPlay());
    }


    IEnumerator WaitAndCanPlay()
    {
        yield return new WaitForSeconds(1);
        m_CanPlay = true;
    }

    IEnumerator MoveBricksAndSpawnNewBricks()
    {
        //Debug.Log("BALL LAUNCHER start coroutine MoveDownBricks");
        yield return StartCoroutine(MoveDownBricks());
        yield return StartCoroutine(MoveHorizontalBricks());
       // yield return StartCoroutine(SpawnBricks());
    }

    IEnumerator MoveDownBricks() {
        yield return BrickSpawner.Instance.MoveDownBricksRows();
        while (BrickSpawner.Instance.AllBricksMovedDown == false)
        {
            yield return null;
        }
    }

    IEnumerator MoveHorizontalBricks() {
        BrickSpawner.Instance.MoveHorizontalBricksRows();
        while (BrickSpawner.Instance.AllBricksMovedHorizontal == false)
        {
            yield return null;
        }
    }

    IEnumerator SpawnBricks() {
        BrickSpawner.Instance.SpawnNewBricks();
        while (BrickSpawner.Instance.AllObjectsCreated == false)
        {
            yield return null;
        }
    }

   

    // public void IncreaseBallsAmountFromOutSide(int amout)
    // {
    //     m_BallsAmount += amout;
    //     m_BallsText.text = "x" + m_BallsAmount.ToString();
    // }

    Vector2[] ConvertArray(Vector3[] v3)
    {
        Vector2[] v2 = new Vector2[v3.Length];
        for (int i = 0; i < v3.Length; i++)
        {
            Vector3 tempV3 = v3[i];
            v2[i] = new Vector2(tempV3.x, tempV3.y);
        }
        return v2;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
       // Debug.Log("GameObject2 collided with " + col.name);
        if (col.gameObject.GetComponent<Brick>() != null)
        {
            colliderTriggered = true;
        }   
    }

    void OnTriggerExit2D (Collider2D col)
    {
        if (col.gameObject.GetComponent<Brick>() != null)
        {
            colliderTriggered = false;
        }
    }
}