using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : WalletController
{
    public static Coins Instance;
    public int m_Coins  {private set; get; }
    public int m_Crystals  {private set; get; }
    

    public Coins() {
        LoadCoins();
       // Debug.Log("Start Coins");
    }
    
    // Add coin and UpdateCoins
    public void AddCoin() {
        m_Coins++;
       // Debug.Log("+ 1 Coin, total = "+ m_Coins);
    }

    public void AddCoin(float amount) {
        m_Coins += (int) amount;
        SaveCoins();
    }

    public void RemoveCoins(float amount)
    {
        m_Coins -= (int) amount;
        SaveCoins();
    }

    public bool IsPurchisable(int price) { // checks if coins are enough to buy something
            return (m_Coins >= price);
    }

    public void SaveCoins() {
        //user Enum for set and get coins as well as crystalls
        PlayerPrefs.SetInt("coins", m_Coins);
       // Debug.Log("Save coins to -> " + m_Coins);
    }

    
    public void LoadCoins() {
        //user Enum for set and get coins as well as crystalls
        m_Coins = PlayerPrefs.GetInt("coins");
       // Debug.Log("Get coins -> " + m_Coins);
    }
}