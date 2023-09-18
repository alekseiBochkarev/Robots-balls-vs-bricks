using System.Collections;
using Assets.Scripts.Gameplay;
using UnityEngine;

public class Hero : MonoBehaviour, IHealth, IDamageable
{
    public static Hero Instance;
    public int AttackSkill { private set; get; }
    private HealthBar healthBar;
    //private HeroStats heroStats;
    private bool isDamage;

    public int appliedDamage;
    public Color damageTextColor;
    public int damageTextFontSize;

    private Vector3 heroCoord;
    [SerializeField] private AudioClip clip;
    private GameObject camera;
    [SerializeField] private static float m_currentHealth;

    [SerializeField] private GameObject heroBody;
    [SerializeField] private GameObject tornado;
    [SerializeField] private GameObject aim;
    [SerializeField] private GameObject fireMove;

    public static float CurrentHealth
    {
        private set { m_currentHealth = value; }
        get { return m_currentHealth; }
    }

    [SerializeField] public float MaxHealth { private set; get; }

    public void Awake()
    {
        //Debug.Log("AttackSkill Awake" + AttackSkill);
        camera = GameObject.Find("MainCamera");
        EventManager.SkinChanged += UpdateAttack;
        EventManager.UpgradeStats += UpdateAttack;
        EventManager.UpgradeAttackPowerStat += UpdateAttack;
        EventManager.LevelStarted += UpdateAttack;
        // LoadHeroSkill();
        SetMaxHealth(HeroStats.Health);
        EventManager.SkinChanged += UpdateHealth;
        // CurrentHealth = MaxHealth;
        UpdateAttack();
        Instance = this;
    }

    private void OnEnable()
    {
        healthBar = gameObject.GetComponent<HealthBar>();
        healthBar.SaveMaxHealth(MaxHealth);
        healthBar.SaveCurrentHealth(CurrentHealth);
        healthBar.ShowHealth();
    }

    private void UpdateAttack()
    {
        AttackSkill = (int)HeroStats.Attack;
        Debug.Log("AttackSkill " + AttackSkill);
    }

    private void UpdateHealth()
    {
        SetMaxHealth(HeroStats.Health);
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

    public void Move(Vector3 targetPosition)
    {
        StartCoroutine(ShowFire(Vector2.Distance(transform.position, targetPosition)/5));
        iTween.MoveTo(this.gameObject,
            iTween.Hash("position", new Vector3(targetPosition.x, transform.position.y, transform.position.z),
                "easetype", iTween.EaseType.linear, "time", (Vector2.Distance(transform.position, targetPosition))/5));
    }

    IEnumerator ShowFire(float time)
    {
        fireMove.SetActive(true);
        yield return new WaitForSeconds(time);
        fireMove.SetActive(false);
    }

    public void ShowTornado()
    {
        tornado.SetActive(true);
        heroBody.SetActive(false);
    }

    public void ShowAim()
    {
        aim.SetActive(true);
        heroBody.SetActive(false);
    }

    public void StopAim()
    {
        aim.SetActive(false);
        heroBody.SetActive(true);
    }

    public void StopTornado()
    {
        tornado.SetActive(false);
        heroBody.SetActive(true);
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
        //Debug.Log("Hero takes damage with damage -> " + appliedDamage);
        EventManager.OnHeroTakesDamage();
        healthBar.SaveCurrentHealth(CurrentHealth);
        healthBar.ShowHealth();
        heroCoord = gameObject.transform.position;
        camera.GetComponent<AudioManager>().PlayAudio(clip);
        DamagePopupController.Instance.CreateDamagePopup(heroCoord, appliedDamage, false,
            isDamage, TextController.COLOR_RED, TextController.FONT_SIZE_MAX);
        if (CurrentHealth <= 0)
        {
            EventManager.OnLifeIsOverEvent();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Bullet>() != null)
        {
            appliedDamage = collider.gameObject.GetComponent<Bullet>().GetAttackPower;
            TakeDamage(appliedDamage);
        }
    }

    public void HealUp(float healHealthUpAmount)
    {
        isDamage = false;
        int healHealthUpAmountInt = (int)healHealthUpAmount;
        CurrentHealth += healHealthUpAmountInt;
        EventManager.OnHeroHealsUp();
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