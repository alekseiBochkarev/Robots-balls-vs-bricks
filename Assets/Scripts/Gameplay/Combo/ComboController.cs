using Assets.Scripts.Gameplay.Combo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboController : MonoBehaviour
{
    public ComboCounter ComboCounter {private set; get;}
    [SerializeField] private Text comboAmountText;


    private void Awake()
    {
        ComboCounter = new ComboCounter();
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
        ComboCounter.AddComboPoint();
        ComboLauncher.Instance.AddComboPointAndStartComboAttack();
        ShowCombo();
    }

    private void HideCombo()
    {
        gameObject.SetActive(false);
        ComboCounter.SetComboToZero();
        Debug.Log("Hide combo");
        
    }

    private void ShowCombo(){
       comboAmountText.text = $"{ComboCounter.GetComboAmount()}";
    }
}
