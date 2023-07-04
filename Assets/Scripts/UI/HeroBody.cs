using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBody : MonoBehaviour
{
    void OnEnable()
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Robots/" + LoadSkinData());
    }
    public void SetSkin(string skin)
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Robots/" + skin);
        SaveSkin(skin);
    }
    private void SaveSkin(string skin)
    {
        PlayerPrefs.SetString("CurrentSkin", skin);
        PlayerPrefs.Save();
    }

    private string LoadSkinData()
    {
        string defaultSkin = "r0";
        if (PlayerPrefs.HasKey("CurrentSkin"))
        {
            return PlayerPrefs.GetString("CurrentSkin");
        }
        else
        {
            return defaultSkin;
        }
    }
}
