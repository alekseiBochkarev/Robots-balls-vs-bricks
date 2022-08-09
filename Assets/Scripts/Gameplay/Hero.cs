using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour, IHealth, IDamageable
{
    public int attackSkill = 3;
    public int defendSkill = 0;
    public int healthSkill = 10;
    public int heroHealth = 100; // need to define what's the best value for start
    private HealthBar healthBar;
    private bool isDamage;

    private Vector3 heroCoord;
    [SerializeField] public float CurrentHealth { private set; get; }
    [SerializeField] public float MaxHealth {private set; get; }

    public void Awake ()
    {
        LoadHeroSkill();
        SetMaxHealth(heroHealth);
        CurrentHealth = MaxHealth;
    }

    private void OnEnable() 
    {
        healthBar = gameObject.GetComponent<HealthBar>();
        healthBar.SaveMaxHealth(MaxHealth);
        healthBar.SaveCurrentHealth(CurrentHealth);
        healthBar.ShowHealth();
    }

    public void AddAttackSkill(int value)
    {
        attackSkill += value;
        Debug.Log("new attack skill " + attackSkill);
    }

    public void SaveHeroSkills()
    {
        PlayerPrefs.SetInt("attackSkill", attackSkill);
        PlayerPrefs.SetInt("defendSkill", defendSkill);
        PlayerPrefs.SetInt("healthSkill", healthSkill);
    }

    public void LoadHeroSkill()
    {
        if (PlayerPrefs.GetInt("attackSkill") != 0)
     attackSkill = PlayerPrefs.GetInt("attackSkill");
        if (PlayerPrefs.GetInt("defendSkill")!= 0)
     defendSkill = PlayerPrefs.GetInt("defendSkill");
        if (PlayerPrefs.GetInt("healthSkill") != 0)
     healthSkill = PlayerPrefs.GetInt("healthSkill");   
    }
    
    public void SetMaxHealth(int maxHealth)
    {
        MaxHealth = (float) maxHealth;
    }

    public void TakeDamage(int appliedDamage)
    {
        isDamage = true;
        CurrentHealth -= appliedDamage;
        Debug.Log("Hero takes damage with damage -> " + appliedDamage);
        healthBar.SaveCurrentHealth(CurrentHealth);
        healthBar.ShowHealth();
        heroCoord = gameObject.transform.position;
        DamagePopup.CreateDamagePopup(heroCoord, appliedDamage, false,
         isDamage, TextController.COLOR_RED, TextController.FONT_SIZE_MAX);
    }

    public void HealUp(int healHealthUpAmount)
    {
        isDamage = false;
        CurrentHealth += healHealthUpAmount;
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
        healthBar.SaveCurrentHealth(CurrentHealth);
        healthBar.ShowHealth();
        heroCoord = gameObject.transform.position;
        DamagePopup.CreateDamagePopup(heroCoord, healHealthUpAmount, false,
         isDamage, TextController.COLOR_GREEN, TextController.FONT_SIZE_MAX);
    }
}
