using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
using Assets.Scripts.Data_Managing;
using Assets.Scripts.DataManaging.Utills;
using System.Threading.Tasks;
using System.Diagnostics;

public class RewardAdsManager : MonoBehaviour
{
    public YandexGame sdk;

    public GameObject adsButton;

    void Start()
    {
        adsButton.SetActive(true);
        GetData();
    }

    public void ShowRewAdd()
    {
        sdk._RewardedShow(1);
    }

    public void AddCoinsAfterAdd()
    {
        WalletController.Instance.AddMoneyAndShow(1000);
        adsButton.SetActive(false);
		EventManager.OnCoinsChanged();
    }

    public async void GetData()
    {
        // ƒожидаемс€, пока SDK не станет доступным
        while (!YandexGame.SDKEnabled)
        {
            await Task.Delay(200); // ћожно изменить интервал ожидани€ (в миллисекундах)
        }
        Task.Delay(100);
        int currentLevel = SaveManager.LoadDayData();
        int maxKilledEnemies = SaveManager.LoadKilledEnemies();
        UnityEngine.Debug.Log("Max killed enemies " + maxKilledEnemies);

        YandexGame.NewLeaderboardScores("KilledEnemies", maxKilledEnemies);
        YandexGame.NewLeaderboardScores("MaxLevel", currentLevel);
    }
}
