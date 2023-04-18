using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SightLengthPrefabController : MonoBehaviour
{
    [SerializeField] private int _baseSightLengthLevel;
    [SerializeField] private int _maxSightLengthLevel;
    [SerializeField] private int _currentSightLengthLevel;

    private SightLengthPrefab _sightLengthPrefab;
    private UpgradeStats upgradeStats;


    private void Awake()
    {
        upgradeStats = new UpgradeStats();
        
        _sightLengthPrefab = GetComponentInChildren<SightLengthPrefab>();
        LoadSightLengthLevel();
    }

    private void LoadSightLengthLevel()
    {
        // подгружаем min/max и текущий уровни прокачки
        _baseSightLengthLevel = (int)UpgradeStats.MinUpgradeSightLengthLevel;
        _maxSightLengthLevel = (int)UpgradeStats.MaxUpgradeSightLengthLevel;
        _currentSightLengthLevel = (int)upgradeStats.LoadUpgradeLevel(UpgradeStats.UpgradeStatLevel.UpgradeSightLengthLevel);
    }
    
    public void LoadSightLengthLevelAndShowSprite()
    {
        LoadSightLengthLevel();
        _sightLengthPrefab.ChangeSprite(_currentSightLengthLevel);
    }

    public void ClearStatsToDefault()
    {
        _sightLengthPrefab.ChangeSprite(_baseSightLengthLevel);
        _currentSightLengthLevel = _baseSightLengthLevel;
    }
}
