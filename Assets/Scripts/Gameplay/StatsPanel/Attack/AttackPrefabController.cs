using Gameplay.StatsPanel.Attack;
using UnityEngine;
using UnityEngine.Serialization;

public class AttackPrefabController : MonoBehaviour
{
    [SerializeField] private int _baseAttackLevel;
    [SerializeField] private int _maxAttackLevel;
    [SerializeField] private int _currentAttackLevel;

    private AttackPrefab _attackPrefab;
    private UpgradeStats upgradeStats;


    private void Awake()
    {
        upgradeStats = new UpgradeStats();
        _attackPrefab = GetComponentInChildren<AttackPrefab>();
        LoadAttackLevel();
    }

    private void LoadAttackLevel()
    {
        // подгружаем min/max и текущий уровни прокачки
        _baseAttackLevel = (int)UpgradeStats.MinUpgradeAttackLevel;
        _maxAttackLevel = (int)UpgradeStats.MaxUpgradeAttackLevel;
        _currentAttackLevel = (int)upgradeStats.LoadUpgradeLevel(UpgradeStats.UpgradeStatLevel.UpgradeAttackLevel);
    }

    public void LoadAttackLevelAndShowSprite()
    {
        LoadAttackLevel();
        _attackPrefab.ChangeSprite(_currentAttackLevel);
    }

    /**
        Сбросить спрайт и уровень здоровья до 0-го уровня
    */
    public void ClearStatsToDefault()
    {
        _attackPrefab.ChangeSprite(_baseAttackLevel);
        _currentAttackLevel = _baseAttackLevel;
    }
}