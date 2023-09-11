using Gameplay.StatsPanel.Attack;
using UnityEngine;
using UnityEngine.Serialization;

public class AttackPrefabController : MonoBehaviour
{
    [SerializeField] private int _baseAttackLevel;
    [SerializeField] private int _maxAttackLevel;
    public int CurrentAttackLevel { private set; get; }

    private AttackPrefab _attackPrefab;
    private UpgradeStats upgradeStats;


    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        if (upgradeStats == null)
            upgradeStats = new UpgradeStats();


        if (_attackPrefab == null)
            _attackPrefab = GetComponentInChildren<AttackPrefab>();

        LoadAttackLevel();
    }

    private void LoadAttackLevel()
    {
        // подгружаем min/max и текущий уровни прокачки
        _baseAttackLevel = (int)UpgradeStats.MinUpgradeAttackLevel;
        _maxAttackLevel = (int)UpgradeStats.MaxUpgradeAttackLevel;
        CurrentAttackLevel = (int)upgradeStats.LoadUpgradeLevel(UpgradeStats.UpgradeStatLevel.UpgradeAttackLevel);
    }

    public void LoadAttackLevelAndShowSprite()
    {
        LoadAttackLevel();
        _attackPrefab.ChangeSprite(CurrentAttackLevel);
    }

    /**
        Сбросить спрайт и уровень атаки до 0-го уровня
    */
    public void ClearStatsToDefault()
    {
        _attackPrefab.ChangeSprite(_baseAttackLevel);
        CurrentAttackLevel = _baseAttackLevel;
    }
}