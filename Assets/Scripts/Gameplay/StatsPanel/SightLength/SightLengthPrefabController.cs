using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SightLengthPrefabController : MonoBehaviour
{
    [SerializeField] private int _baseSightLengthLevel;
    [SerializeField] private int _maxSightLengthLevel;
    public int CurrentSightLengthLevel { private set; get; }

    private SightLengthPrefab _sightLengthPrefab;
    private UpgradeStats upgradeStats;


    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        if (upgradeStats == null)
            upgradeStats = new UpgradeStats();


        if (_sightLengthPrefab == null)
            _sightLengthPrefab = GetComponentInChildren<SightLengthPrefab>();

        LoadSightLengthLevel();
    }

    private void LoadSightLengthLevel()
    {
        // подгружаем min/max и текущий уровни прокачки
        _baseSightLengthLevel = (int)UpgradeStats.MinUpgradeSightLengthLevel;
        _maxSightLengthLevel = (int)UpgradeStats.MaxUpgradeSightLengthLevel;
        CurrentSightLengthLevel = (int)upgradeStats.LoadUpgradeLevel(UpgradeStats.UpgradeStatLevel.UpgradeSightLengthLevel);
    }
    
    public void LoadSightLengthLevelAndShowSprite()
    {
        LoadSightLengthLevel();
        _sightLengthPrefab.ChangeSprite(CurrentSightLengthLevel);
    }

    public void ClearStatsToDefault()
    {
        _sightLengthPrefab.ChangeSprite(_baseSightLengthLevel);
        CurrentSightLengthLevel = _baseSightLengthLevel;
    }
}
