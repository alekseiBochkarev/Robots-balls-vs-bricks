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
}