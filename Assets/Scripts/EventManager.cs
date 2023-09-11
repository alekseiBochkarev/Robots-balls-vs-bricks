using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action BrickDestroyed;
    public static event Action<int> HealthChanged;
    public static event Action BrickHit;

    public static event Action GameWon;
    public static event Action GameLose;
    public static event Action EnergyIsOverEvent;
    public static event Action LifeIsOverEvent;
    public static event Action LevelUp;
    public static event Action UpgradeStats;
    public static event Action UpgradeAttackPowerStat;
    public static event Action CoinsChanged;
    public static event Action<HeroBuffSO> HeroBuffAdded;
    public static event Action<int> ComboCounterChanged;
    public static event Action AllBallsLaunched;
    public static event Action BallsReturned;
    public static event Action SkinChanged;
    public static event Action LevelStarted;
    public static event Action NewBallsOnStartSpawned;
    public static event Action AllBallsReturned;
    public static event Action ResetReturningBallsAmount;

    public static void OnComboCounterChanged(int currentComboAmount)
    {
        ComboCounterChanged?.Invoke(currentComboAmount);
    }

    public static void OnHeroBuffAdded(HeroBuffSO _heroBuffSO)
    {
        HeroBuffAdded?.Invoke(_heroBuffSO);
    }

    public static void OnUpgradeStats()
    {
        UpgradeStats?.Invoke();
    }  
    
    public static void OnUpgradeAttackPowerStat()
    {
        UpgradeAttackPowerStat?.Invoke();
    }

    public static void OnCoinsChanged()
    {
        CoinsChanged?.Invoke();
    }

    public static void OnLevelUp()
    {
        LevelUp?.Invoke();
    }

    public static void OnGameWon()
    {
        Debug.Log("Game won event");
        GameWon?.Invoke();
    }

    public static void OnGameLose()
    {
        Debug.Log("Game lose event");
        GameLose?.Invoke();
    }

    public static void OnEnergyIsOverEvent()
    {
        EnergyIsOverEvent?.Invoke();
    }
    
    public static void OnLifeIsOverEvent()
    {
        LifeIsOverEvent?.Invoke();
    }

    public static void OnBrickDestroyed()
    {
        BrickDestroyed?.Invoke();
    }

    public static void OnHealthChanged(int health)
    {
        HealthChanged?.Invoke(health);
    }

    public static void OnBrickHit()
    {
        BrickHit?.Invoke();
    }

    public static void OnBallsReturned()
    {
        BallsReturned?.Invoke();
    }

    public static void OnSkinChanged()
    {
        SkinChanged?.Invoke();
    }

    public static void OnLevelStarted()
    {
        LevelStarted?.Invoke();
    }

    public static void OnNewBallsOnStartSpawned()
    {
        NewBallsOnStartSpawned?.Invoke();
    }

    //ToDo AllBallsLaunched использовать в будущем для интеграции с батареей
    public static void OnAllBallsLaunched()
    {
        AllBallsLaunched?.Invoke();
    }

    public static void OnAllBallsReturned()
    {
        AllBallsReturned?.Invoke();
    }

    public static void OnResetReturningBallsAmount()
    {
        ResetReturningBallsAmount?.Invoke();
    }
}