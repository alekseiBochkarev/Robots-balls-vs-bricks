using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBall: MonoBehaviour, IBall
{
    public AbstractBall ()
    {

    }

    public AttackBehaviour attackBehaviour;
    public AfterCollisionBehaviour afterCollisionBehaviour;

    //here special balls will be realize unical attack mechanics
    public void SpecialAttack(Vector3 position)
    {
        attackBehaviour.SpecialAttack(position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        afterCollisionBehaviour.DestroyAfterCollision();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
       afterCollisionBehaviour.DestroyAfterCollision();
    }


    public GameObject hero;
    public static Vector3 s_FirstCollisionPoint { private set; get; }
    private static int s_ReturnedBallsAmount = 0;
    public int attackPower;

    private Rigidbody2D m_Rigidbody2D;
    private CircleCollider2D m_Collider2D;
    private SpriteRenderer m_SpriteRenderer;

    public int m_WallCollisionDuration = 0;

    [SerializeField] private float m_MoveSpeed = 10;

    public float m_MinimumYPosition = -4.09f;
    float rot_z;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Rigidbody2D.bodyType = RigidbodyType2D.Static;

        m_Collider2D = GetComponent<CircleCollider2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        hero = GameObject.Find("Hero");
        attackPower = hero.GetComponent<Hero>().attackSkill;
    }

    public int GetAttackPower
    {
        get
        {
            return attackPower;
        }
    }

    void Update()
    {
        if (m_Rigidbody2D.bodyType != RigidbodyType2D.Dynamic)
            return;

        m_Rigidbody2D.velocity = m_Rigidbody2D.velocity.normalized * m_MoveSpeed;
        RotateBall();
        if (transform.localPosition.y < m_MinimumYPosition)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, m_MinimumYPosition, 0);

            if (s_FirstCollisionPoint == Vector3.zero)
            {
                s_FirstCollisionPoint = transform.position;
                BallLauncher.Instance.m_BallSprite.transform.position = s_FirstCollisionPoint;
                BallLauncher.Instance.m_BallSprite.enabled = true;
            }

            DisablePhysics();
            MoveTo(s_FirstCollisionPoint, iTween.EaseType.linear, (Vector2.Distance(transform.position, s_FirstCollisionPoint) / 5.0f), "Deactive");
        }
    }

    void RotateBall()
    {
        rot_z = Mathf.Atan2(m_Rigidbody2D.velocity.y, m_Rigidbody2D.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    private static void ContinuePlaying()
    {
        Debug.Log("ContinuePlaying");
        if (s_FirstCollisionPoint != Vector3.zero)
            BallLauncher.Instance.transform.position = s_FirstCollisionPoint;

        BallLauncher.Instance.m_BallSprite.enabled = true;
        BallLauncher.Instance.ActivateHUD();

        ScoreManager.Instance.UpdateScore();

        BrickSpawner.Instance.MoveDownBricksRows();
        BrickSpawner.Instance.SpawnNewBricks();

        s_FirstCollisionPoint = Vector3.zero;
        s_ReturnedBallsAmount = 0;

        EventManager.OnBallsReturned();

        BallLauncher.Instance.m_CanPlay = true;
        BallLauncher.Instance.FindBricksAndSetRigidbodyType(RigidbodyType2D.Dynamic);
    }

    public static void ResetFirstCollisionPoint()
    {
        s_FirstCollisionPoint = Vector3.zero;
    }

    public static void ResetReturningBallsAmount()
    {
        s_ReturnedBallsAmount = 0;
    }

    public void GetReadyAndAddForce(Vector2 direction)
    {
        m_SpriteRenderer.enabled = true;
        m_Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        m_Collider2D.enabled = true;
        m_Rigidbody2D.AddForce(direction);
    }

    public void Disable()
    {
        m_SpriteRenderer.enabled = false;
        m_Collider2D.enabled = false;
        m_Rigidbody2D.bodyType = RigidbodyType2D.Static;
    }

    public void DisablePhysics()
    {
        m_Collider2D.enabled = false;
        m_Rigidbody2D.bodyType = RigidbodyType2D.Static;
    }

    public void MoveTo(Vector3 position, iTween.EaseType easeType = iTween.EaseType.linear, float time = 0.1f, string onCompleteMethod = "Deactive")
    {
        iTween.Stop(gameObject);

        if (m_SpriteRenderer.enabled)
            iTween.MoveTo(gameObject, iTween.Hash("position", position, "easetype", easeType, "time", time,
                "oncomplete", onCompleteMethod));
    }

    private void Deactive()
    {
        s_ReturnedBallsAmount++;    // then check all of balls are returned to the floor
        //INPOTANT PLACE - HERE I CAN ADD ATACK (BOCH ALEKSEI)
        if (s_ReturnedBallsAmount == BallLauncher.Instance.m_BallsAmount)
            ContinuePlaying();

        m_SpriteRenderer.enabled = false;
    }

    private void DeactiveSprite()
    {
        m_SpriteRenderer.enabled = false;
    }
}

