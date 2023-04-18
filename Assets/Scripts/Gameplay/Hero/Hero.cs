using Assets.Scripts.Gameplay;
using UnityEngine;

public class Hero : MonoBehaviour, IHealth, IDamageable
{
    public static Hero Instance;
    public int attackSkill;
    private HealthBar healthBar;
    private HeroStats heroStats;
    private bool isDamage;

    private Vector3 heroCoord;
    [SerializeField] private float m_currentHealth;
    public float CurrentHealth 
    {
        private set
        {
            m_currentHealth = value;
        }
        get
        {
            return m_currentHealth;
        } 
    }
    [SerializeField] public float MaxHealth { private set; get; }

    public void Awake()
    {
        heroStats = new HeroStats();
        // LoadHeroSkill();
        SetMaxHealth(heroStats.Health);
       // CurrentHealth = MaxHealth;
        attackSkill = (int)heroStats.GetStats(HeroStats.HeroStatsEnum.Attack);
        Instance = this;
    }

    private void OnEnable()
    {
        healthBar = gameObject.GetComponent<HealthBar>();
        healthBar.SaveMaxHealth(MaxHealth);
        healthBar.SaveCurrentHealth(CurrentHealth);
        healthBar.ShowHealth();
    }

    
    public void SetMaxHealth(float maxHealth)
    {
        MaxHealth = maxHealth;
        SetCurrentHealth();
    }

    private void SetCurrentHealth()
    {
        CurrentHealth = MaxHealth;
    }

    /**
     * Записывает максимальное здоровье игрока и выставляет его текущим здоровьем, также для HealthBar
     * Нужно так, чтобы после прокачки здоровья у нас здоровье у игрока изменилось
     */
    public void UpdateHeroHealthAndHealthBar(float maxHealth)
    {
        SetMaxHealth(maxHealth);
        healthBar.SaveMaxHealth(maxHealth);
        healthBar.SaveCurrentHealth(CurrentHealth);
    }

    public void TakeDamage(int appliedDamage)
    {
        isDamage = true;
        CurrentHealth -= appliedDamage;
        Debug.Log("Hero takes damage with damage -> " + appliedDamage);
        healthBar.SaveCurrentHealth(CurrentHealth);
        healthBar.ShowHealth();
        heroCoord = gameObject.transform.position;

        DamagePopupController.Instance.CreateDamagePopup(heroCoord, appliedDamage, false,
            isDamage, TextController.COLOR_RED, TextController.FONT_SIZE_MAX);
        if (CurrentHealth <= 0)
        {
            EventManager.OnLifeIsOverEvent();
        }
    }

    public void HealUp(float healHealthUpAmount)
    {
        isDamage = false;
        int healHealthUpAmountInt = (int)healHealthUpAmount;
        CurrentHealth += healHealthUpAmountInt;
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }

        healthBar.SaveCurrentHealth(CurrentHealth);
        healthBar.ShowHealth();
        heroCoord = gameObject.transform.position;

        DamagePopupController.Instance.CreateDamagePopup(heroCoord, healHealthUpAmountInt, false,
            isDamage, TextController.COLOR_GREEN, TextController.FONT_SIZE_MAX);
    }
}