using System.Collections;
using System.Collections.Generic;
using YG;
using System.Threading.Tasks;
using UnityEngine;
using System.Runtime.InteropServices;

public class Language : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern string GetLang();
    
    public string CurrentLanguage; // ru en

    public static Language Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            CurrentLanguage = GetLang();
            UnityEngine.Debug.Log(CurrentLanguage);
            int i = 0;
            while (CurrentLanguage == null && i < 20)
            {
                CurrentLanguage= GetLang();
                i++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
}
