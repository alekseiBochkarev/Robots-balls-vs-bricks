using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalletController : MonoBehaviour
{
    public static WalletController Instance;
    public Coins Coins {private set; get;}


    [SerializeField] private Text m_CoinsText;
    private Text m_CrystalsText;

    private void Awake() {
        Debug.Log("Awake the Wallet Controller");
        Instance = this;
        Coins = new Coins();
        ShowCoins();
    }

    public void AddCoinAndShow() {
        // Add coins and show it on UI
        Coins.AddCoin();
        Coins.SaveCoins();
        ShowCoins();
    }

    void Update()
    {
        // Should invoke Events for add coins when brick is destroyed
        
    }

    public void ShowCoins() {
        Debug.Log("Show amount of coins -> " + Coins.m_Coins);
        m_CoinsText.text = Coins.m_Coins.ToString();
    }

    // public void ShowCrystals() {

    //     m_CrystalsText = Coins.m_Crystals.ToString;
    // }
}
