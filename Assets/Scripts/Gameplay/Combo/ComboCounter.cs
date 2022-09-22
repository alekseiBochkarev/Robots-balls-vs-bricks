using Assets.Scripts.Gameplay.Combo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboCounter
{   
    private int startCombo = 0;
    public static int CurrentCombo { private set; get;}


    public ComboCounter()
    {
        SetComboToZero();
    }
    public void AddComboPoint()
    {
        CurrentCombo++;
    }
    
    public static int GetComboAmount()
    {
        return CurrentCombo;
    }

    public void SetComboToZero()
    {
        CurrentCombo = startCombo;
    }

}
