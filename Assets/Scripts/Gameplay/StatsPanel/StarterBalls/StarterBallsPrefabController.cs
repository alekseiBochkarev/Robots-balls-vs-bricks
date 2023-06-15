using System.Collections;
using System.Collections.Generic;
using Gameplay.StatsPanel.StarterBalls;
using Interfaces;
using UnityEngine;

public class StarterBallsPrefabController : MonoBehaviour, IResetToDefaultValues
{
    [SerializeField] private int _baseStarterBallsLevel;
    [SerializeField] private int _maxStarterBallsLevel;
    public int CurrentBallsLevel { private set; get; }

    private StarterBallsPrefab _starterBallsPrefab;
    private UpgradeStats upgradeStats;


    private void Awake()
    {
        upgradeStats = new UpgradeStats();
        
        _starterBallsPrefab = GetComponentInChildren<StarterBallsPrefab>();
        LoadStarterBallsLevel();
    }

    private void LoadStarterBallsLevel()
    {
        // подгружаем min/max и текущий уровни прокачки
        _baseStarterBallsLevel = (int)UpgradeStats.MinUpgradeStarterBallsLevel;
        _maxStarterBallsLevel = (int)UpgradeStats.MaxUpgradeStarterBallsLevel;
        CurrentBallsLevel = (int)upgradeStats.LoadUpgradeLevel(UpgradeStats.UpgradeStatLevel.UpgradeStarterBallsLevel);
    }
    
    public void LoadStarterBallsLevelAndShowSprite()
    {
        LoadStarterBallsLevel();
        _starterBallsPrefab.ChangeSprite(CurrentBallsLevel);
    }

    public void ClearStatsToDefault()
    {
        _starterBallsPrefab.ChangeSprite(_baseStarterBallsLevel);
        CurrentBallsLevel = _baseStarterBallsLevel;
    }
}
