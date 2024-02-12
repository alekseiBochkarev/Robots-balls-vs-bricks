using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static void SaveScene(int scene)
    {
        PlayerPrefs.SetInt("CurrentScene", scene);
        PlayerPrefs.Save();
    }

    public static int LoadSceneData()
    {
        int defaultScene = 1;
        if (PlayerPrefs.HasKey("CurrentScene"))
        {
            return PlayerPrefs.GetInt("CurrentScene");
        }
        else
        {
            //Debug.Log("That's OK. Just There is no save data!"); 
            return defaultScene;
        }
    }

    public static void SaveDay(int day)
    {
        PlayerPrefs.SetInt("CurrentDay", day);
        PlayerPrefs.Save();
    }

    public static int LoadDayData()
    {
        int defaultDay = 1;
        if (PlayerPrefs.HasKey("CurrentDay"))
        {
            return PlayerPrefs.GetInt("CurrentDay");
        }
        else
        {
            //Debug.Log("That's OK. Just There is no save data!"); 
            return defaultDay;
        }
    }
}