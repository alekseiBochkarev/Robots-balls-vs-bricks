using Interfaces;
using UnityEngine;

public class HeroStats : IResetToDefaultValues
{
    // Vars
    public float Attack { private set; get; }
    public float BatteryEnergy { private set; get; }
    public float Health { private set; get; }
    public float StarterBalls { private set; get; }
    public float SightLength { private set; get; }
    public float StarterRocketBall { private set; get; }
    public float StarterIceBall { private set; get; }
    public float StarterLaserHorizontalBall { private set; get; }
    public float StarterLaserVerticalBall { private set; get; }
    public float StarterLaserCrossBall { private set; get; }
    public float StarterInstaKillBall { private set; get; }
    public float StarterFireBall { private set; get; }
    public float StarterBombBall { private set; get; }
    public float StarterPoisonBall { private set; get; }
    public float StarterBlackHoleBall { private set; get; }

    // default stats values
    private readonly int _defaultAttackValue = 1;
    private readonly int _defaultBatteryEnergyValue = 3;
    private readonly int _defaultHealthValue = 100;
    private readonly int _defaultStarterBallsValue = 1;
    private readonly int _defaultSightLengthValue = 2;
    private readonly int _defaultStarterSpecialBallValue = 0;

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

    public HeroStats()
    {
        LoadStats();
    }

    private void LoadStats()
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
    private float SetStatsAndSave(HeroStatsEnum statsEnum, float defaultStatsValue)
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

    public float GetStats(HeroStatsEnum statsEnum)
    {
        return PlayerPrefs.GetFloat(statsEnum.ToString());
    }

    private void SaveStats(HeroStatsEnum statsEnum, float statsValue)
    {
        PlayerPrefs.SetFloat(statsEnum.ToString(), statsValue);
    }

    public void UpgradeStats(HeroStatsEnum statsEnum, float upgradeAmount)
    {
        float statsValue = GetStats(statsEnum);
        statsValue += upgradeAmount;
        SaveStats(statsEnum, statsValue);
        LoadStats();
    }

    public void ClearStatsToDefault()
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
    }
}