using Gameplay.Batteries.Battery_Cell;
using Gameplay.StatsPanel.StarterBalls;
using Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIUpgradeStatsPanel : MonoBehaviour, IResetToDefaultValues
{
    /**
     * Данный класс будет отвечать за отображение информации о стате героя, а также его прокачки через кнопку:
     * 1) При отображении панели загружается панель, в которой будет префаб того, что качаем, название и цена
     * 2) Определить единственный метод прокачки, который будет принимать в себя Transform/Gameobject, внутри него будет
     * зашит метод типа Upgrade, к которому и будет идти обращение
     * 3) Все префабы интерактивные, чтобы наглядно показать прокачку героя
     */

    // Need to rework for new STATS, use Transform/gameobject Instea
    private HeroStats heroStats;

    private Coins coins;
    private UpgradeStats upgradeStats;

    private AttackPrefabController _attackPrefabController;
    private BatteryCellController _batteryCellController;
    private HealthPrefabController _healthPrefabController;
    private StarterBallsPrefabController _starterBallsPrefabController;

    [Header("Stat Prefabs")]
    [SerializeField] private GameObject healthPrefab;
    [SerializeField] private GameObject batteryCellsPrefab;
    [SerializeField] private GameObject attackPrefab;
    [SerializeField] private GameObject starterBallsPrefab;
    [SerializeField] private GameObject sightLengthPrefab;

    [Header("Hero Stats Names")] [SerializeField]
    private TextMeshProUGUI healthText;

    [SerializeField] private TextMeshProUGUI batteryCellsText;
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI starterBallsText;
    [SerializeField] private TextMeshProUGUI sightLengthText;

    [Header("Upgrade Buttons")] [SerializeField]
    private Button upgradeHealthButton;

    [SerializeField] private Button upgradeBatteryCellsButton;
    [SerializeField] private Button upgradeAttackPowerButton;
    [SerializeField] private Button upgradeStarterBallsButton;
    [SerializeField] private Button upgradeSightLengthButton;

    [Header("Upgrade Cost Text")] [SerializeField]
    private TextMeshProUGUI upgradeHealthButtonText;

    [SerializeField] private TextMeshProUGUI upgradeBatteryCellsButtonText;
    [SerializeField] private TextMeshProUGUI upgradeAttackPowerButtonText;
    [SerializeField] private TextMeshProUGUI upgradeStarterBallsButtonText;
    [SerializeField] private TextMeshProUGUI upgradeSightLengthButtonText;

    private const string HealthStatText = "Health";
    private const string BatteryCellsStatText = "Battery cells";
    private const string AttackStatText = "Attack";
    private const string StarterBallsStatText = "Starter balls";
    private const string SightLengthStatText = "Sight length";
    private const string MaxLevelStatText = "MAX";

    private const float _addUpgradeMult = 1;
    private const float _addUpgradeLevel = 1;
    private float _playerCoins;
    private float _playerHealth;
    private float _playerBatteryEnergy;
    private float _playerAttack;
    private float _playerStarterBalls;
    private float _playerSightLength;


    private void Awake()
    {
        upgradeStats = new UpgradeStats();
        heroStats = new HeroStats();
        coins = new Coins();

        // Получаем контроллеры всех статов из их префабов
        _attackPrefabController = attackPrefab.GetComponentInChildren<AttackPrefabController>();
        _batteryCellController = batteryCellsPrefab.GetComponentInChildren<BatteryCellController>();
        _healthPrefabController = healthPrefab.GetComponent<HealthPrefabController>();
        _starterBallsPrefabController = starterBallsPrefab.GetComponent<StarterBallsPrefabController>();

        // Подписываемся на ивенты
        EventManager.GameWon += ClearStatsToDefault;
        EventManager.CoinsChanged += ShowStatsDataAndRuleButtons;
        EventManager.UpgradeStats += ShowStatsDataAndRuleButtons;
    }

    private void Start()
    {
        //Init players stats for UI and future upgrade
        GetCoins();

        _playerHealth = heroStats.Health;
        _playerBatteryEnergy = heroStats.BatteryEnergy;
        _playerAttack = heroStats.Attack;
        _playerStarterBalls = heroStats.StarterBalls;
        _playerSightLength = heroStats.SightLength;

        ShowStatsDataAndRuleButtons();

        //Init prefab scripts
        _attackPrefabController.LoadAttackLevelAndShowSprite();
        _batteryCellController.LoadAndShowBatteryCells();
        _healthPrefabController.LoadHealthLevelAndShowSprite();
        _starterBallsPrefabController.LoadStarterBallsLevelAndShowSprite();
    }

    private void OnDestroy()
    {
        EventManager.GameWon -= ClearStatsToDefault;
        EventManager.CoinsChanged -= ShowStatsDataAndRuleButtons;
        EventManager.UpgradeStats -= ShowStatsDataAndRuleButtons;
    }

    private void Update()
    {
        DebugMethod(); // this one only for debugging
    }

    /**
     * Отображает информацию о статах
     * Также управляет жизненным циклом кнопки в зависимости от уровня прокачки статов и кол-ва монеток (вкл/выкл)
     */
    private void ShowStatsDataAndRuleButtons()
    {
        GetCoins();

        ShowCurrentStatsName(healthText, HealthStatText);
        ShowCurrentStatsName(batteryCellsText, BatteryCellsStatText);
        ShowCurrentStatsName(attackText, AttackStatText);
        ShowCurrentStatsName(starterBallsText, StarterBallsStatText);
        ShowCurrentStatsName(sightLengthText, SightLengthStatText);

        ShowUpgradePrice(upgradeHealthButtonText, upgradeStats.UpgradeHealthCoinsRequired);
        ShowUpgradePrice(upgradeBatteryCellsButtonText, upgradeStats.UpgradeBatteryEnergyCoinsRequired);
        ShowUpgradePrice(upgradeAttackPowerButtonText, upgradeStats.UpgradeAttackCoinsRequired);
        ShowUpgradePrice(upgradeStarterBallsButtonText, upgradeStats.UpgradeStarterBallsCoinsRequired);
        ShowUpgradePrice(upgradeSightLengthButtonText, upgradeStats.UpgradeSightLengthCoinsRequired);

        RuleUpgradeButtonState(upgradeHealthButton, upgradeStats.UpgradeHealthCoinsRequired);
        RuleUpgradeButtonState(upgradeBatteryCellsButton, upgradeStats.UpgradeBatteryEnergyCoinsRequired);
        RuleUpgradeButtonState(upgradeAttackPowerButton, upgradeStats.UpgradeAttackCoinsRequired);
        RuleUpgradeButtonState(upgradeStarterBallsButton, upgradeStats.UpgradeStarterBallsCoinsRequired);
        RuleUpgradeButtonState(upgradeSightLengthButton, upgradeStats.UpgradeSightLengthCoinsRequired);
    }

    /**
     * Включает/выключает определенную кнопку апгрейда, если монеток недостаточно
     */
    private void RuleUpgradeButtonState(Button upgradeButton, float coinsRequiredToEnable)
    {
        if (_playerCoins < coinsRequiredToEnable) // check for Health Button
        {
            DisableUpgradeButton(upgradeButton);
        }
        else
        {
            // for Health
            if (upgradeButton.Equals(upgradeHealthButton))
            {
                Debug.Log("UpgradeHealthLevel is -> " + upgradeStats.UpgradeHealthLevel);
                if (upgradeStats.UpgradeHealthLevel == UpgradeStats.MaxUpgradeHealthLevel)
                {
                    ShowMaxLevelInsteadPrice(upgradeHealthButtonText);
                }

                if (upgradeStats.UpgradeHealthLevel < UpgradeStats.MaxUpgradeHealthLevel)
                {
                    EnableUpgradeButton(upgradeButton);
                }
                else
                {
                    DisableUpgradeButton(upgradeButton);
                }
            }

            // for Battery Cells
            if (upgradeButton.Equals(upgradeBatteryCellsButton))
            {
                Debug.Log("UpgradeBatteryEnergyLevel is -> " + upgradeStats.UpgradeBatteryEnergyLevel);
                if (upgradeStats.UpgradeBatteryEnergyLevel == UpgradeStats.MaxUpgradeBatteryEnergyLevel)
                {
                    ShowMaxLevelInsteadPrice(upgradeBatteryCellsButtonText);
                }

                if (upgradeStats.UpgradeBatteryEnergyLevel < UpgradeStats.MaxUpgradeBatteryEnergyLevel)
                {
                    EnableUpgradeButton(upgradeButton);
                }
                else
                {
                    DisableUpgradeButton(upgradeButton);
                }
            }

            // for Attack
            if (upgradeButton.Equals(upgradeAttackPowerButton))
            {
                Debug.Log("UpgradeAttackLevel is -> " + upgradeStats.UpgradeAttackLevel);
                if (upgradeStats.UpgradeAttackLevel == UpgradeStats.MaxUpgradeAttackLevel)
                {
                    ShowMaxLevelInsteadPrice(upgradeAttackPowerButtonText);
                }

                if (upgradeStats.UpgradeAttackLevel < UpgradeStats.MaxUpgradeAttackLevel)
                {
                    EnableUpgradeButton(upgradeButton);
                }
                else
                {
                    DisableUpgradeButton(upgradeButton);
                }
            }

            // for StarterBalls
            if (upgradeButton.Equals(upgradeStarterBallsButton))
            {
                Debug.Log("UpgradeStarterBallsLevel is -> " + upgradeStats.UpgradeStarterBallsLevel);
                if (upgradeStats.UpgradeStarterBallsLevel == UpgradeStats.MaxUpgradeStarterBallsLevel)
                {
                    ShowMaxLevelInsteadPrice(upgradeStarterBallsButtonText);
                }

                if (upgradeStats.UpgradeStarterBallsLevel < UpgradeStats.MaxUpgradeStarterBallsLevel)
                {
                    EnableUpgradeButton(upgradeButton);
                }
                else
                {
                    DisableUpgradeButton(upgradeButton);
                }
            }
        }
    }

    public void UpgradeHealthOnClick() // It upgrades health on click
    {
        // remove coins after buying
        coins.RemoveCoins(upgradeStats.UpgradeHealthCoinsRequired);

        // Add Health to the player
        heroStats.UpgradeStats(HeroStats.HeroStatsEnum.Health, upgradeStats.UpgradeHealthValue);

        // Reinit local values for health
        _playerHealth = heroStats.Health;

        // Update UpgradeMultiplier and reinit RequiredCoins, StatsUpgrading
        GetCoins();
        upgradeStats.SaveUpgradeMultiplier(UpgradeStats.UpgradeMultipliersEnum.HealthMultiplier, _addUpgradeMult);
        upgradeStats.SaveUpgradeLevel(UpgradeStats.UpgradeStatLevel.UpgradeHealthLevel, _addUpgradeLevel);
        upgradeStats.SetUpgradeLevels();
        upgradeStats.SetMultipliers();
        upgradeStats.InitRequiredCoins();
        upgradeStats.InitStatsUpgrading();

        //Show new values on UpgradeButton after changing (DO WE NEED REALLY NEED THIS?)
        ShowUpgradePrice(upgradeHealthButtonText, upgradeStats.UpgradeHealthCoinsRequired);

       // Hero.Instance.SetMaxHealth(heroStats.Health);
        Hero.Instance.UpdateHeroHealthAndHealthBar(_playerHealth);

        // Отобразить префабы статов уже на сброшенных значениях
        _healthPrefabController.LoadHealthLevelAndShowSprite();

        //EventManager to show changes in other classes
        EventManager.OnUpgradeStats();
    }

    public void UpgradeBatteryEnergyOnClick() // It upgrades battery cells on click
    {
        // remove coins after buying
        coins.RemoveCoins(upgradeStats.UpgradeHealthCoinsRequired);

        // Add BatteryEnergy to the player
        heroStats.UpgradeStats(HeroStats.HeroStatsEnum.BatteryEnergy, upgradeStats.UpgradeBatteryEnergyValue);

        // Reinit local values for health
        _playerBatteryEnergy = heroStats.BatteryEnergy;

        // Update UpgradeMultiplier and reinit RequiredCoins, StatsUpgrading
        GetCoins();
        upgradeStats.SaveUpgradeMultiplier(UpgradeStats.UpgradeMultipliersEnum.BatteryEnergyMultiplier,
            _addUpgradeMult);
        upgradeStats.SaveUpgradeLevel(UpgradeStats.UpgradeStatLevel.UpgradeBatteryEnergyLevel, _addUpgradeLevel);
        upgradeStats.SetUpgradeLevels();
        upgradeStats.SetMultipliers();
        upgradeStats.InitRequiredCoins();
        upgradeStats.InitStatsUpgrading();

        //Show new values on UpgradeButton after changing (DO WE NEED REALLY NEED THIS?)
        ShowUpgradePrice(upgradeHealthButtonText, upgradeStats.UpgradeHealthCoinsRequired);

        // Добавляем ячейку в батарею
        _batteryCellController.AddCell();

        //EventManager to show changes in other classes
        EventManager.OnUpgradeStats();
    }

    public void UpgradeAttackPowerOnClick() // It upgrades Attack Power on click
    {
        // remove coins after buying
        coins.RemoveCoins(upgradeStats.UpgradeAttackCoinsRequired);

        // Add Attack Power to the player
        heroStats.UpgradeStats(HeroStats.HeroStatsEnum.Attack, upgradeStats.UpgradeAttackValue);

        // Reinit local values for Attack Power
        _playerAttack = heroStats.Attack;

        // Update UpgradeMultiplier and reinit RequiredCoins, StatsUpgrading
        GetCoins();
        upgradeStats.SaveUpgradeMultiplier(UpgradeStats.UpgradeMultipliersEnum.AttackMultiplier, _addUpgradeMult);
        upgradeStats.SaveUpgradeLevel(UpgradeStats.UpgradeStatLevel.UpgradeAttackLevel, _addUpgradeLevel);
        upgradeStats.SetUpgradeLevels();
        upgradeStats.SetMultipliers();
        upgradeStats.InitRequiredCoins();
        upgradeStats.InitStatsUpgrading();

        //Show new values on UpgradeButton after changing (DO WE NEED REALLY NEED THIS?)
        ShowUpgradePrice(upgradeAttackPowerButtonText, upgradeStats.UpgradeAttackCoinsRequired);

        // Отобразить префаб уже с обновленной атакой
        _attackPrefabController.LoadAttackLevelAndShowSprite();
        
        // Проапргрейдить аттаку
        Hero.Instance.attackSkill = (int)_playerAttack;

        //EventManager to show changes in other classes
        EventManager.OnUpgradeStats();
        EventManager.OnUpgradeAttackPowerStat();
    }

    public void UpgradeStarterBallsOnClick() // It upgrades Starter Balls amount on click
    {
        // remove coins after buying
        coins.RemoveCoins(upgradeStats.UpgradeStarterBallsCoinsRequired);

        // Add Starter Balls to the player
        heroStats.UpgradeStats(HeroStats.HeroStatsEnum.StarterBalls, upgradeStats.UpgradeStarterBallsValue);

        // Reinit local values for Starter Balls
        _playerStarterBalls = heroStats.StarterBalls;

        // Update UpgradeMultiplier and reinit RequiredCoins, StatsUpgrading
        GetCoins();
        upgradeStats.SaveUpgradeMultiplier(UpgradeStats.UpgradeMultipliersEnum.StarterBallsMultiplier, _addUpgradeMult);
        upgradeStats.SaveUpgradeLevel(UpgradeStats.UpgradeStatLevel.UpgradeStarterBallsLevel, _addUpgradeLevel);
        upgradeStats.SetUpgradeLevels();
        upgradeStats.SetMultipliers();
        upgradeStats.InitRequiredCoins();
        upgradeStats.InitStatsUpgrading();

        //Show new values on UpgradeButton after changing (DO WE NEED REALLY NEED THIS?)
        ShowUpgradePrice(upgradeStarterBallsButtonText, upgradeStats.UpgradeStarterBallsCoinsRequired);

        // Отобразить префабы статов уже на сброшенных значениях
        _starterBallsPrefabController.LoadStarterBallsLevelAndShowSprite();
        
        // Добавляем базовый мяч в лист шаров
        Balls.Instance.AddBallToList(BallsTypeEnum.Ball);

        //EventManager to show changes in other classes
        EventManager.OnUpgradeStats();
    }

    public void ClearStatsToDefault()
    {
        // Сброс статов, множителей и уровней прокачки до дефолтных значений
        heroStats.ClearStatsToDefault();
        upgradeStats.ClearStatsToDefault();

        _playerHealth = heroStats.GetStats(HeroStats.HeroStatsEnum.Health);
        _playerAttack = heroStats.GetStats(HeroStats.HeroStatsEnum.Attack);
        _playerStarterBalls = heroStats.GetStats(HeroStats.HeroStatsEnum.StarterBalls);

        Hero.Instance.UpdateHeroHealthAndHealthBar(_playerHealth);
        Hero.Instance.attackSkill = (int)_playerAttack;
        Balls.Instance.ClearStatsToDefault();
        //ToDO Сбросить аттаку

        //Сброс скриптов у префабов до дефолтных значений
        _batteryCellController.ClearStatsToDefault();
        _healthPrefabController.ClearStatsToDefault();
        _attackPrefabController.ClearStatsToDefault();
        _starterBallsPrefabController.ClearStatsToDefault();

        //Отобразить цену после сброса до дефолтных значений
        ShowUpgradePrice(upgradeHealthButtonText, upgradeStats.UpgradeHealthCoinsRequired);
        ShowUpgradePrice(upgradeBatteryCellsButtonText, upgradeStats.UpgradeBatteryEnergyCoinsRequired);
        ShowUpgradePrice(upgradeAttackPowerButtonText, upgradeStats.UpgradeAttackCoinsRequired);
        ShowUpgradePrice(upgradeStarterBallsButtonText, upgradeStats.UpgradeStarterBallsCoinsRequired);
        ShowUpgradePrice(upgradeSightLengthButtonText, upgradeStats.UpgradeSightLengthCoinsRequired);

        //EventManager to show changes in other classes
        EventManager.OnUpgradeStats();
    }

    private void GetCoins()
    {
        _playerCoins = coins.m_Coins;
    }

    private void ShowUpgradePrice(TextMeshProUGUI upgradeButtonText, float priceWithCoins)
    {
        upgradeButtonText.text = $"{priceWithCoins} Coins";
    }

    private void ShowMaxLevelInsteadPrice(TextMeshProUGUI upgradeButtonText)
    {
        upgradeButtonText.text = $"{MaxLevelStatText}";
    }

    private void ShowCurrentStatsName(TextMeshProUGUI currentStatsText, string statsValue)
    {
        currentStatsText.text = $"{statsValue}";
    }


    private void DisableUpgradeButton(Button upgradeButton)
    {
        upgradeButton.interactable = false;
    }

    private void EnableUpgradeButton(Button upgradeButton)
    {
        upgradeButton.interactable = true;
    }

    private void DebugMethod() // this one only for debugging
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            coins.AddCoin(100000);
            WalletController.Instance.ShowCoins();
        }
    }
}