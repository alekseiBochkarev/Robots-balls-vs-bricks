using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action BrickDestroyed;
    public static event Action<int> HealthChanged;
    public static event Action BrickHit;

    public static event Action BallsReturned;

    public static event Action GameWon;
    public static event Action LevelUp;
    public static event Action UpgradeStats;
    public static event Action<HeroBuffSO> HeroBuffAdded;
    public static event Action<int> ComboCounterChanged;

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
    public static void OnLevelUp()
    {
        LevelUp?.Invoke();
    }
    public static void OnGameWon() 
    {
        GameWon?.Invoke();
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
}