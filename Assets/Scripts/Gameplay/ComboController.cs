using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboController : MonoBehaviour
{
    public Combo Combo {private set; get;}
    [SerializeField] private Text comboAmountText;


    private void Awake()
    {
        Combo = new Combo();
        gameObject.SetActive(false);
        EventManager.BrickHit += AddComboAndShow;
        EventManager.BallsReturned += HideCombo;
    }

    private void OnDestroy() {
        EventManager.BrickHit -= AddComboAndShow;
        EventManager.BallsReturned -= HideCombo;
    }

    private void AddComboAndShow()
    {   gameObject.SetActive(true);
        Combo.AddComboPoint();
        ShowCombo();
    }

    private void HideCombo()
    {
        gameObject.SetActive(false);
        Combo.SetComboToZero();
        Debug.Log("Hide combo");
        
    }

    private void ShowCombo(){
       comboAmountText.text = $"{Combo.GetComboAmount()}";
    }
}
