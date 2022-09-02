using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIUpgradeStatsPanel : MonoBehaviour
{
    private HeroStats heroStats;
    private Coins coins;
    private UpgradeStats upgradeStats;

    [Header("Current Hero Stats")]
    [SerializeField] private TextMeshProUGUI currentHealthText;
    [SerializeField] private TextMeshProUGUI currentAttackPowerText;

    [Header("Upgrade Buttons")]
    [SerializeField] private Button upgradeHealthButton;
    [SerializeField] private TextMeshProUGUI upgradeHealthButtonText;
    [SerializeField] private Button upgradeAttackPowerButton;
    [SerializeField] private TextMeshProUGUI upgradeAttackPowerButtonText;
    private float _upgradePoints;
    private float _playerCoins;
    private float _addUpgradeMult = 1;
    private float _playerHealth;
    private float _playerAttackPower;

    private void Start() 
    {
        upgradeStats = new UpgradeStats();
        heroStats = new HeroStats();
        coins = new Coins();
        //Init players stats for UI and future upgrade
        _upgradePoints = heroStats.UpgradePoints;
        _playerCoins = coins.m_Coins;
        _playerHealth = heroStats.Health;
        _playerAttackPower = heroStats.AttackPower;
    }

    /*
        If coins and upgrade points aren't enough -> disable exact upgrade button
    */
    private void Update() 
    {
        GetCoinsAndUpgradePoints();
        ShowCurrentStats(currentHealthText, _playerHealth);
        ShowCurrentStats(currentAttackPowerText, _playerAttackPower);
        ShowUpgradePrice(upgradeHealthButtonText, upgradeStats.UpgradeHealthCoinsRequired);
        ShowUpgradePrice(upgradeAttackPowerButtonText, upgradeStats.UpgradeAttackPowerCoinsRequired);
        if (_playerCoins < upgradeStats.UpgradeHealthCoinsRequired || _upgradePoints <= 0) // check for Health Button
        {
            DisableUpgradeButton(upgradeHealthButton);
        }
        else
        {
            EnableUpgradeButon(upgradeHealthButton);
        }
        if (_playerCoins < upgradeStats.UpgradeAttackPowerCoinsRequired || _upgradePoints <= 0) // check for AttackPower Button
        {
            DisableUpgradeButton(upgradeAttackPowerButton);
        }
        else
        {
            EnableUpgradeButon(upgradeAttackPowerButton);
        }
        AddUpgradePoints(); // this one only for debugging
    }

    public void UpgradeHealthOnClick() // It upgrades health on click
    {   
        // remove coins after buying, remove 1 upgradePoint
        coins.RemoveCoins(upgradeStats.UpgradeHealthCoinsRequired); 
        heroStats.RemoveOneUpgradePoints();

        // Add Health to the player
        heroStats.UpgradeStats(HeroStats.HeroStatsEnum.HeroHealth, upgradeStats.UpgradeHealthValue);

        // Reinit local values for health
        _playerHealth = heroStats.Health;

        // Update UpgradeMultiplier and reinit RequiredCoins, StatsUpgrading
        GetCoinsAndUpgradePoints();
        upgradeStats.SaveUpgradeMultiplier(UpgradeStats.UpgradeMultipliersEnum.HealthMultiplier, _addUpgradeMult);
        upgradeStats.SetMultiplier();
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
        coins.RemoveCoins(upgradeStats.UpgradeAttackPowerCoinsRequired); 
        heroStats.RemoveOneUpgradePoints();

        // Add Attack Power to the player
        heroStats.UpgradeStats(HeroStats.HeroStatsEnum.HeroAttackPower, upgradeStats.UpgradeAttackPowerValue);

        // Reinit local values for Attack Power
        _playerAttackPower = heroStats.AttackPower;

        // Update UpgradeMultiplier and reinit RequiredCoins, StatsUpgrading
        GetCoinsAndUpgradePoints();
        upgradeStats.SaveUpgradeMultiplier(UpgradeStats.UpgradeMultipliersEnum.AttackPowerMultiplier, _addUpgradeMult);
        upgradeStats.SetMultiplier();
        upgradeStats.InitRequiredCoins();
        upgradeStats.InitStatsUpgrading();

        //Show new values on UpgradeButton after changing (DO WE NEED REALLY NEED THIS?)
        ShowUpgradePrice(upgradeAttackPowerButtonText, upgradeStats.UpgradeAttackPowerCoinsRequired);

        //EventManager to show changes in other classes
        EventManager.OnUpgradeStats();
    }
    
    private void GetCoinsAndUpgradePoints()
    {
        _upgradePoints = heroStats.GetStats(HeroStats.HeroStatsEnum.HeroUpgradePoints);
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

    private void EnableUpgradeButon(Button upgradeButton)
    {
        upgradeButton.interactable = true;
    }


    public void AddUpgradePoints() // this one only for debugging
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            heroStats.AddUpgradePoints();
            _upgradePoints = heroStats.GetStats(HeroStats.HeroStatsEnum.HeroUpgradePoints);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            coins.AddCoin(100000);
            WalletController.Instance.ShowCoins();
        }
    }
    
}
