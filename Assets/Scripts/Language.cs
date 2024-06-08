using System.Collections;
using System.Collections.Generic;
using YG;
using System.Threading.Tasks;
using UnityEngine;

public class Language : MonoBehaviour
{
    public string CurrentLanguage; // ru en

    public static Language Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            GetData();
            UnityEngine.Debug.Log(CurrentLanguage);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public async void GetData()
    {
        // ƒожидаемс€, пока SDK не станет доступным
        while (!YandexGame.SDKEnabled)
        {
            await Task.Delay(200); // ћожно изменить интервал ожидани€ (в миллисекундах)
        }
        Task.Delay(100);
        CurrentLanguage = YandexGame.EnvironmentData.language;
    }
}
