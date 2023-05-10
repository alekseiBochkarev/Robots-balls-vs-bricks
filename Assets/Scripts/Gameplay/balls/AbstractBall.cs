using System;
using Assets.Scripts.Gameplay.Combo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBall: MonoBehaviour, IBall
{
    public AttackBehaviour attackBehaviour;
    public AfterCollisionBehaviour afterCollisionBehaviour;
    
    public GameObject hero;
    public static Vector3 s_FirstCollisionPoint { private set; get; }
    //private static int s_ReturnedBallsAmount = 0;
    public int attackPower;
    protected int damageTextFontSize;
    protected Color damageTextColor;

    private Rigidbody2D m_Rigidbody2D;
    private CircleCollider2D m_Collider2D;
    private SpriteRenderer m_SpriteRenderer;
    private TrailRenderer m_TrailRenderer;
    //private SpecialAttackPanelController m_SpecialAttackPanelController;

    public int m_WallCollisionDuration = 0;

    [SerializeField] private float m_MoveSpeed = 10;

    private float m_MinimumYPosition;
    float rot_z;

    public void Init() {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Rigidbody2D.bodyType = RigidbodyType2D.Static;
        m_MinimumYPosition = BallLauncher.ballStartPositionCoordinatesY;
        m_Collider2D = GetComponent<CircleCollider2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_TrailRenderer = GetComponent<TrailRenderer>();
        EventManager.UpgradeAttackPowerStat += InitAttackPower;

        //m_SpecialAttackPanelController = GameObject.Find("SpecialAttackUI").GetComponent<SpecialAttackPanelController>();
    }

    private void Awake()
    {
        Init();
    }

    private void OnDestroy()
    {
        EventManager.UpgradeAttackPowerStat -= InitAttackPower;
    }

    public AbstractBall ()
    {

    }

    private void InitAttackPower()
    {
        attackPower = hero.GetComponent<Hero>().attackSkill;
    }

    public void DestroyAfterTime()
    {
        Destroy(this.gameObject, 2f);
    }

    //here special balls will be realize unical attack mechanics
    public void SpecialAttack(Vector3 position, GameObject brick)
    {
        attackBehaviour.SpecialAttack(position, brick);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Brick>() != null){
            afterCollisionBehaviour.BehaviourAfterCollision();
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Brick>() != null) {
            afterCollisionBehaviour.BehaviourAfterCollision();
        } else if (collision.gameObject.tag.Equals("Floor")) {
            transform.localPosition = new Vector3(transform.localPosition.x, m_MinimumYPosition, 0);
            Debug.Log("BORDER");
            if (s_FirstCollisionPoint == Vector3.zero)
            {
                s_FirstCollisionPoint = transform.position;
                BallLauncher.Instance.ChangePositionAndSetTrue(s_FirstCollisionPoint);
            }

            DisablePhysics();
            MoveTo(s_FirstCollisionPoint, iTween.EaseType.linear, (Vector2.Distance(transform.position, s_FirstCollisionPoint) / 5.0f), "Deactive");
        }
        
    }

    void Start()
    {
        hero = GameObject.Find("Hero");
        InitAttackPower();
        afterCollisionBehaviour = this.gameObject.GetComponent<AfterCollisionBehaviour>();
    }

    public int GetAttackPower
    {
        get
        {
            return attackPower;
        }
    }

    public int GetDamageTextFontSize
    {
        get
        {
            return damageTextFontSize;
        }
    }

    public Color GetDamageTextColor
    {
        get
        {
            return damageTextColor;
        }
    }

    void Update()
    {
        if (m_Rigidbody2D.bodyType != RigidbodyType2D.Dynamic)
            return;

        m_Rigidbody2D.velocity = m_Rigidbody2D.velocity.normalized * m_MoveSpeed;
        RotateBall();
    }

    void RotateBall()
    {
        rot_z = Mathf.Atan2(m_Rigidbody2D.velocity.y, m_Rigidbody2D.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    public static void ResetFirstCollisionPoint()
    {
        s_FirstCollisionPoint = Vector3.zero;
    }

   /* public static void ResetReturningBallsAmount()
    {
        //s_ReturnedBallsAmount = 0;
        Debug.Log("ResetReturningBallsAmount");
        EventManager.OnResetReturningBallsAmount();
    }*/

    public void GetReadyAndAddForce(Vector2 direction)
    {
        m_SpriteRenderer.enabled = true;
        m_Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        m_Collider2D.enabled = true;
        m_Rigidbody2D.AddForce(direction);
        m_TrailRenderer.enabled = true;
    }

    public void Disable()
    {
        m_SpriteRenderer.enabled = false;
        m_TrailRenderer.enabled = false;
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

    public void MoveToStartPosition(Vector3 position, iTween.EaseType easeType = iTween.EaseType.linear, float time = 0.1f, string onCompleteMethod = "Deactive")
    {
        iTween.Stop(gameObject);

        iTween.MoveTo(gameObject, iTween.Hash("position", position, "easetype", easeType, "time", time,
                "oncomplete", onCompleteMethod));
    }

    private void Deactive()
    {
       // s_ReturnedBallsAmount++;
        EventManager.OnBallsReturned();
        m_SpriteRenderer.enabled = false;
            // then check all of balls are returned to the floor
        //INPOTANT PLACE - HERE I CAN ADD ATACK (BOCH ALEKSEI)
       // if (s_ReturnedBallsAmount == Balls.Instance.PlayerBallsAmount)
       //     StartCoroutine(OpenSpecAttackPanelAndContinuePlaying());
    }

 /*   IEnumerator OpenSpecAttackPanelAndContinuePlaying()
    {
        if (LevelManager.Instance.m_LevelState == LevelManager.LevelState.PLAYABLE)
        {
            int magicBallCount = m_SpecialAttackPanelController.GetMagicBallAmount();
            for (int i = 0; i < magicBallCount; i++)
            {
                yield return StartCoroutine(ShowSpecAttackPanelAndClose());
            }
        }
        BallLauncher.Instance.ContinuePlaying();
        m_SpriteRenderer.enabled = false;
    }
    
    IEnumerator ShowSpecAttackPanelAndClose()
    {
        while (ComboLauncher.Instance.CanPlay == false)
        {
            yield return new WaitForSeconds(1f);
        }
        m_SpecialAttackPanelController.ShowSpecAttackPanel();
        while (m_SpecialAttackPanelController.IsSpecAttackPanelOpened == true)
        {
            yield return null;
        }
        m_SpecialAttackPanelController.MinusMagicBallAmount();
    }*/

    private void DeactiveSprite()
    {
        m_SpriteRenderer.enabled = false;
    }

    public void DestroyBall() {
        DisablePhysics();
            MoveTo(s_FirstCollisionPoint, iTween.EaseType.linear, (Vector2.Distance(transform.position, s_FirstCollisionPoint) / 5.0f), "Deactive");
    }
}

