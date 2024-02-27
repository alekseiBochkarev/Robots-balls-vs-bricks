﻿using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public enum Market { PlayStore, CafeBazaar, }
    public Market m_Market = Market.PlayStore;

 //   private Energy energy;

    private int controlSceneIndex = 0;

    public GameObject m_MainMenuQuitPanel;
  //  public GameObject m_SettingsPanel;
    public GameObject m_PauseMenu;  // or backMenu (panel)
    public GameObject m_GymButton; // on click -> opens Upgrade modal panel
    public GameObject m_UpgradePanel;

    public GameObject m_LevelSelectionButton; // on click -> opens Level Selection panel
    public GameObject m_LevelSelectionPanel;

    private float m_timeScale;

    void Start ()
    {
      //  m_SettingsPanel.SetActive(false);
     //   energy = EnergyController.Instance.Energy;
    }
/*
    void Update()
    {
        if (GameManager.Instance != null)
        {
            if (Input.GetKeyUp(KeyCode.Escape) && !m_MainMenuQuitPanel.activeInHierarchy)
                m_MainMenuQuitPanel.SetActive(true);
            else if (Input.GetKeyUp(KeyCode.Escape) && m_MainMenuQuitPanel.activeInHierarchy)
                m_MainMenuQuitPanel.SetActive(false);
        } else if (LevelManager.Instance != null)
        {
            if (Input.GetKeyUp(KeyCode.Escape) && !m_PauseMenu.activeInHierarchy)
                ShowPauseMenu();
            else if (Input.GetKeyUp(KeyCode.Escape) && m_PauseMenu.activeInHierarchy)
                HidePauseMenu();
        }
        /*
        switch(GameManager.Instance.m_GameState)
        {
            case GameManager.GameState.MainMenu:
                if (Input.GetKeyUp(KeyCode.Escape) && !m_MainMenuQuitPanel.activeInHierarchy)
                    m_MainMenuQuitPanel.SetActive(true);
                else if (Input.GetKeyUp(KeyCode.Escape) && m_MainMenuQuitPanel.activeInHierarchy)
                    m_MainMenuQuitPanel.SetActive(false);
                break;

            case GameManager.GameState.Playable:
                if (Input.GetKeyUp(KeyCode.Escape) && !m_PauseMenu.activeInHierarchy)
                    ShowPauseMenu();
                else if (Input.GetKeyUp(KeyCode.Escape) && m_PauseMenu.activeInHierarchy)
                    HidePauseMenu();
                break;
        }
        
    }*/
    /*
    public void StartGame()
    {
        if (energy.CurrentEnergy >= energy.startGameEnergy) {
            //Application.LoadLevel("LevelWithWin");
            SceneManager.LoadScene("LevelWithWin");
          //  energy.currentEnergy -= energy.startGameEnergy;
          energy.ChangeCurrentEnergy(energy.CurrentEnergy - energy.startGameEnergy);
            TimeController.SaveLastPlayTime();
        }
        //GameManager.Instance.m_GameState = GameManager.GameState.Playable;
        //Debug.Log("gamestate " + GameManager.Instance.m_GameState);
    }*/

    public void PlayGameLevel()
    {
        LevelManager.Instance.m_LevelState = LevelManager.LevelState.PLAYABLE;
        EventManager.OnLevelStarted();
    }

    public void DebugWin()
    {
        LevelManager.Instance.m_LevelState = LevelManager.LevelState.WIN;
    }


    public void OpenUpgradePanel() // nice to add some animation on openning
    {
        m_UpgradePanel.SetActive(true);
        m_GymButton.SetActive(false);
    }

    public void OpenLevelSelection() // nice to add some animation on openning
    {
        m_LevelSelectionPanel.SetActive(true);
        m_LevelSelectionButton.SetActive(false);
    }

    public void CloseLevelSelection() // nice to add some animation on openning
    {
        m_LevelSelectionPanel.SetActive(false);
        m_LevelSelectionButton.SetActive(true);
    }

    public void CloseUpgradePanel() // nice to add some animation on closing
    {
        m_UpgradePanel.SetActive(false);
        m_GymButton.SetActive(true);
    }

    public void ShowPauseMenu()
    {
        // 1 - stop the time scale
        m_timeScale = Time.timeScale;
        Time.timeScale = 0;
        //pause = true;
        BallLauncher.Instance.m_CanPlay = false;
       // Debug.Log("can play " + BallLauncher.Instance.m_CanPlay);
        // 2 - active m_PauseMenu
        m_PauseMenu.SetActive(true);
    }

    public void HidePauseMenu()
    {
        // 1 - relaunch the time scale
        Time.timeScale = m_timeScale;
        m_timeScale = 0;
        // 2 - deactive m_PauseMenu
        m_PauseMenu.SetActive(false);
        StartCoroutine("ResumeGameAfterPause");
    }

    IEnumerator ResumeGameAfterPause()
    {
        yield return new WaitForSeconds(0.5f);
        BallLauncher.Instance.m_CanPlay = true;
       // Debug.Log("can play " + BallLauncher.Instance.m_CanPlay);
    }

    public void ShowSettingsPanel()
    {
        // 1 - stop the time scale
        m_timeScale = Time.timeScale;
        Time.timeScale = 0;
        BallLauncher.Instance.m_CanPlay = false;
    //    m_SettingsPanel.SetActive(true);
    }

    public void HideSettingsPanel()
    {
        // 1 - relaunch the time scale
        Time.timeScale = m_timeScale;
        m_timeScale = 0;
        StartCoroutine("ResumeGameAfterPause");
     //   m_SettingsPanel.SetActive(false);
    }
/*
    public void OpenMoreGamesOnMarket()
    {
        if(m_Market == Market.PlayStore)
        {
            Application.OpenURL("https://play.google.com/store/apps/dev?id=5441373224523908318");
        }
        else if(m_Market == Market.CafeBazaar)
        {
#if UNITY_ANDROID
            try
            {
                AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
                AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");

                AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
                intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_VIEW"));
                intentObject.Call<AndroidJavaObject>("setData", uriClass.CallStatic<AndroidJavaObject>("parse", "bazaar://collection?slug=by_author&aid=scientist_studio"));
                intentObject.Call<AndroidJavaObject>("setPackage", "com.farsitel.bazaar");
                AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
                currentActivity.Call("startActivity", intentObject);
            }
            catch (Exception e)
            {
              //  Application.OpenURL("https://cafebazaar.ir/developer/scientist_studio");   // open in browser instead
                Debug.LogAssertion(e.StackTrace);   // was not installed!
            }
#endif
        }
    }
*/
/*
    public void ShareGame()
    {
        if(m_Market == Market.PlayStore)
            ShareAndroid("get Ballz from the Play Store\n\nhttps://play.google.com/store/apps/details?id=com.gameditors.ballz", "", "", null, "text/plain", true, "Share using");
        else if(m_Market == Market.CafeBazaar)
            ShareAndroid("بازی Ballz رو از کافه بازار دانلود کن\n\nhttps://cafebazaar.ir/app/com.gameditors.ballz", "", "", null, "text/plain", true, "اشتراک گذاری با");
    }
    */

    public void ShareScore()
    {
        if (m_Market == Market.PlayStore)
            ShareAndroid("Hi. this is my best score in Ballz (Brick Breaker): " + ScoreManager.Instance.m_BestScore.ToString() + "\n\nhttps://play.google.com/store/apps/details?id=com.gameditors.ballz", "", "", null, "text/plain", true, "Share the best score using");
        else if (m_Market == Market.CafeBazaar)
            ShareAndroid("بالاترین امتیاز من توی بازی Ballz (Brick Breaker): " + ScoreManager.Instance.m_BestScore.ToString() + "\n\nhttps://cafebazaar.ir/app/com.gameditors.ballz", "", "", null, "text/plain", true, "اشتراک گذاری بالاترین امتیاز با");
    }

    public void OpenInstagramPage()
    {
#if UNITY_ANDROID
        try
        {
            AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
            AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");

            AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
            intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_VIEW"));
            intentObject.Call<AndroidJavaObject>("setData", uriClass.CallStatic<AndroidJavaObject>("parse", "https://www.instagram.com/gameditors/"));
            intentObject.Call<AndroidJavaObject>("setPackage", "com.instagram.android");
            AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
            currentActivity.Call("startActivity", intentObject);
        }
        catch (Exception e)
        {
            //Application.OpenURL("https://www.instagram.com/gameditors/");   // open in browser instead
            Debug.LogAssertion(e.StackTrace);   // was not installed!
        }
#endif
    }

    public void OpenRatePageOnMaket()
    {
        if (m_Market == Market.PlayStore)
        {
            Application.OpenURL("https://play.google.com/store/apps/details?id=com.gameditors.ballz");
        }
        else if (m_Market == Market.CafeBazaar)
        {
#if UNITY_ANDROID
            try
            {
                AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
                AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");

                AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
                intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_EDIT"));
                intentObject.Call<AndroidJavaObject>("setData", uriClass.CallStatic<AndroidJavaObject>("parse", "bazaar://details?id=com.gameditors.ballz"));
                intentObject.Call<AndroidJavaObject>("setPackage", "com.farsitel.bazaar");
                AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
                currentActivity.Call("startActivity", intentObject);
            }
            catch (Exception e)
            {
               // Application.OpenURL("https://cafebazaar.ir/app/com.gameditors.ballz");
                Debug.LogAssertion(e.StackTrace);   // maybe Bazaar was not installed!
            }
#endif
        }
    }

    public void SendEmailToUs()
    {
        string email = "gameditors.corp@gmail.com";
        string subject = MyEscapeURL("Ballz Support");
        Application.OpenURL("mailto:" + email + "?subject=" + subject);
    }

    string MyEscapeURL(string url)
    {
        return WWW.EscapeURL(url).Replace("+", "%20");
    }

    /// <summary>
    /// Shares on file maximum
    /// </summary>
    /// <param name="body"></param>
    /// <param name="filePath">The path to the attached file</param>
    /// <param name="url"></param>
    /// <param name="subject"></param>
    /// <param name="mimeType"></param>
    /// <param name="chooser"></param>
    /// <param name="chooserText"></param>
    public void ShareAndroid(string body, string subject, string url, string[] filePaths, string mimeType, bool chooser, string chooserText)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        using (AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent"))
        using (AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent"))
        {
            using (intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND")))
            { }
            using (intentObject.Call<AndroidJavaObject>("setType", mimeType))
            { }
            using (intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), subject))
            { }
            using (intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), body))
            { }

            if (!string.IsNullOrEmpty(url))
            {
                // attach url
                using (AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri"))
                using (AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", url))
                using (intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject))
                { }
            }
            else if (filePaths != null)
            {
                // attach extra files (pictures, pdf, etc.)
                using (AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri"))
                using (AndroidJavaObject uris = new AndroidJavaObject("java.util.ArrayList"))
                {
                    for (int i = 0; i < filePaths.Length; i++)
                    {
                        //instantiate the object Uri with the parse of the url's file
                        using (AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + filePaths[i]))
                        {
                            uris.Call<bool>("add", uriObject);
                        }
                    }

                    using (intentObject.Call<AndroidJavaObject>("putParcelableArrayListExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uris))
                    { }
                }
            }

            // finally start application
            using (AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            using (AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity"))
            {
                if (chooser)
                {
                    AndroidJavaObject jChooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, chooserText);
                    currentActivity.Call("startActivity", jChooser);
                }
                else
                {
                    currentActivity.Call("startActivity", intentObject);
                }
            }
        }
#endif
    }
    /*
    #region GameOver Menu
    public void GotoMainMenuAfterGameOver()
    {
        // if (game won) -> unlock next level and go to main menu
        if (LevelManager.Instance.m_LevelState == LevelManager.LevelState.WIN)
        {
            PlayerPrefs.SetInt("currentScene", SceneManager.GetActiveScene().buildIndex);
        }
        SceneManager.LoadScene(0);
        //GameManager.Instance.m_GameState = GameManager.GameState.MainMenu;
        Saver.Instance.Save(true);
    }*/

    public void RestartCurrentSceneAfterLose()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(controlSceneIndex);
    }

    public void OpenNextSceneAfterWin()
    {
        SaveManager.SaveDay(SaveManager.LoadDayData() + 1);
        int defaultScene = 1;
        int nextScene = ((SceneManager.GetActiveScene().buildIndex + 1) < SceneManager.sceneCountInBuildSettings) ? (SceneManager.GetActiveScene().buildIndex + 1) : defaultScene;
        // Debug.LogError("SceneManager.sceneCount =" + SceneManager.sceneCountInBuildSettings);
        // Debug.LogError("nextScene = " + nextScene + " because SceneManager.GetActiveScene().buildIndex + 1  =" + (SceneManager.GetActiveScene().buildIndex + 1) );
        SaveManager.SaveScene(nextScene);
        SceneManager.LoadScene(controlSceneIndex);
    }
    /*
    public void ReplayAfterGameOver()
    {
        if (energy.CurrentEnergy >= energy.startGameEnergy) {
            energy.ChangeCurrentEnergy(energy.CurrentEnergy - energy.startGameEnergy);
            TimeController.SaveLastPlayTime();
            EnergyController.Instance.ShowEnergy();
            
            BallLauncher.Instance.OnMainMenuActions();
            //BrickSpawner.Instance.HideAllBricksRows();
            LevelManager.Instance.m_LevelState = LevelManager.LevelState.PLAYABLE;
            Saver.Instance.Save(true);
        }
    }
    #endregion
    */

    
    #region Pause Menu
    public void GotoMainMenu()
    {
        //Application.LoadLevel("Main");
        SceneManager.LoadScene("Main");
        HidePauseMenu();
    }

    public void ResumeGame()
    {
        HidePauseMenu();
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_ANDROID && !UNITY_EDITOR
        ScoreManager.Instance.SubmitScoreToLeaderboard();
        Application.Quit();
#endif
    }
    #endregion
}