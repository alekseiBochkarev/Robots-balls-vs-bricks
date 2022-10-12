using UnityEngine;

public class ComboCounter
{   
    private readonly int startCombo = 0;
    private readonly int startComboCounterValue = 1;
    private int comboCounterValue;
    public static int CurrentCombo { private set; get;}


    public ComboCounter()
    {
        SetComboToZero();
        SetComboCounterValue(startComboCounterValue);
    }
    public void SetComboCounterValue(int _comboCounterValue)
    {
        comboCounterValue = _comboCounterValue;
    }
    public void AddComboPoint()
    {
        //Debug.Log("Combo to add as value -> " + comboCounterValue);
        if (comboCounterValue == startComboCounterValue)
        {
            CurrentCombo += startComboCounterValue;
            EventManager.OnComboCounterChanged(CurrentCombo);
        }
        else
        {
            for (int i = 0; i < comboCounterValue; i++)
            {
                CurrentCombo++;
                EventManager.OnComboCounterChanged(CurrentCombo);
            }
        }
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
