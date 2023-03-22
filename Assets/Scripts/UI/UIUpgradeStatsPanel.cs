using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIUpgradeStatsPanel : MonoBehaviour
{
    // Need to rework for new STATS, use Transform/gameobject Instea
    private HeroStats heroStats;
    private Coins coins;
    private UpgradeStats upgradeStats;

    [Header("Current Hero Stats")]
    [SerializeField] private TextMeshProUGUI currentHealthText;
    [SerializeField] private TextMeshProUGUI currentBatteryEnergyText;
    [SerializeField] private TextMeshProUGUI currentAttackPowerText;

    [Header("Upgrade Buttons")]
    [SerializeField] private Button upgradeHealthButton;
    [SerializeField] private TextMeshProUGUI upgradeHealthButtonText;
    [SerializeField] private Button upgradeAttackPowerButton;
    [SerializeField] private TextMeshProUGUI upgradeAttackPowerButtonText;
    private float _playerCoins;
    private float _addUpgradeMult = 1;
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
        _playerCoins = coins.m_Coins;
        
        _playerHealth = heroStats.Health;
        _playerBatteryEnergy = heroStats.BatteryEnergy;
        _playerAttack = heroStats.Attack;
        _playerStarterBalls = heroStats.StarterBalls;
        _playerSightLength = heroStats.SightLength;
    }

    /*
        If coins aren't enough -> disable exact upgrade button
    */
    private void Update() 
    {
        GetCoins();
        ShowCurrentStats(currentHealthText, _playerHealth);
        ShowCurrentStats(currentAttackPowerText, _playerAttack);
        ShowUpgradePrice(upgradeHealthButtonText, upgradeStats.UpgradeHealthCoinsRequired);
        ShowUpgradePrice(upgradeAttackPowerButtonText, upgradeStats.UpgradeAttackCoinsRequired);
        if (_playerCoins < upgradeStats.UpgradeHealthCoinsRequired) // check for Health Button
        {
            DisableUpgradeButton(upgradeHealthButton);
        }
        else
        {
            EnableUpgradeButton(upgradeHealthButton);
        }
        if (_playerCoins < upgradeStats.UpgradeAttackCoinsRequired) // check for AttackPower Button
        {
            DisableUpgradeButton(upgradeAttackPowerButton);
        }
        else
        {
            EnableUpgradeButton(upgradeAttackPowerButton);
        }
        DebugMethod(); // this one only for debugging
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
        upgradeStats.SetMultipliers();
        upgradeStats.InitRequiredCoins();
        upgradeStats.InitStatsUpgrading();

        //Show new values on UpgradeButton after changing (DO WE NEED REALLY NEED THIS?)
        ShowUpgradePrice(upgradeHealthButtonText, upgradeStats.UpgradeHealthCoinsRequired);

        //EventManager to show changes in other classes
        EventManager.OnUpgradeStats();
    }

    public void UpgradeAttackPowerOnClick() // It upgrades Attack Power on click
    {   
        // remove coins after buying, remove 1 upgradePoint
        coins.RemoveCoins(upgradeStats.UpgradeAttackCoinsRequired); 

        // Add Attack Power to the player
        heroStats.UpgradeStats(HeroStats.HeroStatsEnum.Attack, upgradeStats.UpgradeAttackValue);

        // Reinit local values for Attack Power
        _playerAttack = heroStats.Attack;

        // Update UpgradeMultiplier and reinit RequiredCoins, StatsUpgrading
        GetCoins();
        upgradeStats.SaveUpgradeMultiplier(UpgradeStats.UpgradeMultipliersEnum.AttackMultiplier, _addUpgradeMult);
        upgradeStats.SetMultipliers();
        upgradeStats.InitRequiredCoins();
        upgradeStats.InitStatsUpgrading();

        //Show new values on UpgradeButton after changing (DO WE NEED REALLY NEED THIS?)
        ShowUpgradePrice(upgradeAttackPowerButtonText, upgradeStats.UpgradeAttackCoinsRequired);

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

    private void ShowCurrentStats(TextMeshProUGUI currentStatsText, float statsValue)
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


    public void DebugMethod() // this one only for debugging
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            coins.AddCoin(100000);
            WalletController.Instance.ShowCoins();
        }
    }
    
}
