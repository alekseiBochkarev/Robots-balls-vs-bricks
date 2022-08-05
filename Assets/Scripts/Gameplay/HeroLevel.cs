using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroLevel
{
    [Header("HERO LEVEL")]
    private float minLevel = 1;
    private float levelMultiplier;
    public float CurrentHeroLevel { private set; get;}

    [Header("HERO EXPERIENCE")]
    private float startExperience = 0;
    private float requiredExperience;
    private float earnExperience = 100;
    public float HeroExperience { private set; get;}
    private bool IsGameWon;

    public enum HeroLevelEnum
    {
        CurrentLevel
    }

    public enum HeroExperienceEnum
    {
        CurrentExperience
    }
    public void Awake()
    {
        LoadHeroLevel();
        LoadHeroExperience();
        SetLevelMultiplier();
        InitRequiredExperience();
        EventManager.GameWon += AddHeroLevel;
        IsGameWon = false;
        Debug.Log("Awake HeroLevel");
    }

    public HeroLevel()
    {
        LoadHeroLevel();
        LoadHeroExperience();
        SetLevelMultiplier();
        InitRequiredExperience();
    }

    private void OnDestroy() 
    {
        EventManager.GameWon -= AddHeroLevel;
        Debug.Log("Perfrom OnDestroy on HeroLevel");
    }

    public void SaveHeroLevel(HeroLevelEnum levelEnum, float levelAmount)
    {
        PlayerPrefs.SetFloat(levelEnum.ToString(), levelAmount);
    }

    public void SaveHeroExperience(HeroExperienceEnum experienceEnum, float experienceAmount)
    {
        PlayerPrefs.SetFloat(experienceEnum.ToString(), experienceAmount);
    }

    public void LoadHeroLevel()
    {
        if (GetHeroLevel() == 0)
            SaveHeroLevel(HeroLevelEnum.CurrentLevel, minLevel);
        if (GetHeroLevel() != 0)
            CurrentHeroLevel = GetHeroLevel();
            Debug.Log("Current heroLevel is -> " + CurrentHeroLevel);
    }

    public float GetHeroLevel()
    {
        return PlayerPrefs.GetFloat(HeroLevelEnum.CurrentLevel.ToString());
    }

    public void LoadHeroExperience()
    {
        HeroExperience = PlayerPrefs.GetFloat(HeroExperienceEnum.CurrentExperience.ToString());
        Debug.Log("Current HeroExperience is -> " + HeroExperience);
    }

    private void SetLevelMultiplier()
    {
        levelMultiplier = CurrentHeroLevel;
    }

    public void AddExperience()
    {
        HeroExperience += earnExperience;
        SaveHeroExperience(HeroExperienceEnum.CurrentExperience, HeroExperience);
    }

    private void InitRequiredExperience()
    {
        requiredExperience = levelMultiplier * earnExperience;
        Debug.Log("Required experience for new level -> " + requiredExperience);
    }

    private void HeroLevelUp()
    {
        CurrentHeroLevel++;
    }
    public void AddHeroLevel()
    {
        /* IsGameWon bool need for apply this method once,
         because this action is always perfroms after event was called,
         OnDestroy works only when you go to the menu or do replay
         */
        if (IsGameWon == false)
        {
            AddExperience();
            if (IsExperienceEnough())
            {
                HeroLevelUp();
                SaveHeroLevel(HeroLevelEnum.CurrentLevel, CurrentHeroLevel);
                SetLevelMultiplier();
                SaveHeroExperience(HeroExperienceEnum.CurrentExperience, startExperience);
                InitRequiredExperience();
                Debug.Log("New level is added, it's -> " + CurrentHeroLevel);
            }
            IsGameWon = true;
        }
    }

    private bool IsExperienceEnough()
    {
        return HeroExperience >= requiredExperience;
    }

    public float SetCurrentExperienceAsPercentage() 
    {
        if (HeroExperience != 0)
        {
            Debug.Log("HeroExperience is " + HeroExperience + " requiredExperience is " + requiredExperience);
            return HeroExperience / requiredExperience;
        }
        else
        {
            return 0;
        }
    }
}
