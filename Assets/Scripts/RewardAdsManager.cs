using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
using Assets.Scripts.Data_Managing;
using Assets.Scripts.DataManaging.Utills;

public class RewardAdsManager : MonoBehaviour
{
    public YandexGame sdk;

    public GameObject adsButton;

    void Start()
    {
        adsButton.SetActive(true);
    }
    
    public void ShowRewAdd()
    {
        sdk._RewardedShow(1);
    }

    public void AddCoinsAfterAdd()
    {
        WalletController.Instance.AddMoneyAndShow(1000);
        adsButton.SetActive(false);
    }
}
