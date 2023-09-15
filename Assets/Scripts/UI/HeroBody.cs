using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBody : MonoBehaviour
{
    void OnEnable()
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Robots/" + LoadSkinData());
        SetBodyParameters(LoadSkinData());
        EventManager.OnSkinChanged();
    }

    public void SetSkin(string skin)
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Robots/" + skin);
        SaveSkin(skin);
        SetBodyParameters(skin);
        EventManager.OnSkinChanged();
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


    private void SetBodyParameters(string skin)
    {
        switch (skin)
        {
            case "r0":
                HeroStats.BodyHealth = 0;
                HeroStats.BodyAttack = 0;
                HeroStats.BodyStarterBalls = 0;
                HeroStats.BodySightLength = 5;
                break;
            case "r1":
                HeroStats.BodyHealth = 0;
                HeroStats.BodyAttack = 0;
                HeroStats.BodyStarterBalls = 2;
                HeroStats.BodySightLength = 0;
                break;
            case "r2":
                HeroStats.BodyHealth = 0;
                HeroStats.BodyAttack = 2;
                HeroStats.BodyStarterBalls = 0;
                HeroStats.BodySightLength = 0;
                break;
            case "r3":
                HeroStats.BodyHealth = 2;
                HeroStats.BodyAttack = 0;
                HeroStats.BodyStarterBalls = 1;
                HeroStats.BodySightLength = 0;
                break;
            case "r4":
                HeroStats.BodyHealth = 10;
                HeroStats.BodyAttack = 0;
                HeroStats.BodyStarterBalls = 0;
                HeroStats.BodySightLength = 0;
                break;
            case "r5":
                HeroStats.BodyHealth = 2;
                HeroStats.BodyAttack = 0;
                HeroStats.BodyStarterBalls = 0;
                HeroStats.BodySightLength = 4;
                break;
            case "r6":
                HeroStats.BodyHealth = 2;
                HeroStats.BodyAttack = 0;
                HeroStats.BodyStarterBalls = 1;
                HeroStats.BodySightLength = 0;
                break;
            case "r7":
                HeroStats.BodyHealth = 2;
                HeroStats.BodyAttack = 1;
                HeroStats.BodyStarterBalls = 0;
                HeroStats.BodySightLength = 0;
                break;
            case "r8":
                HeroStats.BodyHealth = 4;
                HeroStats.BodyAttack = 0;
                HeroStats.BodyStarterBalls = 0;
                HeroStats.BodySightLength = 3;
                break;
            case "r9":
                HeroStats.BodyHealth = 3;
                HeroStats.BodyAttack = 1;
                HeroStats.BodyStarterBalls = 0;
                HeroStats.BodySightLength = 0;
                break;
            case "r10":
                HeroStats.BodyHealth = 10;
                HeroStats.BodyAttack = 0;
                HeroStats.BodyStarterBalls = 0;
                HeroStats.BodySightLength = 0;
                break;
            case "r11":
                HeroStats.BodyHealth = 2;
                HeroStats.BodyAttack = 1;
                HeroStats.BodyStarterBalls = 1;
                HeroStats.BodySightLength = 2;
                break;
            case "r12":
                HeroStats.BodyHealth = 2;
                HeroStats.BodyAttack = 0;
                HeroStats.BodyStarterBalls = 4;
                HeroStats.BodySightLength = 0;
                break;
            case "r13":
                HeroStats.BodyHealth = 2;
                HeroStats.BodyAttack = 4;
                HeroStats.BodyStarterBalls = 1;
                HeroStats.BodySightLength = 0;
                break;
            case "r14":
                HeroStats.BodyHealth = 15;
                HeroStats.BodyAttack = 1;
                HeroStats.BodyStarterBalls = 3;
                HeroStats.BodySightLength = 0;
                break;
            case "r15":
                HeroStats.BodyHealth = 15;
                HeroStats.BodyAttack = 2;
                HeroStats.BodyStarterBalls = 3;
                HeroStats.BodySightLength = 5;
                break;
            case "HagiWagerR0":
                HeroStats.BodyHealth = 10;
                HeroStats.BodyAttack = 1;
                HeroStats.BodyStarterBalls = 0;
                HeroStats.BodySightLength = 5;
                break;
            case "HagiWagerR1":
                HeroStats.BodyHealth = 10;
                HeroStats.BodyAttack = 1;
                HeroStats.BodyStarterBalls = 1;
                HeroStats.BodySightLength = 5;
                break;
            case "HagiWagerR2":
                HeroStats.BodyHealth = 10;
                HeroStats.BodyAttack = 1;
                HeroStats.BodyStarterBalls = 1;
                HeroStats.BodySightLength = 5;
                break;
            case "HagiWagerR3":
                HeroStats.BodyHealth = 10;
                HeroStats.BodyAttack = 1;
                HeroStats.BodyStarterBalls = 1;
                HeroStats.BodySightLength = 5;
                break;
        }
    }
}
