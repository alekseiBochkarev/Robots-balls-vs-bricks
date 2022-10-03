using Assets.Scripts.Gameplay.Combo;
using Assets.Scripts.Gameplay.HeroBuffs;
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
        EventManager.HeroBuffAdded += AddBuffToCombo;
    }

    private void OnDestroy() {
        EventManager.BrickHit -= AddComboAndShow;
        EventManager.BallsReturned -= HideCombo;
        EventManager.HeroBuffAdded -= AddBuffToCombo;
    }

    private void AddComboAndShow()
    {   gameObject.SetActive(true);
        ComboCounter.AddComboPoint();
        ShowCombo();
    }

    private void AddBuffToCombo(HeroBuffSO buff)
    {
        if (buff.heroBuffType.Equals(HeroBuffsEnum.IncreasedCountComboBuff))
        {
            ComboCounter.SetComboCounterValue(buff.heroBuffValue);
        }
    }

    private void HideCombo()
    {
        gameObject.SetActive(false);
<<<<<<< HEAD:Assets/Scripts/Gameplay/ComboController.cs
        Combo.SetComboToZero();
      //  Debug.Log("Hide combo");
=======
        ComboCounter.SetComboToZero();
        Debug.Log("Hide combo");
>>>>>>> 3a2dea06ef4e84ee208f97a07801e907a945e7a9:Assets/Scripts/Gameplay/Combo/ComboController.cs
        
    }

    private void ShowCombo(){
       comboAmountText.text = $"{ComboCounter.GetComboAmount()}";
    }
}
