using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public int attackSkill = 3;
    public int defendSkill = 0;
    public int healthSkill = 10;

    public void Awake ()
    {
        LoadHeroSkill();
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
        
}
