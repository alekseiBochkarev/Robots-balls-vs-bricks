using Interfaces;
using UnityEngine;

public class UpgradeStats : IResetToDefaultValues
{
    //vars -> Coins required for upgrading
    public float UpgradeHealthCoinsRequired { private set; get; }
    public float UpgradeBatteryEnergyCoinsRequired { private set; get; }
    public float UpgradeAttackCoinsRequired { private set; get; }
    public float UpgradeStarterBallsCoinsRequired { private set; get; }
    public float UpgradeSightLengthCoinsRequired { private set; get; }

    //Upgrade levels
    public float UpgradeHealthLevel { private set; get; }
    public float UpgradeBatteryEnergyLevel { private set; get; }
    public float UpgradeAttackLevel { private set; get; }
    public float UpgradeStarterBallsLevel { private set; get; }
    public float UpgradeSightLengthLevel { private set; get; }

    //Upgrade multipliers
    private readonly float _defaultUpgradeMult = 1;
    public float HealthUpgradeMult { private set; get; }
    public float BatteryEnergyUpgradeMult { private set; get; }
    public float AttackUpgradeMult { private set; get; }
    public float StarterBallsUpgradeMult { private set; get; }
    public float SightLengthUpgradeMult { private set; get; }

    // Values for next upgrading stats
    public float UpgradeHealthValue { private set; get; }
    public float UpgradeBatteryEnergyValue { private set; get; }
    public float UpgradeAttackValue { private set; get; }
    public float UpgradeStarterBallsValue { private set; get; }
    public float UpgradeSightLengthValue { private set; get; }

    // Default values for upgrading stats
    private readonly float _startCoinsUpgradeValue = 480;

    private readonly float _startHealthUpgradeValue = 30;
    private readonly float _startBatteryEnergyUpgradeValue = 1;
    private readonly float _startAttackUpgradeValue = 1;
    private readonly float _startStarterBallsUpgradeValue = 1;
    private readonly float _startSightLengthUpgradeValue = 1;

    // Min and Max levels for upgrading
    public const float MinUpgradeHealthLevel = 0;
    private const float MinUpgradeBatteryEnergyLevel = 3;
    private const float MinUpgradeAttackLevel = 1;
    private const float MinUpgradeStarterBallsLevel = 1;
    private const float MinUpgradeSightLengthLevel = 1;

    public const float MaxUpgradeHealthLevel = 6;
    public const float MaxUpgradeBatteryEnergyLevel = 12;
    public const float MaxUpgradeAttackLevel = 10;
    public const float MaxUpgradeStarterBallsLevel = 8;
    public const float MaxUpgradeSightLengthLevel = 5;

    public enum UpgradeMultipliersEnum
    {
        HealthMultiplier,
        BatteryEnergyMultiplier,
        AttackMultiplier,
        StarterBallsMultiplier,
        SightLengthMultiplier
    }

    private enum RequiredCoinsStatsEnum
    {
        HealthUpgradeCost,
        BatteryEnergyUpgradeCost,
        AttackUpgradeCost,
        StarterBallsUpgradeCost,
        SightLengthUpgradeCost
    }

    public enum UpgradeStatLevel
    {
        UpgradeHealthLevel,
        UpgradeBatteryEnergyLevel,
        UpgradeAttackLevel,
        UpgradeStarterBallsLevel,
        UpgradeSightLengthLevel,
    }

    public UpgradeStats()
    {
        SetMultipliers();
        SetUpgradeLevels();
        InitRequiredCoins();
        InitStatsUpgrading();
    }

    public void InitRequiredCoins()
    {
        // init How many coins required for upgrading all stats
        UpgradeHealthCoinsRequired =
            InitRequiredCoinsForUpgrading(RequiredCoinsStatsEnum.HealthUpgradeCost, HealthUpgradeMult);
        UpgradeBatteryEnergyCoinsRequired =
            InitRequiredCoinsForUpgrading(RequiredCoinsStatsEnum.BatteryEnergyUpgradeCost, BatteryEnergyUpgradeMult);
        UpgradeAttackCoinsRequired =
            InitRequiredCoinsForUpgrading(RequiredCoinsStatsEnum.AttackUpgradeCost, AttackUpgradeMult);
        UpgradeStarterBallsCoinsRequired =
            InitRequiredCoinsForUpgrading(RequiredCoinsStatsEnum.StarterBallsUpgradeCost, StarterBallsUpgradeMult);
        UpgradeSightLengthCoinsRequired =
            InitRequiredCoinsForUpgrading(RequiredCoinsStatsEnum.SightLengthUpgradeCost, SightLengthUpgradeMult);
    }


    // init How many coins required for upgrading single stat
    private float InitRequiredCoinsForUpgrading(RequiredCoinsStatsEnum requiredCoinsStatsEnum, float upgradeMult)
    {
        var upgradeCoinsRequired = _startCoinsUpgradeValue * upgradeMult;
        SaveRequiredCoins(requiredCoinsStatsEnum, upgradeCoinsRequired);

        //  Debug.Log("UpgradeHealthCoinsRequired is ->" + UpgradeHealthCoinsRequired);
        return upgradeCoinsRequired;
    }

    public void InitStatsUpgrading()
    {
        UpgradeHealthValue = _startHealthUpgradeValue * HealthUpgradeMult;
        UpgradeBatteryEnergyValue = _startBatteryEnergyUpgradeValue * BatteryEnergyUpgradeMult;
        UpgradeAttackValue = _startAttackUpgradeValue * AttackUpgradeMult;
        UpgradeStarterBallsValue = _startStarterBallsUpgradeValue * StarterBallsUpgradeMult;
        UpgradeSightLengthValue = _startSightLengthUpgradeValue * SightLengthUpgradeMult;
    }

    public void SetUpgradeLevels()
    {
        UpgradeHealthLevel = SetUpgradeLevel(UpgradeStatLevel.UpgradeHealthLevel);
        UpgradeBatteryEnergyLevel = SetUpgradeLevel(UpgradeStatLevel.UpgradeBatteryEnergyLevel);
        UpgradeAttackLevel = SetUpgradeLevel(UpgradeStatLevel.UpgradeAttackLevel);
        UpgradeStarterBallsLevel = SetUpgradeLevel(UpgradeStatLevel.UpgradeStarterBallsLevel);
        UpgradeSightLengthLevel = SetUpgradeLevel(UpgradeStatLevel.UpgradeSightLengthLevel);
    }

    public float LoadUpgradeLevel(UpgradeStatLevel upgradeLevel)
    {
        return PlayerPrefs.GetFloat(upgradeLevel.ToString());
    }

    public void SaveUpgradeLevel(UpgradeStatLevel upgradeLevel, float levelValue)
    {
        float newMultValue = LoadUpgradeLevel(upgradeLevel);
        newMultValue += levelValue;
        PlayerPrefs.SetFloat(upgradeLevel.ToString(), newMultValue);
        Debug.Log(upgradeLevel + " after saving is -> " + newMultValue);
    }

    private float SetUpgradeLevel(UpgradeStatLevel upgradeLevelEnum)
    {
        float upgradeLevelValue;
        if (LoadUpgradeLevel(upgradeLevelEnum) != 0)
        {
            upgradeLevelValue = LoadUpgradeLevel(upgradeLevelEnum);
        }
        else
        {
            upgradeLevelValue = _defaultUpgradeMult;
            SaveUpgradeLevel(upgradeLevelEnum, upgradeLevelValue);
        }

        return upgradeLevelValue;
    }

    public void SetMultipliers()
    {
        // Set multipliers for all upgrading stats
        HealthUpgradeMult = SetUpgradeMultiplier(UpgradeMultipliersEnum.HealthMultiplier);
        BatteryEnergyUpgradeMult = SetUpgradeMultiplier(UpgradeMultipliersEnum.BatteryEnergyMultiplier);
        AttackUpgradeMult = SetUpgradeMultiplier(UpgradeMultipliersEnum.AttackMultiplier);
        StarterBallsUpgradeMult = SetUpgradeMultiplier(UpgradeMultipliersEnum.StarterBallsMultiplier);
        SightLengthUpgradeMult = SetUpgradeMultiplier(UpgradeMultipliersEnum.SightLengthMultiplier);
    }

    private float SetUpgradeMultiplier(UpgradeMultipliersEnum multipliersEnum)
    {
        float upgradeMult;
        if (LoadUpgradeMultiplier(multipliersEnum) != 0)
        {
            upgradeMult = LoadUpgradeMultiplier(multipliersEnum);
        }
        else
        {
            upgradeMult = _defaultUpgradeMult;
            SaveUpgradeMultiplier(multipliersEnum, upgradeMult);
        }

        return upgradeMult;
    }

    public void SaveUpgradeMultiplier(UpgradeMultipliersEnum multiplierEnum, float multValue)
    {
        float newMultValue = LoadUpgradeMultiplier(multiplierEnum);
        newMultValue += multValue;
        PlayerPrefs.SetFloat(multiplierEnum.ToString(), newMultValue);
    }

    /**
     * Сбрасывает множитель апргрейда до дефолтного значения _defaultUpgradeMult
     */
    private void ClearUpgradeMultipliersToDefault()
    {
        PlayerPrefs.SetFloat(UpgradeMultipliersEnum.HealthMultiplier.ToString(), _defaultUpgradeMult);
        PlayerPrefs.SetFloat(UpgradeMultipliersEnum.BatteryEnergyMultiplier.ToString(), _defaultUpgradeMult);
        PlayerPrefs.SetFloat(UpgradeMultipliersEnum.AttackMultiplier.ToString(), _defaultUpgradeMult);
        PlayerPrefs.SetFloat(UpgradeMultipliersEnum.StarterBallsMultiplier.ToString(), _defaultUpgradeMult);
        PlayerPrefs.SetFloat(UpgradeMultipliersEnum.SightLengthMultiplier.ToString(), _defaultUpgradeMult);

        SetMultipliers();
        InitStatsUpgrading();
        InitRequiredCoins();
    }

    /**
     * Сбрасывает уровень апргрейда до дефолтного значения _defaultUpgradeLevel
     */
    private void ClearUpgradeLevelsToDefault()
    {
        PlayerPrefs.SetFloat(UpgradeStatLevel.UpgradeHealthLevel.ToString(), MinUpgradeHealthLevel);
        PlayerPrefs.SetFloat(UpgradeStatLevel.UpgradeBatteryEnergyLevel.ToString(), MinUpgradeBatteryEnergyLevel);
        PlayerPrefs.SetFloat(UpgradeStatLevel.UpgradeAttackLevel.ToString(), MinUpgradeAttackLevel);
        PlayerPrefs.SetFloat(UpgradeStatLevel.UpgradeStarterBallsLevel.ToString(), MinUpgradeStarterBallsLevel);
        PlayerPrefs.SetFloat(UpgradeStatLevel.UpgradeSightLengthLevel.ToString(), MinUpgradeSightLengthLevel);

        SetUpgradeLevels();
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

    /**
     * Сбрасывает множитель и уровень апгрейда до дефолтных значений _defaultUpgradeMult и _defaultUpgradeLevel
     */
    public void ClearStatsToDefault()
    {
        ClearUpgradeMultipliersToDefault();
        ClearUpgradeLevelsToDefault();
    }
}