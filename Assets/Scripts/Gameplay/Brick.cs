using Assets.Scripts.Gameplay;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Brick : MonoBehaviour, IDamage, IHealth, IDamageable
{
    public Text m_Text;
    public HealthBar healthBar;
    public Hero hero;
    public int m_maxBrickHealth;
    public int m_currentBrickHealth;    // it's gonna be public because the GameManager needs to setup each brick
    public PolygonCollider2D polygonCollider2D;
    private Rigidbody2D rigidbody2D;

    private SpriteRenderer m_SpriteRenderer;
    public ParticleSystem m_ParentParticle;
    public Vector3 brickCoord;
    public Vector3 brickCoordAbove;
    private int attackSkill = 10; // need to define what's the best value for start
    private int appliedDamage;
    public Color damageTextColor;
    public int damageTextFontSize;
    private GameObject parent;
    public Animator animator;

    public IStateBrick idleStateBrick;
    public IStateBrick walkStateBrick;


    IStateBrick state;

    private void Awake()
    {
        parent = transform.parent.gameObject;
        polygonCollider2D = gameObject.GetComponent<PolygonCollider2D>();
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_ParentParticle = GetComponentInParent<ParticleSystem>();
        hero = GameObject.FindGameObjectWithTag("Hero").GetComponent<Hero>();
        animator = GetComponent<Animator>();
        idleStateBrick = new IdleStateBrick(this);
        walkStateBrick = new WalkStateBrick(this);
        state = idleStateBrick;
        SetDefaultTextParams();
    }

    private void OnEnable()
    {
        //GOOD DECISION BUT I SHOULD CHANGE THIS BOCHKAREV ALEKSEI
        m_currentBrickHealth = ScoreManager.Instance.m_LevelOfFinalBrick +1;
        m_maxBrickHealth = m_currentBrickHealth;
       // Debug.Log("Brick OnEnable m_Health " + m_currentBrickHealth);
        m_Text.text = m_currentBrickHealth.ToString();

        // Set HealthBar and show health of brick
        healthBar = gameObject.GetComponentInChildren<HealthBar>();
        healthBar.SaveCurrentBrickHealth();
        healthBar.SaveMaxBrickHealth();
        healthBar.ShowHealth();
        
       // ChangeColor();
    }

    public void SetState (IStateBrick state) {
        if (this.state != null) {
            this.state.Exit();
        }
        this.state = state;
        this.state.Enter();
    }

    private void SetDefaultTextParams()
    {
        damageTextColor = TextController.COLOR_RED;
        damageTextFontSize = TextController.FONT_SIZE_MAX;
    }
    

    public void SetMaxHealth(float maxHealth)
    {
        m_maxBrickHealth = (int) maxHealth;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<IBall>() != null)
        {
            polygonCollider2D.isTrigger = false;
            appliedDamage = collision.gameObject.GetComponent<IBall>().GetAttackPower;
            damageTextColor = collision.gameObject.GetComponent<IBall>().GetDamageTextColor;
            damageTextFontSize = collision.gameObject.GetComponent<IBall>().GetDamageTextFontSize;
            TakeDamage(appliedDamage, damageTextColor, damageTextFontSize);
            if (collision.gameObject.GetComponent<AbstractBall>() != null)
            {
                Vector3 position = collision.gameObject.transform.position;
                collision.gameObject.GetComponent<AbstractBall>().SpecialAttack(position, this.gameObject);
            }                 
        } else if (collision.gameObject.tag == "Finish") 
        {
            Attack();
            Suicide();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<IBall>() != null)
        {
            polygonCollider2D.isTrigger = false;
            appliedDamage = collider.gameObject.GetComponent<IBall>().GetAttackPower;
            damageTextColor = collider.gameObject.GetComponent<IBall>().GetDamageTextColor;
            damageTextFontSize = collider.gameObject.GetComponent<IBall>().GetDamageTextFontSize;
            TakeDamage(appliedDamage, damageTextColor, damageTextFontSize);
            if (collider.gameObject.GetComponent<AbstractBall>() != null)
            {
                Vector3 position = collider.gameObject.transform.position;
                collider.gameObject.GetComponent<AbstractBall>().SpecialAttack(position, this.gameObject);
            }
        } else if (collider.gameObject.tag == "Finish") {
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

    public void DoDamage(int applyDamage)
    {
       state.DoDamage(applyDamage);
    }

    public void HealUp(float healHealthUpAmount) // heals Health of the BRICK
    {
        state.HealUp(healHealthUpAmount);
    }

    private void Update() { // ONLY FOR DEBUGGING AND TESTING
        if (Input.GetMouseButtonDown(1))
        {
            TakeDamage(1);
        }
        if (Input.GetMouseButtonDown(2))
        {
            HealUp(5);
        }
        if(transform.localPosition.y <= BallLauncher.Instance.m_FloorPosition)
        {
            LevelManager.Instance.m_LevelState = LevelManager.LevelState.GAMEOVER;
            //AttackPlayer();
        }
    }

    public void TakeDamage (int appliedDamage)
    {   
        bool isDamage = true;
        bool isCriticalHit = false;
        m_currentBrickHealth = m_currentBrickHealth - appliedDamage;
        m_Text.text = m_currentBrickHealth.ToString();
        healthBar.SaveCurrentBrickHealth();
        healthBar.ShowHealth();
        EventManager.OnBrickHit();

        // Create DamagePopup with damage above the BRICK
        InitBrickDamagePopupPosition();
        DamagePopupController.Instance.CreateDamagePopup(brickCoordAbove, appliedDamage, isCriticalHit, isDamage, damageTextColor, damageTextFontSize);

        if (m_currentBrickHealth <= 0)
        {
            DeathOfBrick();
        }
    }

    public void TakeDamage(int appliedDamage, Color damageTextColor, int damageTextFontSize)
    {   
        bool isDamage = true;
        bool isCriticalHit = false;
        m_currentBrickHealth = m_currentBrickHealth - appliedDamage;
        m_Text.text = m_currentBrickHealth.ToString();
        healthBar.SaveCurrentBrickHealth();
        healthBar.ShowHealth();
        EventManager.OnBrickHit();

        // Create DamagePopup with damage above the BRICK
        InitBrickDamagePopupPosition();
        DamagePopupController.Instance.CreateDamagePopup(brickCoord, appliedDamage, isCriticalHit, isDamage, damageTextColor, damageTextFontSize);

        if (m_currentBrickHealth <= 0)
        {
            DeathOfBrick();
        }
    }

    public void TakeDamage(int appliedDamage, string textPopupTextValue, Color textColor, int textFontSize)
    { 
        m_currentBrickHealth = m_currentBrickHealth - appliedDamage;
        m_Text.text = m_currentBrickHealth.ToString();
        healthBar.SaveCurrentBrickHealth();
        healthBar.ShowHealth();
        EventManager.OnBrickHit();

        // Create DamagePopup with damage above the BRICK
        InitBrickDamagePopupPosition();
        DamagePopupController.Instance.CreateTextPopup(brickCoordAbove, textPopupTextValue, textColor, textFontSize);

        if (m_currentBrickHealth <= 0)
        {
            DeathOfBrick();
        }
    }

    public void DeathOfBrick () {
        // 1 - play a particle
        Color color = new Color(m_SpriteRenderer.color.r, m_SpriteRenderer.color.g, m_SpriteRenderer.color.b, 0.5f);
        m_ParentParticle.startColor = color;
        m_ParentParticle.Play();
        //2 - set Grid to 0
        //gameObject.GetComponentInParent<MoveDownBehaviour>().UpdateCurrentPosition();
        //gameObject.GetComponentInParent<MoveDownBehaviour>().SetZeroToCurrentPosition();
            // 3 - hide this Brick or this row
        gameObject.SetActive(false);
            //m_Parent.CheckBricksActivation();
            // 4 - Set coin 
        EventManager.OnBrickDestroyed();
            //   WalletController.Instance.AddCoinAndShow();
            //destroy parent gameObject
        Destroy(parent, 1);
    }

    public void Suicide () {
        // 1 - play a particle
        Color color = new Color(m_SpriteRenderer.color.r, m_SpriteRenderer.color.g, m_SpriteRenderer.color.b, 0.5f);
        m_ParentParticle.startColor = color;
        m_ParentParticle.Play();
        //2 - set Grid to 0
        //gameObject.GetComponentInParent<MoveDownBehaviour>().UpdateCurrentPosition();
        //gameObject.GetComponentInParent<MoveDownBehaviour>().SetZeroToCurrentPosition();
            // 3 - hide this Brick or this row
        gameObject.SetActive(false);
        EventManager.OnBrickDestroyed();
            //m_Parent.CheckBricksActivation();
            //destroy parent gameObject
        Destroy(parent, 0.1f);
    }

    public void KillBrick(string textPopupTextValue)
    {
        appliedDamage = m_maxBrickHealth;
        damageTextColor = TextController.COLOR_BLACK;
        damageTextFontSize = TextController.FONT_SIZE_MAX;
        TakeDamage(appliedDamage, textPopupTextValue, damageTextColor, damageTextFontSize);
       // Debug.Log("Kill brick applied");
    }

    public void ChangeRigidbodyType (RigidbodyType2D rigidbodyType)
    {
        rigidbody2D.bodyType = rigidbodyType;
    }
    

    public void Attack ()
    {
      //  Debug.Log("Attack");
    }
    
    public void ChangeColor()
    {
        m_SpriteRenderer.color = Color.LerpUnclamped(new Color(1, 0.75f, 0, 1), Color.red, m_currentBrickHealth / (float)ScoreManager.Instance.m_LevelOfFinalBrick);
    }

}