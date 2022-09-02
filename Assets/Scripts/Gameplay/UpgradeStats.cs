using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeStats
{
    public float UpgradeHealthCoinsRequired { private set; get; }
    public float UpgradeAttackPowerCoinsRequired { private set; get; }
    public float HealthUpgradeMult { private set; get; }
    public float AttackUpgradeMult { private set; get; }
    public float UpgradeHealthValue { private set; get; }
    public float UpgradeAttackPowerValue { private set; get; }
    private float startCoinsUpgradeValue = 480;
    private float startHealthUpgradeValue = 30;
    private float startAttackUpgradeValue = 1;
    public enum UpgradeMultipliersEnum
    {
        HealthMultiplier,
        AttackPowerMultiplier
    }

    public enum RequiredCoinsStatsEnum
    {
        HealthUpgradeCost,
        AttackPowerUpgradeCost
    }

    public UpgradeStats()
    {
        SetMultiplier();
        InitRequiredCoins();
        InitStatsUpgrading();
    }

    public void InitRequiredCoins()
    {
        UpgradeHealthCoinsRequired = startCoinsUpgradeValue * HealthUpgradeMult;
        SaveRequiredCoins(RequiredCoinsStatsEnum.HealthUpgradeCost, UpgradeHealthCoinsRequired);
        Debug.Log("UpgradeHealthCoinsRequired is ->" + UpgradeHealthCoinsRequired);

        UpgradeAttackPowerCoinsRequired = startCoinsUpgradeValue * AttackUpgradeMult;
        SaveRequiredCoins(RequiredCoinsStatsEnum.AttackPowerUpgradeCost, UpgradeAttackPowerCoinsRequired);
        Debug.Log("UpgradeAttackPowerCoinsRequired is ->" + UpgradeAttackPowerCoinsRequired);
    }

    public void InitStatsUpgrading()
    {
        UpgradeHealthValue = startHealthUpgradeValue * HealthUpgradeMult;
        UpgradeAttackPowerValue = startAttackUpgradeValue * AttackUpgradeMult;
    }

    public void SetMultiplier()
    {
        if (LoadUpgradeMultiplier(UpgradeMultipliersEnum.HealthMultiplier) != 0)
        {
            HealthUpgradeMult = LoadUpgradeMultiplier(UpgradeMultipliersEnum.HealthMultiplier);
        }
        else
        {
            HealthUpgradeMult = 1;
            SaveUpgradeMultiplier(UpgradeMultipliersEnum.HealthMultiplier, HealthUpgradeMult);
        }
        Debug.Log("HealthUpgradeMult is ->" + HealthUpgradeMult);
        if (LoadUpgradeMultiplier(UpgradeMultipliersEnum.AttackPowerMultiplier) != 0)
        {
            AttackUpgradeMult = LoadUpgradeMultiplier(UpgradeMultipliersEnum.AttackPowerMultiplier);
        }
        else
        {
            AttackUpgradeMult = 1;
            SaveUpgradeMultiplier(UpgradeMultipliersEnum.AttackPowerMultiplier, AttackUpgradeMult);
        }
        Debug.Log("AttackUpgradeMult is ->" + AttackUpgradeMult);
    }

    public void SaveUpgradeMultiplier(UpgradeMultipliersEnum multiplierEnum, float multValue)
    {
        float newMultValue = LoadUpgradeMultiplier(multiplierEnum);
        newMultValue += multValue;
        PlayerPrefs.SetFloat(multiplierEnum.ToString(), newMultValue);
    }

    private float LoadUpgradeMultiplier(UpgradeMultipliersEnum multiplierEnum)
    {
        return PlayerPrefs.GetFloat(multiplierEnum.ToString());
    }

    private void SaveRequiredCoins(RequiredCoinsStatsEnum statsEnum, float requiredCoins)
    {
        PlayerPrefs.SetFloat(statsEnum.ToString(), requiredCoins);
    }

    private float LoadRequiredCoins(RequiredCoinsStatsEnum statsEnum)
    {
        return PlayerPrefs.GetFloat(statsEnum.ToString());
    }
}
