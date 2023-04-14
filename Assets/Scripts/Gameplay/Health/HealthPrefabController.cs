using Gameplay.Health;
using Interfaces;
using UnityEngine;

public class HealthPrefabController : MonoBehaviour, IResetToDefaultValues
{
    [SerializeField] private int _baseHealthLevel;
    [SerializeField] private int _maxHealtLevel;
    [SerializeField] private int _currentHealthLevel;

    private HealthPrefab _healthPrefab;
    private UpgradeStats upgradeStats;


    private void Awake()
    {
        upgradeStats = new UpgradeStats();
        _healthPrefab = GetComponentInChildren<HealthPrefab>();
        LoadHealthLevel();
    }

    private void LoadHealthLevel()
    {
        // подгружаем min/max и текущий уровни прокачки
        _baseHealthLevel = (int)UpgradeStats.MinUpgradeHealthLevel;
        _maxHealtLevel = (int)UpgradeStats.MaxUpgradeHealthLevel;
        _currentHealthLevel = (int)upgradeStats.LoadUpgradeLevel(UpgradeStats.UpgradeStatLevel.UpgradeHealthLevel);
    }

    public void LoadHealthLevelAndShowSprite()
    {
        LoadHealthLevel();
        _healthPrefab.ChangeHealthSprite(_currentHealthLevel);
    }

    public void ClearStatsToDefault()
    {
        //ToDo Сбросить спрайт до 0-го уровня
        _healthPrefab.ChangeHealthSprite(_baseHealthLevel);
        _currentHealthLevel = (int)upgradeStats.LoadUpgradeLevel(UpgradeStats.UpgradeStatLevel.UpgradeHealthLevel);
    }
}