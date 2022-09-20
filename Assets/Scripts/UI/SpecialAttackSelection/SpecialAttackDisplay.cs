using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpecialAttackDisplay : MonoBehaviour
{
    [Header("UI Stats")]
    [SerializeField] private TextMeshProUGUI specialAttackName;
    [SerializeField] private Image specialAttackImage;
    [SerializeField] private TextMeshProUGUI specialAttackDescription;
    private SpecialAttackSO specialAttack;
 
    public void DisplaySpecialAttack(SpecialAttackSO _specialAttack)
    {
        specialAttack = _specialAttack;
        // Display Choosen Special Attack
        specialAttackName.text = _specialAttack.specialAttackName;
        specialAttackDescription.text = _specialAttack.specialAttackDescription;
        specialAttackImage.sprite = _specialAttack.specialAttackImage;
    }

    public void AddSpecAttackOnClick()
    {
        //Adds index of using this specAttack
        specialAttack.currentUseAmount++;

        //Add specAttack
        if (specialAttack.GetType() == typeof(BallSO))
            Balls.Instance.SetSpecialAttack( (BallSO) specialAttack);
        if (specialAttack.GetType() == typeof(ComboAttackSO))
            // Combo.Instance.SetSpecialAttack(specialAttack); ???
        if (specialAttack.GetType() == typeof(HeroBuffSO))
                            // HeroBuffs.Instance.SetHeroBuff(specialAttack); ???

        //Hide the panel
        SpecialAttackController.Instance.HideSpecAttackPanel();
    }
    

}
