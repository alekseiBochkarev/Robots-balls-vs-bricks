using Assets.Scripts.Gameplay;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Gameplay.Loot;

public class Brick : MoveDownBehaviour, IDamage, IHealth, IDamageable
{
    public Text m_Text;
    public HealthBar healthBar;
    public Hero hero;
    public GameObject ice;
    public GameObject fire;
    public GameObject poison;
    [SerializeField] private GameObject shield;
    [SerializeField] private int m_maxBrickHealth;
    [SerializeField] private int m_currentBrickHealth;
	[SerializeField] private AudioClip deathSoundclip;
	[SerializeField] private AudioClip takeDamageClip;
    private GameObject camera;

    public int MMaxBrickHealth
    {
        get => m_maxBrickHealth;
        set
        {
            m_maxBrickHealth = value;
            healthBar.SaveMaxBrickHealth();
            healthBar.ShowHealth();
        }
    }

    public int MCurrentBrickHealth
    {
        get => m_currentBrickHealth;
        set
        {
            m_currentBrickHealth = value;
            healthBar.SaveCurrentBrickHealth();
        }
    }


    [SerializeField] private int m_attackPower; //атакующая сила 1 брика, если их несколько то умножается на количество
   // public PolygonCollider2D polygonCollider2D;
    private Rigidbody2D rigidbody2D;

    [SerializeField] private bool canRangeAttack;
    public bool CanRangeAttack => canRangeAttack;
    [SerializeField] private bool canInstantiateBoom;
    public bool CanInstantiateBoom => canInstantiateBoom;
    
    private bool isWaitMeleeAttack;

    public bool IsWaitMeleeAttack
    {
        get => isWaitMeleeAttack;
        set => isWaitMeleeAttack = value;
    }

    public SpriteRenderer m_SpriteRenderer;
    public ParticleSystem m_ParentParticle;
    public Vector3 brickCoord;
    public Vector3 brickCoordAbove;
    private int attackSkill = 10; // need to define what's the best value for start
    public int appliedDamage;
    public Color damageTextColor;
    public int damageTextFontSize;
    public GameObject parent;
    public GameObject bulletOnlyForRangeAttackedBricks;
    public Animator animator;

    public IStateBrick idleStateBrick;
    public IStateBrick walkStateBrick;
    public IStateBrick deathStateBrick;
    public IStateBrick takeDamageStateBrick;
    public IStateBrick attackStateBrick;
    public IStateBrick freezeStateBrick;
    public IStateBrick fireStateBrick;
    public IStateBrick poisonStateBrick;

    public LootBag lootBag;


    public IStateBrick state;

    private void Awake()
    {
        InitMoveDown();
		camera = GameObject.Find("MainCamera");
        parent = transform.parent.gameObject;
     //   polygonCollider2D = gameObject.GetComponent<PolygonCollider2D>();
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_ParentParticle = GetComponentInParent<ParticleSystem>();
        hero = GameObject.FindGameObjectWithTag("Hero").GetComponent<Hero>();
        animator = GetComponent<Animator>();
        idleStateBrick = new IdleStateBrick(this);
        walkStateBrick = new WalkStateBrick(this);
        deathStateBrick = new DeathStateBrick(this);
        takeDamageStateBrick = new TakeDamageStateBrick(this);
        attackStateBrick = new AttackStateBrick(this);
        freezeStateBrick = new FreezeStateBrick(this);
        fireStateBrick = new FireStateBrick(this);
        poisonStateBrick = new PoisonStateBrick(this);
        state = idleStateBrick;

        lootBag = GetComponent<LootBag>();
        SetDefaultTextParams();
    }

    private void OnEnable()
    {
        healthBar = gameObject.GetComponentInChildren<HealthBar>();
    }

    public void SetState(IStateBrick state)
    {
        if (this.state != null)
        {
            this.state.Exit();
        }

        this.state = state;
        this.state.Enter();
    }

    public void SetStateWithoutExit(IStateBrick state)
    {
        this.state = state;
        this.state.Enter();
    }

	public void PlayDeathMusic() {
		camera.GetComponent<AudioManager>().PlayAudio(deathSoundclip);
	}

	public void PlayTakeDamageMusic() {
		camera.GetComponent<AudioManager>().PlayAudio(takeDamageClip);
	}

    public IStateBrick getState()
    {
        return this.state;
    }

    private void SetDefaultTextParams()
    {
        damageTextColor = TextController.COLOR_RED;
        damageTextFontSize = TextController.FONT_SIZE_MAX;
    }


    public void SetMaxHealth(float maxHealth)
    {
        m_maxBrickHealth = (int)maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<IBall>() != null)
        {
           // polygonCollider2D.isTrigger = false;
            appliedDamage = collision.gameObject.GetComponent<IBall>().GetAttackPower;
            damageTextColor = collision.gameObject.GetComponent<IBall>().GetDamageTextColor;
            damageTextFontSize = collision.gameObject.GetComponent<IBall>().GetDamageTextFontSize;
            TakeDamage(appliedDamage, damageTextColor, damageTextFontSize);
            EventManager.OnBrickHit();
            if (collision.gameObject.GetComponent<AbstractBall>() != null)
            {
                Vector3 position = collision.gameObject.transform.position;
                collision.gameObject.GetComponent<AbstractBall>().SpecialAttack(position, this.gameObject);
            }
        }
        else if (collision.gameObject.tag == "Finish")
        {
            Attack();
            Suicide();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<IBall>() != null)
        {
           // polygonCollider2D.isTrigger = false;
            appliedDamage = collider.gameObject.GetComponent<IBall>().GetAttackPower;
            damageTextColor = collider.gameObject.GetComponent<IBall>().GetDamageTextColor;
            damageTextFontSize = collider.gameObject.GetComponent<IBall>().GetDamageTextFontSize;
            TakeDamage(appliedDamage, damageTextColor, damageTextFontSize);
           // EventManager.OnBrickHit();
            if (collider.gameObject.GetComponent<AbstractBall>() != null)
            {
                Vector3 position = collider.gameObject.transform.position;
                collider.gameObject.GetComponent<AbstractBall>().SpecialAttack(position, this.gameObject);
            }
        }
        else if (collider.gameObject.tag == "Finish")
        {
            Attack();
            Suicide();
        }
    }

    ///* move to state...
    private void InitBrickDamagePopupPosition() // init brickPosition and change Y to show damagePopup above the BRICK
    {
        float damagePopupHeight = .5f;
        brickCoord = m_ParentParticle.transform.position;
        brickCoordAbove = new Vector3(brickCoord.x, brickCoord.y + damagePopupHeight, brickCoord.z);
    }
    //*/

    public IEnumerator DoDamage(int applyDamage)
    {
        Debug.Log("brick Attack");
        yield return state.DoDamage(applyDamage);
    }

    public void HealUp(float healHealthUpAmount) // heals Health of the BRICK
    {
        state.HealUp(healHealthUpAmount);
    }

    private void Update()
    {
        // ONLY FOR DEBUGGING AND TESTING  - ОБРАТИТЬ ВНИМАНИЕ ПЕРЕД РЕЛИЗОМ УДАЛИТЬ
        if (Input.GetMouseButtonDown(1))
        {
            TakeDamage(1);
        }

        if (Input.GetMouseButtonDown(2))
        {
            HealUp(5);
        }
    }

    public void TakeDamage(int appliedDamage)
    {
        state.TakeDamage(appliedDamage);
    }

    public void TakeDamage(int appliedDamage, Color damageTextColor, int damageTextFontSize)
    {
        state.TakeDamage(appliedDamage, damageTextColor, damageTextFontSize);
    }

    public void TakeDamage(int appliedDamage, string textPopupTextValue, Color textColor, int textFontSize)
    {
        state.TakeDamage(appliedDamage, textPopupTextValue, textColor, textFontSize);
    }

    public void DeathOfBrick(bool isInstantiateLoot)
    {
        state.DeathOfBrick(isInstantiateLoot);
    }

    public void Suicide()
    {
        state.Suicide();
    }

    public void KillBrick(string textPopupTextValue)
    {
        state.KillBrick(textPopupTextValue);
    }

    public void ChangeRigidbodyType(RigidbodyType2D rigidbodyType)
    {
        rigidbody2D.bodyType = rigidbodyType;
    }

    /// <summary>
    /// похоже это лишний метд Аттака (так как есть ДуДемедж), хотя я наверно просто могу в нем вызывать дуДемедж
    /// </summary>
    /// <returns></returns>
    public IEnumerator Attack()
    {
        Debug.Log("brick IEnumerator Attack");
        yield return DoDamage(m_attackPower * m_currentBrickHealth);
    }

    public void ChangeColor()
    {
        m_SpriteRenderer.color = Color.LerpUnclamped(new Color(1, 0.75f, 0, 1), Color.red,
            m_currentBrickHealth / (float)ScoreManager.Instance.m_LevelOfFinalBrick);
    }


    public override IEnumerator MoveToTarget(Vector3 startPos, Vector3 endPos, int currentY, int maxY)
    {
        yield return state.MoveToTarget(startPos, endPos, currentY, maxY);
    }

    public void Destroy()
    {
        if (shield is not null)
        {
            Destroy(shield);
        }
        Destroy(parent, 3);
    }
}