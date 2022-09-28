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
        Debug.Log("Combo to add as value -> " + comboCounterValue);
        CurrentCombo += comboCounterValue;
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
