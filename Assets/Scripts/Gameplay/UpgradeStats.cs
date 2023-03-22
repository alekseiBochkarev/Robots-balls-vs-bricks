using UnityEngine;

public class UpgradeStats
{
    //ToDo needs to be done:
    //1) Health
    //2) Battery Energy
    //3) Attack Power
    //4) Starter balls amount
    //5) Sight length

    //vars -> Coins required for upgrading
    public float UpgradeHealthCoinsRequired { private set; get; }
    public float UpgradeBatteryEnergyCoinsRequired { private set; get; }
    public float UpgradeAttackCoinsRequired { private set; get; }
    public float UpgradeStarterBallsCoinsRequired { private set; get; }
    public float UpgradeSightLengthCoinsRequired { private set; get; }


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
    private readonly float _startBatteryEnergyUpgradeValue = 30;
    private readonly float _startAttackUpgradeValue = 1;
    private readonly float _startStarterBallsUpgradeValue = 1;
    private readonly float _startSightLengthUpgradeValue = 1;

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

    public UpgradeStats()
    {
        SetMultipliers();
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