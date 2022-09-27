using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats
{
    public float AttackPower {private set; get;}
    public float Health {private set; get;}
    public float UpgradePoints {private set; get;}

    public enum HeroStatsEnum
    {
        HeroAttackPower,
        HeroHealth,
        HeroUpgradePoints
    }

    public HeroStats()
    {
        LoadStats();
        EventManager.LevelUp += AddUpgradePoints;
    }

    private void OnDestroy() 
    {
        EventManager.LevelUp -= AddUpgradePoints;
    }

    private void LoadStats()
    {
        if (GetStats(HeroStatsEnum.HeroAttackPower) != 0)
        {
            AttackPower = GetStats(HeroStatsEnum.HeroAttackPower);
        }
        else
        {
            AttackPower = 1;
            SaveStats(HeroStatsEnum.HeroAttackPower, AttackPower);
        }
        if (GetStats(HeroStatsEnum.HeroHealth) != 0)
        {
            Health = GetStats(HeroStatsEnum.HeroHealth);
        }
        else
        {
            Health = 100;
            SaveStats(HeroStatsEnum.HeroHealth, Health);
        }
        if (GetStats(HeroStatsEnum.HeroUpgradePoints) != 0)
        {
            UpgradePoints = GetStats(HeroStatsEnum.HeroUpgradePoints);
        }
        else
        {
            UpgradePoints = 0;
            SaveStats(HeroStatsEnum.HeroUpgradePoints, UpgradePoints);
        }
    }

    public float GetStats(HeroStatsEnum statsEnum)
    {
        //Debug.Log(PlayerPrefs.GetFloat(statsEnum.ToString()) + " == "+statsEnum+" == GET that hero stats");
        return PlayerPrefs.GetFloat(statsEnum.ToString());
    }
    private void SaveStats(HeroStatsEnum statsEnum, float statsValue)
    {
        // AttackPower = statsValue;
        PlayerPrefs.SetFloat(statsEnum.ToString(), statsValue);
       // Debug.Log(PlayerPrefs.GetFloat(statsEnum.ToString()) + " == "+statsEnum+" == SAVED that hero stats");
    }

    public void UpgradeStats(HeroStatsEnum statsEnum, float upgradeAmount)
    {
        float statsValue = GetStats(statsEnum);
        statsValue += upgradeAmount;
        SaveStats(statsEnum, statsValue);
        LoadStats();
    }

    public void AddUpgradePoints()
    {
        UpgradePoints++;
        SaveStats(HeroStatsEnum.HeroUpgradePoints, UpgradePoints);
    }

    public void RemoveOneUpgradePoints()
    {
        UpgradePoints--;
        SaveStats(HeroStatsEnum.HeroUpgradePoints, UpgradePoints);
    }
}
