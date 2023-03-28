using System.Collections;
using System.Collections.Generic;
using Gameplay.Batteries.Battery_Cell;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;

public class UIUpgradeStatsPanel : MonoBehaviour
{
    // Need to rework for new STATS, use Transform/gameobject Instea
    private HeroStats heroStats;
    private Coins coins;
    private UpgradeStats upgradeStats;

    private BatteryCellController _batteryCellController;

    [Header("Stat Prefabs")]
    [SerializeField] private GameObject healthPrefab;
    [SerializeField] private GameObject batteryCellsPrefab;
    [SerializeField] private GameObject attackPrefab;
    [SerializeField] private GameObject starterBallsPrefab;
    [SerializeField] private GameObject sightLengthPrefab;
    
    [Header("Current Hero Stats")]
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI batteryCellsText;
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI starterBallsText;
    [SerializeField] private TextMeshProUGUI sightLengthText;

    [Header("Upgrade Buttons")]
    [SerializeField] private Button upgradeHealthButton;
    [SerializeField] private Button upgradeBatteryCellsButton;
    [SerializeField] private Button upgradeAttackPowerButton;
    [SerializeField] private Button upgradeStarterBallsButton;
    [SerializeField] private Button upgradeSightLengthButton;
    
    [Header("Upgrade Cost Text")]
    [SerializeField] private TextMeshProUGUI upgradeHealthButtonText;
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

    private void Start() 
    {
        upgradeStats = new UpgradeStats();
        heroStats = new HeroStats();
        coins = new Coins();
        
        //Init players stats for UI and future upgrade
        GetCoins();
        
        _playerHealth = heroStats.Health;
        _playerBatteryEnergy = heroStats.BatteryEnergy;
        _playerAttack = heroStats.Attack;
        _playerStarterBalls = heroStats.StarterBalls;
        _playerSightLength = heroStats.SightLength;
        
        //Init prefab scripts
        _batteryCellController = batteryCellsPrefab.GetComponentInChildren<BatteryCellController>();
    }

    /*
        If coins aren't enough -> disable exact upgrade button
    */
    //ToDo нужно избавиться от Update и перевести все это дело на события
    private void Update() 
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

        DebugMethod(); // this one only for debugging
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
            // for health
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
            // for attack
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
        upgradeStats.SaveUpgradeMultiplier(UpgradeStats.UpgradeMultipliersEnum.BatteryEnergyMultiplier, _addUpgradeMult);
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

        //EventManager to show changes in other classes
        EventManager.OnUpgradeStats();
    }
    
    public void ResetStatsOnClick() // Resets all stats DEBUG
    {   
        // Add Attack Power to the player
        // heroStats.UpgradeStats(HeroStats.HeroStatsEnum.Attack, upgradeStats.UpgradeAttackValue);
        //
        // // Reinit local values for Attack Power
        // _playerAttack = heroStats.Attack;
        //
        // // Update UpgradeMultiplier and reinit RequiredCoins, StatsUpgrading
        // GetCoins();
        // upgradeStats.SaveUpgradeMultiplier(UpgradeStats.UpgradeMultipliersEnum.AttackMultiplier, _addUpgradeMult);
        // upgradeStats.SetMultipliers();
        // upgradeStats.InitRequiredCoins();
        // upgradeStats.InitStatsUpgrading();
        //
        // //Show new values on UpgradeButton after changing (DO WE NEED REALLY NEED THIS?)
        // ShowUpgradePrice(upgradeAttackPowerButtonText, upgradeStats.UpgradeAttackCoinsRequired);
        
        // Сброс статов, множителей и уровней прокачки до дефолтных значений
        heroStats.ClearStatsToDefault();
        upgradeStats.ClearUpgradeMultipliersToDefault();
        upgradeStats.ClearUpgradeLevelsToDefault();
        
        //Сброс скриптов у префабов до дефолтных значений
        _batteryCellController.ResetAdditionalCells();
        
        //Отобразить цену после сброса до дефолтных значений
        ShowUpgradePrice(upgradeHealthButtonText, upgradeStats.UpgradeHealthCoinsRequired);
        ShowUpgradePrice(upgradeBatteryCellsButtonText, upgradeStats.UpgradeBatteryEnergyCoinsRequired);
        ShowUpgradePrice(upgradeAttackPowerButtonText, upgradeStats.UpgradeAttackCoinsRequired);
        ShowUpgradePrice(upgradeStarterBallsButtonText, upgradeStats.UpgradeStarterBallsCoinsRequired);
        ShowUpgradePrice(upgradeSightLengthButtonText, upgradeStats.UpgradeSightLengthCoinsRequired);
        
        //ToDo Отобразить префабы статов уже на сброшенных значениях
        
        
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
