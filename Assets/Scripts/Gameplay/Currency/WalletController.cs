using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WalletController : MonoBehaviour
{    
    public static WalletController Instance;
    public Coins Coins {private set; get;}


    [SerializeField] private TextMeshProUGUI m_CoinsText;
    private Text m_CrystalsText;

    private void Awake() {
       // Debug.Log("Awake the Wallet Controller");
        Instance = this;
        Coins = new Coins();
        ShowCoins();
        //EventManager.BrickDestroyed += AddCoinAndShow;
        EventManager.UpgradeStats += ShowCoins;
    }
    
    private void OnDestroy() {
        //EventManager.BrickDestroyed -= AddCoinAndShow;
        EventManager.UpgradeStats -= ShowCoins;
    }

    public void AddMoneyAndShow(int amount) {
        // Add coins and show it on UI
        Coins.AddCoin(amount);
        Coins.SaveCoins();
        ShowCoins();
    }

    public void ShowCoins() {
        Coins.LoadCoins();
      //  Debug.Log("Show amount of coins -> " + Coins.m_Coins);
        m_CoinsText.text = Coins.m_Coins.ToString();
    }

    // public void ShowCrystals() {

    //     m_CrystalsText = Coins.m_Crystals.ToString;
    // }
}

public enum WalletMoneyEnum
{
    Coin,
    Crystal,
    Rybin
}
