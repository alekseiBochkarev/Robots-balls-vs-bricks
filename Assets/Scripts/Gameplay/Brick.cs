using System;
using UnityEngine;
using UnityEngine.UI;

public class Brick : MonoBehaviour
{
    public Text m_Text;
    private HealthBar healthBar;
    public int m_maxBrickHealth;
    public int m_currentBrickHealth;    // it's gonna be public because the GameManager needs to setup each brick
    public PolygonCollider2D polygonCollider2D;
    private Rigidbody2D rigidbody2D;

    private SpriteRenderer m_SpriteRenderer;
    private ParticleSystem m_ParentParticle;

    private void Awake()
    {
        polygonCollider2D = gameObject.GetComponent<PolygonCollider2D>();
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_ParentParticle = GetComponentInParent<ParticleSystem>();
    }

    private void OnEnable()
    {
        //GOOD DECISION BUT I SHOULD CHANGE THIS BOCHKAREV ALEKSEI
        m_currentBrickHealth = ScoreManager.Instance.m_LevelOfFinalBrick +1;
        m_maxBrickHealth = m_currentBrickHealth;
        Debug.Log("Brick OnEnable m_Health " + m_currentBrickHealth);
        m_Text.text = m_currentBrickHealth.ToString();

        // Set HealthBar and show health of brick
        healthBar = gameObject.GetComponentInChildren<HealthBar>();
        healthBar.SaveCurrentBrickHealth();
        healthBar.SaveMaxBrickHealth();
        healthBar.ShowHealth();
        
        ChangeColor();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<IBall>() != null)
        {
            polygonCollider2D.isTrigger = false;
            takeDamage(collision.gameObject.GetComponent<IBall>().GetAttackPower);
            if (collision.gameObject.GetComponent<AbstractBall>() != null)
            {
                Vector3 position = collision.gameObject.transform.position;
                collision.gameObject.GetComponent<AbstractBall>().SpecialAttack(position);
            }                 
        }
    }
    

    public void takeDamage (int damage)
    {
        m_currentBrickHealth = m_currentBrickHealth - damage;
        m_Text.text = m_currentBrickHealth.ToString();
        healthBar.SaveCurrentBrickHealth();
        healthBar.ShowHealth();
        EventManager.OnBrickHit();
        if (m_currentBrickHealth <= 0)
        {
            // 1 - play a particle
            Color color = new Color(m_SpriteRenderer.color.r, m_SpriteRenderer.color.g, m_SpriteRenderer.color.b, 0.5f);
            m_ParentParticle.startColor = color;
            m_ParentParticle.Play();

            // 2 - hide this Brick or this row
            gameObject.SetActive(false);
            //m_Parent.CheckBricksActivation();

            // 3 - Set coin 
            EventManager.OnBrickDestroyed();
            //   WalletController.Instance.AddCoinAndShow();
        }
    }

    public void ChangeRigidbodyType (RigidbodyType2D rigidbodyType)
    {
        rigidbody2D.bodyType = rigidbodyType;
    }
    

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<IBall>() != null)
        {
            polygonCollider2D.isTrigger = false;
            takeDamage(collider.gameObject.GetComponent<IBall>().GetAttackPower);
            if (collider.gameObject.GetComponent<AbstractBall>() != null)
            {
                Vector3 position = collider.gameObject.transform.position;
                collider.gameObject.GetComponent<AbstractBall>().SpecialAttack(position);
            }
        }
    }

    public void Attack ()
    {
        Debug.Log("Attack");
    }
    
    public void ChangeColor()
    {
        m_SpriteRenderer.color = Color.LerpUnclamped(new Color(1, 0.75f, 0, 1), Color.red, m_currentBrickHealth / (float)ScoreManager.Instance.m_LevelOfFinalBrick);
    }
}