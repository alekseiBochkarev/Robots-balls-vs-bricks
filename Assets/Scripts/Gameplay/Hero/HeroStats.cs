using UnityEngine;

public class HeroStats
{
    // Vars
    public float Attack { private set; get; }
    public float BatteryEnergy { private set; get; }
    public float Health { private set; get; }
    public float StarterBalls { private set; get; }
    public float SightLength { private set; get; }

    // default stats values
    private readonly int _defaultAttackValue = 1;
    private readonly int _defaultBatteryEnergyValue = 3;
    private readonly int _defaultHealthValue = 100;
    private readonly int _defaultStarterBallsValue = 3;
    private readonly int _defaultSightLengthValue = 1;

    public enum HeroStatsEnum
    {
        Health,
        BatteryEnergy,
        Attack,
        StarterBalls,
        SightLength
    }

    public HeroStats()
    {
        LoadStats();
    }

    private void LoadStats()
    {
        // Load all HeroStats
        Health = SetStatsAndSave(HeroStatsEnum.Health, _defaultHealthValue);
        BatteryEnergy = SetStatsAndSave(HeroStatsEnum.BatteryEnergy, _defaultBatteryEnergyValue);
        Attack = SetStatsAndSave(HeroStatsEnum.Attack, _defaultAttackValue);
        StarterBalls = SetStatsAndSave(HeroStatsEnum.StarterBalls, _defaultStarterBallsValue);
        SightLength = SetStatsAndSave(HeroStatsEnum.SightLength, _defaultSightLengthValue);
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
    }
}