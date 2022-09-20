using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo
{   
    private int startCombo = 0;
    public int CurrentCombo { private set; get;}


    public Combo()
    {
        SetComboToZero();
    }
    public void AddComboPoint()
    {
        CurrentCombo++;
    }
    
    public int GetComboAmount()
    {
        return CurrentCombo;
    }

    public void SetComboToZero()
    {
        CurrentCombo = startCombo;
    }


}

public enum ComboAttackEnum
{
    FireCombo,
    IceCombo
}
