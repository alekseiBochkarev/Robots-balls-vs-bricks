using Gameplay.Health;
using Interfaces;
using UnityEngine;

public class HealthPrefabController : MonoBehaviour, IResetToDefaultValues
{
    [SerializeField] private int _baseHealthLevel;
    [SerializeField] private int _maxHealtLevel;
    public int CurrentHealthLevel { private set; get; }

    private HealthPrefab _healthPrefab;
    private UpgradeStats upgradeStats;


    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        if (upgradeStats == null)
            upgradeStats = new UpgradeStats();


        if (_healthPrefab == null)
            _healthPrefab = GetComponentInChildren<HealthPrefab>();

        LoadHealthLevel();
    }

    private void LoadHealthLevel()
    {
        // подгружаем min/max и текущий уровни прокачки
        _baseHealthLevel = (int)UpgradeStats.MinUpgradeHealthLevel;
        _maxHealtLevel = (int)UpgradeStats.MaxUpgradeHealthLevel;
        CurrentHealthLevel = (int)upgradeStats.LoadUpgradeLevel(UpgradeStats.UpgradeStatLevel.UpgradeHealthLevel);
    }

    public void LoadHealthLevelAndShowSprite()
    {
        LoadHealthLevel();
        _healthPrefab.ChangeSprite(CurrentHealthLevel);
    }

    /**
        Сбросить спрайт и уровень здоровья до 0-го уровня
    */
    public void ClearStatsToDefault()
    {
        _healthPrefab.ChangeSprite(_baseHealthLevel);
        CurrentHealthLevel = _baseHealthLevel;
    }
}