using Interfaces;
using UnityEngine;

public class HeroStats
{
    private static float attack;
    private static float batteryEnergy;
    private static float health;
    private static float starterBalls;
    private static float sightLength;
    private static float starterRocketBall;
    private static float starterIceBall;
    private static float starterLaserHorizontalBall;
    private static float starterLaserVerticalBall;
    private static float starterLaserCrossBall;
    private static float starterInstaKillBall;
    private static float starterFireBall;
    private static float starterBombBall;
    private static float starterPoisonBall;
    private static float starterBlackHoleBall;


    // Vars
    public static float Attack { private set { attack = value; }
        get { 
            LoadStats();
            return attack;
        } }
    public static float BatteryEnergy { private set { batteryEnergy = value; }
        get
        {
            LoadStats();
            return batteryEnergy;
        }
    }
    public static float Health { private set { health = value; }
        get
        {
            LoadStats();
            return health;
        }
    }
    public static float StarterBalls { private set { starterBalls = value; }
        get
        {
            LoadStats();
            return starterBalls;
        }
    }
    public static float SightLength { private set { sightLength = value; }
        get
        {
            LoadStats();
            return sightLength;
        }
    }
    public static float StarterRocketBall { private set { starterRocketBall = value; }
        get
        {
            LoadStats();
            return starterRocketBall;
        }
    }
    public static float StarterIceBall { private set { starterIceBall = value; }
        get
        {
            LoadStats();
            return starterIceBall;
        }
    }
    public static float StarterLaserHorizontalBall { private set { starterLaserHorizontalBall = value; }
        get
        {
            LoadStats();
            return starterLaserHorizontalBall;
        }
    }
    public static float StarterLaserVerticalBall { private set { starterLaserVerticalBall = value; }
        get
        {
            LoadStats();
            return starterLaserVerticalBall;
        }
    }
    public static float StarterLaserCrossBall { private set { starterLaserCrossBall = value; }
        get
        {
            LoadStats();
            return starterLaserCrossBall;
        }
    }
    public static float StarterInstaKillBall { private set { starterInstaKillBall = value; }
        get
        {
            LoadStats();
            return starterInstaKillBall;
        }
    }
    public static float StarterFireBall { private set { starterFireBall = value; }
        get
        {
            LoadStats();
            return starterFireBall;
        }
    }
    public static float StarterBombBall { private set { starterBombBall = value; }
        get
        {
            LoadStats();
            return starterBombBall;
        }
    }
    public static float StarterPoisonBall { private set { starterPoisonBall = value; }
        get
        {
            LoadStats();
            return starterPoisonBall;
        }
    }
    public static float StarterBlackHoleBall { private set { starterBlackHoleBall = value; }
        get
        {
            LoadStats();
            return starterBlackHoleBall;
        }
    }

    // default stats values
    private static readonly int _defaultAttackValue = 1;
    private static readonly int _defaultBatteryEnergyValue = 3;
    private static readonly int _defaultHealthValue = 100;
    private static readonly int _defaultStarterBallsValue = 1;
    private static readonly int _defaultSightLengthValue = 2;
    private static readonly int _defaultStarterSpecialBallValue = 0;

    //vars from body
    public static float BodyAttack { set; get; }
    public static float BodyHealth { set; get; }
    public static float BodyStarterBalls { set; get; }
    public static float BodySightLength { set; get; }

    public enum HeroStatsEnum
    {
        Health,
        BatteryEnergy,
        Attack,
        StarterBalls,
        SightLength,
        StarterRocketBall,
        StarterIceBall,
        StarterLaserHorizontalBall,
        StarterLaserVerticalBall,
        StarterLaserCrossBall,
        StarterInstaKillBall,
        StarterFireBall,
        StarterBombBall,
        StarterPoisonBall,
        StarterBlackHoleBall
    }

    /*public HeroStats()
    {
        LoadStats();
    }*/

    private static void LoadStats()
    {
        // Load all HeroStats
        Health = SetStatsAndSave(HeroStatsEnum.Health, _defaultHealthValue) + BodyHealth;
        BatteryEnergy = SetStatsAndSave(HeroStatsEnum.BatteryEnergy, _defaultBatteryEnergyValue);
        Attack = SetStatsAndSave(HeroStatsEnum.Attack, _defaultAttackValue) + BodyAttack;
        StarterBalls = SetStatsAndSave(HeroStatsEnum.StarterBalls, _defaultStarterBallsValue) + BodyStarterBalls;
        SightLength = SetStatsAndSave(HeroStatsEnum.SightLength, _defaultSightLengthValue) + BodySightLength;
        StarterRocketBall = SetStatsAndSave(HeroStatsEnum.StarterRocketBall, _defaultStarterSpecialBallValue);
        StarterIceBall = SetStatsAndSave(HeroStatsEnum.StarterIceBall, _defaultStarterSpecialBallValue);
        StarterLaserHorizontalBall = SetStatsAndSave(HeroStatsEnum.StarterLaserHorizontalBall, _defaultStarterSpecialBallValue);
        StarterLaserVerticalBall = SetStatsAndSave(HeroStatsEnum.StarterLaserVerticalBall, _defaultStarterSpecialBallValue);
        StarterLaserCrossBall = SetStatsAndSave(HeroStatsEnum.StarterLaserCrossBall, _defaultStarterSpecialBallValue);
        StarterInstaKillBall = SetStatsAndSave(HeroStatsEnum.StarterInstaKillBall, _defaultStarterSpecialBallValue);
        StarterFireBall = SetStatsAndSave(HeroStatsEnum.StarterFireBall, _defaultStarterSpecialBallValue);
        StarterBombBall = SetStatsAndSave(HeroStatsEnum.StarterBombBall, _defaultStarterSpecialBallValue);
        StarterPoisonBall = SetStatsAndSave(HeroStatsEnum.StarterPoisonBall, _defaultStarterSpecialBallValue);
        StarterBlackHoleBall = SetStatsAndSave(HeroStatsEnum.StarterBlackHoleBall, _defaultStarterSpecialBallValue); 
    }

    // Load stat from PlayerPrefs, if no value present -> set defaultStatsValue and SaveIt
    private static float SetStatsAndSave(HeroStatsEnum statsEnum, float defaultStatsValue)
    {
        float statValue;
        if (GetStats(statsEnum) != 0)
        {
            statValue = GetStats(statsEnum);
        }
        else
        {
            statValue = defaultStatsValue;
            SaveStats(statsEnum, statValue);
        }
        return statValue;
    }

    public static float GetStats(HeroStatsEnum statsEnum)
    {
        return PlayerPrefs.GetFloat(statsEnum.ToString());
    }

    private static void SaveStats(HeroStatsEnum statsEnum, float statsValue)
    {
        PlayerPrefs.SetFloat(statsEnum.ToString(), statsValue);
    }

    public static void UpgradeStats(HeroStatsEnum statsEnum, float upgradeAmount)
    {
        float statsValue = GetStats(statsEnum);
        statsValue += upgradeAmount;
        SaveStats(statsEnum, statsValue);
        LoadStats();
    }

    public static void ClearStatsToDefault()
    {
        SaveStats(HeroStatsEnum.Health, _defaultHealthValue);
        SaveStats(HeroStatsEnum.BatteryEnergy, _defaultBatteryEnergyValue);
        SaveStats(HeroStatsEnum.Attack, _defaultAttackValue);
        SaveStats(HeroStatsEnum.StarterBalls, _defaultStarterBallsValue);
        SaveStats(HeroStatsEnum.SightLength, _defaultSightLengthValue);
        SaveStats(HeroStatsEnum.StarterRocketBall, _defaultStarterSpecialBallValue);
        SaveStats(HeroStatsEnum.StarterIceBall, _defaultStarterSpecialBallValue);
        SaveStats(HeroStatsEnum.StarterLaserHorizontalBall, _defaultStarterSpecialBallValue);
        SaveStats(HeroStatsEnum.StarterLaserVerticalBall, _defaultStarterSpecialBallValue);
        SaveStats(HeroStatsEnum.StarterLaserCrossBall, _defaultStarterSpecialBallValue);
        SaveStats(HeroStatsEnum.StarterInstaKillBall, _defaultStarterSpecialBallValue);
        SaveStats(HeroStatsEnum.StarterFireBall, _defaultStarterSpecialBallValue);
        SaveStats(HeroStatsEnum.StarterBombBall, _defaultStarterSpecialBallValue);
        SaveStats(HeroStatsEnum.StarterPoisonBall, _defaultStarterSpecialBallValue);
        SaveStats(HeroStatsEnum.StarterBlackHoleBall, _defaultStarterSpecialBallValue);
        EventManager.OnUpgradeStats();
    }
}