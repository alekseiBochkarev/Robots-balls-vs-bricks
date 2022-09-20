using UnityEngine;

public class SpecialAttackPanelController : MonoBehaviour
{
    public static SpecialAttackPanelController Instance;
    [SerializeField] private GameObject specialAttackPanel;
    [SerializeField] private int magicBallAmount;

    public bool IsSpecAttackPanelOpened;

    private void Awake()
    {
        Instance = this;
    }

    public int GetMagicBallAmount()
    {
        return magicBallAmount;
    }

    public void SetMagicBallAmount(int _value)
    {
        magicBallAmount += _value;
    }

    public void MinusMagicBallAmount()
    {
        magicBallAmount -= 1;
    }

    public void ShowSpecAttackPanel()
    {
        specialAttackPanel.SetActive(true);
        IsSpecAttackPanelOpened = true;
    }

    public void HideSpecAttackPanel()
    {
        specialAttackPanel.SetActive(false);
        IsSpecAttackPanelOpened = false;
    }
}
